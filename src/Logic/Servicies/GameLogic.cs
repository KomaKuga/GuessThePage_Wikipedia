using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuessThePage_Wikipedia.Logic.Entities;

namespace GuessThePage_Wikipedia.Logic.Servicies
{
    public class GameLogic
    {
        private static readonly HttpClient client = new HttpClient();

        string answer;

        public async Task<Article> GetRandomArticleFromCategory(string category)
        {
            string wikiApiUrl = "https://en.wikipedia.org/api/rest_v1/page/summary/";
            string peopleList = File.ReadAllText("C:\\Users\\josep\\source\\repos\\KomaKuga\\GuessThePage_Wikipedia\\src\\Logic\\Servicies\\staticList.JSON");

            using (JsonDocument doc = JsonDocument.Parse(peopleList))
            {
                JsonElement root = doc.RootElement;
                JsonElement peopleArray = root.GetProperty("people");
                JsonElement pickedPerson = peopleArray[Random.Shared.Next(peopleArray.GetArrayLength())];
                answer = pickedPerson.GetString() ?? string.Empty;
                Debug.WriteLine($"Selected person: {answer}");
            }

            try
            {
                var response = await client.GetStringAsync(wikiApiUrl + answer);
                Debug.WriteLine($"Response: {response}");

                using (JsonDocument doc = JsonDocument.Parse(response))
                {
                    JsonElement root = doc.RootElement;
                    string summary = root.GetProperty("extract").GetString() ?? string.Empty;

                    List<string> namesToCensor = new List<string>();

                    // From static answer string: add individual parts (split by underscore)
                    var answerParts = answer.Split('_', StringSplitOptions.RemoveEmptyEntries).ToList();
                    namesToCensor.AddRange(answerParts);

                    // Also add full phrase with spaces instead of underscores
                    namesToCensor.Add(answer.Replace("_", " ").Trim());

                    // Try to get Wikidata ID and add aliases and parts
                    if (root.TryGetProperty("wikibase_item", out JsonElement wikidataIdElement))
                    {
                        string wikidataId = wikidataIdElement.GetString();
                        if (!string.IsNullOrWhiteSpace(wikidataId))
                        {
                            var extraNames = await GetAliasesFromWikidata(wikidataId);

                            foreach (var alias in extraNames)
                            {
                                // Add full alias phrase
                                namesToCensor.Add(alias);

                                // Add individual words from alias for partial matching
                                var aliasParts = alias.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                                namesToCensor.AddRange(aliasParts);
                            }
                        }
                    }

                    summary = CensorNames(summary, namesToCensor.Distinct().ToList());

                    Debug.WriteLine($"Censored summary: {summary}");

                    return new Article
                    {
                        Person = answer,
                        TextBody = summary,
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Article
                {
                    Person = "Doesn't work",
                    TextBody = "Doesn't work"
                };
            }
        }

        private async Task<List<string>> GetAliasesFromWikidata(string wikidataId)
        {
            List<string> aliases = new List<string>();
            string url = $"https://www.wikidata.org/wiki/Special:EntityData/{wikidataId}.json";

            try
            {
                var json = await client.GetStringAsync(url);
                using (JsonDocument doc = JsonDocument.Parse(json))
                {
                    var entity = doc.RootElement.GetProperty("entities").GetProperty(wikidataId);

                    // Label (most known name)
                    if (entity.GetProperty("labels").TryGetProperty("en", out var label))
                        aliases.Add(label.GetProperty("value").GetString() ?? "");

                    // Aliases (other names)
                    if (entity.TryGetProperty("aliases", out var aliasesElement))
                    {
                        if (aliasesElement.TryGetProperty("en", out var enAliases))
                        {
                            foreach (var alias in enAliases.EnumerateArray())
                            {
                                var aliasValue = alias.GetProperty("value").GetString();
                                if (!string.IsNullOrWhiteSpace(aliasValue))
                                    aliases.Add(aliasValue);
                            }
                        }
                    }

                    Debug.WriteLine($"Found aliases count: {aliases.Count}");
                    foreach (var alias in aliases)
                    {
                        Debug.WriteLine($"Alias: {alias}");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Wikidata error: {ex.Message}");
            }

            return aliases.Distinct().ToList();
        }

        private async Task<List<string>> ResolveNameById(string id)
        {
            List<string> names = new List<string>();
            string url = $"https://www.wikidata.org/wiki/Special:EntityData/{id}.json";

            try
            {
                var json = await client.GetStringAsync(url);
                using (JsonDocument doc = JsonDocument.Parse(json))
                {
                    var entity = doc.RootElement.GetProperty("entities").GetProperty(id);
                    if (entity.GetProperty("labels").TryGetProperty("en", out var label))
                    {
                        var name = label.GetProperty("value").GetString();
                        if (!string.IsNullOrWhiteSpace(name)) names.Add(name);
                    }
                }
            }
            catch { }

            return names;
        }

        private string CensorNames(string summary, List<string> nameParts)
        {
            foreach (var part in nameParts)
            {
                if (string.IsNullOrWhiteSpace(part)) continue;

                // Normalize: Replace underscores and trim
                string cleanPart = part.Replace("_", " ").Trim();
                if (string.IsNullOrEmpty(cleanPart)) continue;

                // Try several variations for matching
                var variations = new List<string>
                {
                    cleanPart,
                    cleanPart.Replace(" ", ""), // e.g., ClintEastwood
                    // lowercase variant not needed due to RegexOptions.IgnoreCase
                };

                foreach (var variant in variations.Distinct())
                {
                    string pattern;

                    if (variant.Contains(" "))
                    {
                        // Multi-word phrase, no word boundaries because \b doesn't work across spaces
                        pattern = Regex.Escape(variant);
                    }
                    else
                    {
                        // Single word, use word boundaries and optional possessive
                        pattern = $@"\b{Regex.Escape(variant)}('?s)?\b";
                    }

                    summary = Regex.Replace(summary, pattern, match =>
                    {
                        return new string('*', match.Length);
                    }, RegexOptions.IgnoreCase);
                }
            }

            return summary;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using GuessThePage_Wikipedia.Logic.Entities; //to get Article class


namespace GuessThePage_Wikipedia.Logic.Servicies
{
    public class GameLogic
    {
        private static readonly HttpClient client = new HttpClient();

        string answer;
        public async Task<Article> GetRandomArticleFromCategory(string category)
        {
            string url = "https://en.wikipedia.org/api/rest_v1/page/summary/";
            string peopleList = File.ReadAllText("C:\\Users\\josep\\source\\repos\\KomaKuga\\GuessThePage_Wikipedia\\src\\Logic\\Servicies\\staticList.JSON"); // Reads the static list of persons from a JSON file

            using (JsonDocument doc = JsonDocument.Parse(peopleList)) 
            {
                JsonElement root = doc.RootElement;

                JsonElement peopleArray = root.GetProperty("people");

                JsonElement pickedPerson = peopleArray[Random.Shared.Next(peopleArray.GetArrayLength())]; // Randomly selects a person from the list

                
                answer = pickedPerson.GetString() ?? string.Empty; // Gets the name of the person, asegura que no sea nulo

                Console.WriteLine($"Selected person: {answer}"); // Outputs the selected person to the console
            }

            try
            {
                var response = await client.GetStringAsync(url + answer); // waits for the response from the API
                Console.WriteLine($"Response: {response}"); // Outputs the response to the console
                using (JsonDocument doc = JsonDocument.Parse(response))
                {
                    JsonElement root = doc.RootElement;

                    JsonElement summaryJSON = root.GetProperty("extract");

                    string summary = summaryJSON.GetString() ?? string.Empty;// Randomly selects a person from the list

                    summary = CensorNames(summary, answer);

                    Console.WriteLine($"Selected person: {summary}"); // Outputs the selected person to the console

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

        private string CensorNames(string summary, string fullNameWithUnderscores)
        {
            string[] nameParts = fullNameWithUnderscores.Split('_');

            foreach (var part in nameParts)
            {
                if (string.IsNullOrWhiteSpace(part)) continue;

                // Use Regex to do case-insensitive, whole-word replacement
                string pattern = $@"\b{Regex.Escape(part)}\b";
                summary = Regex.Replace(summary, pattern, new string('*', part.Length), RegexOptions.IgnoreCase);
            }

            return summary;
        }


    }
}

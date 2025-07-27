using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using GuessThePage_Wikipedia.Logic.Entities; //to get Article class


namespace GuessThePage_Wikipedia.Logic.Servicies
{
    public class GameLogic
    {
        private static readonly HttpClient client = new HttpClient();

        /*public async Task<Article> GetRandomArticleFromCategory(string category)
        {
            var categoryUrl = $"https://en.wikipedia.org/w/api.php?action=query&list=categorymembers&cmtitle=Category:{category}&cmlimit=500&format=json";
            var categoryResponse = await client.GetStringAsync(categoryUrl);

            var doc = JsonDocument.Parse(categoryResponse);
            var members = doc.RootElement.GetProperty("query").GetProperty("categorymembers");
            var randomIndex = new Random().Next(members.GetArrayLength());
            var page = members[randomIndex];
            var title = page.GetProperty("title").GetString();

            // Fetch article summary
            var encodedTitle = Uri.EscapeDataString(title);
            var summaryUrl = $"https://en.wikipedia.org/api/rest_v1/page/summary/{encodedTitle}";
            var summaryResponse = await client.GetStringAsync(summaryUrl);
            var summaryDoc = JsonDocument.Parse(summaryResponse).RootElement;

            return new Article
            {
                Person = summaryDoc.GetProperty("title").GetString(),
                TextBody = summaryDoc.GetProperty("extract").GetString(),
                Url = summaryDoc.GetProperty("content_urls").GetProperty("desktop").GetProperty("page").GetString()
            };
        }*/
        public async Task<Article> GetRandomArticleFromCategory(string category)
        {
            string url = "https://en.wikipedia.org/w/api.php?action=query&list=categorymembers&cmtitle=Category:American_actors&cmlimit=10&format=json";

            try
            {
                var response = await client.GetStringAsync(url); // waits for the response from the API
                var doc = JsonDocument.Parse(response); // parses the JSON response


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


    }
}

using System;
using System.Net.Http;
using System.Threading.Tasks;
using micocina_API.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace micocina_API.DAL
{
    public class BloggerClient
    {
        private static readonly HttpClient client = new HttpClient();
        private string bloggerId;
        private string bloggerApiKey;

        public BloggerClient(IOptions<API_Settings> appSettings)
        { 
            this.bloggerApiKey = appSettings.Value.Blogger_ApiKey;
            this.bloggerId = appSettings.Value.Blogger_BlogId;
        }

        public ExperienceResponse GetExperiences()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            var urlGetPosts = "https://www.googleapis.com/blogger/v3/blogs/{0}/posts/search?q=label:experience&key={1}";
            var msg = ExecuteGetRequest(urlGetPosts);
            Console.Write(msg);
            return serializeExperienceResponse(msg);
        }

        public NutriTipResponse GetNutriTips()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            var urlGetPosts = "https://www.googleapis.com/blogger/v3/blogs/{0}/posts/search?q=label:nutritip&key={1}";
            var msg = ExecuteGetRequest(urlGetPosts);
            Console.Write(msg);
            return serializeNutriTipResponse(msg);
        }

        public RecipeResponse GetRecipes(string nextPage)
        {
            //TODO: validate nextpage
            client.DefaultRequestHeaders.Accept.Clear();
            var urlGetPosts = "https://www.googleapis.com/blogger/v3/blogs/{0}/posts?key={1}";
            if (!String.IsNullOrEmpty(nextPage)) {
                urlGetPosts = "https://www.googleapis.com/blogger/v3/blogs/{0}/posts?key={1}&pageToken=" + nextPage;
            }
            var msg = ExecuteGetRequest(urlGetPosts);
            Console.Write(msg);
            return serializeRecipeResponse(msg);
        }

        private string ExecuteGetRequest(string url) {
            url = String.Format(url, this.bloggerId, this.bloggerApiKey);
            var stringTask = client.GetStringAsync(url);
            return stringTask.Result;
        }

        private static RecipeResponse serializeRecipeResponse(string blogResponse) {

            System.Text.Json.JsonDocument doc = JsonDocument.Parse(blogResponse);
            var items = doc.RootElement.GetProperty("items").EnumerateArray();
            var recipes = new List<Recipe>();

            foreach (var item in items) {
                var recipe = new Recipe();
                recipe.Name = item.GetProperty("title").GetString();
                recipe.Url = item.GetProperty("url").GetString();
                recipe.Types = item.GetProperty("labels").GetRawText().Replace("\"","").Replace("[", "").Replace("]", "").Replace("\n", "").Replace("        ", "").Replace("      ", "").Split(",");
                recipes.Add(recipe);
            }

            var nextpage = new JsonElement();
            doc.RootElement.TryGetProperty("nextPageToken", out nextpage);

            return new RecipeResponse()
            {
                Recipes = recipes.ToArray(),
                NextPage = nextpage.ToString()
            };

         }

        private static ExperienceResponse serializeExperienceResponse(string blogResponse)
        {
            System.Text.Json.JsonDocument doc = JsonDocument.Parse(blogResponse);
            var items = doc.RootElement.GetProperty("items").EnumerateArray();
            var experiences = new List<Experience>();

            foreach (var item in items)
            {
                var experience = new Experience();
                experience.Name = item.GetProperty("title").GetString();
                experience.Url = item.GetProperty("url").GetString();
                experiences.Add(experience);
            }

            var nextpage = new JsonElement();
            doc.RootElement.TryGetProperty("nextPageToken", out nextpage);

            return new ExperienceResponse()
            {
                Experiences = experiences.ToArray(),
                NextPage = nextpage.ToString()
            };
        }

        private static NutriTipResponse serializeNutriTipResponse(string blogResponse)
        {
            System.Text.Json.JsonDocument doc = JsonDocument.Parse(blogResponse);
            var items = doc.RootElement.GetProperty("items").EnumerateArray();
            var nutriTips = new List<NutriTip>();

            foreach (var item in items)
            {
                var nutriTip = new NutriTip();
                nutriTip.Name = item.GetProperty("title").GetString();
                nutriTip.Url = item.GetProperty("url").GetString();
                nutriTips.Add(nutriTip);
            }

            var nextpage = new JsonElement();
            doc.RootElement.TryGetProperty("nextPageToken", out nextpage);

            return new NutriTipResponse()
            {
                NutriTips = nutriTips.ToArray(),
                NextPage = nextpage.ToString()
            };

        }

    }

}

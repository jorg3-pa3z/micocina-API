using System;
using System.Collections;
using micocina_API.Models;
using Microsoft.Extensions.Options;

namespace micocina_API.DAL
{
    public class BloggerMiddleware
    {

        private IOptions<API_Settings> appsettings;
        public BloggerMiddleware(IOptions<API_Settings> appSettings)
        {
            this.appsettings = appSettings;
        }

        public RecipeResponse GetRecipes(string nextPage)
        {
            var client = new BloggerClient(this.appsettings);
            return client.GetRecipes(nextPage);
        }

        public NutriTipResponse GetNutriTips()
        {
            var client = new BloggerClient(this.appsettings);
            return client.GetNutriTips();
        }

        public ExperienceResponse GetExperiences() {
            var client = new BloggerClient(this.appsettings);
            return client.GetExperiences();
        }

        public Recipe GetRecipeById(int PostId) {
            return new Recipe();
        }

        public RecipeResponse GetRecipesByType(string type)
        {
            return new RecipeResponse();
        }
    }
}

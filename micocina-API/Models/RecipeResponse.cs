using System;
namespace micocina_API.Models
{
    public class RecipeResponse
    {
        public RecipeResponse()
        {
        }

        private Recipe[] _recipes;
        private string _nextPage;

        public Recipe[] Recipes { get => _recipes; set => _recipes = value; }
        public string NextPage { get => _nextPage; set => _nextPage = value; }
        
    }
}

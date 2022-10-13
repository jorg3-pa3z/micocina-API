using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using micocina_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace micocina_API.Controllers
{
    [Route("[controller]")]
    public class BlogController : Controller
    {

        private readonly IOptions<API_Settings> appSettings;

        public BlogController(IOptions<API_Settings> appSettings) {
            this.appSettings = appSettings;
        }

        [HttpGet("Recipes/{nextPage}")]
        public RecipeResponse GetRecipes(string nextPage)
        {
            micocina_API.DAL.BloggerMiddleware blog = new DAL.BloggerMiddleware(this.appSettings);
            return blog.GetRecipes(nextPage);
        }                                                                                       

        [HttpGet("NutriTips")]
        public NutriTipResponse GetNutriTips()
        {
            micocina_API.DAL.BloggerMiddleware blog = new DAL.BloggerMiddleware(this.appSettings);
            return blog.GetNutriTips();
        }

        [HttpGet("Experiences")]
        public ExperienceResponse GetExperiences()
        {
            micocina_API.DAL.BloggerMiddleware blog = new DAL.BloggerMiddleware(this.appSettings);
            return blog.GetExperiences();
        }

        // GET /values/5
        //[HttpGet("{types}")]
        //public RecipeResponse Get(string types)
        //{
        //    micocina_API.DAL.BloggerMiddleware blog = new DAL.BloggerMiddleware(appSettings);
        //    return blog.GetRecipes();
        //}

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using recipeWebsite.Models;
using AutoMapper;

namespace recipeWebsite.Controllers
{
    [Route("api/[controller]")]
    public class RecipesController : Controller
    {
        protected WebsiteContext DB;

        public RecipesController(WebsiteContext context)
        {
            DB = context;
        }

        // GET api/recipes/5
        [HttpGet("list")]
        public async Task<IActionResult> Get()
        {
            var recipes = await DB.Recipes.ToListAsync();
            //var recipesVM = Mapper.Map<IList<Recipe>,IList<RecipeVM>>(recipes);
            return Ok(recipes);
        }

        // POST api/recipes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Recipe obj)
        {
            if(obj != null)
            {
                var recipe = obj;
                await DB.Recipes.AddAsync(recipe);
                await DB.SaveChangesAsync();

                return Ok(recipe);
            }
            return BadRequest("Expected model was not appropriate.");
        }
    }
}

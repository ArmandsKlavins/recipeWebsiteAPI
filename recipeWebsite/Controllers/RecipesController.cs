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

        // GET api/recipes/list
        [HttpGet("list")]
        public async Task<IActionResult> Get()
        {
            var recipes = await DB.Recipes.Where(c => c.IsDeleted == false)
                
                .Include(c => c.RecipesCategories)
                .ThenInclude(c => c.Category).ToListAsync();
            var recipesVM = Mapper.Map<IList<Recipe>, IList<RecipeVM>>(recipes);

            //var cat = Mapper.Map<ICollection<RecipesCategories>, IList<Categories>>(recipes[0].RecipesCategories);
            return Ok(recipesVM);
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

        // PUT api/recipes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Recipe obj)
        {
            if(obj != null)
            {
                var recipe = await DB.Recipes.FirstOrDefaultAsync(c => c.Id == id);

                if(recipe != null)
                {
                    Mapper.Map<Recipe, Recipe>(obj, recipe);
                    
                    await DB.SaveChangesAsync();
                    return Ok(recipe);
                }
                return BadRequest("The recipe you tried to modify was not found!");
            }
            return BadRequest("Expected model was not appropriate.");
        }

        // DELETE api/recipes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var recipe = await DB.Recipes.FirstOrDefaultAsync(c => c.Id == id);
            if(recipe != null)
            {
                recipe.IsDeleted = true;
                await DB.SaveChangesAsync();
                return Ok();
            }
            return NotFound("The specified recipe was not found.");
        }

        // RESTORE api/recipes/undo/{id}
        [HttpGet("undo/{id}")]
        public async Task<IActionResult> Undo(long id)
        {
            var recipe = await DB.Recipes.FirstOrDefaultAsync(c => c.Id == id);
            if (recipe != null)
            {
                recipe.IsDeleted = false;
                await DB.SaveChangesAsync();
                return Ok(recipe);
            }
            return NotFound("The specified recipe was not found.");
        }
    }
}

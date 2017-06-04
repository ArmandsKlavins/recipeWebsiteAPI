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
        [HttpPost("list")]
        public async Task<IActionResult> Get([FromBody] RecipeQuery rq)
        {
            var recipes = DB.Recipes.Where(c => c.IsDeleted == false);
                
            if (!String.IsNullOrEmpty(rq.Filter))
            {
                recipes = recipes.Where(c => c.Name.Contains(rq.Filter));
            }
            var recipeCount = recipes.Count().ToString();
            if (!String.IsNullOrEmpty(rq.Category)) {
                recipes = recipes.Where(c => c.RecipesCategories.Any(y => y.Category.Name == rq.Category && y.Category.IsDeleted == false));
            }
            HttpContext.Response.Headers.Add("RecipesCount", recipeCount);
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "RecipesCount");

            recipes = recipes.Include(c => c.RecipesCategories)
                .ThenInclude(c => c.Category);
            recipes = recipes.Skip(rq.Limit * (rq.Page - 1)).Take(rq.Limit);
            var recipesVM = Mapper.Map<IList<Recipe>, IList<RecipeVM>>(await recipes.ToListAsync());

            return Ok(recipesVM);
        }

        // POST api/recipes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RecipeVM obj)
        {
            if(obj != null)
            {
                var recipe = Mapper.Map<RecipeVM,Recipe>(obj);
                
                
                await DB.Recipes.AddAsync(recipe);
                foreach(Categories c in obj.Categories)
                {
                    RecipesCategories rc = new RecipesCategories();
                    rc.CategoryId = c.Id;
                    rc.RecipeId = recipe.Id;
                    await DB.RecipesCategories.AddAsync(rc);
                }
                await DB.SaveChangesAsync();

                obj.Id = recipe.Id;
                return Ok(obj);
            }
            return BadRequest("Expected model was not appropriate.");
        }

        // PUT api/recipes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] RecipeVM obj)
        {
            if(obj != null)
            {
                var recipe = await DB.Recipes.FirstOrDefaultAsync(c => c.Id == id);

                if(recipe != null)
                {
                    Mapper.Map<RecipeVM, Recipe>(obj, recipe);

                    var rm = DB.RecipesCategories.Where(c => c.RecipeId == id);
                    foreach(RecipesCategories rc in rm)
                    {
                       DB.RecipesCategories.Remove(rc);
                    }
                    await DB.SaveChangesAsync();
                    foreach (Categories c in obj.Categories)
                    {
                        RecipesCategories rc = new RecipesCategories();
                        rc.CategoryId = c.Id;
                        rc.RecipeId = recipe.Id;
                        await DB.RecipesCategories.AddAsync(rc);
                    }

                    await DB.SaveChangesAsync();
                    
                    return Ok(obj);
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

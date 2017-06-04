using recipeWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace recipeWebsite.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        protected WebsiteContext DB;

        public CategoriesController(WebsiteContext context)
        {
            DB = context;
        }

        // GET api/categories/list
        [HttpPost("list")]
        public async Task<IActionResult> Get([FromBody] CategoryQuery cq)
        {
            var categories = DB.Categories.Where(c => c.IsDeleted == false);
            if (!String.IsNullOrEmpty(cq.Filter)) { 
            categories = categories.Where(c => c.Name.Contains(cq.Filter));
            }
            var CategoryCount = categories.Count().ToString();

            HttpContext.Response.Headers.Add("CategoryCount", CategoryCount);
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "CategoryCount");
            if (cq.Limit != 0)
            {
                categories = categories.Skip(cq.Limit * (cq.Page - 1)).Take(cq.Limit);
            }
            return Ok(await categories.ToListAsync());
        }

        // POST api/categories
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category obj)
        {
            if (obj != null)
            {
                var category = obj;
                await DB.Categories.AddAsync(category);
                await DB.SaveChangesAsync();

                return Ok(category);
            }
            return BadRequest("Expected model was not appropriate.");
        }

        // PUT api/categories/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Category obj)
        {
            if (obj != null)
            {
                var category = await DB.Categories.FirstOrDefaultAsync(c => c.Id == id);

                if (category != null)
                {
                    Mapper.Map<Category, Category>(obj, category);

                    await DB.SaveChangesAsync();
                    return Ok(category);
                }
                return BadRequest("The recipe you tried to modify was not found!");
            }
            return BadRequest("Expected model was not appropriate.");
        }

        // DELETE api/categories/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var category = await DB.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category != null)
            {
                category.IsDeleted = true;
                await DB.SaveChangesAsync();
                return Ok();
            }
            return NotFound("The specified category was not found.");
        }

        // RESTORE api/categories/undo/{id}
        [HttpGet("undo/{id}")]
        public async Task<IActionResult> Undo(long id)
        {
            var category = await DB.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category != null)
            {
                category.IsDeleted = false;
                await DB.SaveChangesAsync();
                return Ok(category);
            }
            return NotFound("The specified category was not found.");
        }
    }
}

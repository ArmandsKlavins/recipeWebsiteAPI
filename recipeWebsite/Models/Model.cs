using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace recipeWebsite.Models
{
    public class WebsiteContext : DbContext
    {
        public WebsiteContext(DbContextOptions<WebsiteContext> options)
            : base(options)
        { }

        public DbSet<Recipe> Recipes { get; set; }
    }

    public class Recipe
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int Time { get; set; }
        public int Servings { get; set; }
        public string Ingredients { get; set; } 
        public string Directions { get; set; }
        public string Url { get; set; }
        public string CreatedBy { get; set; }
    }
    public class RecipeVM
    {
        public string Name { get; set; }
    }
}

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
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RecipesCategories> RecipesCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.Entity<RecipesCategories>().HasKey(x => new { x.RecipeId, x.CategoryId });

            mb.Entity<Recipe>()
                .HasMany(c => c.RecipesCategories)
                .WithOne(c => c.Recipe)
                .HasForeignKey(c => c.RecipeId)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);

            mb.Entity<Category>()
                .HasMany(c => c.RecipesCategories)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);
           
        }

    }


}

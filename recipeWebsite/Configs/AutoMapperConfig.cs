using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using recipeWebsite.Models;

namespace recipeWebsite.Configs
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(c =>
            {
                c.CreateMap<RecipesCategories, Categories>()
                .ForMember(x => x.Name, o => o.MapFrom(y => y.Category.Name))
                .ForMember(x => x.Id, o => o.MapFrom(y => y.Category.Id));
                
                c.CreateMap<Recipe, RecipeVM>()
                .ForMember(x => x.Categories, o => o.MapFrom(y => y.RecipesCategories));
                c.CreateMap<RecipeVM, Recipe>();
                c.CreateMap<RecipeVM, RecipeVM>();
                c.CreateMap<Recipe, Recipe>();
                c.CreateMap<User, Token>();
                c.CreateMap<Category, Category>();
            });
        }
    }
}

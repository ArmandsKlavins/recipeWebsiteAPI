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
                c.CreateMap<Recipe, RecipeVM>();
            });
        }
    }
}

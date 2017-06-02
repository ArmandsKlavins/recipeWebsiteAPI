using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipeWebsite.Models
{
    public class Category : Base
    {
        public string Name { get; set; }
        public ICollection<RecipesCategories> RecipesCategories { get; set; }
    }

    public class Categories
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

}

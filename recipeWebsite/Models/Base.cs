using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipeWebsite.Models
{
    public class Base
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class Token
    {
        public string Username { get; set; }
        public string FullName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipeWebsite.Models
{
    public class User : Base
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}

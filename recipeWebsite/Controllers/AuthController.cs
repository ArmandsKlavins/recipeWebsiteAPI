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
    [Route("api/login/[controller]")]
    public class AuthController : Controller
    {
        protected WebsiteContext DB;

        public AuthController(WebsiteContext context)
        {
            DB = context;
        }

        // POST api/login/Auth
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User obj)
        {
            if(obj != null)
            {
                var user = await DB.Users.FirstOrDefaultAsync(c => c.Username == obj.Username && c.Password == obj.Password);
                if(user != null)
                {
                    var token = Mapper.Map<User, Token>(user);
                    return Ok(token);
                }
                return NotFound("Username or Password is incorrect!");
            }
            return BadRequest("Expected model was not appropriate.");
        }
    }
}

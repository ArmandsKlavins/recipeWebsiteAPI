using System;
using System.Security.Cryptography;
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
                Boolean IsValid = true;
                var user = await DB.Users.FirstOrDefaultAsync(c => c.Username == obj.Username);
                
                if(user != null)
                {
                    byte[] hashBytes = Convert.FromBase64String(user.Password);
                    byte[] salt = new byte[8];
                    Array.Copy(hashBytes, 0, salt, 0, 8);
                    var pbkdf2 = new Rfc2898DeriveBytes(obj.Password, salt, 1);
                    byte[] hash = pbkdf2.GetBytes(8);
                    for (int i = 0; i < 8; i++)
                    {
                        if (hashBytes[i + 8] != hash[i])
                        {
                            IsValid = false;
                        }
                    }
                    if (IsValid)
                    {
                        var token = Mapper.Map<User, Token>(user);
                        return Ok(token);
                    }
               }
                
                return NotFound("Username or Password is incorrect!");
            }
            return BadRequest("Expected model was not appropriate.");
        }
    }
}

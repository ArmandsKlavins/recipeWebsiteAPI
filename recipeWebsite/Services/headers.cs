using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using recipeWebsite.Models;

namespace recipeWebsite.Services
{
    public class PaginationFilter : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "RecipesCount");
            base.OnActionExecuted(context);
        }


    }
}

using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTakToe
{
    public class AuthorisedAttribute : ResultFilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string token = context.HttpContext.Request.Headers["token"].ToString();
            DBConnection obj = new DBConnection();
            bool authorized = obj.isAuthenticated(token);
            if (authorized != true)
            {
                throw new Exception("UnAuthorized");
            }

        }
    }
}

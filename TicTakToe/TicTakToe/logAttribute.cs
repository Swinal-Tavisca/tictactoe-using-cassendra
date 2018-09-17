using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
namespace TicTakToe
{
    public class logAttribute : ResultFilterAttribute, IActionFilter
    {
        log logs = new log();
        DBConnection connection = new DBConnection();

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception==null)
            {
                logs.response = "success";
                logs.request = "not applicable";
                logs.status = "request successfully executed";
                connection.loging(logs);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var route = context.RouteData;
            logs.request = "Controller : " + route.Values["controller"].ToString() + "Action Name : " + route.Values["action"].ToString();
   
        }
    }
}

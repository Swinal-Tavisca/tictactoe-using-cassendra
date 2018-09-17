using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTakToe
{
    public class ExceptionAttribute : ExceptionFilterAttribute
    {
        log logs = new log();
        public override void OnException(ExceptionContext context)
        {
            string req = logs.request;
            if(context.Exception is Exception)
            {
                var routeData = context.RouteData;
                logs.request = "Controller : " + routeData.Values["controller"].ToString() + "Action Name : " + routeData.Values["action"].ToString();
                logs.response = "falure";
                string tempException = context.Exception.ToString();
                int index = tempException.IndexOf("\r");
                logs.exception = tempException.Substring(0, index);
                logs.status = "exception occured";
                DBConnection dBConnection = new DBConnection();
                dBConnection.loging(logs);

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace TicTakToe.Controllers
{
    [Produces("application/json")]
    [Route("api/Identy")]
    [log]
    [Exception]
    public class IdentyController : Controller
    {
        // POST api/values
        [HttpPost]
        public void Post([FromBody]JObject value)
        {
            string firstName = value.GetValue("firstName").ToString();
            string lastName = value.GetValue("lastName").ToString();
            string userID= value.GetValue("userID").ToString();

            DBConnection dBConnection = new DBConnection();
            dBConnection.insert(firstName, lastName, userID);

        }
    }
}
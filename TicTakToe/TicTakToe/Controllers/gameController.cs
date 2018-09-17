using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace TicTakToe.Controllers
{
    //[Produces("application/json")]
    [Route("api/[Controller]")]
    [log]
    [Exception]
    public class gameController : Controller
    {
        static string[] moves = new string[9];
        static List<string> userlist = new List<string>();
        static int count = 0;
        static int flag = 0;
        static int gameEnds = 0;
        [HttpGet]
        [Authorised]
  
        public string makeMoves([FromHeader]string boxId1, [FromHeader]string tokenId)
        {
            int boxId = int.Parse(boxId1);
            string result = "in progres...";
            if (userlist.Count < 2 && !(userlist.Contains(tokenId)))
            {
                userlist.Add(tokenId);
                flag++;
            }
            if(flag>3)
            {
                throw new Exception("Invalid user !!!");
            }
            if (count % 2 == 0 && tokenId == userlist[0])
            {
                if (moves[boxId] == null)
                {
                    moves[boxId] = tokenId;
                    count++;
                }
                else
                {
                    return "Invalid move !!!";
                }

            }
            else if (count % 2 == 1 && tokenId == userlist[1])
            {
                if (moves[boxId] == null)
                {
                    moves[boxId] = tokenId;
                    count++;

                }
                else
                {
                    return "Invalid move !!!";
                }
            }
            else
            {
                throw new Exception("Invalid users turn !!!");
            }
            if(gameEnds!=0)
            {
                throw new Exception("User has already win !!!");
            }
            if (count >= 5)
            {
                result = getStatus();
            }
            return result;
        }
        public string getStatus()
        {
            if ((moves[0] == userlist[0] && moves[3] == userlist[0] && moves[6] == userlist[0]) || (moves[1] == userlist[0] && moves[4] == userlist[0] && moves[7] == userlist[0]) || (moves[2] == userlist[0] && moves[5] == userlist[0] && moves[8] == userlist[0]))
            {
                gameEnds++;
                return "****1 wins****";//user 1 win
            }
            else if ((moves[0] == userlist[0] && moves[1] == userlist[0] && moves[2] == userlist[0]) || (moves[3] == userlist[0] && moves[4] == userlist[0] && moves[5] == userlist[0]) || (moves[6] == userlist[0] && moves[7] == userlist[0] && moves[8] == userlist[0]))
            {
                gameEnds++;
                return "****1 wins****";//user 1 win
            }
            else if ((moves[0] == userlist[0] && moves[4] == userlist[0] && moves[8] == userlist[0]) || (moves[2] == userlist[0] && moves[4] == userlist[0] && moves[6] == userlist[0]))
            {
                gameEnds++;
                return "****1 wins****";   //user 1 win
            }
            else if ((moves[0] == userlist[1] && moves[3] == userlist[1] && moves[6] == userlist[1]) || (moves[1] == userlist[1] && moves[4] == userlist[1] && moves[7] == userlist[1]) || (moves[2] == userlist[1] && moves[5] == userlist[1] && moves[8] == userlist[1]))
            {
                gameEnds++;
                return "****2 wins****"; //user 2 win
            }
            else if ((moves[0] == userlist[1] && moves[1] == userlist[1] && moves[2] == userlist[1]) || (moves[3] == userlist[1] && moves[4] == userlist[1] && moves[5] == userlist[1]) || (moves[6] == userlist[1] && moves[7] == userlist[1] && moves[8] == userlist[1]))
            {
                gameEnds++;
                return "****2 wins****";//user 2 win
            }
            else if ((moves[0] == userlist[1] && moves[4] == userlist[1] && moves[8] == userlist[1]) || (moves[2] == userlist[1] && moves[4] == userlist[1] && moves[6] == userlist[1]))
            {
                gameEnds++;
                return "****2 wins****";//user 2 win
            }
            else
            {
                return "in progress...";//no one wins  
            }
            if(count==8 && gameEnds==0)
            {
                return "tie !!!";
            }
            
        }
    }
}
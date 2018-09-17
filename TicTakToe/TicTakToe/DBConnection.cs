using Cassandra;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TicTakToe
{
    public class DBConnection
    {

        //// Connect to the TicTacToe keyspace on our cluster running at 127.0.0.1
        //Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
        //ISession session = cluster.Connect("TicTacToe");

        ////Prepare a statement once
        //var ps = session.Prepare("INSERT INTO Log (ID, Response, Request, Exception, Date) VALUES (?,?,?,?,?)");

        ////...bind different parameters every time you need to execute
        //var statement = ps.Bind(Guid.NewGuid(), Log.Request, Log.Response, Log.Exception, Log.TimeStamp);
        ////Execute the bound statement with the provided parameters
        //session.Execute(statement);
        //        return true;



        public SqlConnection cnn;
        public SqlConnection connetionString = new SqlConnection("Data Source =.; Initial Catalog = TicTacToe; User ID = sa; Password=test123!@#");
        
        public void insert(string FName, string LName, string UserName)
        {

            connetionString.Open();
            
            string TokenID = Guid.NewGuid().ToString();

            string query = "Insert into  userTable  (firstName,lastName,userID,accessToken) values ('" + FName + "', '" + LName + "', '" + UserName + "', '" + TokenID + "')";

            SqlCommand myCommand = new SqlCommand(query, connetionString);
            myCommand.ExecuteNonQuery();
            connetionString.Close();

        }
        public bool isAuthenticated(string tokenId)
        {
            connetionString.Open();
            string query = "SELECT * FROM userTable where accessToken = '" + tokenId+"'";
            SqlCommand sqlCommand = new SqlCommand(query, connetionString);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if(sqlDataReader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
            connetionString.Close();
        }
        public bool loging(log logs)
        {
            //connetionString.Open();
            //string query = "Insert into  loging  (request,response,exception,status) values ('" +logs.request +"', '" +logs.response +"','" +logs.exception +"', '" +logs.status +"')";
            //SqlCommand myCommand = new SqlCommand(query, connetionString);
            //myCommand.ExecuteNonQuery();
            //connetionString.Close();


            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect("tictactoe");

            //Prepare a statement once
            var ps = session.Prepare("INSERT INTO loging (request, response, exception, status) VALUES (?,?,?,?)");

            //...bind different parameters every time you need to execute
            var statement = ps.Bind(/*Guid.NewGuid(), */logs.request, logs.response, logs.exception, logs.status);
            //Execute the bound statement with the provided parameters
            session.Execute(statement);
            return true;

        }
    }
}

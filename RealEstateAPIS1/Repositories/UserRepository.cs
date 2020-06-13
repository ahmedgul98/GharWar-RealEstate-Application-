using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RealEstateAPIS1.Repositories
{
    public class UserRepository
    {
        public static bool Login(string username, string password)
        {
            string query = $"SELECT [Password] FROM [RealEstate].[dbo].[User] where email = '" + username + "'";
            string x = "";
            var connectionstring = "Data Source=.;Initial Catalog=RealEstate;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionstring);
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        x = reader.GetString(0);
                    }
                }

                reader.Close();
                sqlCommand.Dispose();
                sqlConnection.Close();


            }
            catch (Exception e)
            {
                throw;

                return false;
            }
            if (password.Equals(x))
            {
                return true;
            }
            return false;
        }
        public static bool signup(string name, string pass,string uid,string email,string ph)
        {
            var connectionstring = "Data Source=.;Initial Catalog=RealEstate;Integrated Security=True";
            var query = "INSERT INTO [RealEstate].[dbo].[User] ([UserId] ,[Name],[Password],[Email] ,[Phone])  VALUES ('@UserId' ,'@Name','@Password','@Email' ,'@Phone')";
            query = query.Replace("@UserId", uid)
                .Replace("@Name", name)
                .Replace("@Password", pass)
                .Replace("@Email", email)
                .Replace("@Phone", ph);
                


            SqlConnection conn = new SqlConnection(connectionstring);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                int x = command.ExecuteNonQuery();
                command.Dispose();
                conn.Close();
                return true;
            }
            catch
            {
            
                return false;
            }
        }
        public static string getIdByName(string uname)
        {
            string query = $"SELECT [UserId] FROM [RealEstate].[dbo].[User] WHERE Email = '" + uname+"'";
            var connectionstring = "Data Source=.;Initial Catalog=RealEstate;Integrated Security=True";
            string string1 = "";
            SqlConnection sqlConnection = new SqlConnection(connectionstring);
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //Property property = new Property();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string1 = reader.GetString(0);

                    }
                }

                reader.Close();
                sqlCommand.Dispose();
                sqlConnection.Close();

                return string1;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public static List<string> GetEmails()
        {
            string query = $"SELECT [Email] FROM [RealEstate].[dbo].[User]";
            List<string> l = new List<string>();
            var connectionstring = "Data Source=.;Initial Catalog=RealEstate;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionstring);
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        l.Add(reader.GetString(0));
                    }
                }

                reader.Close();
                sqlCommand.Dispose();
                sqlConnection.Close();
                return l;

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}

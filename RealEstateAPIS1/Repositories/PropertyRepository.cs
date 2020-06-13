using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using RealEstateAPIS1.Models;

namespace RealEstateAPIS1.Repositories
{
    public class PropertyRepository
    {
        public static bool AddPropertyToDB(Property prop)
        {
            var connectionstring = "Data Source=.;Initial Catalog=RealEstate;Integrated Security=True";
            var query = "INSERT INTO Property (PropetyId,OwnerId,CityId,TypeId,n_Rooms,n_Baths,Title,Description,Area_sqft,Rent,Price) VALUES" +
                " ('@id', '@ownerid', '@cityid', '@typeid'," + prop.n_Rooms + "," + prop.n_Baths + ",'@title','@desc'," + prop.Area_sqft + ",'@rent'," + prop.Price + ")";

            query = query.Replace("@id", prop.PropetyId)
                .Replace("@ownerid", prop.OwnerId)
                .Replace("@cityid", prop.CityId)
                .Replace("@typeid", prop.TypeId)
                //.Replace("@nroom", prop.n_Rooms)
                // .Replace("@nbath", prop.n_Baths.ToString())
                .Replace("@title", prop.Title)
                .Replace("@desc", prop.Description)
                // .Replace("@area", prop.Area_sqft.ToString())
                .Replace("@rent", prop.Rent);
            // .Replace("@price", prop.Price.ToString());


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
        public static List<Property> PropertiesByRent(string rent)
        {
            string query;
            if (rent == "True" || rent == "true")
            {
                query = $"SELECT * FROM PROPERTY WHERE Rent='true'";
            }
            else
            {
                query = $"SELECT * FROM PROPERTY WHERE Rent='false'";
            }

            List<Property> propertiesByType = new List<Property>();
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
                        Property property = new Property();

                        property.PropetyId = reader.GetString(0);
                        property.OwnerId = reader.GetString(2);
                        property.CityId = reader.GetString(2);
                        property.TypeId = reader.GetString(3);
                        property.n_Rooms = reader.GetInt32(4);
                        property.n_Baths = reader.GetInt32(5);
                        property.Title = reader.GetString(6);
                        property.Description = reader.GetString(7);
                        property.Area_sqft = reader.GetInt32(8);
                        property.Rent = reader.GetString(9);
                        property.Price = reader.GetInt32(10);


                        propertiesByType.Add(property);
                    }
                }

                reader.Close();
                sqlCommand.Dispose();
                sqlConnection.Close();

                return propertiesByType;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public static List<Property> PropertiesByFiltering(int rooms, string area, string type)
        {
            string query = $"SELECT* FROM Property WHERE n_Rooms =" + rooms + "AND CityId = (SELECT CityId FROM City WHERE CityName = '" + area + "') AND TypeId = (SELECT TypeId FROM PropertyType WHERE TypeName = '" + type + "')";
            List<Property> propertiesByRoom = new List<Property>();
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
                        Property property = new Property();

                        property.PropetyId = reader.GetString(0);
                        property.OwnerId = reader.GetString(2);
                        property.CityId = reader.GetString(2);
                        property.TypeId = reader.GetString(3);
                        property.n_Rooms = reader.GetInt32(4);
                        property.n_Baths = reader.GetInt32(5);
                        property.Title = reader.GetString(6);
                        property.Description = reader.GetString(7);
                        property.Area_sqft = reader.GetInt32(8);
                        property.Rent = reader.GetString(9);
                        property.Price = reader.GetInt32(10);


                        propertiesByRoom.Add(property);
                    }
                }

                reader.Close();
                sqlCommand.Dispose();
                sqlConnection.Close();

                return propertiesByRoom;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public static List<Property> PropertiesByArea(string area)
        {
            string query = $"SELECT* FROM Property WHERE CityId = (SELECT CityId FROM City WHERE CityName = '" + area + "')";
            List<Property> propertiesByRoom = new List<Property>();
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
                        Property property = new Property();

                        property.PropetyId = reader.GetString(0);
                        property.OwnerId = reader.GetString(2);
                        property.CityId = reader.GetString(2);
                        property.TypeId = reader.GetString(3);
                        property.n_Rooms = reader.GetInt32(4);
                        property.n_Baths = reader.GetInt32(5);
                        property.Title = reader.GetString(6);
                        property.Description = reader.GetString(7);
                        property.Area_sqft = reader.GetInt32(8);
                        property.Rent = reader.GetString(9);
                        property.Price = reader.GetInt32(10);


                        propertiesByRoom.Add(property);
                    }
                }

                reader.Close();
                sqlCommand.Dispose();
                sqlConnection.Close();

                return propertiesByRoom;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public static List<Property> PropertiesByRoom(int rooms)
        {
            string query = $"SELECT * FROM PROPERTY WHERE n_Rooms =" + rooms;
            List<Property> propertiesByRoom = new List<Property>();
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
                        Property property = new Property();

                        property.PropetyId = reader.GetString(0);
                        property.OwnerId = reader.GetString(2);
                        property.CityId = reader.GetString(2);
                        property.TypeId = reader.GetString(3);
                        property.n_Rooms = reader.GetInt32(4);
                        property.n_Baths = reader.GetInt32(5);
                        property.Title = reader.GetString(6);
                        property.Description = reader.GetString(7);
                        property.Area_sqft = reader.GetInt32(8);
                        property.Rent = reader.GetString(9);
                        property.Price = reader.GetInt32(10);


                        propertiesByRoom.Add(property);
                    }
                }

                reader.Close();
                sqlCommand.Dispose();
                sqlConnection.Close();

                return propertiesByRoom;
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public static List<Property> AllProperties()
        {
            string query = $"SELECT * FROM Property";
            List<Property> allProperties = new List<Property>();
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
                        Property property = new Property();

                        property.PropetyId = reader.GetString(0);
                        property.OwnerId = reader.GetString(2);
                        property.CityId = reader.GetString(2);
                        property.TypeId = reader.GetString(3);
                        property.n_Rooms = reader.GetInt32(4);
                        property.n_Baths = reader.GetInt32(5);
                        property.Title = reader.GetString(6);
                        property.Description = reader.GetString(7);
                        property.Area_sqft = reader.GetInt32(8);
                        property.Rent = reader.GetString(9);
                        property.Price = reader.GetInt32(10);


                        allProperties.Add(property);
                    }
                }

                reader.Close();
                sqlCommand.Dispose();
                sqlConnection.Close();

                return allProperties;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public static void AddToFav(string pid, string oid)
        {
            var connectionstring = "Data Source=.;Initial Catalog=RealEstate;Integrated Security=True";
            var query = "INSERT INTO Favourite (PropertyId,OwnerId)  VALUES ('@PropertyId','@OwnerId')";
            query = query.Replace("@PropertyId", pid)
                .Replace("@OwnerId", oid);

            SqlConnection conn = new SqlConnection(connectionstring);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                int x = command.ExecuteNonQuery();
                command.Dispose();
                conn.Close();
                //return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
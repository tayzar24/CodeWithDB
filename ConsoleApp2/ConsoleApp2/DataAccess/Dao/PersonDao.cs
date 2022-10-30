using ConsoleApp2.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DataAccess.Dao
{
    public class PersonDao
    {
        public static int GetLastedPersonID()
        {
            int id = 0;
            var connectionString = ConnectionHelper.GetConnectionString();
            string queryString = "SELECT Max(PersonID) FROM dbo.Persons;";
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                id =(int) command.ExecuteScalar() + 1;
            }
            return id;
        }

        public static List<Person> GetAllPersonList()
        {
            DataSet ds = new DataSet();
            var list = new List<Person>();
            var connectionString = ConnectionHelper.GetConnectionString();
            string queryString = "SELECT * FROM dbo.Persons;";
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);
                list = ConvertToList(ds.Tables[0]);
            }
            return list;
        }

        public static List<Person> GetPersonByName(string name)
        {
            DataSet ds = new DataSet();
            var list = new List<Person>();
            var connectionString = ConnectionHelper.GetConnectionString();
            string queryString = "SELECT * FROM dbo.Persons where FirstName = @name;";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@name", name);
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);
                list = ConvertToList(ds.Tables[0]);
                connection.Close();
            }

            return list;
        }
        public static bool InsertPersonData(Person inputData)
        {
            bool result = true;
            try
            {
                DataSet ds = new DataSet();
                var list = new List<Person>();
                var connectionString = ConnectionHelper.GetConnectionString();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Persons(PersonID, FirstName, LastName,Address,City)   VALUES(@id,@firstName,@lastName,@address,@city)";

                    command.Parameters.AddWithValue("@id", GetLastedPersonID());
                    command.Parameters.AddWithValue("@firstName", inputData.FirstName);
                    command.Parameters.AddWithValue("@lastName", inputData.LastName);
                    command.Parameters.AddWithValue("@address", inputData.Address);
                    command.Parameters.AddWithValue("@city", inputData.City);

                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                //Write Log
                result =  false;
            }
            return result;
            
        }

        #region private method
        private static List<Person> ConvertToList(DataTable dt)
        {
            List<Person> list = new List<Person>();
            list = dt.AsEnumerable().Select(s => new Person
            {
                PersonID = s.Field<int>("PersonID"),
                FirstName = s.Field<string>("FirstName"),
                LastName = s.Field<string>("LastName"),
                Address = s.Field<string>("Address"),
                City = s.Field<string>("City"),
            }).ToList();
            return list;
        }
        #endregion

    }
}

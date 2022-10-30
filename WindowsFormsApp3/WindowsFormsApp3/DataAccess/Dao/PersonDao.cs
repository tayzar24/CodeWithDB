using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp3.DataAccess.DBHelper;
using WindowsFormsApp3.DataAccess.Model;
using WindowsFormsApp3.Model.Response;

namespace WindowsFormsApp3.DataAccess.Dao
{
    public class PersonDao
    {
        public static List<Person> GetAllPersonList()
        {
            var result = new List<Person>();
            try
            {
                DataSet ds = new DataSet();
                var connectionString = DatabaseHelper.GetConnectionString();
                string queryString = "SELECT * FROM Persons;";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var command = new SqlCommand(queryString, connection);
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(ds);
                    result = ConvertToPersonList(ds.Tables[0]);

                    connection.Close();
                }
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public static int GetLastedPersonID()
        {
            try
            {
                DataSet ds = new DataSet();
                var connectionString = DatabaseHelper.GetConnectionString();
                string queryString = "SELECT Max(PersonID) FROM Persons;";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var command = new SqlCommand(queryString, connection);
                    int id = (int)command.ExecuteScalar() + 1;

                    connection.Close();

                    return id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static List<Person> InsertPersonData(Person input)
        {
            var result = new List<Person>();
            try
            {
                input.Id = GetLastedPersonID();
                DataSet ds = new DataSet();
                var connectionString = DatabaseHelper.GetConnectionString();
                string queryString = "INSERT INTO Persons(PersonID,FirstName,LastName,Address,City) VALUES(@id,@firstName,@lastName,@address,@city)";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@id",input.Id);
                    command.Parameters.AddWithValue("@firstName",input.FirstName);
                    command.Parameters.AddWithValue("@lastName",input.LastName);
                    command.Parameters.AddWithValue("@address",input.Address);
                    command.Parameters.AddWithValue("@city",input.City);

                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #region private method
        private static List<Person> ConvertToPersonList(DataTable dt)
        {
            List<Person> list = new List<Person>();
            var i = dt.AsEnumerable();
            list = dt.AsEnumerable().Select(s => new Person
            {
                Id = s.Field<int>("PersonID"),
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

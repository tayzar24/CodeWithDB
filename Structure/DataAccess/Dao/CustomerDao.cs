using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public class CustomerDao
    {
        public static int GetAllPersonList()
        {
            try
            {
                DataSet ds = new DataSet();
                var connectionString = DatabaseDao.connectionString;
                string queryString = "SELECT Count(PersonID) FROM Persons;";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var command = new SqlCommand(queryString, connection);
                    int result = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

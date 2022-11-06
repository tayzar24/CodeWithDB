using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public class DatabaseDao
    {
        public static string connectionString = "";

        public static void Initalize(string connString)
        {
            try
            {
                using (var connection = new SqlConnection(connString))
                {
                    connection.Open();
                    connection.Close();
                }
                connectionString = connString;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

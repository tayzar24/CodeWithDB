using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.DataAccess.DBHelper
{
    public class DatabaseHelper
    {
        /// <summary>
        /// GetConnectionString
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DBString"].ConnectionString;
        }
    }
}

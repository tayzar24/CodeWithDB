using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DataAccess
{
    public class ConnectionHelper
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DBString"].ConnectionString;
        }
    }
}

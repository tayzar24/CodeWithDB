using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Util.Helper
{
    public class DataBaseHelper
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DBString"].ConnectionString;
        }
    }
}

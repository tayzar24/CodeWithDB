using AppService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Util.Helper;

namespace TestProject.Mid
{
    public class DataBaseExecutor
    {
        public static string Initialize()
        {
            return DataAccessAppService.InitializeConnection(DataBaseHelper.GetConnectionString());
        }
    }
}

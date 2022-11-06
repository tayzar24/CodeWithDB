using Common;
using DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Service
{
    public class DataAccessAppService
    {
        public static string InitializeConnection(string connectionString)
        {
            try
            {
                DatabaseDao.Initalize(connectionString);

            }catch(Exception ex)
            {
                string message = CreateExceptionMessage.CreateResultMessage(ex);
                return message;
            }
            return string.Empty;
        }
    }
}

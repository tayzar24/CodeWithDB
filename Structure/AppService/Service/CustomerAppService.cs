using AppService.Model;
using DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dao = DataAccess.Modal;

namespace AppService.Service
{
    public class CustomerAppService
    {
        public static int GetPersonCount()
        {
            try
            {
                return CustomerDao.GetAllPersonList();

            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

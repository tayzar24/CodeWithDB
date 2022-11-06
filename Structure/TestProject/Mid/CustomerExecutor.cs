using AppService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Mid
{
    public class CustomerExecutor
    {
        public int GetCustomerCount()
        {
            return CustomerAppService.GetPersonCount();
        }
    }
}

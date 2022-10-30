using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp3.Model.Response;

namespace WindowsFormsApp3.Service
{
    interface IPersonAppService
    {
        ResGetPersonList GetAllPersonList();
    }
}

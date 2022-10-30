using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.Model.Response
{
    public class ResGetPersonList :ResponseBase
    {
        public List<Person> PersonList { get; set; }
    }
}

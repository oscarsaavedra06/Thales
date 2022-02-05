using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThalesTestApplicationCore.CustomEnities
{
   public class EmployeeApiResponse <T>
    {
       
        public string status { get; set; }
        public T Data { get; set; }
        public string message { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThalesTestApplicationCore.Entities
{
   public class Employee
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public decimal employee_salary { get; set; }
        public decimal employee_anual_salary { get; set; }
        public int employee_age { get; set; }
        public string profile_image { get; set; }
    }
}

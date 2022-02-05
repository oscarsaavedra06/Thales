using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThalesTestApplicationCore.Entities;

namespace ThalesTestApplicationCore.Interfaces
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> getEmployees();
        Task<Employee> getEmployeesById(int id);
    }
}

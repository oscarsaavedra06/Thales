using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThalesTestApplicationCore.CustomEnities;
using ThalesTestApplicationCore.Entities;
using ThalesTestApplicationCore.Interfaces;
using ThalesTestApplicationCore.ServiceHelper;
using ThalesTestApplicationCore.SettingHelper;

namespace ThalesTestInfrastructure.Repositories
{
    public class EmployeeRepository : IEmployee
    {

        public EmployeeRepository()
        {

        }
        public decimal employeeAnaulSalary(decimal salary)
        {

            return salary * 12;
        }

        public async Task<IEnumerable<Employee>> getEmployees()
        {
            try
            {
                string apiUrl = AppSettings.Instance.EmployesApiUrl;
                var apiResult = await ServiceHelper.GetIRequest(apiUrl);
                var apiEntityResponse = JsonConvert.DeserializeObject<EmployeeApiResponse<List<Employee>>>(apiResult);
                if (apiEntityResponse.status.Equals("success"))
                {

                    apiEntityResponse.Data.ForEach(item =>
                   {

                       item.employee_anual_salary = employeeAnaulSalary(item.employee_salary);
                   });

                    return apiEntityResponse.Data;
                }
                else
                {
                    return Enumerable.Empty<Employee>();
                }

            }
            catch (Exception ex)
            {
                return null;
                //registrar en log
            }

        }

        public async Task<Employee> getEmployeesById(int id)
        {
            try
            {
                string apiUrl = $"{AppSettings.Instance.GetEmployeeApiUrl}/{id}";
                var apiResult = await ServiceHelper.GetIRequest(apiUrl);
                var apiEntityResponse = JsonConvert.DeserializeObject<EmployeeApiResponse<Employee>>(apiResult);
                if (apiEntityResponse.status.Equals("success"))
                {
                    apiEntityResponse.Data.employee_anual_salary = employeeAnaulSalary(apiEntityResponse.Data.employee_salary);
                    return apiEntityResponse.Data;
                }
                else
                {
                    return new Employee();
                }

            }
            catch (Exception ex)
            {
                return null;
                //registrar en log
            }
        }
    }
}

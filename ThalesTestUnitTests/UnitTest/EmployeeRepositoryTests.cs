using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using ThalesTestInfrastructure.Repositories;

namespace ThalesTestUnitTests
{
    [TestClass]
    public class EmployeeRepositoryTests
    {
        [TestMethod]
        public void CalculateAnnualSalaryCorrectly()
        {
            var repository = new EmployeeRepository();
            var value = 10000;
            var result = repository.employeeAnaulSalary(value);

            Assert.AreEqual(value * 12, result);
        }
    }
}

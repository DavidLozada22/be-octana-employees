using be_octana_employees.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OctanaEmployeesBe.Domain.Business;
using OctanaEmployeesBe.Domain.Contracts;
using OctanaEmployeesBe.Domain.Entities;
using OctanaEmployeesBe.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctanaEmployeesBe.Domain.Business.Tests
{
    [TestClass()]
    public class EmployeeBusinessTests
    {
        private IEmployeeBusiness<Employee> _employeeBusiness;

        public EmployeeBusinessTests(IEmployeeBusiness<Employee> employeeBusiness)
        {
            _employeeBusiness = employeeBusiness;
        }

        [TestMethod()]
        public async Task GetEmployeeByIdsAsyncTest()
        {
            // Arrange
            var mockEmployeeRepository = new Mock<IEmployeeRepository<Employee>>().Object;

            _employeeBusiness = new EmployeeBusiness(mockEmployeeRepository);
            
            var expectedEmployee = new Employee { 
                id = 1, 
                employee_name = "Tiger Nixon", 
                employee_salary = 320800, 
                employee_age = 61, 
                profile_image = "", 
                employee_annual_salary = 320800 * 12
            };

            // Act
            var result = await _employeeBusiness.GetEmployeeByIdsAsync(1);

            //Assert
            Assert.AreEqual(expectedEmployee, result);
        }
    }
}
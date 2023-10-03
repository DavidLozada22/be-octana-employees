using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OctanaEmployeesBe.Domain.Contracts;
using OctanaEmployeesBe.Domain.Entities;
using OctanaEmployeesBe.Infrastructure.Contracts;

namespace OctanaEmployeesBe.Domain.Business.Tests
{
    [TestClass()]
    public class EmployeeBusinessTests
    {
        private IEmployeeBusiness<Employee> _employeeBusiness;

        [TestInitialize]
        public void Initialize()
        {
            //var mockEmployeeRepository = new Mock<IEmployeeRepository<Employee>>().Object;
            //_employeeBusiness = new EmployeeBusiness(mockEmployeeRepository);

            var mockEmployeeRepository = new Mock<IEmployeeRepository<Employee>>();

            mockEmployeeRepository.Setup(repo => repo.GetEmployeeByIdsAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => new Employee
                {
                    id = id,
                    employee_name = "Tiger Nixon",
                    employee_salary = 320800,
                    employee_age = 61,
                    profile_image = "",
                    employee_annual_salary = 320800 * 12
                });

            // Convierte el mock en un objeto real
            var employeeRepository = mockEmployeeRepository.Object;

            // Crea la instancia de EmployeeBusiness utilizando el objeto mock
            _employeeBusiness = new EmployeeBusiness(employeeRepository);
        }

        [TestMethod()]
        public async Task GetEmployeeByIdsAsyncTest()
        {
            // Arrange
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
            Assert.AreEqual(expectedEmployee.id, result.id);
            Assert.AreEqual(expectedEmployee.employee_name, result.employee_name);
            Assert.AreEqual(expectedEmployee.employee_salary, result.employee_salary);
            Assert.AreEqual(expectedEmployee.employee_age, result.employee_age);
            Assert.AreEqual(expectedEmployee.profile_image, result.profile_image);
            Assert.AreEqual(expectedEmployee.employee_annual_salary, result.employee_annual_salary);
        }
    }
}
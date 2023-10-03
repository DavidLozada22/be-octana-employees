using OctanaEmployeesBe.Domain.Contracts;
using OctanaEmployeesBe.Domain.Entities;
using OctanaEmployeesBe.Infrastructure.Contracts;

namespace OctanaEmployeesBe.Domain.Business
{
    public class EmployeeBusiness : IEmployeeBusiness<Employee>
    {
        private readonly IEmployeeRepository<Employee> _employeeRepository;

        public EmployeeBusiness(IEmployeeRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var result = await _employeeRepository.GetEmployeesAsync();
            return result.ToList();
        }

        public async Task<Employee> GetEmployeeByIdsAsync(int id)
        {
            var result = await _employeeRepository.GetEmployeeByIdsAsync(id);
            result.employee_annual_salary = result.employee_salary * 12;
            return result;
        }
    }
}
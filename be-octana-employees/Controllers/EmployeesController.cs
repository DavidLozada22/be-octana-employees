using Microsoft.AspNetCore.Mvc;
using OctanaEmployeesBe.Domain.Contracts;
using OctanaEmployeesBe.Domain.Entities;

namespace be_octana_employees.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeBusiness<Employee> _employeeBusiness;

        public EmployeesController(IEmployeeBusiness<Employee> employeeBusiness)
        {
            _employeeBusiness = employeeBusiness;
        }

        [HttpGet("GetEmployees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesAsync()
        {

            var result = await _employeeBusiness.GetEmployeesAsync();
            return result.ToList();
        }

        [HttpGet("GetEmployeeById/{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeByIdsAsync(int id)
        {
            var result = await _employeeBusiness.GetEmployeeByIdsAsync(id);

            return result;
        }
    }
}

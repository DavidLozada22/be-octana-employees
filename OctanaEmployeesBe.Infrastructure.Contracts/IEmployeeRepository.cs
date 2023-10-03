using OctanaEmployeesBe.Domain.Entities;

namespace OctanaEmployeesBe.Infrastructure.Contracts
{
    public interface IEmployeeRepository<T> where T : class
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdsAsync(int id);
    }
}
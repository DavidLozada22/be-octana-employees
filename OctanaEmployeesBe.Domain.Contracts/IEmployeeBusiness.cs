using OctanaEmployeesBe.Domain.Entities;

namespace OctanaEmployeesBe.Domain.Contracts
{
    public interface IEmployeeBusiness<T> where T : class
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdsAsync(int id);
    }
}
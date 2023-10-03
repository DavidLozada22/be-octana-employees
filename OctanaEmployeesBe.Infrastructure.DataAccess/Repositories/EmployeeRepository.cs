using Newtonsoft.Json;
using OctanaEmployeesBe.Domain.Entities;
using OctanaEmployeesBe.Infrastructure.Contracts;
using System.Net;
using System.Text.Json.Nodes;

namespace OctanaEmployeesBe.Infrastructure.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository<Employee>
    {
        private readonly HttpClient _httpClient;

        public EmployeeRepository()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://dummy.restapiexample.com/api/v1/employees");

            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)   
            {
                var result = JsonConvert.DeserializeObject<ListEmployeeResponse>(await response.Content.ReadAsStringAsync());
                return result.data;
            }

            throw new Exception($"Error getting employees: {response.StatusCode}");
        }

        public async Task<Employee> GetEmployeeByIdsAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://dummy.restapiexample.com/api/v1/employee/" + id);

            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = JsonConvert.DeserializeObject<EmployeeResponse>(await response.Content.ReadAsStringAsync());
                return result.data;
            }

            throw new Exception($"Error getting employees: {response.StatusCode}");
        }
    }
}
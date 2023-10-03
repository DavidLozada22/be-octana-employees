namespace OctanaEmployeesBe.Domain.Entities
{
    public class Employee
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public int employee_salary { get; set; }
        public int employee_age { get; set; }
        public string profile_image { get; set; }
        public int? employee_annual_salary { get; set; }
    }

    public class EmployeeResponse
    {
        public Employee data { get; set; }
    }

    public class ListEmployeeResponse
    {
        public List<Employee> data { get; set; }
    }
}
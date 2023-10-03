using OctanaEmployeesBe.Domain.Business;
using OctanaEmployeesBe.Domain.Contracts;
using OctanaEmployeesBe.Domain.Entities;
using OctanaEmployeesBe.Infrastructure.Contracts;
using OctanaEmployeesBe.Infrastructure.DataAccess.Repositories;

namespace be_octana_employees.IoC
{
    public static class DependencyBuilder
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:4200")
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });
        }

        public static void DependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeBusiness<Employee>, EmployeeBusiness>();
            services.AddScoped<IEmployeeRepository<Employee>, EmployeeRepository>();
        }
    }
}

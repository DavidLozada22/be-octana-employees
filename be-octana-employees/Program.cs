using OctanaEmployeesBe.Domain.Business;
using OctanaEmployeesBe.Domain.Contracts;
using OctanaEmployeesBe.Domain.Entities;
using OctanaEmployeesBe.Infrastructure.Contracts;
using OctanaEmployeesBe.Infrastructure.DataAccess.Repositories;
using be_octana_employees.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.DependencyInjection();
builder.Services.ConfigureCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

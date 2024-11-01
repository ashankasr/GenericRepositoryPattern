using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Database;
using TestWebApi.Entities;
using TestWebApi.Entities.Repositories;
using TestWebApi.Request;

namespace TestWebApi.Endpoints
{
    public static class EmployeeEndpoints
    {
        public static void MapEmployeeEndpoints(this WebApplication app)
        {
            app.MapGet("/Employees", async (ApplicationDbContext context) =>
            {
                var result = await context.Employees.FirstOrDefaultAsync();
                return result;
            }).WithName("Get Employee");

            app.MapPost("/Employees", async (
                [FromBody] EmployeePostRequest request,
                ApplicationDbContext context,
                IAuditableEntityRepository<Employee> repository) =>
            {
                await repository.AddAsync(Employee.Create(request.FirstName));

                return;
            }).WithName("Post Employee");

            app.MapPost("/MaritalStatus", async (
                [FromBody] EmployeePostRequest request,
                ApplicationDbContext context,
                ILookupEntityRepository<MaritalStatus> repository) =>
            {
                await repository.AddAsync(MaritalStatus.Create(request.FirstName));

                return;
            }).WithName("Post Marital Status");
        }
    }
}
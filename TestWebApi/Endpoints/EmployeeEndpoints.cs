using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Database;
using TestWebApi.Entities;
using TestWebApi.Entities.Repositories;
using TestWebApi.Interfaces;
using TestWebApi.Request;

namespace TestWebApi.Endpoints
{
    public static class EmployeeEndpoints
    {
        public static void MapEmployeeEndpoints(this WebApplication app)
        {
            app.MapGet("/Employees", async (IAuditableEntityRepository<Employee> repository) =>
            {
                var result = await repository.GetAllAsync();
                return result;
            }).WithName("Get Employee");

            app.MapGet("/Employees/{id}", async (IAuditableEntityRepository<Employee> repository, Guid id) =>
            {
                var result = await repository.GetByIdAsync(id);
                return result;
            }).WithName("Get Employee by Id");

            app.MapPost("/Employees", async (
                [FromBody] EmployeePostRequest request,
                IAuditableEntityRepository<Employee> repository) =>
            {
                await repository.AddAsync(Employee.Create(request.FirstName));

                return;
            }).WithName("Post Employee");

            app.MapPost("/MaritalStatus", async (
                [FromBody] EmployeePostRequest request,
                ILookupEntityRepository<MaritalStatus> repository,
                IUnitOfWork unitOfWork) =>
            {

                await using DbTransaction transaction = await unitOfWork.BeginTransactionAsync();

                await repository.AddAsync(MaritalStatus.Create(request.FirstName));

                await unitOfWork.SaveChangesAsync();

                await transaction.CommitAsync();

                return;
            }).WithName("Post Marital Status");
        }
    }
}
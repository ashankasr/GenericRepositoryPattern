namespace GenericRepositoryPattern.Endpoints;

using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using GenericRepositoryPattern.Entities;
using GenericRepositoryPattern.Entities.Repositories;
using GenericRepositoryPattern.Interfaces;
using GenericRepositoryPattern.Request;

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
            [FromBody] MaritalStatusRequest request,
            ILookupEntityRepository<MaritalStatus> repository,
            IUnitOfWork unitOfWork) =>
        {

            await using DbTransaction transaction = await unitOfWork.BeginTransactionAsync();

            await repository.AddAsync(MaritalStatus.Create(request.Name));

            await unitOfWork.SaveChangesAsync();

            await transaction.CommitAsync();

            return;
        }).WithName("Post Marital Status");

        app.MapPost("/ComposeType/{employeeId}", async (
            Guid employeeId,
            IRepository<ComposeType> repository,
            IUnitOfWork unitOfWork) =>
        {

            await using DbTransaction transaction = await unitOfWork.BeginTransactionAsync();

            await repository.AddAsync(ComposeType.CreateSingle(employeeId));

            await unitOfWork.SaveChangesAsync();

            await transaction.CommitAsync();

            return;
        }).WithName("Post Compose Type");
    }
}
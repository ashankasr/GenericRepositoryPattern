namespace GenericRepositoryPattern;

using Microsoft.EntityFrameworkCore;
using GenericRepositoryPattern.Database;
using GenericRepositoryPattern.Database.Repositories;
using GenericRepositoryPattern.Entities.Repositories;
using GenericRepositoryPattern.Interfaces;
using GenericRepositoryPattern.Interfaces.Services;
using GenericRepositoryPattern.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddScoped(typeof(IAuditableEntityRepository<>), typeof(AuditableEntityRepository<>));
        services.AddScoped(typeof(ILookupEntityRepository<>), typeof(LookupEntityRepository<>));

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ApplicationDbContext>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}
using Microsoft.EntityFrameworkCore;
using TestWebApi.Database;
using TestWebApi.Database.Repositories;
using TestWebApi.Entities.Repositories;
using TestWebApi.Interfaces;
using TestWebApi.Interfaces.Services;
using TestWebApi.Services;

namespace TestWebApi;

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
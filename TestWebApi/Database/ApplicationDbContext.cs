using Microsoft.EntityFrameworkCore;
using TestWebApi.Entities;
using TestWebApi.Entities.Base;
using TestWebApi.Interfaces.Services;

namespace TestWebApi.Database;
public class ApplicationDbContext : DbContext
{
    private ITokenService tokenService { get; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<MaritalStatus> MaritalStatuses { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ITokenService tokenService)
            : base(options)
    {
        this.tokenService = tokenService;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditableEntities();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        UpdateAuditableEntities();
        return base.SaveChanges();
    }

    private void UpdateAuditableEntities()
    {
        var username = this.tokenService.GetUsername();

        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is AuditableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            var entity = (AuditableEntity)entry.Entity;

            if (entry.State == EntityState.Added)
            {
                entity.CreatedDate = DateTime.UtcNow;
                entity.CreatedBy = username;
            }

            entity.ModifiedBy = username;
            entity.ModifiedDate = DateTime.UtcNow;
        }
    }
}


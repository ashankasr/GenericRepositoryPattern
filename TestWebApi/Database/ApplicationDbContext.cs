namespace TestWebApi.Database;

using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TestWebApi.Entities;
using TestWebApi.Entities.Base;
using TestWebApi.Interfaces;
using TestWebApi.Interfaces.Services;

public class ApplicationDbContext : DbContext, IUnitOfWork
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
        Interceptor();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        Interceptor();

        return base.SaveChanges();
    }

    private void Interceptor()
    {
        var username = this.tokenService.GetUsername();
        var now = DateTime.UtcNow;

        var auditableEntries = ChangeTracker.Entries()
            .Where(e => e.Entity is AuditableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

        var softDeleteEntries = ChangeTracker.Entries()
            .Where(e => e.Entity is ISoftDelete && e.State == EntityState.Deleted);

        foreach (var entry in auditableEntries)
        {
            var entity = (AuditableEntity)entry.Entity;

            if (entry.State == EntityState.Added)
            {
                entity.CreatedDate = now;
                entity.CreatedBy = username;
            }

            entity.ModifiedBy = username;
            entity.ModifiedDate = now;
        }

        foreach (var entry in softDeleteEntries)
        {
            var entity = (ISoftDelete)entry.Entity;
            entity.IsDeleted = true;
            entry.State = EntityState.Modified;
        }
    }

    public async Task<DbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (Database.CurrentTransaction is not null)
        {
            await Database.CurrentTransaction.DisposeAsync();
        }

        return (await Database.BeginTransactionAsync(cancellationToken)).GetDbTransaction();
    }
}


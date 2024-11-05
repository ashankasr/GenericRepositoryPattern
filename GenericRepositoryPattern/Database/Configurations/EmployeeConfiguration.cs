using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GenericRepositoryPattern.Database.Configurations.Base;
using GenericRepositoryPattern.Entities;

namespace GenericRepositoryPattern.Database.Configurations;

public class EmployeeConfiguration : AuditableEntityConfiguration<Employee>
{
    public override void Configure(EntityTypeBuilder<Employee> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.FirstName)
            .IsRequired()
            .HasColumnType("nvarchar(100)");
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApi.Database.Configurations.Base;
using TestWebApi.Entities;

namespace TestWebApi.Database.Configurations;

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

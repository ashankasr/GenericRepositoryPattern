using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GenericRepositoryPattern.Database.Configurations.Base;
using GenericRepositoryPattern.Entities.Base;

namespace GenericRepositoryPattern.Entities;

public class ComposeType : Entity
{
    private ComposeType()
    {

    }

    public Guid EmployeeId { get; set; }
    public int MaritalStatusId { get; set; }

    public static ComposeType CreateSingle(Guid employeeId)
    {
        return new ComposeType()
        {
            EmployeeId = employeeId,
            MaritalStatusId = 1
        };
    }
}

public class ComposeTypeConfiguration : EntityConfiguration<ComposeType>
{
    public override void Configure(EntityTypeBuilder<ComposeType> builder)
    {
        base.Configure(builder);
        builder.HasKey(e => new { e.EmployeeId, e.MaritalStatusId });

        builder.HasOne<Employee>()
            .WithMany()
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
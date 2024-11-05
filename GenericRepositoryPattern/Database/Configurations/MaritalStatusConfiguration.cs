using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GenericRepositoryPattern.Database.Configurations.Base;
using GenericRepositoryPattern.Entities;

namespace GenericRepositoryPattern.Database.Configurations;

public class MaritalStatusConfiguration : LookupEntityConfiguration<MaritalStatus>
{
    public override void Configure(EntityTypeBuilder<MaritalStatus> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasQueryFilter(e => e.Name == "Single");
    }
}

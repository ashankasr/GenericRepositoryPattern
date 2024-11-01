using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApi.Database.Configurations.Base;
using TestWebApi.Entities;

namespace TestWebApi.Database.Configurations;

public class MaritalStatusConfiguration : LookupEntityConfiguration<MaritalStatus>
{
    public override void Configure(EntityTypeBuilder<MaritalStatus> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}

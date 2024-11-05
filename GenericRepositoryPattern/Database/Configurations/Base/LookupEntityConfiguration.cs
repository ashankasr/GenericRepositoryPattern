using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GenericRepositoryPattern.Entities.Base;

namespace GenericRepositoryPattern.Database.Configurations.Base;

public class LookupEntityConfiguration<TEntity> : EntityConfiguration<TEntity, int> where TEntity : LookupEntity
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.IsDeleted).IsRequired().HasDefaultValue(false);

        builder.HasQueryFilter(e => !e.IsDeleted);
    }
}

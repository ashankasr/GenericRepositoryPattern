using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GenericRepositoryPattern.Entities.Base;

namespace GenericRepositoryPattern.Database.Configurations.Base;

public abstract class AuditableEntityConfiguration<TEntity> : EntityConfiguration<TEntity, Guid> where TEntity : AuditableEntity
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.CreatedDate).IsRequired();
        builder.Property(e => e.CreatedBy).IsRequired().HasColumnType("nvarchar(100)");
        builder.Property(e => e.ModifiedDate);
        builder.Property(e => e.ModifiedBy).HasColumnType("nvarchar(100)");
        builder.Property(e => e.IsDeleted).IsRequired().HasDefaultValue(false);

        builder.HasQueryFilter(e => !e.IsDeleted);
    }
}

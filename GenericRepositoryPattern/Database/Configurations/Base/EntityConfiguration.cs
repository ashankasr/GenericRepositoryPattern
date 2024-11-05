using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GenericRepositoryPattern.Entities.Base;

namespace GenericRepositoryPattern.Database.Configurations.Base;

public abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        // Set the table name
        builder.ToTable(typeof(TEntity).Name);
    }
}

public abstract class EntityConfiguration<TEntity, TId> : EntityConfiguration<TEntity>
    where TEntity : Entity<TId>
    where TId : struct
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);

        // Set the primary key
        builder.HasKey(e => e.Id);

        // PK column should be the 1st column in the table
        builder.Property(e => e.Id).HasColumnOrder(0);
    }
}
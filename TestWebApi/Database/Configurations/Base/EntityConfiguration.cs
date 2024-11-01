using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApi.Entities.Base;

namespace TestWebApi.Database.Configurations.Base;

public abstract class EntityConfiguration<TEntity, TId> : IEntityTypeConfiguration<TEntity>
    where TEntity : Entity<TId>
    where TId : struct
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        // Set the table name
        builder.ToTable(typeof(TEntity).Name);

        // Set the primary key
        builder.HasKey(e => e.Id);

        // PK column should be the 1st column in the table
        builder.Property(e => e.Id).HasColumnOrder(0);
    }
}
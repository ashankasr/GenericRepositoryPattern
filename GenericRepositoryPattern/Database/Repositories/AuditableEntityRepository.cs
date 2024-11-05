using GenericRepositoryPattern.Entities.Base;
using GenericRepositoryPattern.Entities.Repositories;

namespace GenericRepositoryPattern.Database.Repositories
{
    public class AuditableEntityRepository<T> : Repository<T, Guid>, IAuditableEntityRepository<T> where T : AuditableEntity
    {
        public AuditableEntityRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
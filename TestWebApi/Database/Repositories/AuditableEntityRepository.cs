using TestWebApi.Entities.Base;
using TestWebApi.Entities.Repositories;

namespace TestWebApi.Database.Repositories
{
    public class AuditableEntityRepository<T> : Repository<T, Guid>, IAuditableEntityRepository<T> where T : AuditableEntity
    {
        public AuditableEntityRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
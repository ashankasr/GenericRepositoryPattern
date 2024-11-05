using GenericRepositoryPattern.Entities.Base;
using GenericRepositoryPattern.Entities.Repositories;

namespace GenericRepositoryPattern.Database.Repositories
{
    public class LookupEntityRepository<T> : Repository<T, int>, ILookupEntityRepository<T> where T : LookupEntity
    {
        public LookupEntityRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
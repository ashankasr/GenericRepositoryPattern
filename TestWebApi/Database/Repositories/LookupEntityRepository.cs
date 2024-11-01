using TestWebApi.Entities.Base;
using TestWebApi.Entities.Repositories;

namespace TestWebApi.Database.Repositories
{
    public class LookupEntityRepository<T> : Repository<T, int>, ILookupEntityRepository<T> where T : LookupEntity
    {
        public LookupEntityRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
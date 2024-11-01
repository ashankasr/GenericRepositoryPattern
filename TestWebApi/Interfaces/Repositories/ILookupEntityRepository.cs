using TestWebApi.Entities.Base;

namespace TestWebApi.Entities.Repositories
{
    public interface ILookupEntityRepository<T> : IRepository<T> where T : LookupEntity
    {
    }
}
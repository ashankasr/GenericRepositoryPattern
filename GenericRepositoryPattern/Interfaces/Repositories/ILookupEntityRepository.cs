using GenericRepositoryPattern.Entities.Base;

namespace GenericRepositoryPattern.Entities.Repositories
{
    public interface ILookupEntityRepository<T> : IRepository<T> where T : LookupEntity
    {
    }
}
using GenericRepositoryPattern.Entities.Base;

namespace GenericRepositoryPattern.Entities.Repositories
{
    public interface IAuditableEntityRepository<T> : IRepository<T, Guid> where T : AuditableEntity
    {
    }
}
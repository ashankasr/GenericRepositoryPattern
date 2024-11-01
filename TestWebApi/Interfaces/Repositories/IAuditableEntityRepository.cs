using TestWebApi.Entities.Base;

namespace TestWebApi.Entities.Repositories
{
    public interface IAuditableEntityRepository<T> : IRepository<T, Guid> where T : AuditableEntity
    {
    }
}
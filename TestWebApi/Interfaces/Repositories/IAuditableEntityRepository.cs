using TestWebApi.Entities.Base;

namespace TestWebApi.Entities.Repositories
{
    public interface IAuditableEntityRepository<T> : IRepository<T> where T : AuditableEntity
    {
    }
}
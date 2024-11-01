using System.Linq.Expressions;
using TestWebApi.Entities.Base;

namespace TestWebApi.Entities.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        // Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
    }

    public interface IRepository<T, TId> : IRepository<T> where T : Entity<TId> where TId : struct
    {
        Task<T> GetByIdAsync(TId id);
    }
}
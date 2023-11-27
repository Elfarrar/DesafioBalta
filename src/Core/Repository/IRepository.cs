using Model;
using System.Linq.Expressions;

namespace Repository
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task<IEnumerable<T>> Get(bool track = true, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate, bool track = true, CancellationToken cancellationToken = default);
        Task<T?> GetById(Guid id, bool track = true, CancellationToken cancellationToken = default);
        Task<T> Create(T entity, CancellationToken cancellationToken = default);
        Task<T> Update(T entity, CancellationToken cancellationToken = default);
        Task<T> Delete(T entity, CancellationToken cancellationToken = default);
    }
}

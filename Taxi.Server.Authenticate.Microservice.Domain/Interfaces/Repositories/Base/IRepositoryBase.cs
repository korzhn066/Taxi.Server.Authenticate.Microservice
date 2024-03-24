using System.Linq.Expressions;

namespace Taxi.Server.Authenticate.Microservice.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<T?> GetFirstAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);

        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        void Delete(T entity);
        Task SaveChangesAsync();
    }
}

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Taxi.Server.Authenticate.Microservice.Domain.Interfaces.Repositories.Base;
using Taxi.Server.Authenticate.Microservice.Infrastructure.Data;

namespace Taxi.Server.Authenticate.Microservice.Infrastructure.Repositories.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DBContext Context { get; set; }
        public RepositoryBase(DBContext context)
        {
            Context = context;
        }

        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await Context.Set<T>().FindAsync(id, cancellationToken);

            return entity;
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await Context.Set<T>().AddAsync(entity, cancellationToken);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public async Task<T?> GetFirstAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            var entity = await Context.Set<T>().FirstOrDefaultAsync(expression, cancellationToken);

            return entity;
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}

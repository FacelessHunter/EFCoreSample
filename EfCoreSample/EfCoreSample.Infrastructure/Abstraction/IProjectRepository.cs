using EfCoreSample.Doman.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreSample.Infrastructure.Abstraction
{
    public interface IProjectRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        TEntity Find(long key);
        Task<TEntity> FindAsync(TKey key);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetProjects(long key);
        Task<TEntity> InsertAsync(TEntity item);
        bool IsExist(TKey key);
        Task<bool> IsExistAsync(TKey key);
        TEntity Update(TEntity item);
        bool Remove(TEntity item);
        bool Remove(TKey key);
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bartdebever.Patterns.Models;

namespace Bartdebever.Patterns.Repositories
{
    public interface IRepository<TEntity, TKey>
    where TEntity : IEntity<TKey>
    {
        TEntity Find(Expression<Func<TEntity, bool>> query);

        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> query);

        IEnumerable<TEntity> FindRange(Expression<Func<TEntity, bool>> query);

        Task<List<TEntity>> FindRangeAsync(Expression<Func<TEntity, bool>> query);

        IEnumerable<TEntity> GetAll();

        Task<List<TEntity>> GetAllAsync();

        TEntity GetById(TKey id);

        Task<TEntity> GetByIdAsync(TKey id);

        TEntity Add(TEntity entity);
#if NETSTANDARD
        Task<TEntity> AddAsync(TEntity entity);

        TEntity Update(TEntity entity);
#endif
        void Remove(TEntity entity);
    }
}

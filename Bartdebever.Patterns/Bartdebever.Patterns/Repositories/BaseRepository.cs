using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bartdebever.Patterns.Models;
#if NETSTANDARD
using Microsoft.EntityFrameworkCore;
#endif
#if NETFULL
using System.Data.Entity;
#endif

namespace Bartdebever.Patterns.Repositories
{
    /// <summary>
    /// Base repository to be inherited when using the <see cref="IEntity{TKey}"/> and
    /// not the <see cref="BaseEntity"/> as the class of choice.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The entity to be used in the 
    /// <see cref="Queryable"/> of this repository.
    /// </typeparam>
    /// <typeparam name="TKey">
    /// The type of key used in the <see cref="GetById"/> functions.
    /// </typeparam>
    public abstract class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        private readonly DbSet<TEntity> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TEntity,TKey}"/> class.
        /// </summary>
        /// <param name="context">
        /// The context to be used in the <see cref="Queryable"/> and other functions.
        /// </param>
        public BaseRepository(DbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        /// <inheritdoc />
        public virtual TEntity Find(Expression<Func<TEntity, bool>> query)
        {

            return _dbSet.Where(query).FirstOrDefault();
        }

        /// <inheritdoc />
        public virtual Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> query)
        {
            return _dbSet.Where(query).FirstOrDefaultAsync();
        }

        /// <inheritdoc />
        public virtual IEnumerable<TEntity> FindRange(Expression<Func<TEntity, bool>> query)
        {
            return _dbSet.Where(query).ToList();
        }

        /// <inheritdoc />
        public virtual Task<List<TEntity>> FindRangeAsync(Expression<Func<TEntity, bool>> query)
        {
            return _dbSet.Where(query).ToListAsync();
        }

        /// <inheritdoc />
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        /// <inheritdoc />
        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }

        /// <inheritdoc />
        public virtual TEntity GetById(TKey id)
        {
            return _dbSet.FirstOrDefault(entity => entity.Id.Equals(id));
        }

        /// <inheritdoc />
        public virtual Task<TEntity> GetByIdAsync(TKey id)
        {
            return _dbSet.FirstOrDefaultAsync(entity => entity.Id.Equals(id));
        }

        /// <inheritdoc />
        public virtual TEntity Add(TEntity entity)
        {
#if NETSTANDARD
            return _dbSet.Add(entity).Entity;
#elif NETFULL
            return _dbSet.Add(entity);
#endif
        }
#if NETSTANDARD
        /// <inheritdoc />
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {

            var result = await _dbSet.AddAsync(entity);
            return result.Entity;
        }

        /// <inheritdoc />
        public virtual TEntity Update(TEntity entity)
        {
            return _dbSet.Update(entity).Entity;
        }
#endif
        /// <inheritdoc />
        public virtual void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        protected IQueryable<TEntity> Queryable => _dbSet.AsQueryable();
    }
}

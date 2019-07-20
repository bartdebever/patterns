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
    public abstract class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
#if NETSTANDARD
        private readonly DbSet<TEntity> _dbSet;
        
        public BaseRepository(DbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }
#elif NETFULL
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }
#endif


        public virtual TEntity Find(Expression<Func<TEntity, bool>> query)
        {

            return _dbSet.Where(query).FirstOrDefault();
        }

        public virtual Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> query)
        {
            return _dbSet.Where(query).FirstOrDefaultAsync();
        }

        public virtual IEnumerable<TEntity> FindRange(Expression<Func<TEntity, bool>> query)
        {
            return _dbSet.Where(query).ToList();
        }

        public virtual Task<List<TEntity>> FindRangeAsync(Expression<Func<TEntity, bool>> query)
        {
            return _dbSet.Where(query).ToListAsync();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }

        public virtual TEntity GetById(TKey id)
        {
            return _dbSet.FirstOrDefault(entity => entity.Id.Equals(id));
        }

        public virtual Task<TEntity> GetByIdAsync(TKey id)
        {
            return _dbSet.FirstOrDefaultAsync(entity => entity.Id.Equals(id));
        }

        public virtual TEntity Add(TEntity entity)
        {
#if NETSTANDARD
            return _dbSet.Add(entity).Entity;
#elif NETFULL
            return _dbSet.Add(entity);
#endif
        }
#if NETSTANDARD
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {

            var result = await _dbSet.AddAsync(entity);
            return result.Entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            return _dbSet.Update(entity).Entity;
        }
#endif
        public virtual void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        protected IQueryable<TEntity> Queryable => _dbSet.AsQueryable();
    }
}

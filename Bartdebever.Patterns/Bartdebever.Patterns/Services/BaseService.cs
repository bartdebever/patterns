using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bartdebever.Patterns.Models;
using Bartdebever.Patterns.Repositories;

namespace Bartdebever.Patterns.Services
{
    public abstract class BaseService<TEntity, TKey, TRepository> : IService<TEntity, TKey, TRepository>
        where TEntity : class, IEntity<TKey>
        where TRepository : IRepository<TEntity, TKey>
    {
        protected readonly TRepository Repository;

        public BaseService(TRepository repository)
        {
            Repository = repository;
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> query)
        {
            return Repository.Find(query);
        }

        public virtual Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> query)
        {
            return Repository.FindAsync(query);
        }

        public virtual IEnumerable<TEntity> FindRange(Expression<Func<TEntity, bool>> query)
        {
            return Repository.FindRange(query);
        }

        public virtual Task<List<TEntity>> FindRangeAsync(Expression<Func<TEntity, bool>> query)
        {
            return Repository.FindRangeAsync(query);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Repository.GetAll();
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return Repository.GetAllAsync();
        }

        public virtual TEntity GetById(TKey id)
        {
            return Repository.GetById(id);
        }

        public virtual Task<TEntity> GetByIdAsync(TKey id)
        {
            return Repository.GetByIdAsync(id);
        }

        public virtual TEntity Add(TEntity entity)
        {
            return Repository.Add(entity);
        }
#if NETSTANDARD
        public virtual Task<TEntity> AddAsync(TEntity entity)
        {
            return Repository.AddAsync(entity);
        }

        public virtual TEntity Update(TEntity entity)
        {
            return Repository.Update(entity);
        }
#endif
        public virtual void Remove(TEntity entity)
        {
            Repository.Remove(entity);
        }
    }
}

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

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService{TEntity,TKey,TRepository}"/> class.
        /// </summary>
        /// <param name="repository">The repository used to do calls.</param>
        public BaseService(TRepository repository)
        {
            Repository = repository;
        }

        /// <inheritdoc />
        public virtual TEntity Find(Expression<Func<TEntity, bool>> query)
        {
            return Repository.Find(query);
        }

        /// <inheritdoc />
        public virtual Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> query)
        {
            return Repository.FindAsync(query);
        }

        /// <inheritdoc />
        public virtual IEnumerable<TEntity> FindRange(Expression<Func<TEntity, bool>> query)
        {
            return Repository.FindRange(query);
        }

        /// <inheritdoc />
        public virtual Task<List<TEntity>> FindRangeAsync(Expression<Func<TEntity, bool>> query)
        {
            return Repository.FindRangeAsync(query);
        }

        /// <inheritdoc />
        public virtual IEnumerable<TEntity> GetAll()
        {
            return Repository.GetAll();
        }

        /// <inheritdoc />
        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return Repository.GetAllAsync();
        }

        /// <inheritdoc />
        public virtual TEntity GetById(TKey id)
        {
            return Repository.GetById(id);
        }

        /// <inheritdoc />
        public virtual Task<TEntity> GetByIdAsync(TKey id)
        {
            return Repository.GetByIdAsync(id);
        }

        /// <inheritdoc />
        public virtual TEntity Add(TEntity entity)
        {
            return Repository.Add(entity);
        }

#if NETSTANDARD
        /// <inheritdoc />
        public virtual Task<TEntity> AddAsync(TEntity entity)
        {
            return Repository.AddAsync(entity);
        }

        /// <inheritdoc />
        public virtual TEntity Update(TEntity entity)
        {
            return Repository.Update(entity);
        }
#endif

        /// <inheritdoc />
        public virtual void Remove(TEntity entity)
        {
            Repository.Remove(entity);
        }
    }
}

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
        protected readonly TRepository _repository;

        public BaseService(TRepository repository)
        {
            _repository = repository;
        }

        public TEntity Find(Expression<Func<TEntity, bool>> query)
        {
            return _repository.Find(query);
        }

        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> query)
        {
            return _repository.FindAsync(query);
        }

        public IEnumerable<TEntity> FindRange(Expression<Func<TEntity, bool>> query)
        {
            return _repository.FindRange(query);
        }

        public Task<List<TEntity>> FindRangeAsync(Expression<Func<TEntity, bool>> query)
        {
            return _repository.FindRangeAsync(query);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public TEntity GetById(TKey id)
        {
            return _repository.GetById(id);
        }

        public Task<TEntity> GetByIdAsync(TKey id)
        {
            return _repository.GetByIdAsync(id);
        }

        public TEntity Add(TEntity entity)
        {
            return _repository.Add(entity);
        }
#if NETSTANDARD
        public Task<TEntity> AddAsync(TEntity entity)
        {
            return _repository.AddAsync(entity);
        }

        public TEntity Update(TEntity entity)
        {
            return _repository.Update(entity);
        }
#endif
        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
        }
    }
}

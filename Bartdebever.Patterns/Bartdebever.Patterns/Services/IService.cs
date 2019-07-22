using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bartdebever.Patterns.Models;
using Bartdebever.Patterns.Repositories;

namespace Bartdebever.Patterns.Services
{
    public interface IService<TEntity, TKey, TRepository>
        where TEntity : class, IEntity<TKey>
        where TRepository : IRepository<TEntity, TKey>
    {
        /// <summary>
        /// Finds the first <typeparamref name="TEntity"/> based on the given
        /// <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The query to search the repository with.</param>
        /// <returns>The first <typeparamref name="TEntity"/> found or null.</returns>
        TEntity Find(Expression<Func<TEntity, bool>> query);

        /// <summary>
        /// Asynchronously finds the first <typeparamref name="TEntity"/>
        /// based on the given <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The query to search the repository for.</param>
        /// <returns>The first <typeparamref name="TEntity"/> found or null.</returns>
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> query);

        /// <summary>
        /// Finds all <typeparamref name="TEntity"/> for the given <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The query to search the repository with.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> objects found.</returns>
        IEnumerable<TEntity> FindRange(Expression<Func<TEntity, bool>> query);

        /// <summary>
        /// Asynchronously finds all <typeparamref name="TEntity"/> for the
        /// given <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The query to search the repository with.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> objects found.</returns>
        Task<List<TEntity>> FindRangeAsync(Expression<Func<TEntity, bool>> query);

        /// <summary>
        /// Gets all <typeparamref name="TEntity"/> from the <typeparamref name="TRepository"/>.
        /// </summary>
        /// <returns>A list of <typeparamref name="TEntity"/></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Asynchronously gets all <typeparamref name="TEntity"/> from
        /// the <typeparamref name="TRepository"/>.
        /// </summary>
        /// <returns>A list of <typeparamref name="TEntity"/></returns>
        Task<List<TEntity>> GetAllAsync();

        /// <summary>
        /// Gets the first <typeparamref name="TEntity"/> with the <see cref="IEntity{TKey}.Id"/>
        /// that is equal to <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id to be searched for.</param>
        /// <returns>An <typeparamref name="TEntity"/> instance or null.</returns>
        TEntity GetById(TKey id);


        /// <summary>
        /// Asynchronously gets the first <typeparamref name="TEntity"/> with
        /// the <see cref="IEntity{TKey}.Id"/>
        /// that is equal to <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id to be searched for.</param>
        /// <returns>An <typeparamref name="TEntity"/> instance or null.</returns>
        Task<TEntity> GetByIdAsync(TKey id);

        /// <summary>
        /// Adds the entity to the <typeparamref name="TRepository"/>.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/> to be saved.</param>
        /// <returns>The added version of the <paramref name="entity"/>.</returns>
        TEntity Add(TEntity entity);
#if NETSTANDARD

        /// <summary>
        /// Asynchronously adds the entity to the <typeparamref name="TRepository"/>.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/> to be saved.</param>
        /// <returns>The added version of the <paramref name="entity"/>.</returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Updates the entity with the new values in the <typeparamref name="TRepository"/>.
        /// Note that the <see cref="IEntity{TKey}.Id"/> needs to be filled
        /// for this to be executed.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        /// <returns>The updated entity.</returns>
        TEntity Update(TEntity entity);
#endif
        /// <summary>
        /// Removes the entity from the <typeparamref name="TRepository"/>.
        /// </summary>
        /// <param name="entity">The entity to be removed.</param>
        void Remove(TEntity entity);
    }
}

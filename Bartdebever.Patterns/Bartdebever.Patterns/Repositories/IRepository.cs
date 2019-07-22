using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
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
    public interface IRepository<TEntity, in TKey>
    where TEntity : IEntity<TKey>
    {
        /// <summary>
        /// Finds the first entity for the given <paramref name="query"/>.
        /// </summary>
        /// <param name="query">
        /// The query which will be executed on the underlying dataset.
        /// </param>
        /// <returns>The first entity found or null.</returns>
        TEntity Find(Expression<Func<TEntity, bool>> query);

        /// <summary>
        /// Asynchronously finds the first entity for the given <paramref name="query"/>.
        /// </summary>
        /// <param name="query">
        /// The query which will be executed on the underlying dataset.
        /// </param>
        /// <returns>The first entity found or null.</returns>
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> query);

        /// <summary>
        /// Finds a range of entities for the given <paramref name="query"/>.
        /// </summary>
        /// <param name="query">
        /// The query which will be executed on the underlying dataset.
        /// </param>
        /// <returns>The first entity found or null.</returns>
        IEnumerable<TEntity> FindRange(Expression<Func<TEntity, bool>> query);

        /// <summary>
        /// Asynchronously finds the first entity for the given <paramref name="query"/>.
        /// </summary>
        /// <param name="query">
        /// The query which will be executed on the underlying dataset.
        /// </param>
        /// <returns>The first entity found or null.</returns>
        Task<List<TEntity>> FindRangeAsync(Expression<Func<TEntity, bool>> query);

        /// <summary>
        /// Gets all entities stored in the dataset.
        /// </summary>
        /// <returns>
        /// An list of entities of the <typeparamref name="TEntity"/> type.
        /// </returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Gets all entities stored in the dataset asynchronously.
        /// </summary>
        /// <returns>
        /// An list of entities of the <typeparamref name="TEntity"/> type.
        /// </returns>
        Task<List<TEntity>> GetAllAsync();

        /// <summary>
        /// Gets the first entity by the given <paramref name="id"/>.
        /// </summary>
        /// <param name="id">
        /// The id wanting to be searched for.
        /// </param>
        /// <returns>The first entity found or <see langword="null"/>.</returns>
        TEntity GetById(TKey id);

        /// <summary>
        /// Gets the first entity by the given <paramref name="id"/> asynchronously.
        /// </summary>
        /// <param name="id">
        /// The id wanting to be searched for.
        /// </param>
        /// <returns>The first entity found or <see langword="null"/>.</returns>
        Task<TEntity> GetByIdAsync(TKey id);

        /// <summary>
        /// Adds an entity to the change tracking.
        /// Will be saved to the underlying dataset when the next <see cref="DbContext.SaveChanges"/>
        /// gets called.
        /// </summary>
        /// <param name="entity">
        /// The entity to be added to the underlying dataset.
        /// </param>
        /// <returns>The entity which is now being tracked.</returns>
        TEntity Add(TEntity entity);
#if NETSTANDARD
        /// <summary>
        /// Asynchronously adds an entity to the change tracking.
        /// Will be saved to the underlying dataset when the next <see cref="DbContext.SaveChanges"/>
        /// gets called.
        /// </summary>
        /// <param name="entity">
        /// The entity to be added to the underlying dataset.
        /// </param>
        /// <returns>The entity which is now being tracked.</returns>
        Task<TEntity> AddAsync(TEntity entity);

        TEntity Update(TEntity entity);
#endif

        /// <summary>
        /// Removes an entity from the underlying dataset.
        /// </summary>
        /// <param name="entity">
        /// The entity to be removed.
        /// </param>
        void Remove(TEntity entity);
    }
}

using Bartdebever.Patterns.Models;
#if NETSTANDARD
using Microsoft.EntityFrameworkCore;
#endif
#if NETFULL
using System.Data.Entity;
#endif

namespace Bartdebever.Patterns.Repositories
{
    public abstract class EntityRepository<TEntity> : BaseRepository<TEntity, long>
        where TEntity : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">
        /// The database context to be used to gather entities.
        /// </param>
        public EntityRepository(DbContext context) : base(context)
        {
        }
    }
}

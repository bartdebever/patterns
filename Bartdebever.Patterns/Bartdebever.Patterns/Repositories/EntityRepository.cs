using System;
using System.Collections.Generic;
using System.Linq;
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
    public abstract class EntityRepository<TEntity> : BaseRepository<TEntity, long>
        where TEntity : BaseEntity
    {
        public EntityRepository(DbContext context) : base(context)
        {
        }
    }
}

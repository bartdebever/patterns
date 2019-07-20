using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bartdebever.Patterns.Models;
using Bartdebever.Patterns.Repositories;

namespace Bartdebever.Patterns.Services
{
    public abstract class EntityService<TEntity, TRepository> : BaseService<TEntity, long, TRepository>
        where TEntity : BaseEntity
        where TRepository : IRepository<TEntity, long>
    {
        protected EntityService(TRepository repository) : base(repository)
        {
        }
    }
}

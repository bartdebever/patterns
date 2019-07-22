using System.ComponentModel.DataAnnotations;

namespace Bartdebever.Patterns.Models
{
    public class BaseEntity : IEntity<long>
    {
        /// <inheritdoc cref="IEntity{TKey}.Id"/>
        [Key]
        public virtual long Id { get; set; }
    }
}

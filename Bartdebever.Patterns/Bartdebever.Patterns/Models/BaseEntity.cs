using System.ComponentModel.DataAnnotations;

namespace Bartdebever.Patterns.Models
{
    public class BaseEntity : IEntity<long>
    {
        [Key]
        public virtual long Id { get; set; }
    }
}

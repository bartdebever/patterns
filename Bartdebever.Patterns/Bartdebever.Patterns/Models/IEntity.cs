using System;
using System.Collections.Generic;
using System.Text;

namespace Bartdebever.Patterns.Models
{
    public interface IEntity <TKey>
    {
        TKey Id { get; set; }
    }
}

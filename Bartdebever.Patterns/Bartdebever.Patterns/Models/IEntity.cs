using System;
using System.Collections.Generic;
using System.Text;

namespace Bartdebever.Patterns.Models
{
    /// <summary>
    /// An interface to implement the basic entity to be
    /// stored in the database.
    /// </summary>
    /// <typeparam name="TKey">
    /// The type which the <see cref="Id"/> should have.
    /// </typeparam>
    public interface IEntity <TKey>
    {
        /// <summary>
        /// The identifier for the entity.
        /// Should be unique.
        /// </summary>
        TKey Id { get; set; }
    }
}

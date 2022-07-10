using SeedWork.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Domain.Aggregates.NoteAggregate.ValueObject
{
    /// <summary>
    ///  Represents Notes App Note Tags. Value Object
    /// </summary>
    public record Tag
    {
        /// <summary>
        /// Represents Tag Id. Normally it is not required. Ef Core OwnsMany doent require but App uses Caching. 
        /// </summary>
        public Guid Id { get; private set; }
        /// <summary>
        /// Represents Tag Name
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Consructor
        /// </summary>
        /// <param name="name">Represents Tag name.</param>
        public Tag(string name)
        {
            Id = Guid.NewGuid();
            SetName(name);
        }
        /// <summary>
        /// Setter method for Tag name
        /// </summary>
        /// <param name="name">Represents Tag name.</param>
        /// <exception cref="AttributeNotValidException"></exception>
        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new AttributeNotValidException($"{nameof(name)} can not be null or empty");
            Name = name;
        }
    }
}

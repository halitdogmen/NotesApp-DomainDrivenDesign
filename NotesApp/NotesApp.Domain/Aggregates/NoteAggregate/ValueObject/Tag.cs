using SeedWork.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Domain.Aggregates.NoteAggregate.ValueObject
{
    public record Tag
    {
        // For caching
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Tag(string name)
        {
            Id = Guid.NewGuid();
            SetName(name);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new AttributeNotValidException($"{nameof(name)} can not be null or empty");
            Name = name;
        }
    }
}

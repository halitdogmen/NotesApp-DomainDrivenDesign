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
        public string Name { get; private set; }

        public Tag(string name)
        {
            SetName(name);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new AttributeNotValidException($"{nameof(name)} can not be null or empty");
            Name = name;
        }
    }
}

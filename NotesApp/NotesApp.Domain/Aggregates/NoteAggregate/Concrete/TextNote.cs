using NotesApp.Domain.Aggregates.NoteAggregate.Abstract;
using NotesApp.Domain.Aggregates.NoteAggregate.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Domain.Aggregates.NoteAggregate.Concrete
{
    public class TextNote : Note
    {
        private TextNote() { /* For EFCore*/}
        public TextNote(string title, string description) : base(title, description) { }

        public TextNote(string title, string description, List<Tag> tags) : base(title, description,tags) { }

    }
}

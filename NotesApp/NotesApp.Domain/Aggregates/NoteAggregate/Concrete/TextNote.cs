using NotesApp.Domain.Aggregates.NoteAggregate.Abstract;
using NotesApp.Domain.Aggregates.NoteAggregate.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Domain.Aggregates.NoteAggregate.Concrete
{
    /// <summary>
    ///  Represents Notes Application Text Note.
    /// </summary>
    public class TextNote : Note
    {
        /// <summary>
        /// Consructor For EfCore
        /// </summary>
        private TextNote() { /* For EFCore*/}
        /// <summary>
        /// Consructor.
        /// </summary>
        /// <param name="title">Represents TextNote Title. Cannot be empty or null</param>
        /// <param name="description">Represents TextNote Description. Cannot be empty or null. </param>
        /// <param name="accountId">Represents Account(Owner). Cannot be empty ornull.</param>
        public TextNote(string title, string description, Guid accountId) : base(title, description, accountId) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title">Represents TextNote Title. Cannot be empty or null</param>
        /// <param name="description">Represents TextNote Description. Cannot be empty or null. </param>
        /// <param name="tags">Represents Text Note Tags.</param>
        /// <param name="accountId">Represents Account(Owner). Cannot be empty ornull.</param>
        public TextNote(string title, string description, List<Tag> tags, Guid accountId) : base(title, description,tags, accountId) { }

    }
}

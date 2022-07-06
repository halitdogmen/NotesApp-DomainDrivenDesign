using NotesApp.Domain.Aggregates.NoteAggregate.ValueObject;
using SeedWork.Domain.Exceptions;
using SeedWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Domain.Aggregates.NoteAggregate.Abstract
{
    public abstract class Note:BaseModel
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public List<Tag> Tags { get; private set; }
        public Guid AccountId { get; private set; }

        protected Note() { /* For EFCore */}

        public Note(string title, string description, Guid accountId) 
        {
            SetTitle(title);
            SetTitle(description);
            Tags = new List<Tag>();
            AccountId = accountId;
        }
        public Note(string title, string description, List<Tag> tags, Guid accountId)
        {
            SetTitle(title);
            SetTitle(description);
            Tags = tags;
            AccountId = accountId;
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrEmpty(title)) throw new AttributeNotValidException(nameof(title));
            Title = title;
        }
        public void SetDescription(string description)
        {
            if(string.IsNullOrEmpty(description)) throw new AttributeNotValidException(nameof(description));
            Description = description;
        }
    }
}

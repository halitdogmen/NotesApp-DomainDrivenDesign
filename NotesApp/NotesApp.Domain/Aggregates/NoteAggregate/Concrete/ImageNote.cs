using NotesApp.Domain.Aggregates.NoteAggregate.Abstract;
using NotesApp.Domain.Aggregates.NoteAggregate.ValueObject;
using SeedWork.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Domain.Aggregates.NoteAggregate.Concrete
{
    public class ImageNote: Note
    {
        public string ImageUrl { get; private set; }

        public ImageNote(string title, string description, string imageUrl, Guid accountId) :base(title,description,accountId) 
        {
            SetImageUrl(imageUrl);
        }
        public ImageNote(string title, string description, string imageUrl, List<Tag> tags, Guid accountId) : base(title, description,tags,accountId)
        {
            SetImageUrl(imageUrl);
        }

        public void SetImageUrl(string imageUrl)
        {
            if (!Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute)) throw new AttributeNotValidException($"{nameof(imageUrl)} can not be null or empty");
            ImageUrl = imageUrl;
        }
    }
}

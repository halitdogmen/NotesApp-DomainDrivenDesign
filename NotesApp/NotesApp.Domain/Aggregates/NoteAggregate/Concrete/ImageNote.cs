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

        public ImageNote(string title, string description, string imageUrl):base(title,description) 
        {
            SetImageUrl(imageUrl);
        }
        public ImageNote(string title, string description, string imageUrl, List<Tag> tags) : base(title, description,tags)
        {
            SetImageUrl(imageUrl);
        }

        public void SetImageUrl(string imageUrl)
        {
            if (!Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute)) throw new AttributeNotValidException(nameof(imageUrl));
            ImageUrl = imageUrl;
        }
    }
}

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
    /// <summary>
    /// Represents Notes Application Note with image
    /// </summary>
    public class ImageNote: Note
    {
        /// <summary>
        ///  Image url. Must be valid url. Ex: http://www.example.com/image_url.png
        /// </summary>
        public string ImageUrl { get; private set; }
        /// <summary>
        /// Consructor
        /// </summary>
        /// <param name="title"> Represents ImageNote Title. Cannot be empty or null</param>
        /// <param name="description">Represents ImageNote Description. Cannot be empty or null</param>
        /// <param name="imageUrl">Represent ImageNote Image Url. It must be Valid. Ex: http://www.example.com/image_url.png</param>
        /// <param name="accountId">REpresents ImageNote Account(Owner). Cannot be empty or null</param>
        public ImageNote(string title, string description, string imageUrl, Guid accountId) :base(title,description,accountId) 
        {
            SetImageUrl(imageUrl);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"> Represents ImageNote Title. Cannot be empty or null</param>
        /// <param name="description">Represents ImageNote Description. Cannot be empty or null</param>
        /// <param name="imageUrl">Represent ImageNote Image Url. It must be Valid. Ex: http://www.example.com/image_url.png</param>
        /// <param name="tags">Represents Image Note Tags.</param>
        /// <param name="accountId">REpresents ImageNote Account(Owner). Cannot be empty or null</param>
        public ImageNote(string title, string description, string imageUrl, List<Tag> tags, Guid accountId) : base(title, description,tags,accountId)
        {
            SetImageUrl(imageUrl);
        }
        /// <summary>
        ///  Consructor For EfCore.
        /// </summary>
        private ImageNote() { }
        /// <summary>
        /// Setter method for Imaga Note ImangeUrl. 
        /// </summary>
        /// <param name="imageUrl">Must be valid url. Ex: http://www.example.com/image_url.png</param>
        /// <exception cref="AttributeNotValidException"></exception>
        public void SetImageUrl(string imageUrl)
        {
            if (!Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute)) throw new AttributeNotValidException($"{nameof(imageUrl)} is not valid");
            ImageUrl = imageUrl;
        }
    }
}

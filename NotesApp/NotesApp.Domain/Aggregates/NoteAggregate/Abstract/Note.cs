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
    /// <summary>
    /// Represents Base Note For Notes Application
    /// </summary>
    public abstract class Note:BaseModel
    {
        /// <summary>
        ///  Represents Note Title.
        /// </summary>
        public string Title { get; private set; }
        /// <summary>
        /// Represents Note Description.
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// Represents Notes Tags. 
        /// </summary>
        public List<Tag> Tags { get; private set; }
        /// <summary>
        ///  Represents Account Id.
        /// </summary>
        public Guid AccountId { get; private set; }
        /// <summary>
        ///  base empty constructor. Required For EfCore
        /// </summary>
        protected Note() { /* For EFCore */}
        /// <summary>
        /// Base Note Consructor.
        /// </summary>
        /// <param name="title">Represents Note Title. Cannot be null or empty.</param>
        /// <param name="description"> Represents Note Description. Cannot be null or empty.</param>
        /// <param name="accountId">Represents Account Id.</param>
        public Note(string title, string description, Guid accountId) 
        {
            SetTitle(title);
            SetDescription(description);
            Tags = new List<Tag>();
            AccountId = accountId;
        }
        /// <summary>
        /// Base Note Consructor.
        /// </summary>
        /// <param name="title">Represents Note Title. Cannot be null or empty.</param>
        /// <param name="description"> Represents Note Description. Cannot be null or empty.</param>
        /// <param name="accountId">Represents Account Id.</param>
        /// <param name="tags">Represents Tags.</param>
        public Note(string title, string description, List<Tag> tags, Guid accountId)
        {
            SetTitle(title);
            SetDescription(description);
            Tags = tags;
            AccountId = accountId;
        }
        /// <summary>
        /// Setter method for Title.
        /// </summary>
        /// <param name="title">Represents Note Title</param>
        /// <exception cref="AttributeNotValidException"></exception>
        public void SetTitle(string title)
        {
            if (string.IsNullOrEmpty(title)) throw new AttributeNotValidException($"{nameof(title)} can not be null or empty");
            Title = title;
        }
        /// <summary>
        /// Setter method for Description.
        /// </summary>
        /// <param name="description">Represents Notes Description.</param>
        /// <exception cref="AttributeNotValidException"></exception>
        public void SetDescription(string description)
        {
            if(string.IsNullOrEmpty(description)) throw new AttributeNotValidException($"{nameof(description)} can not be null or empty");
            Description = description;
        }
        /// <summary>
        ///  Adds tag to Note.
        /// </summary>
        /// <param name="tag">Note Tag object.</param>
        public void AddTag(Tag tag)
        {
            Tags.Add(tag);
        }
        /// <summary>
        ///  deletes specific tag by tag.
        /// </summary>
        /// <param name="tag">Represents  to be deleted Note Tag.</param>
        public void DeleteTag(Tag tag)
        {
            Tags.Remove(tag);
        }
    }
}

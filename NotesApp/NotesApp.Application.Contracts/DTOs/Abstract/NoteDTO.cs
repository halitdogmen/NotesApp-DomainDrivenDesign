using NotesApp.Domain.Aggregates.NoteAggregate.Concrete;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.DTOs.Abstract
{
    /// <summary>
    /// Represents Note Data Transfer Object.
    /// </summary>
    [SwaggerSubType(typeof(TextNote))]
    [SwaggerSubType(typeof(ImageNote))]
    public abstract class NoteDTO
    {
        /// <summary>
        /// Note Unique Identifier.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Note Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Note Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Note Tags
        /// </summary>
        public List<string> Tags { get; set; }
        /// <summary>
        /// Note Account Unique Identifier
        /// </summary>
        public Guid AccountId { get; set; }
        /// <summary>
        /// Object Type.
        /// </summary>
        public string Type { get; set; }
    }
}

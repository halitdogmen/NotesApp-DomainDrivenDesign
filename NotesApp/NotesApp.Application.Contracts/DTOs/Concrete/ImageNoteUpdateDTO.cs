using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.DTOs.Concrete
{
    /// <summary>
    /// Represents Image Note Update Data Transfer Object. It is used for updating Image Note.
    /// </summary>
    public class ImageNoteUpdateDTO
    {
        /// <summary>
        /// Represents Image Note Title. Cannot be empty or null.
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// Represents Image Description. Cannot be empty or null.
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Represents Image Url. It must be valid.
        /// </summary>
        public string? ImageUrl { get; set; }
    }
}

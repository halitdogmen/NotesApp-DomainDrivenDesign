using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.DTOs.Concrete
{
    /// <summary>
    /// Represents Image Note Creation Data Tranfer Objects. It is used for creation
    /// </summary>
    public class ImageNoteCreationDTO
    {
        /// <summary>
        /// Note Title. Cannot be null or empty
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Note Description. Cannot be null or empty
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Note Image Url. Cannot be null or empty.
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// Note Tags. It's optinal.
        /// </summary>
        public List<string>? Tags { get; set; }
        /// <summary>
        /// Note Owner Id. Cannot be null or empty.
        /// </summary>
        public Guid AccountId { get; set; }
    }
}

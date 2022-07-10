using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.DTOs.Concrete
{
    /// <summary>
    /// Represents Text Note Creation Data Transfer Object. It is used for creation
    /// </summary>
    public class TextNoteCreationDTO
    {
        /// <summary>
        /// Represents Text Note Title. Cannot be empty or null.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Represents Text Note Description. Cannot be empty or null.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Represents Text Note Tag. It is optinal.
        /// </summary>
        public List<string>? Tags { get; set; }
        /// <summary>
        /// Represents Accout Unique Identifier. Cannot be null or empty.
        /// </summary>
        public Guid AccountId { get; set; }
    }
}

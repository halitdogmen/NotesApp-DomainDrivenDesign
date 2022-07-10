using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.DTOs.Concrete
{
    /// <summary>
    /// Represents Text Note Update Data Transfer Object. It is used for modifying.
    /// </summary>
    public class TextNoteUpdateDTO
    {
        /// <summary>
        /// Represents Text Note Title.
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// Represents Text Note Description.
        /// </summary>
        public string? Description { get; set; }
    }
}

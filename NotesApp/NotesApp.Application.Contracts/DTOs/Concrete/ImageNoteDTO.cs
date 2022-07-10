using NotesApp.Application.Contracts.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.DTOs.Concrete
{
    /// <summary>
    /// Represents Image Note Data Transfer object
    /// </summary>
    public class ImageNoteDTO:NoteDTO
    {
        /// <summary>
        /// ImageUrl. It must be valid. Ex: https://www.example.com/image_url.png
        /// </summary>
        public string ImageUrl { get; set; }
    }
}

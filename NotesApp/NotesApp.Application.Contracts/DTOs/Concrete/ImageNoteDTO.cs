using NotesApp.Application.Contracts.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.DTOs.Concrete
{
    public class ImageNoteDTO:NoteDTO
    {
        public string ImageUrl { get; set; }
    }
}

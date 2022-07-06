using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.DTOs.Concrete
{
    public class ImageNoteUpdateDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public List<string>? Tags { get; set; }
    }
}

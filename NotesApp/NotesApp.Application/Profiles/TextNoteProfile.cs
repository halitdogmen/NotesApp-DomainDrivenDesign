using AutoMapper;
using NotesApp.Application.Contracts.DTOs.Concrete;
using NotesApp.Domain.Aggregates.NoteAggregate.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Profiles
{
    public class TextNoteProfile : Profile
    {
        public TextNoteProfile()
        {
            CreateMap<TextNote, TextNoteDTO>();
        }
    }
}

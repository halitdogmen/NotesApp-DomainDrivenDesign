using AutoMapper;
using NotesApp.Application.Contracts.DTOs.Abstract;
using NotesApp.Domain.Aggregates.NoteAggregate.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Profiles
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<Note, NoteDTO>()
                .IncludeAllDerived()
                .ForMember(
                    dest => dest.Type,
                    opt => opt.MapFrom(x => x.GetType().Name)
                );
        }
    }
}

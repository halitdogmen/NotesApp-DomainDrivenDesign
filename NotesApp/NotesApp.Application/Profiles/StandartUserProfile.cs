using AutoMapper;
using NotesApp.Application.Contracts.DTOs.Concrete;
using NotesApp.Domain.Aggregates.AccountAggregate.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Profiles
{
    public class StandartUserProfile : Profile
    {
        public StandartUserProfile()
        {
            CreateMap<StandartUser, StandartUserDTO>();
        }
    }
}

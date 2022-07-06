using AutoMapper;
using NotesApp.Application.Contracts.DTOs.Abstract;
using NotesApp.Domain.Aggregates.AccountAggregate.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDTO>()
            .IncludeAllDerived()
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(x=>x.Email.Value)
                )
                .ForMember(
                    dest => dest.Type,
                    opt => opt.MapFrom(x => x.GetType().Name)
                );
        }
    }
}

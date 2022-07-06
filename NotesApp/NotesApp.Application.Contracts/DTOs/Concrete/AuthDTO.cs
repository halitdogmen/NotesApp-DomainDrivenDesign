using NotesApp.Application.Contracts.DTOs.Abstract;
using SeedWork.Application.Utils.JWT.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.DTOs.Concrete
{
    public class AuthDTO
    {
        public AccountDTO Account { get; set; }
        public AccessToken Token { get; set; }
    }
}

using NotesApp.Application.Contracts.DTOs.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.Services
{
    public interface IAuthenticationAppService
    {
        Task<AuthDTO> LoginAsync(LoginDTO loginDTO);
        Task<AuthDTO> RegisterStandartUserAsync(StandartUserRegisterDTO standartUserRegisterDTO);
    }
}

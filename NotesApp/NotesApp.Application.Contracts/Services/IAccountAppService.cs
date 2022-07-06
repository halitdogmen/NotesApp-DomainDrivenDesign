using NotesApp.Application.Contracts.DTOs.Abstract;
using NotesApp.Application.Contracts.DTOs.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.Services
{
    public interface IAccountAppService
    {
        Task<List<AccountDTO>> GetAllAsync(ClaimsPrincipal claimsPrincipal, int limit, int offset);
        Task<AccountDTO> GetByIdAsync(ClaimsPrincipal claimsPrincipal, Guid id);
        Task<AccountDTO> UpdateAsync(ClaimsPrincipal claimsPrincipal, Guid id, StandartUserUpdateDTO standartUserUpdateDTO);
        Task<AccountDTO> PartialUpdateAsync(ClaimsPrincipal claimsPrincipal, Guid id, StandartUserUpdateDTO standartUserUpdateDTO);
        Task<AccountDTO> DeleteAsync(ClaimsPrincipal claimsPrincipal, Guid id);
    }
}

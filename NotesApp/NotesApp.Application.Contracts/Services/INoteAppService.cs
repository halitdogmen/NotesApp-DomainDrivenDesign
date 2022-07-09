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
    public interface INoteAppService
    {
        Task<List<NoteDTO>> GetAllAsync(ClaimsPrincipal claimsPrincipal, int limit, int offset);
        Task<List<NoteDTO>> GetByAccountIdAsync(ClaimsPrincipal claimsPrincipal,Guid accountId, int limit, int offset);
        Task<NoteDTO> GetByIdAsync(ClaimsPrincipal claimsPrincipal, Guid id);
        Task<NoteDTO> CreateAsync(ClaimsPrincipal claimsPrincipal, TextNoteCreationDTO textNoteCreationDTO);
        Task<NoteDTO> CreateAsync(ClaimsPrincipal claimsPrincipal, ImageNoteCreationDTO imageNoteCreationDTO);
        Task<NoteDTO> AddTagAsync(ClaimsPrincipal claimsPrincipal, Guid noteId, TagCreateDTO tagCreateDTO);
        Task<NoteDTO> DeleteTagAsync(ClaimsPrincipal claimsPrincipal, Guid noteId, string tagName);
        Task<NoteDTO> UpdateAsync(ClaimsPrincipal claimsPrincipal, Guid id, TextNoteUpdateDTO textNoteUpdateDTO);
        Task<NoteDTO> PartialUpdateAsync(ClaimsPrincipal claimsPrincipal, Guid id, TextNoteUpdateDTO textNoteUpdateDTO);
        Task<NoteDTO> UpdateAsync(ClaimsPrincipal claimsPrincipal, Guid id, ImageNoteUpdateDTO imageNoteUpdateDTO);
        Task<NoteDTO> PartialUpdateAsync(ClaimsPrincipal claimsPrincipal, Guid id, ImageNoteUpdateDTO imageNoteUpdateDTO);
        Task<NoteDTO> DeleteAsync(ClaimsPrincipal claimsPrincipal, Guid id);
    }
}

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Application.Contracts.DTOs.Abstract;
using NotesApp.Application.Contracts.DTOs.Concrete;
using NotesApp.Application.Contracts.Services;

namespace NotesApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class NotesController : ControllerBase
    {
        private readonly INoteAppService _noteAppService;

        public NotesController(INoteAppService noteAppService)
        {
            _noteAppService = noteAppService;
        }

        [HttpGet]
        public async Task<ActionResult<List<NoteDTO>>> GetAllAsync([FromQuery] Guid? accountId,[FromQuery] int limit = 10, [FromQuery] int offset = 0)
        {
            List<NoteDTO> notes;
            if(accountId is not null)
            {
                notes = await _noteAppService.GetByAccountIdAsync(User, accountId.Value, limit, offset);
            }
            else
            {
                notes = await _noteAppService.GetAllAsync(User, limit, offset);
            }
            return Ok(notes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NoteDTO>> GetByIdAsync([FromRoute] Guid id)
        {
            var note = await _noteAppService.GetByIdAsync(User, id);
            return Ok(note);
        }

        [HttpPost("textNote")]
        public async Task<ActionResult<NoteDTO>> Create([FromBody] TextNoteCreationDTO textNoteCreationDTO)
        {
            var note = await _noteAppService.CreateAsync(User, textNoteCreationDTO);
            return Ok(note);
        }

        [HttpPost("{id}/tags")]
        public async Task<ActionResult<NoteDTO>> Create([FromRoute] Guid id, [FromBody] TagCreateDTO tagCreateDTO)
        {
            var note = await _noteAppService.AddTagAsync(User,id, tagCreateDTO);
            return Ok(note);
        }

        [HttpPost("imageNote")]
        public async Task<ActionResult<NoteDTO>> Create([FromBody] ImageNoteCreationDTO imageNoteCreation)
        {
            var note = await _noteAppService.CreateAsync(User, imageNoteCreation);
            return Ok(note);
        }

        [HttpPut("textNote/{id}")]
        public async Task<ActionResult<NoteDTO>> UpdateAsync([FromRoute] Guid id,[FromBody] TextNoteUpdateDTO textNoteUpdateDTO)
        {
            var note = await _noteAppService.UpdateAsync(User, id,textNoteUpdateDTO);
            return Ok(note);
        }

        [HttpPatch("textNote/{id}")]
        public async Task<ActionResult<NoteDTO>> PartialUpdateAsync([FromRoute] Guid id, [FromBody] TextNoteUpdateDTO textNoteUpdateDTO)
        {
            var note = await _noteAppService.PartialUpdateAsync(User, id, textNoteUpdateDTO);
            return Ok(note);
        }

        [HttpPut("imageNote/{id}")]
        public async Task<ActionResult<NoteDTO>> UpdateAsync([FromRoute] Guid id, [FromBody] ImageNoteUpdateDTO imageNoteCreationDTO)
        {
            var note = await _noteAppService.UpdateAsync(User, id, imageNoteCreationDTO);
            return Ok(note);
        }

        [HttpPatch("imageNote/{id}")]
        public async Task<ActionResult<NoteDTO>> PartialUpdateAsync([FromRoute] Guid id, [FromBody] ImageNoteUpdateDTO imageNoteCreationDTO)
        {
            var note = await _noteAppService.PartialUpdateAsync(User, id, imageNoteCreationDTO);
            return Ok(note);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<NoteDTO>> DeleteAsync([FromRoute] Guid id)
        {
            var note = await _noteAppService.DeleteAsync(User, id);
            return Ok(note);
        }
        [HttpDelete("{id}/tags")]
        public async Task<ActionResult<NoteDTO>> DeleteAsync([FromRoute] Guid id, [FromQuery] string tagName)
        {
            var note = await _noteAppService.DeleteTagAsync(User, id,tagName);
            return Ok(note);
        }
    }
}

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesApp.API.Models;
using NotesApp.Application.Contracts.DTOs.Abstract;
using NotesApp.Application.Contracts.DTOs.Concrete;
using NotesApp.Application.Contracts.Services;

namespace NotesApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    public class NotesController : ControllerBase
    {
        private readonly INoteAppService _noteAppService;

        public NotesController(INoteAppService noteAppService)
        {
            _noteAppService = noteAppService;
        }
        /// <summary>
        /// Gets All Notes in the Notes Application
        /// </summary>
        /// <param name="accountId">Query with AccountId(Owner Id)</param>
        /// <param name="limit">How Many</param>
        /// <param name="offset">Where From</param>
        /// <returns>List Of Notes</returns>
        /// <response code="200"> List of Note Data Transfer Object</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<NoteDTO>), StatusCodes.Status200OK)]
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
        /// <summary>
        /// Get Specific Note in Notes Application
        /// </summary>
        /// <param name="id">Note Unique Identifier</param>
        /// <returns>Specific Note</returns>
        /// <response code="200"> Specific Note Data Tranfer Object</response>
        /// <response code="404">Specific Note is Not Found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(NoteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NoteDTO>> GetByIdAsync([FromRoute] Guid id)
        {
            var note = await _noteAppService.GetByIdAsync(User, id);
            return Ok(note);
        }
        /// <summary>
        /// Creates new Text Note in Notes Application.
        /// </summary>
        /// <param name="textNoteCreationDTO">Represents Text Note Creation Data Transfer Object</param>
        /// <returns>Newly Created TextNote</returns>
        /// <response code="200"> Newly Created TextNote</response>
        /// <response code="400"> Attributes are not valid.</response>
        [HttpPost("textNote")]
        [ProducesResponseType(typeof(TextNoteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<NoteDTO>> Create([FromBody] TextNoteCreationDTO textNoteCreationDTO)
        {
            var note = await _noteAppService.CreateAsync(User, textNoteCreationDTO);
            return Ok(note);
        }
        /// <summary>
        /// Creates new Tag for Notes in Notes Application
        /// </summary>
        /// <param name="id">Note Unique Identifier</param>
        /// <param name="tagCreateDTO">Represents Tag Creation Data Transfer Object</param>
        /// <returns>Returns Note Data Tranfer Object</returns>
        /// <response code="200"> Note Data Transfer Object</response>
        /// <response code="400"> Attributes are not valid</response>
        /// <response code="404"> Note not found.</response>
        [HttpPost("{id}/tags")]
        [ProducesResponseType(typeof(TextNoteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NoteDTO>> Create([FromRoute] Guid id, [FromBody] TagCreateDTO tagCreateDTO)
        {
            var note = await _noteAppService.AddTagAsync(User,id, tagCreateDTO);
            return Ok(note);
        }
        /// <summary>
        /// Creates new Image Note in Notes Application.
        /// </summary>
        /// <param name="imageNoteCreation">Represents Image Note Creation Data Transfer Object</param>
        /// <returns>Newly Created ImageNote</returns>
        /// <response code="200"> Newly Created ImageNote</response>
        /// <response code="400"> Attributes are not valid.</response>
        [HttpPost("imageNote")]
        [ProducesResponseType(typeof(ImageNoteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<NoteDTO>> Create([FromBody] ImageNoteCreationDTO imageNoteCreation)
        {
            var note = await _noteAppService.CreateAsync(User, imageNoteCreation);
            return Ok(note);
        }
        /// <summary>
        ///  Updates Text Note All Attributes in the Notes Apllicaiton.
        /// </summary>
        /// <param name="id">Note Unique Identifier</param>
        /// <param name="textNoteUpdateDTO">Represents Text Note Creation Data Transfer Objects</param>
        /// <returns></returns>
        /// <response code="200"> Newly Updated TextNote</response>
        /// <response code="400"> Attributes are not valid.</response>
        /// <response code="404">TextNote not foud.</response>
        [HttpPut("textNote/{id}")]
        [ProducesResponseType(typeof(TextNoteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NoteDTO>> UpdateAsync([FromRoute] Guid id,[FromBody] TextNoteUpdateDTO textNoteUpdateDTO)
        {
            var note = await _noteAppService.UpdateAsync(User, id,textNoteUpdateDTO);
            return Ok(note);
        }
        /// <summary>
        ///  Updates Text Note Specific Attributes in the Notes Apllicaiton.
        /// </summary>
        /// <param name="id">Note Unique Identifier</param>
        /// <param name="textNoteUpdateDTO"></param>
        /// <returns></returns>
        /// <response code="200"> Newly Updated TextNote</response>
        /// <response code="400"> Attributes are not valid.</response>
        /// <response code="404">TextNote not foud.</response>
        [HttpPatch("textNote/{id}")]
        [ProducesResponseType(typeof(TextNoteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NoteDTO>> PartialUpdateAsync([FromRoute] Guid id, [FromBody] TextNoteUpdateDTO textNoteUpdateDTO)
        {
            var note = await _noteAppService.PartialUpdateAsync(User, id, textNoteUpdateDTO);
            return Ok(note);
        }
        /// <summary>
        ///  Updates Image Note All Attributes in the Notes Apllicaiton.
        /// </summary>
        /// <param name="id">Note Unique Identifier</param>
        /// <param name="imageNoteUpdateDTO">Represents Image Note Creation Data Transfer Objects</param>
        /// <returns></returns>
        /// <response code="200"> Newly Updated ImageNote</response>
        /// <response code="400"> Attributes are not valid.</response>
        /// <response code="404">ImageNote not foud.</response>
        [HttpPut("imageNote/{id}")]
        [ProducesResponseType(typeof(ImageNoteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NoteDTO>> UpdateAsync([FromRoute] Guid id, [FromBody] ImageNoteUpdateDTO imageNoteUpdateDTO)
        {
            var note = await _noteAppService.UpdateAsync(User, id, imageNoteUpdateDTO);
            return Ok(note);
        }
        /// <summary>
        ///  Updates Image Note Specific Attributes in the Notes Apllicaiton.
        /// </summary>
        /// <param name="id">Note Unique Identifier</param>
        /// <param name="imageNoteUpdateDTO">Represents Image Note Creation Data Transfer Objects</param>
        /// <returns></returns>
        /// <response code="200"> Newly Updated ImageNote</response>
        /// <response code="400"> Attributes are not valid.</response>
        /// <response code="404">ImageNote not foud.</response>
        [ProducesResponseType(typeof(ImageNoteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [HttpPatch("imageNote/{id}")]
        public async Task<ActionResult<NoteDTO>> PartialUpdateAsync([FromRoute] Guid id, [FromBody] ImageNoteUpdateDTO imageNoteUpdateDTO)
        {
            var note = await _noteAppService.PartialUpdateAsync(User, id, imageNoteUpdateDTO);
            return Ok(note);
        }
        /// <summary>
        /// Deletes Specific Note in the Notes Application.
        /// </summary>
        /// <param name="id">Note Unique Identifier</param>
        /// <returns>Deleted Note.</returns>
        /// <response code="200">Return the Deleted Note</response>
        /// <response code="404">Note Not Found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ImageNoteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NoteDTO>> DeleteAsync([FromRoute] Guid id)
        {
            var note = await _noteAppService.DeleteAsync(User, id);
            return Ok(note);
        }

        /// <summary>
        /// Deletes Specific Note Tag in the Notes Application.
        /// </summary>
        /// <param name="id">Note Unique Identifier</param>
        /// <param name="tagName">Tag</param>
        /// <returns>Deleted Note.</returns>
        /// <response code="200">Return the Deleted Tag Note</response>
        /// <response code="404">Note Not Found</response>

        [HttpDelete("{id}/tags")]
        [ProducesResponseType(typeof(ImageNoteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NoteDTO>> DeleteAsync([FromRoute] Guid id, [FromQuery] string tagName)
        {
            var note = await _noteAppService.DeleteTagAsync(User, id,tagName);
            return Ok(note);
        }
    }
}

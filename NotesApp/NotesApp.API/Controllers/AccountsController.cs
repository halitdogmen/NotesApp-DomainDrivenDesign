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
    public class AccountsController : ControllerBase
    {
        private readonly IAccountAppService _accountAppService;

        public AccountsController(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }
        /// <summary>
        /// Gets all accounts in the Notes Application.
        /// </summary>
        /// <param name="limit">How Many</param>
        /// <param name="offset">From Where</param>
        /// <returns>List of Accounts</returns>
        /// <response code="200">Returns the List Of Accounts</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<AccountDTO>>> GetAllAsync([FromQuery]int limit=10, [FromQuery]int offset =0)
        {
            var accounts = await _accountAppService.GetAllAsync(User, limit, offset);
            return Ok(accounts);
        }
        /// <summary>
        /// Get Specific Account by Id in the Notes Application.
        /// </summary>
        /// <param name="id">Account Unique Identifier</param>
        /// <returns>Specific Account.</returns>
        /// <response code="200">Return the Specific Account</response>
        /// <response code="404">Account Not Found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AccountDTO),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AccountDTO>> GetByIdAsync([FromRoute] Guid id)
        {
            var account = await _accountAppService.GetByIdAsync(User, id);
            return Ok(account);
        }
        /// <summary>
        /// Update Standart User All Attributes in the Notes Apllicaiton.
        /// </summary>
        /// <param name="id">Standart User Unique Identifier.</param>
        /// <param name="standartUserUpdateDTO">Standart User Update Data Transfer Object</param>
        /// <returns>Updated Account</returns>
        /// <response code="200">Return the Updated Account</response>
        /// <response code="404">Account Not Found</response>
        /// <response code="400">Attribute is not valid</response>
        [HttpPut("standartUser/{id}")]
        [ProducesResponseType(typeof(AccountDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccountDTO>> UpdateAsync([FromRoute] Guid id, [FromBody] StandartUserUpdateDTO standartUserUpdateDTO)
        {
            var account = await _accountAppService.UpdateAsync(User, id, standartUserUpdateDTO);
            return Ok(account);
        }
        /// <summary>
        /// Update Standart User Specific attributes in the Notes Application.
        /// </summary>
        /// <param name="id">Standart User Unique Identifier.</param>
        /// <param name="standartUserUpdateDTO">Standart User Update Data Transfer Object</param>
        /// <returns>Updated Account.</returns>
        /// <response code="200">Return the Updated Account</response>
        /// <response code="404">Account Not Found</response>
        /// <response code="400">Attribute is not valid</response>
        [HttpPatch("standartUser/{id}")]
        [ProducesResponseType(typeof(AccountDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccountDTO>> PartialUpdateAsync([FromRoute] Guid id, [FromBody] StandartUserUpdateDTO standartUserUpdateDTO)
        {
            var account = await _accountAppService.PartialUpdateAsync(User, id, standartUserUpdateDTO);
            return Ok(account);
        }
        /// <summary>
        /// Deletes Specific Account in the Notes Application.
        /// </summary>
        /// <param name="id">Account Unique Identifier</param>
        /// <returns>Deleted Account.</returns>
        /// <response code="200">Return the Deleted Account</response>
        /// <response code="404">Account Not Found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(AccountDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AccountDTO>> DeleteAsync([FromRoute] Guid id)
        {
            var account = await _accountAppService.DeleteAsync(User, id);
            return Ok(account);
        }
    }
}

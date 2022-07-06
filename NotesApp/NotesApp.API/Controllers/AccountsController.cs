using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Application.Contracts.DTOs.Abstract;
using NotesApp.Application.Contracts.DTOs.Concrete;
using NotesApp.Application.Contracts.Services;

namespace NotesApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountAppService _accountAppService;

        public AccountsController(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AccountDTO>>> GetAllAsync([FromQuery]int limit=10, [FromQuery]int offset =0)
        {
            var accounts = await _accountAppService.GetAllAsync(User, limit, offset);
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDTO>> GetByIdAsync([FromRoute] Guid id)
        {
            var account = await _accountAppService.GetByIdAsync(User, id);
            return Ok(account);
        }

        [HttpPut("standartUser/{id}")]
        public async Task<ActionResult<AccountDTO>> UpdateAsync([FromRoute] Guid id, [FromBody] StandartUserUpdateDTO standartUserUpdateDTO)
        {
            var account = await _accountAppService.UpdateAsync(User, id, standartUserUpdateDTO);
            return Ok(account);
        }

        [HttpPatch("standartUser/{id}")]
        public async Task<ActionResult<AccountDTO>> PartialUpdateAsync([FromRoute] Guid id, [FromBody] StandartUserUpdateDTO standartUserUpdateDTO)
        {
            var account = await _accountAppService.PartialUpdateAsync(User, id, standartUserUpdateDTO);
            return Ok(account);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccountDTO>> DeleteAsync([FromRoute] Guid id)
        {
            var account = await _accountAppService.DeleteAsync(User, id);
            return Ok(account);
        }
    }
}

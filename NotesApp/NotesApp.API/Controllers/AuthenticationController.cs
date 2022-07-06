using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Application.Contracts.DTOs.Abstract;
using NotesApp.Application.Contracts.DTOs.Concrete;
using NotesApp.Application.Contracts.Services;

namespace NotesApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationAppService _authenticationAppService;

        public AuthenticationController(IAuthenticationAppService authenticationAppService)
        {
            _authenticationAppService = authenticationAppService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<List<AccountDTO>>> LoginAsync([FromBody] LoginDTO loginDTO)
        {
            var authDTO = await _authenticationAppService.LoginAsync(loginDTO);
            return Ok(authDTO);
        }

        [HttpPost("register/standartUser")]
        public async Task<ActionResult<List<AccountDTO>>> RegisterAsync([FromBody] StandartUserRegisterDTO registerDTO)
        {
            var authDTO = await _authenticationAppService.RegisterStandartUserAsync(registerDTO);
            return Ok(authDTO);
        }
    }
}

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
    [Produces("application/json")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationAppService _authenticationAppService;

        public AuthenticationController(IAuthenticationAppService authenticationAppService)
        {
            _authenticationAppService = authenticationAppService;
        }
        /// <summary>
        /// Authenticates Account
        /// </summary>
        /// <param name="loginDTO"> Login Parameters</param>
        /// <returns>Authentication Response</returns>
        /// <response code="200">Succesfuly. Authentication Response</response>
        /// <response code="401">Unauthenticated Response</response>
        [HttpPost("login")]
        [ProducesResponseType(typeof(AuthDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<AuthDTO>>> LoginAsync([FromBody] LoginDTO loginDTO)
        {
            var authDTO = await _authenticationAppService.LoginAsync(loginDTO);
            return Ok(authDTO);
        }
        /// <summary>
        ///  Creates and Authenticates newly Standart User Account
        /// </summary>
        /// <param name="registerDTO">Standart User Register Data Transfer Object</param>
        /// <returns>Authentication Response</returns>
        /// <response code="400">Atrributes are not valid.</response>
        [HttpPost("register/standartUser")]
        [ProducesResponseType(typeof(AuthDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<AuthDTO>>> RegisterAsync([FromBody] StandartUserRegisterDTO registerDTO)
        {
            var authDTO = await _authenticationAppService.RegisterStandartUserAsync(registerDTO);
            return Ok(authDTO);
        }
    }
}

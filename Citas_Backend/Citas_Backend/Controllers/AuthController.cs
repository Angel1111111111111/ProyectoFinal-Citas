using Citas_Backend.Dtos.Security;
using Citas_Backend.Dtos;
using Citas_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Citas_Backend.Dtos.pacientes;

namespace Citas_Backend.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseDto<LoginResponseDto>>> Login(
            LoginDto dto
            )
        {
            var authResponse = await _authService.LoginAsync(dto);
            return StatusCode(authResponse.StatusCode, authResponse);
        }
    }
}
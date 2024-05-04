using Citas_Backend.Dtos.Security;
using Citas_Backend.Dtos;
using Citas_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Citas_Backend.Dtos.Logs;

namespace Citas_Backend.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogsService _logsService;

        public AuthController(IAuthService authService, ILogsService logsService)
        {
            _authService = authService;
            _logsService = logsService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseDto<LoginResponseDto>>> Login(LoginDto dto)
        {
            var authResponse = await _authService.LoginAsync(dto);

            if (authResponse.Status)
            {
                await _logsService.LogLoginAsync(dto.Email);
            }

            return StatusCode(authResponse.StatusCode, authResponse);
        }
    }
}

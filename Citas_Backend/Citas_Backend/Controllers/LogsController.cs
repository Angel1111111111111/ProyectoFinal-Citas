// LogsController.cs
using Microsoft.AspNetCore.Mvc;
using Citas_Backend.Services;
using Citas_Backend.Dtos.Logs;
using System;
using System.Threading.Tasks;
using Citas_Backend.Services.Interfaces;
using Citas_Backend.Dtos;
using Citas_Backend.Entities;

namespace Citas_Backend.Controllers
{
	[Route("api/log")]
	[ApiController]
	public class LogsController : ControllerBase
	{
		private readonly LogsService _logsService;

		public LogsController(LogsService logsService)
		{
			_logsService = logsService;
		}

		[HttpPost("login")]
		public async Task<IActionResult> LogLogin([FromBody] string usuario)
		{
			try
			{
				await _logsService.LogLoginAsync(usuario);
				return Ok(new { message = "Inicio de sesión registrado correctamente" });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = $"Error al registrar el inicio de sesión: {ex.Message}" });
			}
		}

		[HttpPost("edit")]
		public async Task<IActionResult> LogEdit([FromBody] LogDto actionDto)
		{
			try
			{
				await _logsService.LogEditAsync(actionDto.Usuario, actionDto.Accion);
				return Ok(new { message = "Edición registrada correctamente" });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = $"Error al registrar la edición: {ex.Message}" });
			}
		}

		[HttpPost("delete")]
		public async Task<IActionResult> LogDelete([FromBody] LogDto actionDto)
		{
			try
			{
				await _logsService.LogDeleteAsync(actionDto.Usuario, actionDto.Accion);
				return Ok(new { message = "Eliminación registrada correctamente" });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = $"Error al registrar la eliminación: {ex.Message}" });
			}
		}

		[HttpPost("create")]
		public async Task<IActionResult> LogCreate([FromBody] LogDto actionDto)
		{
			try
			{
				await _logsService.LogCreateAsync(actionDto.Usuario, actionDto.Accion);
				return Ok(new { message = "Creación registrada correctamente" });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = $"Error al registrar la creación: {ex.Message}" });
			}
		}
        [HttpGet]
        public async Task<ActionResult> GetLogs()
        {
            var response = await _logsService.GetLogsAsync();

            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<LogEntity>>> GetLogById(Guid id)
        {
            var response = await _logsService.GetLogByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

    }
}

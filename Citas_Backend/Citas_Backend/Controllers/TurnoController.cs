using Microsoft.AspNetCore.Mvc;
using Citas_Backend.Services.Interfaces;
using Citas_Backend.Dtos;
using Citas_Backend.Dtos.Turnos;
using System.Threading.Tasks;
using Citas_Backend.Dtos.Citas;
using Citas_Backend.Services;

namespace Citas_Backend.Controllers
{
    [Route("api/turnos")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly ITurnoService _turnoService;
        private readonly ILogsService _logsService;

        public TurnoController(ITurnoService turnoService, ILogsService logsService)
        {
            _turnoService = turnoService;
            _logsService = logsService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<CitasDto>>>> GetTurnos(string searchTerm = "")
        {
            var response = await _turnoService.GetTurnosAsync(searchTerm);
            
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTurno([FromBody] TurnoCreateDto model)
        {
            var response = await _turnoService.CreateTurnoAsync(model);

            if (response.Status)
            {
                await _logsService.LogCreateAsync("", "Turno creado");
            }

            return StatusCode(response.StatusCode, response);

        }
    }
}

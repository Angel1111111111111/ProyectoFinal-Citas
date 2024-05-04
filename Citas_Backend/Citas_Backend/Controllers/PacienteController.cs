using Microsoft.AspNetCore.Mvc;
using Citas_Backend.Dtos.Pacientes;
using Citas_Backend.Services.Interfaces;
using Citas_Backend.Dtos;
using Citas_Backend.Dtos.pacientes;
using Citas_Backend.Services;
using Citas_Backend.Dtos.Doctores;

namespace Citas_Backend.Controllers
{
    [Route("api/pacientes")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;
        private readonly ILogsService _logsService;

        public PacienteController(IPacienteService pacienteService, ILogsService logsService)
        {
            _pacienteService = pacienteService;
            _logsService = logsService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ResponseDto<PacienteDto>>> Register(PacienteCreateDto pacienteDto)
        {
            var response = await _pacienteService.RegistrarPacienteAsync(pacienteDto);

            if (response.Status)
            {
                await _logsService.LogCreateAsync("", "Paciente registrado");
            }

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        public async Task<ActionResult> GetPacienteAsync()
        {
            var response = await _pacienteService.ObtenerPacienteAsync();

            if (response.Status)
            {
                return Ok(response.Data);
            }
            else
            {
                return NotFound(response);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteDto>> GetPacienteByIDAsync(Guid id)
        {
            var response = await _pacienteService.ObtenerPacienteByIdAsync(id);
            if (!response.Status)
            {
                return NotFound(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpGet("correo/{correoElectronico}")]
        public async Task<ActionResult<ResponseDto<PacienteDto>>> GetPacienteAsync(string correoElectronico)
        {
            var response = await _pacienteService.ObtenerPacientePorCorreoElectronicoAsync(correoElectronico);
            return StatusCode(response.StatusCode, response);
        }
    }
}

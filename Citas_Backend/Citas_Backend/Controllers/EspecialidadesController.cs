using Citas_Backend.Dtos.Especialidades;
using Citas_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Citas_Backend.Controllers
{
    [Route("api/especialidad")]
    [ApiController]
    public class EspecialidadesController : ControllerBase
    {
        private readonly IEspecialidadService _especialidadService;

        public EspecialidadesController(IEspecialidadService especialidadService)
        {
            _especialidadService = especialidadService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEspecialidades()
        {
            var response = await _especialidadService.GetEspecialidadesAsync();
            if (response.Status)
            {
                return Ok(response.Data);
            }
            else
            {
                return NotFound(response.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEspecialidad(EspecialidadDto especialidadDto)
        {
            var response = await _especialidadService.CreateAsync(especialidadDto);

            if (response.Status)
            {
                return CreatedAtAction(nameof(GetEspecialidadById), new { id = response.Data.Id }, response.Data);
            }
            else
            {
                return StatusCode(response.StatusCode, response.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEspecialidadById(int id)
        {
            var response = await _especialidadService.GetEspecialidadByIdAsync(id);
            if (response.Status)
            {
                return Ok(response.Data);
            }
            else
            {
                return NotFound(response.Message);
            }
        }
    }
}

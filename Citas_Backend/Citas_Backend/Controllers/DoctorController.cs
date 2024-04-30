using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Citas_Backend.Dtos.Doctores;
using Citas_Backend.Dtos.Turnos;
using Citas_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Citas_Backend.Controllers
{
    [Route("api/doctores")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // GET: api/doctores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctores()
        {
            var response = await _doctorService.GetDoctorAsync();
            return Ok(response.Data);
        }

        // GET: api/doctores/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDto>> GetDoctor(Guid id)
        {
            var response = await _doctorService.GetDoctorByIdAsync(id);
            if (!response.Status)
            {
                return NotFound(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpGet("especialidad/{especialidadId}")]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctoresByEspecialidad(Guid especialidadId)
        {
            var response = await _doctorService.GetDoctorAsyncByEspecialidad(especialidadId);
            return Ok(response.Data);
        }


        // POST: api/doctores
        [HttpPost]
        public async Task<ActionResult<DoctorDto>> PostDoctor(DoctorDto doctorDto)
        {
            var response = await _doctorService.CreateDoctorAsync(doctorDto);
            if (!response.Status)
            {
                return BadRequest(response.Message);
            }
            return CreatedAtAction(nameof(GetDoctor), new { id = response.Data }, response.Data);
        }

        // PUT: api/doctores/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(Guid id, DoctorDto doctorDto)
        {
            var response = await _doctorService.UpdateDoctorAsync(id, doctorDto);
            if (!response.Status)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

        // DELETE: api/doctores/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {
            var response = await _doctorService.DeleteDoctorAsync(id);
            if (!response.Status)
            {
                return NotFound(response.Message);
            }
            return NoContent();
        }

        // GET: api/doctores/turnos
        [HttpGet("turnos")]
        public async Task<ActionResult<IEnumerable<TurnoDto>>> GetTurnos()
        {
            var response = await _doctorService.GetTurnosAsync();
            return Ok(response.Data);
        }
    }
}

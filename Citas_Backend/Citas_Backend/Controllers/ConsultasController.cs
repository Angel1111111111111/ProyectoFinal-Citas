using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Citas_Backend.Services.Interfaces;
using Citas_Backend.Dtos.Consultas;
using Citas_Backend.Services;

namespace Citas_Backend.Controllers
{
    [Route("api/consulta")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultasService _consultaService;
        private readonly ILogsService _logsService;

        public ConsultaController(IConsultasService consultaService, ILogsService logsService)
        {
            _consultaService = consultaService;
            _logsService = logsService;
        }

        // GET: api/consulta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsultaDto>>> GetConsultas()
        {
            var response = await _consultaService.GetConsultasAsync();
            
            return StatusCode(response.StatusCode, response);
        }

        // GET: api/consulta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultaDto>> GetConsultaById(Guid id)
        {
            var response = await _consultaService.GetConsultasByIdAsync(id);
            
            return StatusCode(response.StatusCode, response);
        }

        // POST: api/consulta
        [HttpPost]
        public async Task<ActionResult<ConsultaDto>> PostConsulta([FromBody] ConsultaCreateDto model)
        {
            var response = await _consultaService.CreateConsultaAsync(model);

            if (response.Status)
            {
                await _logsService.LogCreateAsync("", "Consulta creada");
            }

            return StatusCode(response.StatusCode, response);
        }
    }
}

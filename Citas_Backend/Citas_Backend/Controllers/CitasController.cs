﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Citas_Backend.Services;
using Citas_Backend.Services.Interfaces;
using Citas_Backend.Dtos.Citas;
using Citas_Backend.Dtos;
using Citas_Backend.Dtos.Especialidades;

namespace Citas_Backend.Controllers
{
    [Route("api/citas")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly ICitasService _citasService;
        private readonly ILogsService _logsService;
        private readonly IAuthService authService;

        public CitasController(
            ICitasService citasService, ILogsService logsService)
        {
            _citasService = citasService;
            _logsService = logsService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<CitasDto>>>> GetAllCitas(string searchTerm = "")
        {
            var response = await _citasService.GetListAsync(searchTerm);

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<CitasDto>>> GetCitaOneById(Guid id)
        {
            var response = await _citasService.GetOneByIdAsync(id);

            return StatusCode(response.StatusCode, response);
        }


        [HttpPost]
        public async Task<ActionResult<CitasDto>> CreateCita([FromBody] CitaCreateDto model)
        {
            var response = await _citasService.CreateAsync(model);

            if (response.Status)
            {
                await _logsService.LogCreateAsync("", "Cita creada");
            }

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCita([FromBody] CitasDto dto, Guid id)
        {
            var response = await _citasService.UpdateAsync(dto, id);

            if (response.Status)
            {
                await _logsService.LogEditAsync("", "Cita editada}");
            }

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<CitasDto>>> DeleteCita(Guid id)
        {
            var response = await _citasService.DeleteAsync(id);

            if (response.Status)
            {
                await _logsService.LogDeleteAsync("", "Cita eliminada");
            }

            return StatusCode(response.StatusCode, response);

        }

        //[HttpGet("especialidades")]
        //public async Task<ActionResult<ResponseDto<List<EspecialidadDto>>>> GetEspecialidades()
        //{
        //    var response = await _citasService.GetEspecialidadesAsync();
        //    return StatusCode(response.StatusCode, response);
        //}
    }
}

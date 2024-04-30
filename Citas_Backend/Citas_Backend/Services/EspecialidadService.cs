using AutoMapper;
using Citas_Backend.Database;
using Citas_Backend.Dtos;
using Citas_Backend.Dtos.Especialidades;
using Citas_Backend.Entities;
using Citas_Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Citas_Backend.Services
{
    public class EspecialidadService : IEspecialidadService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EspecialidadService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<EspecialidadDto>>> GetEspecialidadesAsync()
        {
            var especialidades = await _context.Especialidades.ToListAsync();
            var especialidadesDto = _mapper.Map<List<EspecialidadDto>>(especialidades);

            return new ResponseDto<List<EspecialidadDto>>
            {
                Status = true,
                StatusCode = 200,
                Message = "Lista de especialidades obtenida correctamente",
                Data = especialidadesDto
            };
        }

        public async Task<ResponseDto<EspecialidadDto>> GetEspecialidadByIdAsync(int id)
        {
            var especialidad = await _context.Especialidades.FindAsync(id);

            if (especialidad == null)
            {
                return new ResponseDto<EspecialidadDto>
                {
                    Status = false,
                    StatusCode = 404,
                    Message = $"Especialidad con ID {id} no encontrada"
                };
            }

            var especialidadDto = _mapper.Map<EspecialidadDto>(especialidad);

            return new ResponseDto<EspecialidadDto>
            {
                Status = true,
                StatusCode = 200,
                Message = $"Especialidad con ID {id} obtenida correctamente",
                Data = especialidadDto
            };
        }

        public async Task<ResponseDto<EspecialidadDto>> CreateAsync(EspecialidadDto especialidadDto)
        {
            try
            {
                var especialidadEntity = _mapper.Map<EspecialidadEntity>(especialidadDto);

                _context.Especialidades.Add(especialidadEntity);
                await _context.SaveChangesAsync();

                var especialidadDtoResult = _mapper.Map<EspecialidadDto>(especialidadEntity);

                return new ResponseDto<EspecialidadDto>
                {
                    Status = true,
                    StatusCode = 201,
                    Message = "Especialidad creada correctamente",
                    Data = especialidadDtoResult
                };
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la creación de la especialidad
                return new ResponseDto<EspecialidadDto>
                {
                    Status = false,
                    StatusCode = 500,
                    Message = $"Error al crear la especialidad: {ex.Message}"
                };
            }
        }
    }
}

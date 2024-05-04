using AutoMapper;
using Citas_Backend.Database;
using Citas_Backend.Dtos;
using Citas_Backend.Dtos.Citas;
using Citas_Backend.Dtos.Especialidades;
using Citas_Backend.Entities;
using Citas_Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Citas_Backend.Services
{
    public class CitasService : ICitasService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogsService _logsService;

        public CitasService(ApplicationDbContext context, IMapper mapper, ILogsService logsService)
        {
            _context = context;
            _mapper = mapper;
            _logsService = logsService;
        }

        public async Task<ResponseDto<List<CitasDto>>> GetListAsync(string searchTerm = "")
        {
            var citasEntity = await _context.Citas
                .Where(c => c.DoctorId.ToString().Contains(searchTerm))
                .ToListAsync();

            var citasDto = _mapper.Map<List<CitasDto>>(citasEntity);

            return new ResponseDto<List<CitasDto>>
            {
                Status = true,
                StatusCode = 200,
                Message = "Datos obtenidos correctamente",
                Data = citasDto
            };
        }

        public async Task<ResponseDto<CitasDto>> GetOneByIdAsync(Guid id)
        {
            var citaEntity = await _context.Citas.SingleOrDefaultAsync(c => c.Id == id);
            if (citaEntity is null)
            {
                return new ResponseDto<CitasDto>
                {
                    Status = true,
                    StatusCode = 404,
                    Message = $"El cita {id} no encontrada"
                };
            }

            var citaDto = _mapper.Map<CitasDto>(citaEntity);

            return new ResponseDto<CitasDto>
            {
                Status = true,
                StatusCode = 200,
                Message = $"Cita con Id {citaDto.Id} no encontrada",
                Data = citaDto
            };
        }

        public async Task<ResponseDto<CitasDto>> CreateAsync(CitaCreateDto model)
        {
            var citaEntity = _mapper.Map<CitasEntity>(model);

            _context.Citas.Add(citaEntity);
            await _context.SaveChangesAsync();

            var citaDto = _mapper.Map<CitasDto>(citaEntity);

            // Registra el log de la creación de la cita
            //await _logsService.RegistrarLogAsync("Cita creada", citaDto.Id);

            return new ResponseDto<CitasDto>
            {
                Status = true,
                StatusCode = 201,
                Message = "Cita creada correctamente",
                Data = citaDto
            };
        }

        public async Task<ResponseDto<CitasDto>> UpdateAsync(CitasDto dto, Guid id)
        {
            var citaEntity = await _context.Citas.FirstOrDefaultAsync(c => c.Id == id);

            if (citaEntity is null)
            {
                return new ResponseDto<CitasDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = $"Cita {id} no encontrada"
                };
            }

            _mapper.Map<CitasDto, CitasEntity>(dto, citaEntity);

            _context.Update(citaEntity);
            await _context.SaveChangesAsync();

            var citaDto = _mapper.Map<CitasDto>(citaEntity);

            // Registra el log de la edicion de la cita
           // await _logsService.RegistrarLogAsync("Cita editada", citaDto.Id);

            return new ResponseDto<CitasDto>
            {
                StatusCode = 200,
                Status = true,
                Message = $"Cita {id} actualizada correctamente",
                Data = citaDto
            };
        }

        public async Task<ResponseDto<CitasDto>> DeleteAsync(Guid id)
        {
            var citaEntity = await _context.Citas.SingleOrDefaultAsync(c => c.Id == id);

            if (citaEntity is null)
            {
                return new ResponseDto<CitasDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = $"Cita no encontrada"
                };
            }

            _context.Citas.Remove(citaEntity);
            await _context.SaveChangesAsync();

            // Registra el log de la eliminacion de la cita
           // await _logsService.RegistrarLogAsync("Cita eliminada", id);

            return new ResponseDto<CitasDto>
            {
                StatusCode = 200,
                Status = true,
                Message = $"Cita eliminada correctamente"
            };
        }
        //public async Task<ResponseDto<List<EspecialidadDto>>> GetEspecialidadesAsync()
        //{
        //    var especialidadesEntity = await _context.Especialidades.ToListAsync();
        //    var especialidadesDto = _mapper.Map<List<EspecialidadDto>>(especialidadesEntity);

        //    return new ResponseDto<List<EspecialidadDto>>
        //    {
        //        Status = true,
        //        StatusCode = 200,
        //        Message = "Lista de especialidades obtenida correctamente",
        //        Data = especialidadesDto
        //    };
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Citas_Backend.Database;
using Citas_Backend.Dtos;
using Citas_Backend.Dtos.Doctores;
using Citas_Backend.Dtos.Turnos;
using Citas_Backend.Entities;
using Citas_Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Citas_Backend.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogsService _logsService;

        public DoctorService(ApplicationDbContext context, IMapper mapper, ILogsService logsService)
        {
            _context = context;
            _mapper = mapper;
            _logsService = logsService;
        }

        public async Task<ResponseDto<List<DoctorDto>>> GetDoctorAsyncByEspecialidad(Guid especialidadId)
        {
            var doctores = await _context.Doctor
                .Include(d => d.Turno) 
                .Where(d => d.EspecialidadId == especialidadId)
                .ToListAsync();

            var doctoresDto = _mapper.Map<List<DoctorDto>>(doctores);

            return new ResponseDto<List<DoctorDto>>
            {
                Status = true,
                StatusCode = 200,
                Message = "Lista de doctores obtenida correctamente",
                Data = doctoresDto
            };
        }

        public async Task<ResponseDto<List<DoctorDto>>> GetDoctorAsync()
        {
            var doctores = await _context.Doctor
                 .Include(d => d.Turno) 
                 .ToListAsync();

            var doctoresDto = _mapper.Map<List<DoctorDto>>(doctores);

            return new ResponseDto<List<DoctorDto>>
            {
                Status = true,
                StatusCode = 200,
                Message = "Lista de doctores obtenida correctamente",
                Data = doctoresDto
            };
        }

        public async Task<ResponseDto<List<TurnoDto>>> GetTurnosAsync()
        {
            var turnos = await _context.Doctor
                .Where(d => d.Turno != null) 
                .Select(d => d.Turno)
                .ToListAsync();

            var turnosDto = _mapper.Map<List<TurnoDto>>(turnos);

            return new ResponseDto<List<TurnoDto>>
            {
                Status = true,
                StatusCode = 200,
                Message = "Lista de turnos obtenida correctamente",
                Data = turnosDto
            };
        }

        public async Task<ResponseDto<DoctorDto>> GetDoctorByIdAsync(Guid id)
        {
            var doctorEntity = await _context.Doctor.FindAsync(id);
            if (doctorEntity == null)
            {
                return new ResponseDto<DoctorDto>
                {
                    Status = false,
                    StatusCode = 404,
                    Message = "Doctor no encontrado",
                };
            }
            var doctorDto = _mapper.Map<DoctorDto>(doctorEntity);

            return new ResponseDto<DoctorDto>
            {
                Status = true,
                StatusCode = 200,
                Message = "Doctor encontrado",
                Data = doctorDto
            };
        }

        public async Task<ResponseDto<bool>> CreateDoctorAsync(DoctorDto doctorDto)
        {
            var doctorEntity = _mapper.Map<DoctorEntity>(doctorDto);

            _context.Doctor.Add(doctorEntity);
            await _context.SaveChangesAsync();

            // Registrar el log de la creación del doctor
            //await _logsService.RegistrarLogAsync("Doctor creado correctamente", doctorDto.Id);

            return new ResponseDto<bool>
            {
                Status = true,
                StatusCode = 201,
                Message = "Doctor creado correctamente",
                Data = true
            };
        }

        public async Task<ResponseDto<bool>> UpdateDoctorAsync(Guid id, DoctorDto doctorDto)
        {
            var doctorEntity = await _context.Doctor.FindAsync(id);
            if (doctorEntity == null)
            {
                return new ResponseDto<bool>
                {
                    Status = false,
                    StatusCode = 404,
                    Message = "Doctor no encontrado",
                };
            }

            _mapper.Map(doctorDto, doctorEntity);

            await _context.SaveChangesAsync();

            // Registrar el log de la edicion del doctor
            //await _logsService.RegistrarLogAsync("Doctor editado correctamente", doctorDto.Id);

            return new ResponseDto<bool>
            {
                Status = true,
                StatusCode = 200,
                Message = "Doctor actualizado correctamente",
                Data = true
            };
        }

        public async Task<ResponseDto<bool>> DeleteDoctorAsync(Guid id)
        {
            var doctorEntity = await _context.Doctor.FindAsync(id);
            if (doctorEntity == null)
            {
                return new ResponseDto<bool>
                {
                    Status = false,
                    StatusCode = 404,
                    Message = "Doctor no encontrado",
                };
            }

            _context.Doctor.Remove(doctorEntity);
            await _context.SaveChangesAsync();

            // Registrar el log de la eliminacion del doctor
            //await _logsService.RegistrarLogAsync("Doctor eliminado correctamente", id);

            return new ResponseDto<bool>
            {
                Status = true,
                StatusCode = 200,
                Message = "Doctor eliminado correctamente",
                Data = true
            };
        }
    }
}

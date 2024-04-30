using Citas_Backend.Database;
using Citas_Backend.Dtos;
using Citas_Backend.Dtos.Turnos;
using Citas_Backend.Entities;
using Citas_Backend.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Citas_Backend.Services
{
    public class TurnoService : ITurnoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TurnoService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<TurnoDto>>> GetTurnosAsync(string searchTerm = "")
        {
            var turnos = await _context.Turnos.ToListAsync();
            var turnoDtos = _mapper.Map<List<TurnoDto>>(turnos);

            return new ResponseDto<List<TurnoDto>>
            {
                Status = true,
                StatusCode = 200,
                Message = "Lista de turnos obtenida correctamente",
                Data = turnoDtos
            };
        }

        public async Task<ResponseDto<TurnoDto>> CreateTurnoAsync(TurnoCreateDto model)
        {
            var turnoEntity = _mapper.Map<TurnoEntity>(model);

            _context.Turnos.Add(turnoEntity);
            await _context.SaveChangesAsync();

            var turnoDto = _mapper.Map<TurnoDto>(turnoEntity);

            return new ResponseDto<TurnoDto>
            {
                Status = true,
                StatusCode = 201,
                Message = "Turno creado correctamente",
                Data = turnoDto

            };
        }
    }
}

using AutoMapper;
using Citas_Backend.Database;
using Citas_Backend.Dtos;
using Citas_Backend.Entities;
using Citas_Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Citas_Backend.Dtos.Consultas;

namespace Citas_Backend.Services
{
    public class ConsultaService : IConsultasService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ConsultaService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ConsultaDto>> CreateConsultaAsync(ConsultaCreateDto model)
        {
            var consultaEntity = _mapper.Map<ConsultaEntity>(model);

            _context.Consultas.Add(consultaEntity);
            await _context.SaveChangesAsync();

            var consultaDto = _mapper.Map<ConsultaDto>(consultaEntity);

            return new ResponseDto<ConsultaDto>
            {
                Status = true,
                StatusCode = 201,
                Message = "Consulta creada correctamente",
                Data = consultaDto
            };
        }
                
        public async Task<ResponseDto<List<ConsultaDto>>> GetConsultasAsync()
        {
            var consultasEntity = await _context.Consultas.ToListAsync();
            var consultasDto = _mapper.Map<List<ConsultaDto>>(consultasEntity);

            return new ResponseDto<List<ConsultaDto>>
            {
                Status = true,
                StatusCode = 200,
                Message = "Consultas obtenidas correctamente",
                Data = consultasDto
            };

        }

        public async Task<ResponseDto<ConsultaDto>> GetConsultasByIdAsync(Guid id)
        {
            var consultasEntity = await _context.Consultas.FirstOrDefaultAsync(c => c.Id == id);

            if (consultasEntity is null)
            {
                return new ResponseDto<ConsultaDto>
                {
                    Status = true,
                    StatusCode = 404,
                    Message = $"Consultas {id} no encontrada",
                };
            }

            var consultaDto = _mapper.Map<ConsultaDto>(consultasEntity);

            return new ResponseDto<ConsultaDto>
            {
                Status = true,
                StatusCode = 200,
                Message = $"Consultas {consultaDto.Id} encontrada",
                Data = consultaDto
            };
        }
    }
}
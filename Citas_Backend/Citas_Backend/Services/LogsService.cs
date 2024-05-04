using System;
using System.Threading.Tasks;
using Citas_Backend.Database;
using Citas_Backend.Dtos;
using Citas_Backend.Entities;
using Citas_Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Citas_Backend.Services
{
    public class LogsService : ILogsService
    {
        private readonly LogDbContext _context;

        public LogsService(LogDbContext context)
        {
            _context = context;
        }

        public async Task LogLoginAsync(string usuario)
        {
            var logEntity = new LogEntity
            {
                Fecha = DateTime.Now,
                Usuario = usuario,
                Accion = "Inicio de sesión"
            };
            _context.Logs.Add(logEntity);
            await _context.SaveChangesAsync();
        }

        public async Task LogEditAsync(string usuario, string accion)
        {
            var logEntity = new LogEntity
            {
                Fecha = DateTime.Now,
                Usuario = usuario,
                Accion = $"Edición - {accion}"
            };
            _context.Logs.Add(logEntity);
            await _context.SaveChangesAsync();
        }

        public async Task LogDeleteAsync(string usuario, string accion)
        {
            var logEntity = new LogEntity
            {
                Fecha = DateTime.Now,
                Usuario = usuario,
                Accion = $"Eliminación - {accion}"
            };
            _context.Logs.Add(logEntity);
            await _context.SaveChangesAsync();
        }

        public async Task LogCreateAsync(string usuario, string accion)
        {
            var logEntity = new LogEntity
            {
                Fecha = DateTime.Now,
                Usuario = usuario,
                Accion = $"Creación - {accion}"
            };
            _context.Logs.Add(logEntity);
            await _context.SaveChangesAsync();
        }
        public async Task<ResponseDto<List<LogEntity>>> GetLogsAsync()
        {
            var logs = await _context.Logs.ToListAsync();

            return new ResponseDto<List<LogEntity>>
            {
                Status = true,
                StatusCode = 200,
                Message = "Logs obtenidos correctamente",
                Data = logs
            };
        }
        public async Task<ResponseDto<LogEntity>> GetLogByIdAsync(Guid id)
        {
            try
            {
                var log = await _context.Logs.FindAsync(id);
                if (log == null)
                {
                    return new ResponseDto<LogEntity>
                    {
                        Status = false,
                        StatusCode = 404,
                        Message = $"Log with ID {id} not found."
                    };
                }

                return new ResponseDto<LogEntity>
                {
                    Status = true,
                    StatusCode = 200,
                    Message = $"Log with ID {id} found.",
                    Data = log
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<LogEntity>
                {
                    Status = false,
                    StatusCode = 500,
                    Message = $"Error retrieving log with ID {id}: {ex.Message}"
                };
            }
        }

    }

}


using Citas_Backend.Dtos;
using Citas_Backend.Dtos.Logs;
using Citas_Backend.Entities;

namespace Citas_Backend.Services.Interfaces
{
    public interface ILogsService
    {
        Task<ResponseDto<LogEntity>> GetLogByIdAsync(Guid id);
        Task<ResponseDto<List<LogEntity>>> GetLogsAsync();
        Task LogCreateAsync(string usuario, string accion);
        Task LogDeleteAsync(string usuario, string accion);
        Task LogEditAsync(string usuario, string accion);
        Task LogLoginAsync(string usuario);
    }
}

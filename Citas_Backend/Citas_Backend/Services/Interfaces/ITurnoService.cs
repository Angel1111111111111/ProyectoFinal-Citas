using Citas_Backend.Dtos;
using Citas_Backend.Dtos.Turnos;

namespace Citas_Backend.Services.Interfaces
{
    public interface ITurnoService
    {
        Task<ResponseDto<TurnoDto>> CreateTurnoAsync(TurnoCreateDto turnoDto);
        Task<ResponseDto<List<TurnoDto>>> GetTurnosAsync(string searchTerm = "");
    }
}

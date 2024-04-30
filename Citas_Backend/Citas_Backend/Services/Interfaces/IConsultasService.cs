using Citas_Backend.Dtos;
using Citas_Backend.Dtos.Consultas;

namespace Citas_Backend.Services.Interfaces
{
    public interface IConsultasService
    {
        Task<ResponseDto<ConsultaDto>> CreateConsultaAsync(ConsultaCreateDto consultaCreateDto);
        Task<ResponseDto<List<ConsultaDto>>> GetConsultasAsync();
        Task<ResponseDto<ConsultaDto>> GetConsultasByIdAsync(Guid id);
    }
}

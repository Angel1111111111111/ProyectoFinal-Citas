using Citas_Backend.Dtos;
using Citas_Backend.Dtos.Especialidades;

namespace Citas_Backend.Services.Interfaces
{
    public interface IEspecialidadService
    {
        Task<ResponseDto<EspecialidadDto>> CreateAsync(EspecialidadDto especialidadDto);
        Task<ResponseDto<EspecialidadDto>> GetEspecialidadByIdAsync(int id);
        Task<ResponseDto<List<EspecialidadDto>>> GetEspecialidadesAsync();
    }
}

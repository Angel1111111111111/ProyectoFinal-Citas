using Citas_Backend.Dtos;
using Citas_Backend.Dtos.Citas;
using Citas_Backend.Dtos.Especialidades;

namespace Citas_Backend.Services.Interfaces
{
    public interface ICitasService
    {
        Task<ResponseDto<CitasDto>> CreateAsync(CitaCreateDto model);
        Task<ResponseDto<CitasDto>> DeleteAsync(Guid id);
        //Task<ResponseDto<List<EspecialidadDto>>> GetEspecialidadesAsync();
        Task<ResponseDto<List<CitasDto>>> GetListAsync(string searchTerm = "");
        Task<ResponseDto<CitasDto>> GetOneByIdAsync(Guid id);
        Task<ResponseDto<CitasDto>> UpdateAsync(CitasDto dto, Guid id);
    }
}

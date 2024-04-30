using Citas_Backend.Dtos;
using Citas_Backend.Dtos.Doctores;
using Citas_Backend.Dtos.Turnos;

namespace Citas_Backend.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<ResponseDto<bool>> CreateDoctorAsync(DoctorDto doctorDto);
        Task<ResponseDto<bool>> DeleteDoctorAsync(Guid id);
        Task<ResponseDto<List<DoctorDto>>> GetDoctorAsync();
        Task<ResponseDto<List<DoctorDto>>> GetDoctorAsyncByEspecialidad(Guid especialidadId);
        Task<ResponseDto<DoctorDto>> GetDoctorByIdAsync(Guid id);
        Task<ResponseDto<List<TurnoDto>>> GetTurnosAsync();
        Task<ResponseDto<bool>> UpdateDoctorAsync(Guid id, DoctorDto doctorDto);
    }
}

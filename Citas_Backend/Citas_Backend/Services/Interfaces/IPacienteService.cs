using Citas_Backend.Dtos;
using Citas_Backend.Dtos.pacientes;
using Citas_Backend.Dtos.Pacientes;
using Citas_Backend.Entities;

namespace Citas_Backend.Services.Interfaces
{
    public interface IPacienteService
    {
        Task<ResponseDto<List<PacienteDto>>> ObtenerPacienteAsync();
        Task<ResponseDto<PacienteDto>> ObtenerPacienteByIdAsync(Guid id);
        Task<ResponseDto<PacienteDto>> ObtenerPacientePorCorreoElectronicoAsync(string correoElectronico);
        Task<ResponseDto<PacienteDto>> RegistrarPacienteAsync(PacienteCreateDto pacienteDto);
    }
}

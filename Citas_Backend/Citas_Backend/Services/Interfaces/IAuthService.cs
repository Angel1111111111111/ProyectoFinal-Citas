using Citas_Backend.Dtos;
using Citas_Backend.Dtos.Security;

namespace Citas_Backend.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseDto<LoginResponseDto>> LoginAsync(LoginDto dto);
    }
}

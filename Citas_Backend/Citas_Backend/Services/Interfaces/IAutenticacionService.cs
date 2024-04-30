
namespace Citas_Backend.Services.Interfaces
{
    public interface IAutenticacionService
    {
        Task<string> IniciarSesionAsync(string correoElectronico, string contraseña);
    }
}

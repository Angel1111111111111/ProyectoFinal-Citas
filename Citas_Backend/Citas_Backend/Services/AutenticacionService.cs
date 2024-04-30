using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Citas_Backend.Dtos;
using Citas_Backend.Dtos.Security;
using Citas_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Citas_Backend.Services
{
    public class AutenticacionService : IAutenticacionService
    {
        private readonly IPacienteService _pacienteService;
        private readonly string _claveSecreta;

        public AutenticacionService(IPacienteService pacienteService, 
            IConfiguration configuration)
        {
            _pacienteService = pacienteService;
            _claveSecreta = configuration["JWT:Secret"];
        }

        public async Task<string> IniciarSesionAsync(string correoElectronico, string contraseña)
        {
            var pacienteResponse = await _pacienteService.ObtenerPacientePorCorreoElectronicoAsync(correoElectronico);

            if (pacienteResponse.Status && pacienteResponse.Data != null && pacienteResponse.Data.Contraseña == contraseña)
            {
                var paciente = pacienteResponse.Data;

                var authClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, paciente.Id.ToString())
                };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(authClaims),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_claveSecreta)), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }

            return null;
        }
    }
}

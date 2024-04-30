using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Citas_Backend.Dtos.pacientes
{
    public class PacienteDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Identidad { get; set; }
        public string Telefono { get; set; }
        public string Genero { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contraseña { get; set; }
    }
}


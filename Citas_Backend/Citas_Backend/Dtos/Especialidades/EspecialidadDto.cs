using System.ComponentModel.DataAnnotations;

namespace Citas_Backend.Dtos.Especialidades
{
    public class EspecialidadDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}

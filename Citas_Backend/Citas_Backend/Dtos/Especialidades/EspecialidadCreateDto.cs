using System.ComponentModel.DataAnnotations;

namespace Citas_Backend.Dtos.Especialidades
{
    public class EspecialidadCreateDto
    {
        [Display(Name = "nombre")]
        [Required(ErrorMessage = "El {0} es requerido")]
        [StringLength(maximumLength: 255, MinimumLength = 10, ErrorMessage = "El {0} debe tener entre {2} y {1} caracteres")]
        public string Nombre { get; set; }
        
        [Display(Name = "descripcion")]
        public string Descripcion { get; set; }
    }
}

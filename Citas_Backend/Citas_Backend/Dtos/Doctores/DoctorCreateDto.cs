using System;
using System.ComponentModel.DataAnnotations;

namespace Citas_Backend.Dtos.Doctores
{
    public class DoctorCreateDto
    {
        [Display(Name = "nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(maximumLength: 255, MinimumLength = 10, ErrorMessage = "El {0} debe tener entre {2} y {1} caracteres")]
        public string Nombre { get; set; }

        [Required]
        public Guid EspecialidadId { get; set; }

        [Required]
        public Guid TurnoId { get; set; }
    }
}

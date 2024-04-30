using System.ComponentModel.DataAnnotations;

namespace Citas_Backend.Dtos.Pacientes
{
    public class PacienteCreateDto
    {
        [Display(Name = "nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(maximumLength: 255, MinimumLength = 3, ErrorMessage = "El {0} debe tener entre {2} y {1} caracteres")]
        public string Nombre { get; set; }

        [Display(Name = "identidad")]
        [Required(ErrorMessage = "El campo Identidad es obligatorio.")]
        [StringLength(maximumLength: 255, MinimumLength = 3, ErrorMessage = "El {0} debe tener entre {2} y {1} caracteres")]
        public string Identidad { get; set; }

        [Display(Name = "telefono")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(maximumLength: 255, MinimumLength = 3, ErrorMessage = "El {0} debe tener entre {2} y {1} caracteres")]
        public string Telefono { get; set; }

        [Display(Name = "genero")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Genero { get; set; }

        [Display(Name = "Correo Electronico")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo {0} debe ser una dirección de correo electrónico válida.")]
        [StringLength(maximumLength: 255, MinimumLength = 10, ErrorMessage = "El {0} debe tener entre {2} y {1} caracteres")]
        public string CorreoElectronico { get; set; }

        [Display(Name = "contraseña")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "La {0} debe tener al menos {2} caracteres.")]
        public string Contraseña { get; set; }
    }
}

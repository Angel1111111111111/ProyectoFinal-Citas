using System.ComponentModel.DataAnnotations;

namespace Citas_Backend.Dtos.Security
{
    public class LoginDto
    {
        [Display(Name = "Correo Electronico")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public string Email { get; set; }
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public string Password { get; set; }
    }
}

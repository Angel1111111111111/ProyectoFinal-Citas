using System;
using System.ComponentModel.DataAnnotations;

namespace Citas_Backend.Dtos.Logs
{
    public class LogCreateDto
    {
        [Display(Name = "fecha")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime Fecha { get; set; }
        [Display(Name = "accion")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Accion { get; set; }
        
        [Display(Name = "usuario")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Usuario { get; set; }
    }
}
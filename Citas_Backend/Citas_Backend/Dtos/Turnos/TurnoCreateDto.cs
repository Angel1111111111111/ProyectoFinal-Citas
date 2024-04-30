using System.ComponentModel.DataAnnotations;

namespace Citas_Backend.Dtos.Turnos
{
    public class TurnoCreateDto
    {
        [Display(Name = "dia de semana")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public string DiaSemana { get; set; }

        [Display(Name = "hora de inicio")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public DateTime HoraInicio { get; set; }

        [Display(Name = "hora de fin")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public DateTime HoraFin { get; set; }
    }
}

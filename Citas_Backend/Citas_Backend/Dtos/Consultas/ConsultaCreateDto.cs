using System.ComponentModel.DataAnnotations;

namespace Citas_Backend.Dtos.Consultas
{
    public class ConsultaCreateDto
    {
        [Required]
        public Guid CitaId { get; set; }

        [Display(Name = "fecha")]
        [Required(ErrorMessage = "La {0} es requerida")]
        public DateTime Fecha { get; set; }

        [Display(Name = "peso")]
        [Required(ErrorMessage = "El {0} es requerido")]
        public decimal Peso { get; set; }

        [Display(Name = "altura")]
        [Required(ErrorMessage = "La {0} es requerida")]
        public decimal Altura { get; set; }

        [Display(Name = "antecedentes")]
        [Required(ErrorMessage = "Los {0} son requeridos")]
        [StringLength(maximumLength: 255, MinimumLength = 10, ErrorMessage = "Los {0} deben tener entre {2} y {1} caracteres")]
        public string Antecedentes { get; set; }

        [Display(Name = "diagnostico")]
        [Required(ErrorMessage = "El {0} es requerido")]
        [StringLength(maximumLength: 255, MinimumLength = 10, ErrorMessage = "El {0} debe tener entre {2} y {1} caracteres")]
        public string Diagnostico { get; set; }

        [Display(Name = "medicamento")]
        [Required(ErrorMessage = "El {0} es requerido")]
        [StringLength(maximumLength: 255, MinimumLength = 10, ErrorMessage = "El {0} debe tener entre {2} y {1} caracteres")]
        public string Medicamento { get; set; }

        [Display(Name = "motivo_consulta")]
        [Required(ErrorMessage = "El {0} es requerido")]
        [StringLength(maximumLength: 255, MinimumLength = 10, ErrorMessage = "El {0} debe tener entre {2} y {1} caracteres")]
        public string MotivoConsulta { get; set; }

        [Display(Name = "comentario")]
        [StringLength(maximumLength: 255, MinimumLength = 10, ErrorMessage = "El {0} debe tener entre {2} y {1} caracteres")]
        public string Comentario { get; set; }
    }
}

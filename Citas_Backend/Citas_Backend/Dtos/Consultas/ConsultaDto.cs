using System.ComponentModel.DataAnnotations;

namespace Citas_Backend.Dtos.Consultas
{
    public class ConsultaDto
    {
        public Guid Id { get; set; }
        public Guid CitaId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
        public string Antecedentes { get; set; }
        public string Diagnostico { get; set; }
        public string Medicamento { get; set; }
        public string MotivoConsulta { get; set; }
        public string Comentario { get; set; }
    }
}

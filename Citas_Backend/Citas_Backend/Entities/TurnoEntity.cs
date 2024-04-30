using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Citas_Backend.Entities
{
    [Table("turnos", Schema = "cita")]
    public class TurnoEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("dia_semana")]
        public string DiaSemana { get; set; }

        [Required]
        [Column("hora_inicio")]
        public DateTime HoraInicio { get; set; }

        [Required]
        [Column("hora_fin")]
        public DateTime HoraFin { get; set; }
    }
}

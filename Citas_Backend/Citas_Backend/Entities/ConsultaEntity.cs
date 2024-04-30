using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Citas_Backend.Entities
{
    [Table("consultas", Schema = "cita")]
    public class ConsultaEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("cita_id")]
        public Guid CitaId { get; set; }

        [ForeignKey(nameof(CitaId))]
        public virtual CitasEntity Cita { get; set; }

        [Required]
        [Column("fecha")]
        public DateTime Fecha { get; set; }

        [Required]
        [Column("peso")]
        public decimal Peso { get; set; }

        [Required]
        [Column("altura")]
        public decimal Altura { get; set; }

        [Required]
        [Column("antecedentes")]
        [StringLength(250)]
        public string Antecedentes { get; set; }

        [Required]
        [Column("diagnostico")]
        [StringLength(250)]
        public string Diagnostico { get; set; }

        [Required]
        [Column("medicamento")]
        [StringLength(250)]
        public string Medicamento { get; set; }

        [Required]
        [Column("motivo_consulta")]
        [StringLength(250)]
        public string MotivoConsulta { get; set; }

        [Required]
        [Column("comentario")]
        [StringLength(250)]
        public string Comentario { get; set; }
    }
}

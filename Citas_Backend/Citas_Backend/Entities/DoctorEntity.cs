using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Citas_Backend.Entities
{
    [Table("doctores")]
    public class DoctorEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Column("especialidad_id")]
        public Guid EspecialidadId { get; set; }

        [ForeignKey(nameof(EspecialidadId))]
        public virtual EspecialidadEntity Especialidad { get; set; }

        [Column("turno_id")]
        public Guid TurnoId { get; set; }

        [ForeignKey(nameof(TurnoId))]
        public virtual TurnoEntity Turno { get; set; }
    }
}

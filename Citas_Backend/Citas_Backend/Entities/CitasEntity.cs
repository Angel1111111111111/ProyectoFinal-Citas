using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using todo_list_backend.Entities;

namespace Citas_Backend.Entities
{
    [Table("citas", Schema = "cita")]
    public class CitasEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("paciente_id")]
        public Guid PacienteId { get; set; }

        [ForeignKey(nameof(PacienteId))]
        public virtual PacienteEntity Paciente { get; set; }

        [Column("doctor_id")]
        public Guid DoctorId { get; set; }

        [ForeignKey(nameof(DoctorId))]
        public virtual DoctorEntity Doctor { get; set; }

        [Required]
        [Column("fecha")]
        public DateTime Fecha { get; set; }

        [Required]
        [Column("motivo_cita")]
        public string MotivoCita { get; set; }

        [Required]
        [Column("estado")]
        public bool Estado { get; set; }
        
        //[Required]
        //[Column("user_id")]
        //public string userId { get; set; }

        //[ForeignKey(nameof(userId))]
        //public virtual UserEntity User { get; set; }
    }
}

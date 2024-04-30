using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Citas_Backend.Entities
{
    [Table("pacientes", Schema = "cita")]
    public class PacienteEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Required]
        [Column("identidad")]
        public string Identidad { get; set; }

        [Required]
        [Column("telefono")]
        public string Telefono { get; set; }

        //[Required]
        [Column("genero")]
        public string Genero { get; set; }

        [Required]
        [EmailAddress]
        [Column("correo_electronico")]
        public string CorreoElectronico { get; set; }

        [Required]
        [Column("contrasena")]
        public string Contraseña { get; set; }
    }
}
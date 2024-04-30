using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Citas_Backend.Entities
{
    [Table("especialidades", Schema = "cita")]
    public class EspecialidadEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }
        [Required]
        [Column("descripcion")]
        public string Descripcion { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using todo_list_backend.Entities;

namespace Citas_Backend.Entities
{
    [Table("log")]
    public class LogEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        
        [Required]
        [Column("fecha")]
        public DateTime Fecha { get; set; }
        
        [Required]
        [Column("accion")]
        public string Accion { get; set; }
        
        [Required]
        [Column("usuario")]
        public string Usuario { get; set; }
    }
}

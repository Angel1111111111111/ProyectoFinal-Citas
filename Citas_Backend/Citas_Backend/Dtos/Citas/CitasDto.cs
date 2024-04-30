using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Citas_Backend.Dtos.Citas
{
    public class CitasDto
    {
        public Guid Id { get; set; }
        public Guid PacienteId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime Fecha { get; set; }
        public string MotivoCita { get; set; }
        public bool Estado { get; set; }
    }
}

namespace Citas_Backend.Dtos.Doctores
{
    public class DoctorDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public Guid EspecialidadId { get; set; }
        public Guid TurnoId { get; set; }
    }
}

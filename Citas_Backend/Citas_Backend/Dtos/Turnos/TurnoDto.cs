namespace Citas_Backend.Dtos.Turnos
{
    public class TurnoDto
    {
        public Guid Id { get; set; }
        public string DiaSemana { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
    }
}

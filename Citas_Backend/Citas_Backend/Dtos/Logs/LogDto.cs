namespace Citas_Backend.Dtos.Logs
{
    public class LogDto
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; }
        public string Usuario { get; set; }
    }
}

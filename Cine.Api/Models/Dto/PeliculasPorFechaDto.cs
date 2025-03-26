namespace Cine.Api.Models.Dto
{
    public class PeliculasPorFechaDto
    {
        public string? Nombre { get; set; }
        public int Duracion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
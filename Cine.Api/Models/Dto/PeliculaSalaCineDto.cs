namespace Cine.Api.Models.Dto
{
    public class PeliculaSalaCineDto
    {
        public int PeliculaCineId { get; set; }
        public int SalaCineId { get; set; }
        public int PeliculaId { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
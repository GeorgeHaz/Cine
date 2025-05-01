namespace Cine.Api.Models.Dto
{
    public class PeliculaDto
    {
        public int PeliculaId { get; set; }
        public string Nombre { get; set; } = null!;
        public int Duracion { get; set; }
        public DateTime FechaPublicacion { get; set; }

    }
}

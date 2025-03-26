namespace Cine.Api.Models.Dto
{
    public class PeliculaResponseDto
    {
        public int IdPelicula { get; set; }
        public string Nombre { get; set; } = null!;
        public int Duracion { get; set; }

    }
}

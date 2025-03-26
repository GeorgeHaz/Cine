namespace Cine.Api.Models.Dto
{
    public class PeliculaRequestDto
    {
        public int IdPelicula { get; }
        public string Nombre { get; set; } = null!;

        public int Duracion { get; set; }

    }
}

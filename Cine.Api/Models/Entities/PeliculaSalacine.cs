namespace Cine.Api.Models.Entities;

public partial class PeliculaSalacine
{
    public int PeliculaSalaCineId { get; set; }

    public int SalaCineId { get; set; }
    public SalaCine SalaCine { get; set; } = null!;
    public int PeliculaId { get; set; }
    public Pelicula Pelicula { get; set; } = null!;

    public DateTime FechaPublicacion { get; set; }
    public DateTime FechaFin { get; set; }
}

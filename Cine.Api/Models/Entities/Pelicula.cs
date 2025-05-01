namespace Cine.Api.Models.Entities;

public partial class Pelicula : AuditableEntity
{
    public int PeliculaId { get; set; }

    public string Nombre { get; set; } = null!;

    public int Duracion { get; set; }

    public DateTime FechaPublicacion { get; set; }

    public virtual ICollection<PeliculaSalacine> PeliculaSalacines { get; set; } = new List<PeliculaSalacine>();
}
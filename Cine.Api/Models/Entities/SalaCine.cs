namespace Cine.Api.Models.Entities;

public partial class SalaCine
{
    public int IdSalaCine { get; set; }

    public string Nombre { get; set; } = null!;

    public int Estado { get; set; }

    public int Activo { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public virtual ICollection<PeliculaSalacine> PeliculaSalacines { get; set; } = new List<PeliculaSalacine>();
}

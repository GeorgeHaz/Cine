namespace Cine.Api.Models.Entities;

public partial class SalaCine : AuditableEntity
{
    public int SalaCineId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Estado { get; set; } = "Sala disponible";

    public virtual ICollection<PeliculaSalacine> PeliculaSalacines { get; set; } = new List<PeliculaSalacine>();
}

﻿namespace Cine.Api.Models.Entities;

public partial class Pelicula
{
    public int IdPelicula { get; set; }

    public string Nombre { get; set; } = null!;

    public int Duracion { get; set; }

    public int Activo { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public virtual ICollection<PeliculaSalacine> PeliculaSalacines { get; set; } = new List<PeliculaSalacine>();
}
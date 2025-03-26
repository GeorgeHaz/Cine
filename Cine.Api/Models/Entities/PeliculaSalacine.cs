﻿namespace Cine.Api.Models.Entities;

public partial class PeliculaSalacine
{
    public int IdPeliculaSala { get; set; }

    public int IdSalaCine { get; set; }

    public DateOnly FechaPublicacion { get; set; }

    public DateOnly FechaFin { get; set; }

    public int IdPelicula { get; set; }

    public virtual Pelicula IdPeliculaNavigation { get; set; } = null!;

    public virtual SalaCine IdSalaCineNavigation { get; set; } = null!;
}

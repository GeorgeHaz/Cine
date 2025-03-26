using Cine.Api.Models.Dto;
using Cine.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cine.Api.Data;

public partial class CineContext : DbContext
{
    public CineContext()
    {
    }

    public CineContext(DbContextOptions<CineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    public virtual DbSet<PeliculaSalacine> PeliculaSalacines { get; set; }

    public virtual DbSet<SalaCine> SalaCines { get; set; }

    public DbSet<PeliculasPorFechaDto> PeliculasPorFecha {get;set;}
    public DbSet<SalaDisponibleDto> SalaDisponible { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.IdPelicula).HasName("PK__pelicula__B5017F4D5F7AC192");

            entity.ToTable("pelicula");

            entity.Property(e => e.IdPelicula).HasColumnName("id_pelicula");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Duracion).HasColumnName("duracion");
            entity.Property(e => e.FechaEliminacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_eliminacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<PeliculaSalacine>(entity =>
        {
            entity.HasKey(e => e.IdPeliculaSala).HasName("PK__pelicula__39BC477FE217AB26");

            entity.ToTable("pelicula_salacine");

            entity.Property(e => e.IdPeliculaSala).HasColumnName("id_pelicula_sala");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaPublicacion).HasColumnName("fecha_publicacion");
            entity.Property(e => e.IdPelicula).HasColumnName("id_pelicula");
            entity.Property(e => e.IdSalaCine).HasColumnName("id_sala_cine");

            entity.HasOne(d => d.IdPeliculaNavigation).WithMany(p => p.PeliculaSalacines)
                .HasForeignKey(d => d.IdPelicula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pelicula_salacine_pelicula");

            entity.HasOne(d => d.IdSalaCineNavigation).WithMany(p => p.PeliculaSalacines)
                .HasForeignKey(d => d.IdSalaCine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pelicula_salacine_sala_cine");
        });

        modelBuilder.Entity<SalaCine>(entity =>
        {
            entity.HasKey(e => e.IdSalaCine).HasName("PK__sala_cin__83CDE2C12D521000");

            entity.ToTable("sala_cine");

            entity.Property(e => e.IdSalaCine).HasColumnName("id_sala_cine");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaEliminacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_eliminacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<PeliculasPorFechaDto>().HasNoKey();
        modelBuilder.Entity<SalaDisponibleDto>().HasNoKey();
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

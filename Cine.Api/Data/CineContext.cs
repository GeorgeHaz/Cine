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
    public virtual DbSet<SalaCine> SalaCines { get; set; }
    public virtual DbSet<PeliculaSalacine> PeliculaSalacines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.PeliculaId);

            entity.ToTable("pelicula");

            entity.Property(e => e.PeliculaId).HasColumnName("id_pelicula");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.Duracion).HasColumnName("duracion");
            entity.Property(e => e.FechaPublicacion).HasColumnName("fecha_publicacion");
            entity.Property(e => e.AuditDeleteDate).HasColumnName("audit_delete_date");
            entity.Property(e => e.AuditDeleteUser).HasColumnName("audit_delete_user");
        });

        modelBuilder.Entity<SalaCine>(entity =>
        {
            entity.HasKey(e => e.SalaCineId);

            entity.ToTable("sala_cine");

            entity.Property(e => e.SalaCineId).HasColumnName("id_sala");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.AuditDeleteDate).HasColumnName("audit_delete_date");
            entity.Property(e => e.AuditDeleteUser).HasColumnName("audit_delete_user");
        });

        modelBuilder.Entity<PeliculaSalacine>(entity =>
        {
            entity.HasKey(e => e.PeliculaSalaCineId);

            entity.ToTable("pelicula_salacine");

            entity.Property(e => e.PeliculaSalaCineId).HasColumnName("id_pelicula_sala");
            entity.Property(e => e.SalaCineId).HasColumnName("salaCineId");
            entity.Property(e => e.PeliculaId).HasColumnName("peliculaId");
            entity.Property(e => e.FechaPublicacion).HasColumnName("fecha_publicacion");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");


            entity.HasOne(d => d.Pelicula)
                .WithMany(p => p.PeliculaSalacines)
                .HasForeignKey(d => d.PeliculaId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.SalaCine)
                .WithMany(p => p.PeliculaSalacines)
                .HasForeignKey(d => d.SalaCineId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

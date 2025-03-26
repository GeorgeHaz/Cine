using Cine.Api.Data;
using Cine.Api.Models.Dto;
using Cine.Api.Models.Entities;
using Cine.Api.Repository.Intefaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Cine.Api.Repository.Implementaciones
{
    public class PeliculaRepository:IPeliculaRepository
    {
        private readonly CineContext _context;

        public PeliculaRepository(CineContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pelicula>> ListarPeliculas()
        {
            return await _context.Peliculas.Where(p => p.Activo == 1).ToListAsync();
        }

        public async Task<Pelicula?> ObtenerPorId(int id)
        {

            return await _context.Peliculas
                .FirstOrDefaultAsync(p => p.IdPelicula.Equals(id) && p.Activo == 1);
        }

        public async Task<IEnumerable<Pelicula?>> ObtenerPorNombre(string nombrePelicula)
        {
            var parametro = new SqlParameter("@Nombre", nombrePelicula);

            var pelicula = await _context.Peliculas
                .FromSqlRaw("EXEC buscar_pelicula_nombre @Nombre", parametro)
                .ToListAsync();

            return pelicula;
        }

        public async Task<bool> CrearPelicula(Pelicula pelicula)
        {
            await _context.AddAsync(pelicula);
            var registrosAfectados = await _context.SaveChangesAsync();

            return registrosAfectados > 0;
        }

        public async Task<bool> EditarPelicula(Pelicula pelicula)
        {
            _context.Peliculas.Update(pelicula);

            var registrosAfectados = await _context.SaveChangesAsync();

            return registrosAfectados > 0;
        }

        public async Task EliminarPelicula(Pelicula pelicula)
        {
            pelicula.Activo = 0;
            pelicula.FechaEliminacion = DateTime.Now;
            _context.Peliculas.Update(pelicula);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PeliculasPorFechaDto?>> PeliculaPorFecha(DateTime fecha)
        {
            var parametro = new SqlParameter("@Fecha", fecha);

            var pelicula = await _context.PeliculasPorFecha
                .FromSqlRaw("EXEC pelicula_por_fecha_especifica @Fecha", parametro)
                .ToListAsync();
            return pelicula;
        }

        public async Task<SalaDisponibleDto?> SalaDisponible(string nombreSala)
        {
            var parametro = new SqlParameter("@Nombre", nombreSala);

            var sala = _context.SalaDisponible
                .FromSqlRaw("EXEC sala_cine_disponibilidad @Nombre",parametro)
                .AsEnumerable()
                .FirstOrDefault();

            return sala;
        }
    }
}
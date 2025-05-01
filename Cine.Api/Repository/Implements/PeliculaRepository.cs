using Cine.Api.Data;
using Cine.Api.Models.Dto;
using Cine.Api.Models.Entities;
using Cine.Api.Repository.Intefaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Cine.Api.Repository.Implements
{
    public class PeliculaRepository:IPeliculaRepository
    {
        private readonly CineContext _context;

        public PeliculaRepository(CineContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pelicula>> GetAllAsync()
        {
            return await _context.Peliculas
                .Where(e => e.AuditDeleteDate == null)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Pelicula?> GetByIdAsync(int id)
        {
            return await _context.Peliculas
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.PeliculaId == id && e.AuditDeleteDate == null);
        }
        public async Task<IEnumerable<Pelicula>> GetByNombreAsync(string nombre)
        {
            return await _context.Peliculas
                .AsNoTracking()
                .Where(p => p.Nombre.Contains(nombre) && p.AuditDeleteDate == null)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pelicula>> GetByFechaPublicacionAsync(DateTime fecha)
        {
            return await _context.Peliculas
                .FromSqlRaw("EXEC GetPeliculasByFecha @p0",fecha.Date)
                .Where(p => p.AuditDeleteDate == null)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddAsync(Pelicula pelicula)
        {
            await _context.Peliculas.AddAsync(pelicula);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pelicula pelicula)
        {
            _context.Peliculas.Update(pelicula);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Peliculas.FindAsync(id);
            if (entity == null) return;

            entity.AuditDeleteDate = DateTime.UtcNow;
            entity.AuditDeleteUser = 1;

            _context.Peliculas.Update(entity);
            
            await _context.SaveChangesAsync();
        }
    }
}
using Cine.Api.Data;
using Cine.Api.Models.Entities;
using Cine.Api.Repository.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace Cine.Api.Repository.Implements
{
    public class PeliculaSalaCineRepository : IPeliculaSalaCineRepository
    {
        private readonly CineContext _context;

        public PeliculaSalaCineRepository(CineContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PeliculaSalacine>> GetAllAsync()
        {
            return await _context.PeliculaSalacines
                .Include(e => e.Pelicula)
                .Include(e => e.SalaCine)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<PeliculaSalacine?> GetByIdAsync(int id)
        {
            return await _context.PeliculaSalacines
                .Include(e => e.Pelicula)
                .Include(e => e.SalaCine)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.PeliculaSalaCineId == id);
        }
        public async Task<IEnumerable<PeliculaSalacine>> GetFromDateAsync(DateTime fecha)
        {
            return await _context.PeliculaSalacines
                .FromSqlRaw("EXEC dbo.GetPeliculaSalaCineFromDate @p0", fecha.Date)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddAsync(PeliculaSalacine asignacion)
        {
            await _context.PeliculaSalacines.AddAsync(asignacion);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(PeliculaSalacine asignacion)
        {
            _context.PeliculaSalacines.Update(asignacion);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.PeliculaSalacines.FindAsync(id);
            if (entity is null) return;

            _context.PeliculaSalacines.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}

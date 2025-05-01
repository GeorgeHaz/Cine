using Cine.Api.Data;
using Cine.Api.Models.Entities;
using Cine.Api.Repository.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace Cine.Api.Repository.Implements
{
    public class SalaCineRepository : ISalaCineRepository
    {
        private readonly CineContext _context;

        public SalaCineRepository(CineContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SalaCine>> GetAllAsync()
        {
            return await _context.SalaCines
                .Where(e => e.AuditDeleteUser == null)
                .AsNoTracking() 
                .ToListAsync();
        }

        public async Task<SalaCine?> GetByIdAsync(int id)
        {
            return await _context.SalaCines
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.SalaCineId == id && e.AuditDeleteDate == null);
        }

        public async Task<IEnumerable<SalaCine>> GetByNameAsync(string nombre)
        {
            return await _context.SalaCines
                .AsNoTracking()
                .Where(e => e.Nombre.Contains(nombre) && e.AuditDeleteDate == null)
                .ToListAsync();
        }
        public async Task AddAsync(SalaCine sala)
        {
            await _context.SalaCines.AddAsync(sala);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(SalaCine sala)
        {
            _context.SalaCines.Update(sala);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.SalaCines.FindAsync(id);
            if (entity is null) return;

            entity.AuditDeleteDate = DateTime.UtcNow;
            entity.AuditDeleteUser = 1;
            _context.SalaCines.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetPeliculaCountBySalaAsync(int salaCineId)
        {
            return await _context.PeliculaSalacines
                .CountAsync(e => e.SalaCineId == salaCineId);
        }
    }
}

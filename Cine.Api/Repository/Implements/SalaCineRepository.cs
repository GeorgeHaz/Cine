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
                .AsNoTracking() 
                .ToListAsync();
        }

        public async Task<SalaCine?> GetByIdAsync(int id)
        {
            return await _context.SalaCines
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.SalaCineId == id);
        }

        public async Task<IEnumerable<SalaCine>> GetByNameAsync(string nombre)
        {
            return await _context.SalaCines
                .AsNoTracking()
                .Where(e => e.Nombre.Contains(nombre))
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

            _context.SalaCines.Remove(entity);
            await _context.SaveChangesAsync();
        }

    }
}

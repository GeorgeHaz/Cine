using Cine.Api.Models.Entities;

namespace Cine.Api.Repository.Intefaces
{
    public interface IPeliculaSalaCineRepository
    {
        Task<IEnumerable<PeliculaSalacine>> GetAllAsync();
        Task<PeliculaSalacine?> GetByIdAsync(int id);
        Task<IEnumerable<PeliculaSalacine>> GetFromDateAsync(DateTime fecha);
        Task AddAsync(PeliculaSalacine asignacion);
        Task UpdateAsync(PeliculaSalacine asignacion);
        Task DeleteAsync(int id);
    }
}

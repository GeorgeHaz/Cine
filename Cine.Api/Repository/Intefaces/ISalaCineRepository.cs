using Cine.Api.Models.Entities;

namespace Cine.Api.Repository.Intefaces
{
    public interface ISalaCineRepository
    {
        Task<IEnumerable<SalaCine>> GetAllAsync();
        Task<SalaCine?> GetByIdAsync(int id);
        Task<IEnumerable<SalaCine>> GetByNameAsync(string nombre);
        Task AddAsync(SalaCine sala);
        Task UpdateAsync(SalaCine sala);
        Task DeleteAsync(int id);
        Task<int> GetPeliculaCountBySalaAsync(int salaCineId);
    }
}

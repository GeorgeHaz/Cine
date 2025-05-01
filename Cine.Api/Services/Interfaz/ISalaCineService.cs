using Cine.Api.Models.Dto;

namespace Cine.Api.Services.Interfaz
{
    public interface ISalaCineService
    {
        Task<IEnumerable<SalaCineDto>> GetAllAsync();
        Task<SalaCineDto?> GetByIdAsync(int id);
        Task<IEnumerable<SalaCineDto>> SearchByNameAsync(string nombre);
        Task<SalaCineDto> CreateAsync(SalaCineDto dto);
        Task<bool> UpdateAsync(SalaCineDto dto);
        Task<bool> DeleteAsync(int id);
    }
}

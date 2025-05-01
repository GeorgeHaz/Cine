using Cine.Api.Models.Dto;

namespace Cine.Api.Services.Interfaz
{
    public interface IPeliculaSalaCineService
    {
        Task<IEnumerable<PeliculaSalaCineDto>> GetAllAsync();
        Task<PeliculaSalaCineDto?> GetByIdAsync(int id);
        Task<PeliculaSalaCineDto> CreateAsync(PeliculaSalaCineDto dto);
        Task<bool> UpdateAsync(PeliculaSalaCineDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<PeliculaSalaCineDto>> SearchFromDateAsync(DateTime fecha);
    }
}

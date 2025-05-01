using Cine.Api.Models.Dto;

namespace Cine.Api.Services.Interfaz
{
    public interface IPeliculaService
    {
        Task<IEnumerable<PeliculaDto>> GetAllAsync();
        Task<PeliculaDto?> GetByIdAsync(int id);
        Task<IEnumerable<PeliculaDto>> SearchAsync(string? nombre, DateTime? fecha);
        Task<PeliculaDto> CreateAsync(PeliculaDto dto);
        Task<bool> UpdateAsync(PeliculaDto dto);
        Task<bool> DeleteAsync(int id);
    }
}

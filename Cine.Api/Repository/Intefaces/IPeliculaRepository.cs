using Cine.Api.Models.Dto;
using Cine.Api.Models.Entities;

namespace Cine.Api.Repository.Intefaces
{
    public interface IPeliculaRepository
    {
        Task<IEnumerable<Pelicula>> GetAllAsync();
        Task<Pelicula?> GetByIdAsync(int id);
        Task<IEnumerable<Pelicula>> GetByNombreAsync(string nombre);
        Task<IEnumerable<Pelicula>> GetByFechaPublicacionAsync(DateTime fecha);
        Task AddAsync(Pelicula pelicula);
        Task UpdateAsync(Pelicula pelicula);
        Task DeleteAsync(int id);
    }
}
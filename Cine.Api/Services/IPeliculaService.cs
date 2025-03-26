using Cine.Api.Models;
using Cine.Api.Models.Dto;

namespace Cine.Api.Services
{
    public interface IPeliculaService
    {
        Task CrearPelicula(PeliculaRequestDto requestDto);
        Task<bool> EditarPelicula(int id, PeliculaRequestDto requestDto);
        Task<bool> EliminarPelicula(int id);
        Task<IEnumerable<PeliculaResponseDto>> ListarPeliculas();
        Task<IEnumerable<PeliculasPorFechaDto?>> PeliculaPorFecha(DateTime fecha);
        Task<PeliculaResponseDto> PeliculaPorId(int id);
        Task<IEnumerable<PeliculaResponseDto?>> PeliculaPorNombre(string peliculaNombre);
        Task<string> SalaDisponible(string nombreSala);
    }
}
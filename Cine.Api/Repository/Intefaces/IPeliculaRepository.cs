using Cine.Api.Models.Dto;
using Cine.Api.Models.Entities;

namespace Cine.Api.Repository.Intefaces
{
    public interface IPeliculaRepository
    {
        Task<bool> CrearPelicula(Pelicula pelicula);
        Task<bool> EditarPelicula(Pelicula pelicula);
        Task EliminarPelicula(Pelicula pelicula);
        Task<IEnumerable<Pelicula>> ListarPeliculas();
        Task<IEnumerable<Pelicula?>> ObtenerPorNombre(string nombrePelicula);
        Task<Pelicula?> ObtenerPorId(int id);
        Task<IEnumerable<PeliculasPorFechaDto?>> PeliculaPorFecha(DateTime fecha);
        Task<SalaDisponibleDto?> SalaDisponible(string nombreSala);
    }
}
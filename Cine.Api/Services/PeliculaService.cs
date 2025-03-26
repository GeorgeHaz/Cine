using Cine.Api.Models.Dto;
using Cine.Api.Models.Entities;
using Cine.Api.Repository.Intefaces;

namespace Cine.Api.Services
{
    public class PeliculaService:IPeliculaService
    {
        private readonly IPeliculaRepository _repository;
        public PeliculaService(IPeliculaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PeliculaResponseDto>> ListarPeliculas()
        {
            var pelicula = await _repository.ListarPeliculas();

            return pelicula.Select(p => new PeliculaResponseDto
            {
                IdPelicula = p.IdPelicula,
                Nombre = p.Nombre,
                Duracion = p.Duracion
            });
        }

        public async Task<PeliculaResponseDto?> PeliculaPorId(int peliculaId)
        {
            var pelicula = await _repository.ObtenerPorId(peliculaId);
            if (pelicula is null) return null;

            var response = new PeliculaResponseDto 
            { 
                IdPelicula = pelicula.IdPelicula, 
                Nombre = pelicula.Nombre, 
                Duracion = pelicula.Duracion 
            };

            return response;
        }

        public async Task<IEnumerable<PeliculaResponseDto>> PeliculaPorNombre(string peliculaNombre)
        {
            var pelicula = await _repository.ObtenerPorNombre(peliculaNombre);
            if (!pelicula.Any()) return Enumerable.Empty<PeliculaResponseDto>();

            var response = pelicula.Select(p => new PeliculaResponseDto
            {
                IdPelicula = p.IdPelicula,
                Nombre = p.Nombre,
                Duracion = p.Duracion
            });

            return response;
        }

        public async Task CrearPelicula(PeliculaRequestDto requestDto)
        {
            var pelicula = new Pelicula
            {
                Nombre = requestDto.Nombre,
                Duracion = requestDto.Duracion,
                Activo = 1,
                FechaEliminacion = null
            };

            await _repository.CrearPelicula(pelicula);
        }

        public async Task<bool> EditarPelicula(int id, PeliculaRequestDto requestDto)
        {

            var pelicula = await _repository.ObtenerPorId(id);
            if (pelicula is null) return false;
            

            pelicula.Nombre = requestDto.Nombre;
            pelicula.Duracion = requestDto.Duracion;

            await _repository.EditarPelicula(pelicula);

            return true;
            
        }
        public async Task<bool> EliminarPelicula(int id)
        {
            var pelicula = await _repository.ObtenerPorId(id);
            if (pelicula is null) return false;

            await _repository.EliminarPelicula(pelicula);

            return true;
        }

        public async Task<IEnumerable<PeliculasPorFechaDto?>> PeliculaPorFecha(DateTime fecha)
        {
            var response = await _repository.PeliculaPorFecha(fecha);

            return response;
        }

        public async Task<string> SalaDisponible(string nombreSala)
        {
            var response = await _repository.SalaDisponible(nombreSala);

            return response?.Mensaje ?? "No se pudo obtener la disponibilidad";
        }
    }
}
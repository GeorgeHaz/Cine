using Cine.Api.Models.Dto;
using Cine.Api.Models.Entities;
using Cine.Api.Repository.Intefaces;
using Cine.Api.Services.Interfaz;

namespace Cine.Api.Services.Repository
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaRepository _repository;

        public PeliculaService(IPeliculaRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<PeliculaDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var dtos = new List<PeliculaDto>();
            foreach (var p in entities)
            {
                dtos.Add(new PeliculaDto
                {
                    PeliculaId = p.PeliculaId,
                    Nombre = p.Nombre,
                    Duracion = p.Duracion,
                    FechaPublicacion = p.FechaPublicacion
                });
            }

            return dtos;
        }

        public async Task<PeliculaDto?> GetByIdAsync(int id)
        {
            var p = await _repository.GetByIdAsync(id);
            if (p == null) return null;
            return new PeliculaDto
            {
                PeliculaId = p.PeliculaId,
                Nombre = p.Nombre,
                Duracion = p.Duracion,
                FechaPublicacion = p.FechaPublicacion
            };
        }

        public async Task<IEnumerable<PeliculaDto>> SearchAsync(string? nombre, DateTime? fecha)
        {
            IEnumerable<Pelicula> list;
            if (!string.IsNullOrEmpty(nombre))
            {
                list = await _repository.GetByNombreAsync(nombre);
            }
            else if (fecha.HasValue)
            {
                list = await _repository.GetByFechaPublicacionAsync(fecha.Value);
            }
            else
            {
                throw new ArgumentException("Debe especificar nombre o fecha para la busqueda.");
            }
            return list.Select(e => new PeliculaDto
            {
                PeliculaId = e.PeliculaId,
                Nombre = e.Nombre,
                Duracion = e.Duracion,
                FechaPublicacion = e.FechaPublicacion
            });   
        }

        public async Task<PeliculaDto> CreateAsync(PeliculaDto dto)
        {
            var entity = new Pelicula
            {
                Nombre = dto.Nombre,
                Duracion = dto.Duracion,
                FechaPublicacion = dto.FechaPublicacion
            };
            await _repository.AddAsync(entity);
            return new PeliculaDto
            {
                PeliculaId = entity.PeliculaId,
                Nombre = entity.Nombre,
                Duracion = entity.Duracion,
                FechaPublicacion = entity.FechaPublicacion
            };
        }

        public async Task<bool> UpdateAsync(PeliculaDto dto)
        {
            var existing = await _repository.GetByIdAsync(dto.PeliculaId);
            if (existing is null) return false;
            existing.Nombre = dto.Nombre;
            existing.Duracion = dto.Duracion;
            existing.FechaPublicacion = dto.FechaPublicacion;

            await _repository.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing is null) return false;

            await _repository.DeleteAsync(id);
            return false;
        }
    }
}

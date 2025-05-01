using Cine.Api.Models.Dto;
using Cine.Api.Models.Entities;
using Cine.Api.Repository.Intefaces;
using Cine.Api.Services.Interfaz;

namespace Cine.Api.Services.Repository
{
    public class PeliculaSalaCineService : IPeliculaSalaCineService
    {
        private readonly IPeliculaSalaCineRepository _repository;

        public PeliculaSalaCineService(IPeliculaSalaCineRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<PeliculaSalaCineDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            var dtos = new List<PeliculaSalaCineDto>();
            foreach(var p in list)
            {
                dtos.Add(new PeliculaSalaCineDto
                {
                    PeliculaCineId = p.PeliculaSalaCineId,
                    SalaCineId = p.SalaCineId,
                    PeliculaId = p.PeliculaId,
                    FechaPublicacion = p.FechaPublicacion,
                    FechaFin = p.FechaFin
                });
            }
            return dtos;
        }

        public async Task<PeliculaSalaCineDto?> GetByIdAsync(int id)
        {
            var pelicula = await _repository.GetByIdAsync(id);
            if (pelicula is null) return null;

            return new PeliculaSalaCineDto
            {
                PeliculaCineId = pelicula.PeliculaSalaCineId,
                SalaCineId = pelicula.SalaCineId,
                PeliculaId = pelicula.PeliculaId,
                FechaPublicacion = pelicula.FechaPublicacion,
                FechaFin = pelicula.FechaFin
            };
        }

        public async Task<IEnumerable<PeliculaSalaCineDto>> SearchFromDateAsync(DateTime fecha)
        {
            var entities = await _repository.GetFromDateAsync(fecha);
            return entities.Select(p => new PeliculaSalaCineDto
            {
                PeliculaCineId = p.PeliculaSalaCineId,
                SalaCineId = p.SalaCineId,
                PeliculaId = p.PeliculaId,
                FechaPublicacion = p.FechaPublicacion,
                FechaFin = p.FechaFin
            });
        }
        public async Task<PeliculaSalaCineDto> CreateAsync(PeliculaSalaCineDto dto)
        {
            var entity = new PeliculaSalacine
            {
                SalaCineId = dto.SalaCineId,
                PeliculaId = dto.PeliculaId,
                FechaPublicacion = dto.FechaPublicacion,
                FechaFin = dto.FechaFin
            };
            await _repository.AddAsync(entity);
            return new PeliculaSalaCineDto
            {
                PeliculaCineId = entity.PeliculaSalaCineId,
                SalaCineId = entity.SalaCineId,
                PeliculaId = entity.PeliculaId,
                FechaPublicacion = entity.FechaPublicacion,
                FechaFin = entity.FechaFin
            };
        }

        public async Task<bool> UpdateAsync(PeliculaSalaCineDto dto)
        {
            var existing = await _repository.GetByIdAsync(dto.PeliculaCineId);
            if(existing is null) return false;

            existing.SalaCineId = dto.SalaCineId;
            existing.PeliculaId = dto.PeliculaId;
            existing.FechaPublicacion = dto.FechaPublicacion;
            existing.FechaFin = dto.FechaFin;

            await _repository.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing is null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}

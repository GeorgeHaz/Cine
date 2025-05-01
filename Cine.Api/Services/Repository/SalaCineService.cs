using Cine.Api.Models.Dto;
using Cine.Api.Models.Entities;
using Cine.Api.Repository.Intefaces;
using Cine.Api.Services.Interfaz;

namespace Cine.Api.Services.Repository
{
    public class SalaCineService : ISalaCineService
    {
        private readonly ISalaCineRepository _repository;

        public SalaCineService(ISalaCineRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<SalaCineDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var dtos = new List<SalaCineDto>();
            foreach (var s in entities)
            {
                dtos.Add(new SalaCineDto
                {
                    SalaCineId = s.SalaCineId,
                    Nombre = s.Nombre,
                    Estado = s.Estado
                });
            }
            return dtos;
        }

        public async Task<SalaCineDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null) return null;

            return new SalaCineDto
            {
                SalaCineId = entity.SalaCineId,
                Nombre = entity.Nombre,
                Estado = entity.Estado
            };
        }

        public async Task<IEnumerable<SalaCineDto>> SearchByNameAsync(string nombre)
        {
            var list = await _repository.GetByNameAsync(nombre);
            var dtos = new List<SalaCineDto>();
            foreach(var s in list)
            {
                dtos.Add(new SalaCineDto
                {
                    SalaCineId = s.SalaCineId,
                    Nombre = s.Nombre,
                    Estado = s.Estado
                });
            }
            return dtos;
        }
        public async Task<SalaCineDto> CreateAsync(SalaCineDto dto)
        {
            var entity = new SalaCine
            {
                Nombre = dto.Nombre,
                Estado = dto.Estado
            };
            await _repository.AddAsync(entity);
            return new SalaCineDto
            {
                SalaCineId = entity.SalaCineId,
                Nombre = entity.Nombre,
                Estado = entity.Estado
            };
        }
        public async Task<bool> UpdateAsync(SalaCineDto dto)
        {
            var existing = await _repository.GetByIdAsync(dto.SalaCineId);
            if (existing is null) return false;
            existing.Nombre = dto.Nombre;
            existing.Estado = dto.Estado;

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

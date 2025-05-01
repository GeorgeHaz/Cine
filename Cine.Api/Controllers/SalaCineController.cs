using Cine.Api.Models.Dto;
using Cine.Api.Services.Interfaz;
using Microsoft.AspNetCore.Mvc;

namespace Cine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaCineController : ControllerBase
    {
        private readonly ISalaCineService _service;

        public SalaCineController(ISalaCineService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ListarSalaCine()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("BuscarPorId/{salaCineId}")]
        public async Task<IActionResult> ObtenerPorId(int salaCineId)
        {
            var response = await _service.GetByIdAsync(salaCineId);
            if (response is null) return NotFound();

            return Ok(response);
        }

        [HttpGet("BuscarPorNombre/{salaCineNombre}")]
        public async Task<IActionResult> ObtenerPorNombre([FromQuery] string? salaCineNombre)
        {
            var response = await _service.SearchByNameAsync(salaCineNombre!);

            return Ok(response);
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> CrearSalaCine([FromBody] SalaCineDto requestDto)
        {
            await _service.CreateAsync(requestDto);

            return Ok("Sala Creada");
        }

        [HttpPut("Editar/{salaCineId:int}")]
        public async Task<IActionResult> EditarPelicula(int salaCineId, [FromBody] SalaCineDto requestDto)
        {
            if (salaCineId != requestDto.SalaCineId) return BadRequest("Id no encontrado");

            await _service.UpdateAsync(requestDto);
            return Ok("Editado con exito");
        }

        [HttpPut("Eliminar/{salaCineId:int}")]
        public async Task<IActionResult> Eliminar(int salaCineId)
        {
            await _service.DeleteAsync(salaCineId);
            return Ok("Eliminado con exito");
        }
    }
}

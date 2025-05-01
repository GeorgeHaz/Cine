using Cine.Api.Models.Dto;
using Cine.Api.Services.Interfaz;
using Microsoft.AspNetCore.Mvc;

namespace Cine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaSalaCineController : ControllerBase
    {
        private readonly IPeliculaSalaCineService _service;

        public PeliculaSalaCineController(IPeliculaSalaCineService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ListarPeliculaSalaCine()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("BuscarPorId/{peliculaSalaCineId}")]
        public async Task<IActionResult> ObtenerPorId(int peliculaSalaCineId)
        {
            var response = await _service.GetByIdAsync(peliculaSalaCineId);
            if (response is null) return NotFound();

            return Ok(response);
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> CrearSalaCine([FromBody] PeliculaSalaCineDto requestDto)
        {
            await _service.CreateAsync(requestDto);

            return Ok("Creado con exito");
        }

        [HttpGet("Buscar/desde")]
        public async Task<ActionResult<IEnumerable<PeliculaSalaCineDto>>> BuscarDesdeFecha([FromQuery] DateTime fecha)
        {
            var dtos = await _service.SearchFromDateAsync(fecha);
            return Ok(dtos);
        }

        [HttpPut("Editar/{peliculaSalaCineId:int}")]
        public async Task<IActionResult> EditarPelicula(int peliculaSalaCineId, [FromBody] PeliculaSalaCineDto requestDto)
        {
            if (peliculaSalaCineId != requestDto.PeliculaCineId) return BadRequest("Id no encontrado");

            await _service.UpdateAsync(requestDto);
            return Ok("Editado con exito");
        }

        [HttpPut("Eliminar/{peliculaSalaCineId:int}")]
        public async Task<IActionResult> Eliminar(int peliculaSalaCineId)
        {
            await _service.DeleteAsync(peliculaSalaCineId);
            return Ok("Eliminado con exito");
        }
    }
}

using Cine.Api.Models.Dto;
using Cine.Api.Services.Interfaz;
using Microsoft.AspNetCore.Mvc;

namespace Cine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaService _service;

        public PeliculaController(IPeliculaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeliculaDto>>> ListarPelicula()
        {
            var response = await _service.GetAllAsync();
            if (response is null) return NotFound();

            return Ok(response);
        }

        [HttpGet("BuscarPorId/{peliculaId}")]
        public async Task<ActionResult<PeliculaDto>> ObtenerPorId(int peliculaId)
        {
            var response = await _service.GetByIdAsync(peliculaId);
            if (response is null) return NotFound();

            return Ok(response);
        }

        [HttpGet("BuscarPorNombre/{peliculaNombre}")]
        public async Task<IActionResult> ObtenerPorNombre([FromQuery] string? peliculaNombre, [FromQuery] DateTime? fecha)
        {
            try
            {
                var response = await _service.SearchAsync(peliculaNombre, fecha);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Registrar")]
        public async Task<ActionResult<PeliculaDto>> CrearPelicula([FromBody]PeliculaDto requestDto)
        {
            await _service.CreateAsync(requestDto);

            return Ok("Pelicula Creada");
        }

        [HttpPut("Editar/{peliculaId:int}")]
        public async Task<IActionResult> EditarPelicula(int peliculaId,[FromBody] PeliculaDto requestDto)
        {
            if (peliculaId != requestDto.PeliculaId) return BadRequest("Id no encontrado");

            await _service.UpdateAsync(requestDto);
            return Ok("Editado con exito");
        }

        [HttpPut("Eliminar/{peliculaId:int}")]
        public async Task<IActionResult> Eliminar(int peliculaId)
        {
            await _service.DeleteAsync(peliculaId);
            return Ok("Eliminado con exito");
        }
    }
}

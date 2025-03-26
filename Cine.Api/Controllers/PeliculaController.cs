using Cine.Api.Models.Dto;
using Cine.Api.Services;
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
        public async Task<IActionResult> ListarPelicula()
        {
            var response = await _service.ListarPeliculas();

            return Ok(response);
        }

        [HttpGet("BuscarPorId/{peliculaId}")]
        public async Task<IActionResult> ObtenerPorId(int peliculaId)
        {
            var response = await _service.PeliculaPorId(peliculaId);

            return Ok(response);
        }

        [HttpGet("BuscarPorNombre/{peliculaNombre}")]
        public async Task<IActionResult> ObtenerPorNombre(string peliculaNombre)
        {
            var response = await _service.PeliculaPorNombre(peliculaNombre);

            return Ok(response);
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> CrearPelicula([FromBody]PeliculaRequestDto requestDto)
        {
            await _service.CrearPelicula(requestDto);

            return Ok("Pelicula Creada");
        }

        [HttpPut("Editar/{peliculaId:int}")]
        public async Task<IActionResult> EditarPelicula(int peliculaId,[FromBody] PeliculaRequestDto requestDto)
        {
            await _service.EditarPelicula(peliculaId, requestDto);
            return Ok("Editado con exito");
        }

        [HttpPut("Eliminar/{peliculaId:int}")]
        public async Task<IActionResult> Eliminar(int peliculaId)
        {
            await _service.EliminarPelicula(peliculaId);
            return Ok("Eliminado con exito");
        }

        [HttpGet("BuscarPorFecha/{peliculaPorFecha}")]
        public async Task<IActionResult> ObtenerPorFecha(DateTime peliculaPorFecha)
        {
            var response = await _service.PeliculaPorFecha(peliculaPorFecha);

            return Ok(response);
        }

        [HttpGet("BuscarDisponiblidadSala/{nombreSala}")]
        public async Task<IActionResult> ObtenerSala(string nombreSala)
        {
            var response = await _service.SalaDisponible(nombreSala);

            return Ok(new {response});
        }
    }
}

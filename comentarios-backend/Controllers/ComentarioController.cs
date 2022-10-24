using comentarios_backend.DTO;
using comentarios_backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace comentarios_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private IComentarioService _comentarioService;
        public ComentarioController(IComentarioService comentarioService)
        {
            _comentarioService = comentarioService;
        }

        // GET: api/<ComentarioController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var listado = await _comentarioService.ListadoComentario();
            return Ok(listado);
        }

        // GET api/<ComentarioController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _comentarioService.ComentarioPorId(id);
            return result == null? NotFound(): Ok(result);
        }

        // POST api/<ComentarioController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ComentarioDto request)
        {
            var result = await _comentarioService.NuevoComentario(request);
            return result == null ? NotFound() : Ok(result);
        }

        // PUT api/<ComentarioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ComentarioDto request)
        {
            var result = await _comentarioService.ActualizarComentario(id, request);
            return result == null ? NotFound() : Ok(result);
        }

        // DELETE api/<ComentarioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _comentarioService.EliminarComentario(id);
            return !result? NotFound() : Ok();
        }
    }
}

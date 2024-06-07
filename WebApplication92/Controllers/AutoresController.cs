using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplication92.Services;

namespace WebApplication92.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {

        private readonly IAutorServices _autorServices;

        public AutoresController(IAutorServices autorServices)
        {
            _autorServices = autorServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAutores()
        {
            return Ok(await _autorServices.GetAutores());
        }

        [HttpPost("CrearAutor")]

        public async Task<IActionResult> CrearAutor([FromBody] Autor autor)
        {
            return Ok(await _autorServices.CrearAutor(autor));
        }

        [HttpPut("EditarAutor/{id}")]

        public async Task<IActionResult> EditarAutor(int id, [FromBody] Autor autor)
        {
            var result = await _autorServices.EditarAutor(id, autor);
            return Ok(result);
        }

        [HttpDelete("DeleteAutor/{id}")]
        public async Task<ActionResult<Response<int>>> DeleteAutor(int id)
        {
            var result = await _autorServices.DeleteAutor(id);
            return Ok(result);
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetByIdAutor(int id)
        {
            return Ok(await _autorServices.GetByIdAutor(id));
        }
    }
}

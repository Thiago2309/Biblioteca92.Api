using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplication92.Services;

namespace WebApplication92.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosServices _usuariosServices;
        public UsuariosController(IUsuariosServices usuariosServices)
        {
            _usuariosServices = usuariosServices;
        }

        [HttpGet]

        public async Task<IActionResult> GetUsuarios()
        {
            var response = await _usuariosServices.GetUsuarios();

            return Ok(response);
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetById(int id) 
        {
            return Ok(await _usuariosServices.GetById(id));
        }

        [HttpPost("CrearUsuario")]

        public async Task<IActionResult> Crear([FromBody] UsuarioResponse request)
        {
            var response = await _usuariosServices.CrearUsuario(request);
            return Ok(response);
        }


        [HttpDelete("DeleteUsuario/{id}")]
        public async Task<ActionResult<Response<int>>> DeleteUsuarios(int id)
        {
            var result = await _usuariosServices.DeleteUsuario(id);
            return Ok(result);
        }


        [HttpPut("UpdateUsuario/{id}")]
        public async Task<ActionResult<Response<int>>> UpdateUsuarios(int id, [FromBody] UsuarioResponse request)
        {

            var result = await _usuariosServices.UpdateUsuario(id, request);
            return Ok(result);
        }
    }
}

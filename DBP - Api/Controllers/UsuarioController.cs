using DBP___Api.Models;
using DBP___Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DBP___Api.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuario _usuario;
        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuario.GetAllUser());
        }
        [HttpPost("agregar")]
        public IActionResult Add(Cliente client)
        {
            _usuario.add(client);
            return CreatedAtAction(nameof(Add), client);
        }

        [HttpDelete("Eliminar/{id}")]
        public IActionResult delete(int id)
        {
            _usuario.remove(id);
            return NoContent();
        }

        [HttpPut("Modificar")]
        public IActionResult modificarDetalles(Cliente client)
        {
            _usuario.editDetails(client);
            return CreatedAtAction(nameof(modificarDetalles), client);
        }


    }
}

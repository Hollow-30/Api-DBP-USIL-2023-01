using DBP___Api.Models;
using DBP___Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DBP___Api.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class MarcasController : Controller
    {
        private readonly IMarcas _marcas;
        public MarcasController(IMarcas marcas)
        {
            _marcas = marcas;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_marcas.GetAllMarcas());
        }
        [HttpPost("agregar")]
        public IActionResult add(Marca marc)
        {
            _marcas.add(marc);
            return CreatedAtAction(nameof(add), marc);
        }

        [HttpDelete("Eliminar/{id}")]
        public IActionResult delete(int id)
        {
            _marcas.remove(id);
            return NoContent();
        }

        [HttpPut("Modificar")]
        public IActionResult modificarDetalles(Marca marc)
        {
            _marcas.editDetails(marc);
            return CreatedAtAction(nameof(modificarDetalles), marc);
        }

    }
}

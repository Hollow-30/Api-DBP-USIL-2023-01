using DBP___Api.Models;
using DBP___Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DBP___Api.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class ProductosController : Controller
    {
        private readonly IProducto _producto;
        public ProductosController(IProducto producto)
        {
            _producto = producto;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_producto.GetAllProducts());
        }
        [HttpGet("productos/hombre")]
        public IActionResult GetProdHombre()
        {
            return Ok(_producto.GetAllProductsHombre());
        }
        [HttpGet("productos/mujer")]
        public IActionResult GetProdMujer ()
        {
            return Ok(_producto.GetAllProductsMujer());
        }
        [HttpPost("agregar")]
        public IActionResult add(Tbproducto producto)
        {
            _producto.add(producto);
            return CreatedAtAction(nameof(add), producto);
        }

        [HttpDelete("Eliminar/{id}")]
        public IActionResult delete(int id)
        {
            _producto.remove(id);
            return NoContent();
        }

        [HttpPut("Modificar")]
        public IActionResult modificarDetalles(Tbproducto producto)
        {
            _producto.editDetails(producto);
            return CreatedAtAction(nameof(modificarDetalles), producto);
        }
        [HttpGet("{id}")]
        public IActionResult GetProd(int id)
        {
            var obj = _producto.GetProducto(id);
            if (obj == null)
            {
                return NotFound("El Producto(" + id.ToString() + ") no existe");
            }
            else
            {
                return Ok(obj);
            }
        }

    }
}

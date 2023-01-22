using BLL.Productos;
using DTO_Comunes.DtoRequest;
using DTO_Comunes.DtoResponse;
using Microsoft.AspNetCore.Mvc;
using MODELS.Models;

namespace Tarea.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        [HttpPost]
        public async Task <IActionResult> AgregarProducto(DtoProductoRequest producto)
        {
            ResponseObject responseObject= new() ;
            try
            {
                responseObject = await ProductosBll.AgregarProducto(producto);
                if (responseObject.HasError)
                {
                    throw new Exception();
                }
                return Ok(responseObject);
            }
            catch (Exception )
            {

                return BadRequest(responseObject);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AgregarCategoria(DtoCategoria categoria)
        {
            ResponseObject responseObject = new();
            try
            {
                responseObject = await CategoriaPresentacion.CrearCategoria(categoria);
                if (responseObject.HasError)
                {
                    throw new Exception();
                }
                return Ok(responseObject);
            }
            catch (Exception)
            {
                return BadRequest(responseObject);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AgregarPresentacionProducto(DtoPresentacionProducto presentacionProducto)
        {
            ResponseObject responseObject = new();
            try
            {
                responseObject = await CategoriaPresentacion.CrearPresentacion(presentacionProducto);
                if (responseObject.HasError)
                {
                    throw new Exception();
                }
                return Ok(responseObject);
            }
            catch (Exception)
            {
                return BadRequest(responseObject);
            }
        }
        [HttpGet]
        public async Task<IActionResult> ConsultarProductos(int idProducto=0)
        {
            ResponseObject responseObject = new();

            try
            {
                responseObject = await ProductosBll.ConsultarProductos (idProducto);
                if (responseObject.HasError)
                {
                    throw new Exception();
                }
                return Ok(responseObject);
            }
            catch (Exception)
            {
                return BadRequest(responseObject);
            }

        }
        [HttpDelete]
        public async Task<IActionResult> EliminarProducto(int idProducto = 0)
        {
            ResponseObject responseObject = new();

            try
            {
                responseObject = await ProductosBll.EliminarProductos_Bll(idProducto);
                if (responseObject.HasError)
                {
                    throw new Exception();
                }
                return Ok(responseObject);
            }
            catch (Exception)
            {
                return BadRequest(responseObject);
            }

        }
        [HttpPut]
        public async Task<IActionResult> ActivarProducto(int idProducto = 0)
        {
            ResponseObject responseObject = new();

            try
            {
                responseObject = await ProductosBll.ActivarProducto_BLL(idProducto);
                if (responseObject.HasError)
                {
                    throw new Exception();
                }
                return Ok(responseObject);
            }
            catch (Exception)
            {
                return BadRequest(responseObject);
            }

        }
    }

}

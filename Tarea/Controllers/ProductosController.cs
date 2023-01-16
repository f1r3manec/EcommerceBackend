using BLL.Productos;
using DTO_Comunes.DtoRequest;
using DTO_Comunes.DtoResponse;

using Microsoft.AspNetCore.Mvc;

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

                responseObject = await AgregarProductoBLL.AgregarProducto(producto);
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
        
    }
}

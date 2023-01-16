using DTO_Comunes.DtoResponse;
using Microsoft.AspNetCore.Mvc;
using BLL.Contenido;

namespace Tarea.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContenidoController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetCategoriasProductos ()
        {
            
            try
            {
                return Ok(await Contenido.GetListaCategoria());
            }
            catch (Exception ex)
            {
                ResponseObject response = new();
                response.MensajeError = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPresentacionesProductos()
        {
            try
            {
                return Ok(await Contenido.GetListaPresentaciones());
            }
            catch (Exception ex)
            {
                ResponseObject response = new();
                response.MensajeError = ex.Message;
                return BadRequest(response);
            }
        }
    }
}

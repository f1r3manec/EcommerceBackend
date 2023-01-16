using BLL.Inventario;
using DTO_Comunes.DtoRequest;
using Microsoft.AspNetCore.Mvc;

namespace Tarea.Controllers
{
    public class InventarioController : Controller
    {
        public IActionResult AddMovimientoInventario(DtoMovimientoInventario movimiento )
        {
            
            try
            {
                 
                return Ok(MovimientoInventario.MovimeintoInventarioBLL(movimiento));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        
        }
    }
}

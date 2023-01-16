using DTO_Comunes.DtoRequest;
using DTO_Comunes.DtoResponse;
using MODELS.Models;

namespace DAT.Inventario
{
    public class Inventario
    {
        public static async Task<ResponseObject> AgregarMovimientoInventario(DtoMovimientoInventario movimiento)
        {
            ResponseObject respuesta = new ResponseObject();
            using (var db = new PrEcomerseContext())
            {
                var transaccion = db.Database.BeginTransaction();
                try
                {
                    var insert = new StockProducto
                    {
                        IntCantidadMovimiento = movimiento.Cantidad,
                        IntIdStockProducto = movimiento.IdProducto
                    };
                    await db.AddAsync(insert);
                    await db.SaveChangesAsync();
                    movimiento.IdMovimiento = insert.IntIdMovimientoStock;
                    transaccion.Commit();
                    respuesta.Payload= movimiento;
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    respuesta.HasError= true;
                    respuesta.MensajeError=ex.Message;
                }
            }
            return respuesta;
        }
    }
}

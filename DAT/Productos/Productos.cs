using DTO_Comunes.DtoRequest;
using DTO_Comunes.DtoResponse;
using MODELS.Models;


namespace DAT.Productos
{
    public class Productos
    {

        public static async Task<ResponseObject> AgregarProducto(DtoProductoRequest producto)
        {
            ResponseObject response = new ResponseObject();
            using (var objContext = new PrEcomerseContext())
            {
                var transaccion = objContext.Database.BeginTransaction();
                try
                { 
                    var insert = new Producto
                    {
                        StrDescripcionProducto = producto.DescripcionProducto,
                        IntIdCategoriaProducto = producto.IdCategoria,
                        IntIdPresentacionProducto = producto.IdPresentacion,
                    };
                    await objContext.AddAsync(insert);
                    await objContext.SaveChangesAsync();
                    producto.IdProducto = insert.IntIdProduto;

                    DtoMovimientoInventario movimientoInventario= new DtoMovimientoInventario{ 
                        Cantidad = producto.Cantidad_Producto,
                        IdProducto= producto.IdProducto,
                    };
                    
                    ResponseObject movimientoInventarioSave   = await Inventario.Inventario.AgregarMovimientoInventario(movimientoInventario);
                    if (movimientoInventarioSave.HasError)
                    {
                        transaccion.Rollback();
                        response.HasError = true;
                        response.MensajeError = movimientoInventarioSave.MensajeError;

                    }
                    else
                    {
                        response.Payload = movimientoInventarioSave.Payload;
                        transaccion.Commit();
                    }

                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    response.HasError = true;
                    response.MensajeError = ex.Message;
                }
                return response;
            }
        }
      
    }
}


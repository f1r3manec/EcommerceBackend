using DTO_Comunes.DtoRequest;
using DTO_Comunes.DtoResponse;
using MODELS.Models;


namespace DAT.Productos
{
    public class Productos
    {
        /// <summary>
        /// Agrega producto en base de datos y valor inicial de procutos
        /// </summary>
        /// <param name="producto">O</param>
        /// <returns>ResponseObject</returns>
        public static async Task<ResponseObject> AgregarProducto(DtoProductoRequest producto)
        {
            ResponseObject response = new ResponseObject();
            using (var objContext = new PrEcomerseContext())
            {
                // var transaccion = objContext.Database.BeginTransaction();
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
                        // transaccion.Rollback();
                        response.HasError = true;
                        response.MensajeError = movimientoInventarioSave.MensajeError;

                    }
                    else
                    {
                        response.Payload = movimientoInventarioSave.Payload;
                        // transaccion.Commit();
                    }

                }
                catch (Exception ex)
                {
                    // transaccion.Rollback();
                    response.SetErrorDtoResponse(ex);                    
                }
                return response;
            }
        }

        /// <summary>
        /// Devuelve catalogo de productos con su cantidad en stock
        /// </summary>
        /// <param name="IdProducto"></param>
        /// <returns>Retorna Response Object con lista de productos sea 1 o varios</returns>
        public static async Task<ResponseObject> ConsultarProductos(int IdProducto=0)
        {
            ResponseObject response = new ResponseObject();
            List<DtoProductosResponse> productos = new();
            using (var db= new PrEcomerseContext())
            {
                try
                {
                    if (IdProducto == 0)
                    {
                        productos = (from p in db.Productos
                                     from c in db.CategoriaProductos
                                     from pre in db.PresentacionProductos
                                     where p.IntIdPresentacionProducto == pre.IntIdPresentacionProducto && p.IntIdCategoriaProducto == c.IntIdCategoriaProducto
                                     select new DtoProductosResponse
                                     {
                                         IdProducto = p.IntIdProduto,
                                         NombreProducto = p.StrNombreProducto!,
                                         DescripcionProducto = p.StrDescripcionProducto!,
                                         IdCategoria = c.IntIdCategoriaProducto,
                                         Categoria = c.StrNombreCategoria!,
                                         IdPresentacion = pre.IntIdPresentacionProducto,
                                         Presentacion = pre.StrDescripcionPresentacion!,
                                         Stock = (int) (from s in db.StockProductos where p.IntIdProduto == s.IntIdStockProducto 
                                                  select s.IntCantidadMovimiento).Sum()!
                                   }

                                   ).ToList();
                    }
                    else
                    {
                        productos = (from p in db.Productos
                                     from c in db.CategoriaProductos
                                     from pre in db.PresentacionProductos
                                     where p.IntIdPresentacionProducto == pre.IntIdPresentacionProducto 
                                            && p.IntIdCategoriaProducto == c.IntIdCategoriaProducto
                                            && p.IntIdProduto==IdProducto
                                     select new DtoProductosResponse
                                     {
                                         IdProducto = p.IntIdProduto,
                                         NombreProducto = p.StrNombreProducto!,
                                         DescripcionProducto = p.StrDescripcionProducto!,
                                         IdCategoria = c.IntIdCategoriaProducto,
                                         Categoria = c.StrNombreCategoria!,
                                         IdPresentacion = pre.IntIdPresentacionProducto,
                                         Presentacion = pre.StrDescripcionPresentacion!,
                                         Stock = (int)(from s in db.StockProductos
                                                       where p.IntIdProduto == s.IntIdStockProducto
                                                       select s.IntCantidadMovimiento).Sum()!
                                     }).ToList();
                    }
                }
                catch (Exception ex)
                {

                    response.SetErrorDtoResponse(ex);
                }

            }

            return response;
        }
      
    }
}


using DTO_Comunes.DtoRequest;
using DTO_Comunes.DtoResponse;
using DTO_Comunes.Servicios;
using Microsoft.EntityFrameworkCore;
using MODELS.Models;
using System.Data;

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
                        StrNombreProducto= producto.NombreProducto,
                        StrDescripcionProducto = producto.DescripcionProducto,
                        IntIdCategoriaProducto = producto.IdCategoria,
                        IntIdPresentacionProducto = producto.IdPresentacion,
                        MonValorCostoUnitario=producto.Costo_unitario,
                        BitActivo=producto.ProductoActivo,
                        BitGravaIva=producto.GrabaIva,
                        IntPorcentajeGanancia=producto.PorcentajeMargenGanancia,
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
        public static async Task<ResponseObject> ConsultarProductos(int IdProducto)
        {
            ResponseObject response = new ResponseObject();
            List<DtoProductosResponse> productos = new();
            using (var db= new PrEcomerseContext())
            {
                try
                {
                    if (IdProducto == 0)
                    {
                        productos = await (from p in db.Productos
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
                                               GrabaIva = p.BitGravaIva,
                                               CostoUnitario = p.MonValorCostoUnitario,
                                               MargenGananacia = p.IntPorcentajeGanancia,
                                               ProductoActivo = p.BitActivo,
                                               CostoCliente = CalculosImpuestosCostos.CalcularCostoCliente(p.MonValorCostoUnitario, p.BitGravaIva, p.IntPorcentajeGanancia),
                                               Stock=0
                                           }).ToListAsync();
              

                    }
                    else
                    {
                        productos = await (from p in db.Productos
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
                                         GrabaIva = p.BitGravaIva,
                                         CostoUnitario = p.MonValorCostoUnitario,
                                         MargenGananacia = p.IntPorcentajeGanancia,
                                         ProductoActivo = p.BitActivo!,
                                         CostoCliente = CalculosImpuestosCostos.CalcularCostoCliente(p.MonValorCostoUnitario, p.BitGravaIva, p.IntPorcentajeGanancia),
                                         Stock = (int)(from s in db.StockProductos
                                                       where p.IntIdProduto == s.IntIdStockProducto
                                                       select s.IntCantidadMovimiento).Sum()!
                                     }).ToListAsync();
                        if (productos.Count() == 0 )
                        {
                            throw new SystemException("Producto No Existe");
                        }
                    }

                    response.Payload = productos;
                }
                catch (Exception ex)
                {

                    response.SetErrorDtoResponse(ex);
                }

            }

            return response;
        }

        /// <summary>
        /// Eliminado Lógico de producto
        /// </summary>
        /// <param name="IdProducto"></param>
        /// <returns></returns>
        public static async Task<ResponseObject> EliminarProducto(int IdProducto)
        {
            ResponseObject respuesta = new ResponseObject();
            using (var db = new PrEcomerseContext())
            
            {
                try
                {
                    Producto producto = await (from p in db.Productos where p.IntIdProduto.Equals(IdProducto) select p).FirstOrDefaultAsync();
                    if (producto == null)
                    {
                        throw new SystemException("Producto no existente");
                    }
                    producto!.BitActivo = false;
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    respuesta.SetErrorDtoResponse(ex);
                }
            }
            return respuesta;
        }
        /// <summary>
        /// Activa producto que esté deshabilitado
        /// </summary>
        /// <param name="IdProducto"></param>
        /// <returns></returns>
        public static async Task<ResponseObject> ActivarProducto(int IdProducto)
        {
            ResponseObject respuesta = new ResponseObject();
            using (var db = new PrEcomerseContext())

            {
                try
                {
                    Producto producto = await (from p in db.Productos where p.IntIdProduto.Equals(IdProducto) select p).FirstOrDefaultAsync();
                    if (producto == null) 
                    {
                        throw new SystemException("Producto no existente");
                    }
                    producto!.BitActivo = true;
                    await db.SaveChangesAsync();
                    
                }
                catch (Exception ex)
                {
                    respuesta.SetErrorDtoResponse(ex);
                }
            }
            return respuesta;
        }
    }
}


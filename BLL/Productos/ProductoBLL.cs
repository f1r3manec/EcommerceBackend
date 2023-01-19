
using DTO_Comunes.StructHelpers;
using DTO_Comunes.DtoRequest;
using DTO_Comunes.DtoResponse;
using DTO_Comunes;

namespace BLL.Productos
{
    public  class ProductosBll

    {
        /// <summary>
        /// Método para validar lógica de negocio sobre el producto a agregar
        /// </summary>
        /// <param name="producto">Dto de tipo producto </param>
        /// <returns>ResponseObjec con los datos del proceso</returns>
        public static async Task<ResponseObject> AgregarProducto(DtoProductoRequest producto)
        {
            ResponseObject respuesta = new();
            try
			{
                if (!Validadores.ValidaStrings(producto.NombreProducto, 8))
                {
                    throw new Exception("Error en la validación del nombre del producto, valide campo");
                }
                if (!Validadores.ValidaStrings(producto.DescripcionProducto, 15))
                {
                    throw new Exception("Error en la validación de la descripción del producto, valide campo");
                }
                if (!Validadores.ValidaCantidadEnteros(producto.Cantidad_Producto,GenericoStruct.PresentaCionProductos.MayoresCero)){
                    throw new Exception("Error en la cantidad del producto, valide campo");
                }
                respuesta = await DAT.Productos.Productos.AgregarProducto(producto);
            }
			catch (Exception ex)
			{
				respuesta.SetErrorDtoResponse(ex);
			}
            return respuesta;
        }

        public static async Task<ResponseObject>ConsultarProductos(int idProducto = 0)
        {
            ResponseObject respuesta = new();
            try
            {
                respuesta = await DAT.Productos.Productos.ConsultarProductos(idProducto);
            }
            catch (Exception ex)
            {
                respuesta.SetErrorDtoResponse(ex);
            }
            return respuesta;   
        }

        public static async Task<ResponseObject> EliminarProductos_Bll(int idProducto = 0)
        {
            ResponseObject respuesta = new();
            try
            {
                respuesta = await DAT.Productos.Productos.EliminarProducto(idProducto);
            }
            catch (Exception ex)
            {
                respuesta.SetErrorDtoResponse(ex);
            }
            return respuesta;
        }
        public static async Task<ResponseObject> ActivarProducto_BLL(int idProducto = 0)
        {
            ResponseObject respuesta = new();
            try
            {
                respuesta = await DAT.Productos.Productos.ActivarProducto(idProducto);
            }
            catch (Exception ex)
            {
                respuesta.SetErrorDtoResponse(ex);
            }
            return respuesta;
        }

    }
}

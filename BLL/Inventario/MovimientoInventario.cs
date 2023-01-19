
using DTO_Comunes;
using DTO_Comunes.DtoRequest;
using DTO_Comunes.DtoResponse;
using DTO_Comunes.StructHelpers;

namespace BLL.Inventario
{
    public  class MovimientoInventario
    {
        /// <summary>
        /// Valida datos para generar moviemiento de inventario
        /// </summary>
        /// <param name="movimientoInventario"></param>
        /// <returns>ResponseObjec con los datos del proceso</returns>
        public static async Task<ResponseObject> MovimeintoInventarioBLL(DtoMovimientoInventario movimientoInventario)
        {
            ResponseObject respuesta = new();
            try
			{
                respuesta= await DAT.Inventario.Inventario.AgregarMovimientoInventario(movimientoInventario);
                if (!Validadores.ValidaCantidadEnteros(movimientoInventario.Cantidad, GenericoStruct.PresentaCionProductos.DiferentesDeCero))
                {
                    throw new Exception("Error en la cantidad del producto, valide campo");
                }
                respuesta = await DAT.Inventario.Inventario.AgregarMovimientoInventario(movimientoInventario);

            }
			catch (Exception ex)
			{
				respuesta.SetErrorDtoResponse(ex);
			}
            return respuesta;
        }
    }
}

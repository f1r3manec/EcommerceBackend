using DTO_Comunes.DtoRequest;
using DTO_Comunes.DtoResponse;


namespace BLL.Inventario
{
    public  class MovimientoInventario
    {
        public static async Task<ResponseObject> MovimeintoInventarioBLL(DtoMovimientoInventario movimientoInventario)
        {
			try
			{
                return await DAT.Inventario.Inventario.AgregarMovimientoInventario(movimientoInventario);

            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}

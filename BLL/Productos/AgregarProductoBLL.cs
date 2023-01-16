using DTO_Comunes.DtoRequest;
using DTO_Comunes.DtoResponse;


namespace BLL.Productos
{
    public  class AgregarProductoBLL
    {
        public static async Task<ResponseObject> AgregarProducto(DtoProductoRequest producto)
        {
			try
			{
                return await DAT.Productos.Productos.AgregarProducto(producto);

            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}

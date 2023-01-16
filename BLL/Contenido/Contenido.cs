using DTO_Comunes.DtoResponse;

using DAT.Contenido;

namespace BLL.Contenido
{
    public class Contenido
    {
        public static async Task<ResponseObject> GetListaCategoria()
        {
			try
			{
                return await ContenidoCatalogos.GetCategorias();

            }
			catch (Exception)
			{

				throw;
			}
        }
        public static async Task<ResponseObject> GetListaPresentaciones()
        {
            try
            {
                return await ContenidoCatalogos.GetPresentaciones();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

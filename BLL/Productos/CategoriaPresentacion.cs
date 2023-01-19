using DAT.Productos;
using DTO_Comunes;
using DTO_Comunes.DtoRequest;
using DTO_Comunes.DtoResponse;


namespace BLL.Productos
{
    public class CategoriaPresentacion
    {
        /// <summary>
        /// Valida categoría a agergar
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>ResponseObjec con los datos del proceso</returns>
        public static async Task<ResponseObject> CrearCategoria(DtoCategoria categoria)
        {
            ResponseObject respuesta = new();
            try
            {
     
                if(!Validadores.ValidaStrings(categoria.CategoriaDescripcion,4))
                {
                    throw new Exception("Error en la validación de la descripción de categoria, valide campo");
                }
                respuesta = await Categorias.AgregarCategoria(categoria);

            }
            catch (Exception ex )
            {
                respuesta.SetErrorDtoResponse(ex)   ;
            }
            return respuesta;
        }
        /// <summary>
        /// Valida presentación de producto a agregar
        /// </summary>
        /// <param name="presentacionProducto"></param>
        /// <returns>ResponseObjec con los datos del proceso</returns>
        public static async Task<ResponseObject> CrearPresentacion(DtoPresentacionProducto presentacionProducto)
        {
            ResponseObject respuesta = new();
            try
            {
                if (!Validadores.ValidaStrings(presentacionProducto.DescriptionPresentacion, 10))
                {
                    throw new Exception("Error en la validación de la descripción de presentación del producto, valide campo");
                }
                respuesta = await PresentacionProcuto.AgregarPresentacionProducto(presentacionProducto);
            }
            catch (Exception ex)
            {
                respuesta.SetErrorDtoResponse(ex);
            }
            return respuesta;
        }
    }
    
}

using DTO_Comunes.DtoRequest;
using DTO_Comunes.DtoResponse;
using MODELS.Models;


namespace DAT.Productos
{
    public class Categorias
    {
        /// <summary>
        /// Agrega categoría de producto
        /// </summary>
        /// <param name="categoria">Dto Categoría</param>
        /// <returns>ResponseObjec con los datos del proceso</returns>
        public static async Task<ResponseObject> AgregarCategoria(DtoCategoria categoria)
        {
            ResponseObject response = new ResponseObject();

            using (var db = new PrEcomerseContext())
            {
                var transaccion = db.Database.BeginTransaction();
                try
                {
                    var insert = new CategoriaProducto
                    {
                        StrNombreCategoria = categoria.CategoriaDescripcion
                    };
                    await db.AddAsync(insert);
                    await db.SaveChangesAsync();
                    transaccion.Commit();
                    categoria.CategoriaId = insert.IntIdCategoriaProducto;
                    response.Payload = categoria;

                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    response.SetErrorDtoResponse(ex);
                }
                return response;
            }

        }
    }


    public class PresentacionProcuto
    {
        /// <summary>
        /// Agrega tipo de presentación
        /// </summary>
        /// <param name="presentacionProducto">DTOPresentación</param>
        /// <returns>ResponseObjec con los datos del proceso</returns>
        public static async Task<ResponseObject> AgregarPresentacionProducto(DtoPresentacionProducto presentacionProducto)
        {
            ResponseObject response = new ResponseObject();
            using (var db = new PrEcomerseContext())
            {
                var transaccion = db.Database.BeginTransaction();
                try
                {

                    var insert = new MODELS.Models.PresentacionProducto
                    {
                        StrDescripcionPresentacion = presentacionProducto.DescriptionPresentacion
                    };
                    await db.AddAsync(insert);
                    await db.SaveChangesAsync();
                    transaccion.Commit();
                    presentacionProducto.IdPresentacion = insert.IntIdPresentacionProducto;
                    response.Payload = presentacionProducto;
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    response.SetErrorDtoResponse(ex);
                }
            }
            return response;
        }


    }
}

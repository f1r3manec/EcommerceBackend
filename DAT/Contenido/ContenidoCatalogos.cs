using Azure;
using DTO_Comunes.DtoResponse;
using MODELS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT.Contenido
{
    public class ContenidoCatalogos
    {
        /// <summary>
        /// Retorna Catalogo de categorias
        /// </summary>
        /// <returns></returns>
        public static async Task<ResponseObject> GetCategorias()
        {
            ResponseObject respuesta= new();
            try
            {
                using (var objectConection = new PrEcomerseContext())
                {
                    respuesta.Payload = await Task.FromResult((from p in objectConection.CategoriaProductos select new DtoComboBoxListados
                    {
                        IdItem=p.IntIdCategoriaProducto,
                        Descripcion=p.StrNombreCategoria

                    }).ToList());
                }

            }
            catch (Exception ex)
            {
                respuesta.SetErrorDtoResponse(ex);
            }
            return respuesta;



        }
        /// <summary>
        /// Retorna catalogo de presentaciones de productos
        /// </summary>
        /// <returns>ResponseObjec con los datos del proceso</returns>

        public static async Task<ResponseObject> GetPresentaciones()
        {
            ResponseObject respuesta = new();
            try
            {
                using (var objectConection = new PrEcomerseContext())
                {
                    respuesta.Payload = await Task.FromResult((from p in objectConection.PresentacionProductos select new DtoComboBoxListados
                    {
                        IdItem = p.IntIdPresentacionProducto,
                        Descripcion = p.StrDescripcionPresentacion!

                    }).ToList());
                }
              
            }
            catch (Exception ex)
            {
                respuesta.SetErrorDtoResponse(ex);
            }
            return respuesta;

        }
    }
}

using Azure;
using DTO_Comunes.DtoResponse;
using MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT.Contenido
{
    public class ContenidoCatalogos
    {
        
        public static async Task<ResponseObject> GetCategorias()
        {
            ResponseObject respuesta= new();
            try
            {
                using (var objectConection = new PrEcomerseContext())
                {
                    respuesta.Payload = await Task.FromResult((from p in objectConection.CategoriaProductos select p).ToList());
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.HasError= true;
                respuesta.MensajeError= ex.Message;
                return respuesta;
            }

            
        }

        public  static async Task<ResponseObject> GetPresentaciones()
        {
            ResponseObject respuesta = new();
            try
            {
                using (var objectConection = new PrEcomerseContext())
                {
                    respuesta.Payload = await Task.FromResult((from p in objectConection.PresentacionProductos select p).ToList());
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.HasError = true;
                respuesta.MensajeError = ex.Message;
                return respuesta;
            }


        }
    }
}

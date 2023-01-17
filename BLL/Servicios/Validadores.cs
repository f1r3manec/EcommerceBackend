using DAT.Productos;
using DTO_Comunes.StructHelpers;
using MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class Validadores
    {
        /// <summary>
        /// Método valida Strings que no estén vacios, nulos  y que la longitud sea mayor a la que se pase por parámetro 
        /// </summary>
        /// <param name="descriocionValidar">String a validar </param>
        /// <param name="longitudValidacion">Longitud a validar de la cadena</param>
        /// <returns>ResponseObjec con los datos del proceso</returns>
        public static bool ValidaStrings (string descriocionValidar, int longitudValidacion)
        {
            bool blValidacionString = true;
            if (descriocionValidar== null || String.IsNullOrEmpty(descriocionValidar.Trim()) || descriocionValidar.Trim().Length < longitudValidacion)
            {
                blValidacionString = false;

            }
            return blValidacionString;
        }
        /// <summary>
        /// Metodo para validar cantidades, se a en productos o ingresados o movimientos de stock 
        /// /// </summary>
        /// <param name="cantidad"> Cantidad productos</param>
        /// <param name="tipo">Enumerable de tipo de validacion de enteros Mayores a Cero o diferentes de 0</param>
        /// <returns>ResponseObjec con los datos del proceso</returns>
        public static bool ValidaCantidadEnteros(int cantidad, GenericoStruct.PresentaCionProductos tipo)
        {
            bool blnCantidad = true;
            switch (tipo)
            {
                case GenericoStruct.PresentaCionProductos.MayoresCero :
                    if (cantidad < 1) blnCantidad = false;
                    break
                        ;
                case GenericoStruct.PresentaCionProductos.DiferentesDeCero:
                    if(cantidad ==0) blnCantidad = false; 
                    break;
                default:
                    blnCantidad = false; 
                    break;
            }
            return blnCantidad;



        }
    }
}

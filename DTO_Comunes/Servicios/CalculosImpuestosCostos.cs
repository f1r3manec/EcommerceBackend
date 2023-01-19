using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DTO_Comunes.StructHelpers.GenericoStruct;

namespace DTO_Comunes.Servicios
{
    public class CalculosImpuestosCostos
    {
        /// <summary>
        /// Calcula valor de costo al cliente 
        /// </summary>
        /// <param name="costoCliente">valor costo negocio </param>
        /// <param name="gravaIva">Si Grava o no IVA </param>
        /// <param name="porcentajeGanancia">margen ganancia</param>
        /// <returns></returns>
        public static decimal CalcularCostoCliente (decimal costoCliente, bool gravaIva, int porcentajeGanancia )
        {
            decimal iva = gravaIva?Math.Round( ((decimal)Impuestos.IVA/100),2) : 0;
            decimal dcCostoBase = (costoCliente + (costoCliente * iva));
            decimal dcPorcentajeGanancia =Math.Round( ((decimal)porcentajeGanancia / 100),2);
            decimal temp = dcCostoBase * dcPorcentajeGanancia;
                return (temp + dcCostoBase);

        }
    }
}

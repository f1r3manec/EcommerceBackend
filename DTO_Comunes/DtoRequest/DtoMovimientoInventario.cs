using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Comunes.DtoRequest
{
    public class DtoMovimientoInventario
    {
        public int IdMovimiento { get; set; }
        [Required]
        public int IdProducto{ get; set; }
        [Required]
        public int Cantidad { get; set; }

    }
}

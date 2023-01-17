using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Comunes.DtoRequest
{
    public class DtoProductoRequest
    {
        public int IdProducto { get; set; }
        [Required]
        public string  NombreProducto { get; set; }

        [Required]
        public string  DescripcionProducto { get; set; }

        [Required]
        public int IdCategoria { get; set; }
        [Required]
        public int  IdPresentacion { get;set; }

        [Required]  
        public int Cantidad_Producto { get; set; }

    }
}

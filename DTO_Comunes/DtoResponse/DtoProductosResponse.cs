using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Comunes.DtoResponse
{
    public class DtoProductosResponse
    {
        [Required]
        public int IdProducto { get; set; }
        [Required]
        public string  NombreProducto { get; set; }
        
        [Required] 
        public string DescripcionProducto { get; set; }
        [Required] 
        public int IdCategoria { get; set; }
        [Required] 
        public string Categoria { get; set; }   
        [Required]
        public int IdPresentacion { get;set; }
        [Required]
        public string Presentacion { get;set; }
        [Required]
        public int Stock { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Comunes.DtoRequest
{
    public class DtoCategoria
    {
        
        public int CategoriaId { get;set; }
        [Required]
        public string CategoriaDescripcion { get;set; }    

    }
}

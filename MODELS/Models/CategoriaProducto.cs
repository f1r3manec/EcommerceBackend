using System;
using System.Collections.Generic;

namespace MODELS.Models;

public partial class CategoriaProducto
{
    public int IntIdCategoriaProducto { get; set; }

    public string? StrNombreCategoria { get; set; }

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}

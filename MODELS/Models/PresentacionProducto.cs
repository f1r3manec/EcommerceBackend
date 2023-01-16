using System;
using System.Collections.Generic;

namespace MODELS.Models;

public partial class PresentacionProducto
{
    public int IntIdPresentacionProducto { get; set; }

    public string? StrDescripcionPresentacion { get; set; }

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}

using System;
using System.Collections.Generic;

namespace MODELS.Models;

public partial class Producto
{
    public int IntIdProduto { get; set; }

    public string? StrNombreProducto { get; set; }

    public string? StrDescripcionProducto { get; set; }

    public int? IntIdPresentacionProducto { get; set; }

    public int? IntIdCategoriaProducto { get; set; }

    public virtual CategoriaProducto? IntIdCategoriaProductoNavigation { get; set; }

    public virtual PresentacionProducto? IntIdPresentacionProductoNavigation { get; set; }

    public virtual ICollection<StockProducto> StockProductos { get; } = new List<StockProducto>();
}

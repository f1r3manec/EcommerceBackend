using System;
using System.Collections.Generic;

namespace MODELS.Models;

public partial class Producto
{
    public int IntIdProduto { get; set; }

    public string StrNombreProducto { get; set; } = null!;

    public string StrDescripcionProducto { get; set; } = null!;

    public int IntIdPresentacionProducto { get; set; }

    public int IntIdCategoriaProducto { get; set; }

    public bool BitGravaIva { get; set; }

    public decimal MonValorCostoUnitario { get; set; }

    public short IntPorcentajeGanancia { get; set; }

    public bool BitActivo { get; set; }

    public virtual CategoriaProducto IntIdCategoriaProductoNavigation { get; set; } = null!;

    public virtual PresentacionProducto IntIdPresentacionProductoNavigation { get; set; } = null!;

    public virtual ICollection<StockProducto> StockProductos { get; } = new List<StockProducto>();


}

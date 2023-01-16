using System;
using System.Collections.Generic;

namespace MODELS.Models;

public partial class StockProducto
{
    public int IntIdMovimientoStock { get; set; }

    public int? IntCantidadMovimiento { get; set; }

    public int? IntIdStockProducto { get; set; }

    public virtual Producto? IntIdStockProductoNavigation { get; set; }
}

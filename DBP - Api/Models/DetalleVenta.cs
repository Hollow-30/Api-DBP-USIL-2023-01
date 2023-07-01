using System;
using System.Collections.Generic;

namespace DBP___Api.Models;

public partial class DetalleVenta
{
    public int IdVentaDetalle { get; set; }

    public int? IdVenta { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Total { get; set; }

    public virtual Tbproducto? IdProductoNavigation { get; set; }

    public virtual Ventum? IdVentaNavigation { get; set; }
}

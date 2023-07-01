using System;
using System.Collections.Generic;

namespace DBP___Api.Models;

public partial class Ventum
{
    public int IdVenta { get; set; }

    public int? IdCliente { get; set; }

    public string? Direccion { get; set; }

    public decimal? MontoTotal { get; set; }

    public string? Telefono { get; set; }

    public DateTime? FechaVenta { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Cliente? IdClienteNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace DBP___Api.Models;

public partial class Tbproducto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public int? IdMarca { get; set; }

    public int? IdCategoria { get; set; }

    public decimal? Precio { get; set; }

    public int? Stock { get; set; }

    public string? RutaImagen { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual Marca? IdMarcaNavigation { get; set; }
}

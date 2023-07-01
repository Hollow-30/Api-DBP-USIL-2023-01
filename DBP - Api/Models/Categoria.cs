using System;
using System.Collections.Generic;

namespace DBP___Api.Models;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Tbproducto> Tbproductos { get; set; } = new List<Tbproducto>();
}

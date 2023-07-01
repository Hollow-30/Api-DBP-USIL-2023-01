﻿using System;
using System.Collections.Generic;

namespace DBP___Api.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? Correo { get; set; }

    public string? Clave { get; set; }

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}

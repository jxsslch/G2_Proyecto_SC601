using System;
using System.Collections.Generic;

namespace G2_Proyecto_SC601.Models;

public partial class Provincium
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Canton> Cantons { get; set; } = new List<Canton>();

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}

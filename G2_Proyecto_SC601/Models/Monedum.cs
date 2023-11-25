using System;
using System.Collections.Generic;

namespace G2_Proyecto_SC601.Models;

public partial class Monedum
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();
}

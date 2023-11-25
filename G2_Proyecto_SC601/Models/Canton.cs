using System;
using System.Collections.Generic;

namespace G2_Proyecto_SC601.Models;

public partial class Canton
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int? ProvinciaId { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Provincium? Provincia { get; set; }
}

using System;
using System.Collections.Generic;

namespace G2_Proyecto_SC601.Models;

public partial class Empresa
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int NumTelefono { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}

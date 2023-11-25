using System;
using System.Collections.Generic;

namespace G2_Proyecto_SC601.Models;

public partial class Cliente
{
    public int Cedula { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int NumTelefono { get; set; }

    public int? EmpresaId { get; set; }

    public int? ProvinciaId { get; set; }

    public int? CantonId { get; set; }

    public virtual Canton? Canton { get; set; }

    public virtual Empresa? Empresa { get; set; }

    public virtual Provincium? Provincia { get; set; }

    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();
}

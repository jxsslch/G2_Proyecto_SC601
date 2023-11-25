using System;
using System.Collections.Generic;

namespace G2_Proyecto_SC601.Models;

public partial class Transaccione
{
    public int Id { get; set; }

    public int? ClienteId { get; set; }

    public int? LenguajeId { get; set; }

    public int? MonedaId { get; set; }

    public int? MetodoPagoId { get; set; }

    public decimal Monto { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Lenguaje? Lenguaje { get; set; }

    public virtual MetodoPago? MetodoPago { get; set; }

    public virtual Monedum? Moneda { get; set; }
}

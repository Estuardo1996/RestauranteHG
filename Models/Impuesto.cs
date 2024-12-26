using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class Impuesto
{
    public int ImpuestoId { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Porcentaje { get; set; }

    public int EstadoId { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual Estado Estado { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class Combo
{
    public int ComboId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int EstadoId { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual ICollection<DetalleCombo> DetalleCombos { get; set; } = new List<DetalleCombo>();

    public virtual Estado Estado { get; set; } = null!;
}

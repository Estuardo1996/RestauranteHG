using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class DetalleCombo
{
    public int DetalleComboId { get; set; }

    public int ComboId { get; set; }

    public int ProductoId { get; set; }

    public decimal Cantidad { get; set; }

    public int EstadoId { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual Combo Combo { get; set; } = null!;

    public virtual Estado Estado { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}

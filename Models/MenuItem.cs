using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class MenuItem
{
    public int MenuItemId { get; set; }

    public int MenuId { get; set; }

    public int ProductoId { get; set; }

    public decimal Precio { get; set; }

    public int EstadoId { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual Menu Menu { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class RecetaDetalle
{
    public int RecetaDetalleId { get; set; }

    public int RecetaId { get; set; }

    public int ProductoId { get; set; }

    public decimal CantidadUsada { get; set; }

    public int? UnidadMedidaId { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int EstadoId { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;

    public virtual Recetum Receta { get; set; } = null!;

    public virtual UnidadMedidum? UnidadMedida { get; set; }
}

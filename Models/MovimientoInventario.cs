using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class MovimientoInventario
{
    public int MovimientoId { get; set; }

    public int InventarioId { get; set; }

    public int TipoMovimientoInventarioId { get; set; }

    public decimal Cantidad { get; set; }

    public string? Motivo { get; set; }

    public decimal? CostoTotal { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int EstadoId { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual Inventario Inventario { get; set; } = null!;

    public virtual TipoMovimientoInventario TipoMovimientoInventario { get; set; } = null!;
}

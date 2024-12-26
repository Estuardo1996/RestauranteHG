using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class HistorialInventario
{
    public int HistorialId { get; set; }

    public int InventarioId { get; set; }

    public DateTime? FechaMovimiento { get; set; }

    public decimal CantidadAnterior { get; set; }

    public decimal CantidadActual { get; set; }

    public string TipoMovimiento { get; set; } = null!;

    public string? Motivo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int EstadoId { get; set; }

    public virtual Inventario Inventario { get; set; } = null!;
}

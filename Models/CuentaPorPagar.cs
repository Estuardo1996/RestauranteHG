using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class CuentaPorPagar
{
    public int CuentaPorPagarId { get; set; }

    public int ProveedorId { get; set; }

    public decimal MontoTotal { get; set; }

    public decimal MontoPendiente { get; set; }

    public DateTime? FechaEmision { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public int EstadoId { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual Proveedor Proveedor { get; set; } = null!;
}

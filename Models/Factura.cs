using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class Factura
{
    public int FacturaId { get; set; }

    public int OrdenId { get; set; }

    public string NumeroFactura { get; set; } = null!;

    public DateTime? FechaFactura { get; set; }

    public decimal MontoTotal { get; set; }

    public string? NumeroAutorizacion { get; set; }

    public DateTime? FechaExpiracion { get; set; }

    public int EstadoId { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual Orden Orden { get; set; } = null!;
}

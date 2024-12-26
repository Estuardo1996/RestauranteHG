using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class Pago
{
    public int PagoId { get; set; }

    public int OrdenId { get; set; }

    public decimal Monto { get; set; }

    public decimal MontoParcial { get; set; }

    public int MetodoPagoId { get; set; }

    public decimal? Propina { get; set; }

    public decimal? Descuento { get; set; }

    public string? Moneda { get; set; }

    public decimal? TipoCambio { get; set; }

    public DateTime? FechaPago { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int EstadoId { get; set; }

    public int? CuponId { get; set; }

    public virtual Cupon? Cupon { get; set; }

    public virtual ICollection<DetallePago> DetallePagos { get; set; } = new List<DetallePago>();

    public virtual Estado Estado { get; set; } = null!;

    public virtual MetodoPago MetodoPago { get; set; } = null!;

    public virtual Orden Orden { get; set; } = null!;
}

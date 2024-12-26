using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class DetallePago
{
    public int DetallePagoId { get; set; }

    public int PagoId { get; set; }

    public int DetalleOrdenId { get; set; }

    public decimal Cantidad { get; set; }

    public decimal? Subtotal { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int EstadoId { get; set; }

    public virtual DetalleOrden DetalleOrden { get; set; } = null!;

    public virtual Estado Estado { get; set; } = null!;

    public virtual Pago Pago { get; set; } = null!;
}

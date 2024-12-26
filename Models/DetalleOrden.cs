using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class DetalleOrden
{
    public int DetalleOrdenId { get; set; }

    public int OrdenId { get; set; }

    public int ItemVendibleId { get; set; }

    public decimal Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? Impuesto { get; set; }

    public decimal? Descuento { get; set; }

    public int? PromocionId { get; set; }

    public int? OrdenPersonaId { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int EstadoId { get; set; }

    public virtual ICollection<DetallePago> DetallePagos { get; set; } = new List<DetallePago>();

    public virtual Estado Estado { get; set; } = null!;

    public virtual ItemVendible ItemVendible { get; set; } = null!;

    public virtual Orden Orden { get; set; } = null!;

    public virtual OrdenPersona? OrdenPersona { get; set; }

    public virtual Promocion? Promocion { get; set; }
}

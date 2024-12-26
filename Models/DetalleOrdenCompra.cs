using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class DetalleOrdenCompra
{
    public int DetalleOrdenCompraId { get; set; }

    public int OrdenCompraId { get; set; }

    public int ProductoId { get; set; }

    public decimal Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal? Subtotal { get; set; }

    public int EstadoId { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual OrdenCompra OrdenCompra { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}

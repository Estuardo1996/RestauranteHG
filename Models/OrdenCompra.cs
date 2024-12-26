using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class OrdenCompra
{
    public int OrdenCompraId { get; set; }

    public int ProveedorId { get; set; }

    public int MetodoPagoId { get; set; }

    public DateTime? FechaOrden { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public int EstadoId { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<DetalleOrdenCompra> DetalleOrdenCompras { get; set; } = new List<DetalleOrdenCompra>();

    public virtual Estado Estado { get; set; } = null!;

    public virtual MetodoPago MetodoPago { get; set; } = null!;

    public virtual Proveedor Proveedor { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class MetodoPago
{
    public int MetodoPagoId { get; set; }

    public string Descripcion { get; set; } = null!;

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int EstadoId { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<OrdenCompra> OrdenCompras { get; set; } = new List<OrdenCompra>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}

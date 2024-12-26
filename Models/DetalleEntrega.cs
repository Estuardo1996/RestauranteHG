using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class DetalleEntrega
{
    public int DetalleEntregaId { get; set; }

    public int OrdenId { get; set; }

    public string Direccion { get; set; } = null!;

    public DateTime? FechaEntrega { get; set; }

    public string? EstadoEntrega { get; set; }

    public int? RepartidorId { get; set; }

    public int EstadoId { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual Orden Orden { get; set; } = null!;
}

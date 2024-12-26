using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class Orden
{
    public int OrdenId { get; set; }

    public int? MesaId { get; set; }

    public string CodigoPedido { get; set; } = null!;

    public int UsuarioId { get; set; }

    public int EstadoId { get; set; }

    public string? TipoOrden { get; set; }

    public string? FuenteOrden { get; set; }

    public int? TiempoEstimadoEntrega { get; set; }

    public string? NotasEspeciales { get; set; }

    public string? DireccionEntrega { get; set; }

    public int? ClienteId { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<DetalleEntrega> DetalleEntregas { get; set; } = new List<DetalleEntrega>();

    public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; } = new List<DetalleOrden>();

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual ICollection<FeedbackCliente> FeedbackClientes { get; set; } = new List<FeedbackCliente>();

    public virtual Mesa? Mesa { get; set; }

    public virtual ICollection<OrdenPersona> OrdenPersonas { get; set; } = new List<OrdenPersona>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual Usuario Usuario { get; set; } = null!;
}

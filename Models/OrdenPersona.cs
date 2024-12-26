using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class OrdenPersona
{
    public int OrdenPersonaId { get; set; }

    public int OrdenId { get; set; }

    public int PersonaNumero { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int EstadoId { get; set; }

    public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; } = new List<DetalleOrden>();

    public virtual Estado Estado { get; set; } = null!;

    public virtual Orden Orden { get; set; } = null!;
}

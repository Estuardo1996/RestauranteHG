using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class Promocion
{
    public int PromocionId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public decimal? DescuentoPorcentaje { get; set; }

    public decimal? DescuentoMonto { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int EstadoId { get; set; }

    public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; } = new List<DetalleOrden>();

    public virtual Estado Estado { get; set; } = null!;
}

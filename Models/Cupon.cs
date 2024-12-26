using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class Cupon
{
    public int CuponId { get; set; }

    public string Codigo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public decimal? DescuentoPorcentaje { get; set; }

    public decimal? DescuentoMonto { get; set; }

    public int? UsoMaximo { get; set; }

    public int? UsosRealizados { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int EstadoId { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}

using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class TipoMovimientoInventario
{
    public int TipoMovimientoInventarioId { get; set; }

    public string Descripcion { get; set; } = null!;

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int EstadoId { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<MovimientoInventario> MovimientoInventarios { get; set; } = new List<MovimientoInventario>();
}

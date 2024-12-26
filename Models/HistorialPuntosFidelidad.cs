using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class HistorialPuntosFidelidad
{
    public int HistorialId { get; set; }

    public int ClienteId { get; set; }

    public int Puntos { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Descripcion { get; set; }

    public int EstadoId { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Estado Estado { get; set; } = null!;
}

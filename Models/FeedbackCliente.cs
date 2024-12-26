using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class FeedbackCliente
{
    public int FeedbackId { get; set; }

    public int? ClienteId { get; set; }

    public int? OrdenId { get; set; }

    public string Comentarios { get; set; } = null!;

    public int? Calificacion { get; set; }

    public int EstadoId { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual Orden? Orden { get; set; }
}

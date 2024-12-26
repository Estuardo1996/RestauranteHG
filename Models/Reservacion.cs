using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class Reservacion
{
    public int ReservacionId { get; set; }

    public int MesaId { get; set; }

    public int? ClienteId { get; set; }

    public string? NombreCliente { get; set; }

    public int? TipoReservacionId { get; set; }

    public DateTime FechaReservacion { get; set; }

    public bool? TodoRestaurante { get; set; }

    public string? Notas { get; set; }

    public string? EstadoReservacion { get; set; }

    public int EstadoId { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual Mesa Mesa { get; set; } = null!;

    public virtual TipoReservacion? TipoReservacion { get; set; }
}

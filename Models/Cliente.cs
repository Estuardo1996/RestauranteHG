using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public string? Nit { get; set; }

    public string? PreferenciasDieteticas { get; set; }

    public int? PuntosFidelidad { get; set; }

    public string? NivelFidelidad { get; set; }

    public bool? ConsentimientoDatos { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int EstadoId { get; set; }

    public virtual ICollection<DireccionCliente> DireccionClientes { get; set; } = new List<DireccionCliente>();

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<FeedbackCliente> FeedbackClientes { get; set; } = new List<FeedbackCliente>();

    public virtual ICollection<HistorialPuntosFidelidad> HistorialPuntosFidelidads { get; set; } = new List<HistorialPuntosFidelidad>();

    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();

    public virtual ICollection<Reservacion> Reservacions { get; set; } = new List<Reservacion>();
}

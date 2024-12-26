using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class ListaEspera
{
    public int ListaEsperaId { get; set; }

    public string NombreCliente { get; set; } = null!;

    public string? Telefono { get; set; }

    public int NumeroPersonas { get; set; }

    public DateTime? HoraSolicitud { get; set; }

    public string? Estado { get; set; }

    public int EstadoId { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual Estado EstadoNavigation { get; set; } = null!;
}

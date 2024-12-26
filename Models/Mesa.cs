using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class Mesa
{
    public int MesaId { get; set; }

    public int SucursalId { get; set; }

    public int NumeroMesa { get; set; }

    public int Capacidad { get; set; }

    public string? EstadoMesa { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int EstadoId { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<MesaUnidum> MesaUnidumMesaPrincipals { get; set; } = new List<MesaUnidum>();

    public virtual ICollection<MesaUnidum> MesaUnidumMesaSecundaria { get; set; } = new List<MesaUnidum>();

    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();

    public virtual ICollection<Reservacion> Reservacions { get; set; } = new List<Reservacion>();

    public virtual Sucursal Sucursal { get; set; } = null!;
}

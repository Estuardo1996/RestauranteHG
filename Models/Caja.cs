using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class Caja
{
    public int CajaId { get; set; }

    public int SucursalId { get; set; }

    public int NumeroCaja { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int EstadoId { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual Sucursal Sucursal { get; set; } = null!;
}

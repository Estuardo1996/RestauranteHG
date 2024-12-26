using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class HorarioSucursal
{
    public int HorarioId { get; set; }

    public int SucursalId { get; set; }

    public int DiaSemana { get; set; }

    public TimeOnly HoraApertura { get; set; }

    public TimeOnly HoraCierre { get; set; }

    public bool? CerradoTemporal { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int EstadoId { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual Sucursal Sucursal { get; set; } = null!;
}

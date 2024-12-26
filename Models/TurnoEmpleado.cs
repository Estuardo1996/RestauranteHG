using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class TurnoEmpleado
{
    public int TurnoEmpleadoId { get; set; }

    public int EmpleadoId { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly? HoraInicioReal { get; set; }

    public TimeOnly? HoraFinReal { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public int SucursalId { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int EstadoId { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual Estado Estado { get; set; } = null!;

    public virtual Sucursal Sucursal { get; set; } = null!;
}

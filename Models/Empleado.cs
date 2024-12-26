using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class Empleado
{
    public int EmpleadoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string DocumentoIdentidad { get; set; } = null!;

    public DateOnly? FechaNacimiento { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public DateOnly? FechaContratacion { get; set; }

    public string? Cargo { get; set; }

    public decimal? Salario { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int EstadoId { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<TurnoEmpleado> TurnoEmpleados { get; set; } = new List<TurnoEmpleado>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}

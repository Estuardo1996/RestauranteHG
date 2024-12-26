using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class Sucursal
{
    public int SucursalId { get; set; }

    public int EmpresaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int EstadoId { get; set; }

    public virtual ICollection<Caja> Cajas { get; set; } = new List<Caja>();

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<HorarioSucursal> HorarioSucursals { get; set; } = new List<HorarioSucursal>();

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<Mesa> Mesas { get; set; } = new List<Mesa>();

    public virtual ICollection<TurnoEmpleado> TurnoEmpleados { get; set; } = new List<TurnoEmpleado>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}

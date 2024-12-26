using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Usuario1 { get; set; } = null!;

    public byte[] ContrasenaHash { get; set; } = null!;

    public int RolId { get; set; }

    public int? EmpresaId { get; set; }

    public int? SucursalId { get; set; }

    public int? EmpleadoId { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int EstadoId { get; set; }

    public virtual Empleado? Empleado { get; set; }

    public virtual Empresa? Empresa { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();

    public virtual Rol Rol { get; set; } = null!;

    public virtual Sucursal? Sucursal { get; set; }
}

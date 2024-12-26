using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class RolPermiso
{
    public int RolId { get; set; }

    public int PermisoId { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int EstadoId { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual Permiso Permiso { get; set; } = null!;

    public virtual Rol Rol { get; set; } = null!;
}

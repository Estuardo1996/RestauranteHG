using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class Empresa
{
    public int EmpresaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? RazonSocial { get; set; }

    public string? Nit { get; set; }

    public string? Correo { get; set; }

    public string? Contacto { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int EstadoId { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<Proveedor> Proveedors { get; set; } = new List<Proveedor>();

    public virtual ICollection<Sucursal> Sucursals { get; set; } = new List<Sucursal>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}

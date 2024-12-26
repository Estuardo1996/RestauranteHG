using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class Proveedor
{
    public int ProveedorId { get; set; }

    public int? EmpresaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public string? RazonSocial { get; set; }

    public string? Nit { get; set; }

    public string? Contacto { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int EstadoId { get; set; }

    public virtual ICollection<CuentaPorPagar> CuentaPorPagars { get; set; } = new List<CuentaPorPagar>();

    public virtual Empresa? Empresa { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<OrdenCompra> OrdenCompras { get; set; } = new List<OrdenCompra>();
}

using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class DireccionCliente
{
    public int DireccionId { get; set; }

    public int ClienteId { get; set; }

    public string Direccion { get; set; } = null!;

    public string? Ciudad { get; set; }

    public string? Departamento { get; set; }

    public string? Pais { get; set; }

    public string? CodigoPostal { get; set; }

    public bool? Principal { get; set; }

    public int EstadoId { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Estado Estado { get; set; } = null!;
}

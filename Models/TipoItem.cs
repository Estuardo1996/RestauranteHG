using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class TipoItem
{
    public int TipoItemId { get; set; }

    public string Nombre { get; set; } = null!;

    public int EstadoId { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<ItemVendible> ItemVendibles { get; set; } = new List<ItemVendible>();
}

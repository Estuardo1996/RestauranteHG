using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class ItemVendible
{
    public int ItemVendibleId { get; set; }

    public int? TipoItemId { get; set; }

    public int ReferenciaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? ImagenUrl { get; set; }

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int EstadoId { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; } = new List<DetalleOrden>();

    public virtual Estado Estado { get; set; } = null!;

    public virtual TipoItem? TipoItem { get; set; }
}

using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class Recetum
{
    public int RecetaId { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal? CostoPorcion { get; set; }

    public int? TiempoPreparacion { get; set; }

    public int? CategoriaId { get; set; }

    public string? Instrucciones { get; set; }

    public string? Foto { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int EstadoId { get; set; }

    public virtual Categorium? Categoria { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    public virtual ICollection<RecetaDetalle> RecetaDetalles { get; set; } = new List<RecetaDetalle>();
}

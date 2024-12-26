using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string? CodigoProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? MarcaId { get; set; }

    public int? UnidadMedidaId { get; set; }

    public int? CategoriaId { get; set; }

    public decimal Precio { get; set; }

    public decimal? CostoProduccion { get; set; }

    public decimal Stock { get; set; }

    public bool? EsProducible { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int EstadoId { get; set; }

    public int? RecetaId { get; set; }

    public virtual Categorium? Categoria { get; set; }

    public virtual ICollection<DetalleCombo> DetalleCombos { get; set; } = new List<DetalleCombo>();

    public virtual ICollection<DetalleOrdenCompra> DetalleOrdenCompras { get; set; } = new List<DetalleOrdenCompra>();

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual Marca? Marca { get; set; }

    public virtual ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

    public virtual Recetum? Receta { get; set; }

    public virtual ICollection<RecetaDetalle> RecetaDetalles { get; set; } = new List<RecetaDetalle>();

    public virtual UnidadMedidum? UnidadMedida { get; set; }

    public virtual ICollection<Alergeno> Alergenos { get; set; } = new List<Alergeno>();
}

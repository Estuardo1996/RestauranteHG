using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class Inventario
{
    public int InventarioId { get; set; }

    public int SucursalId { get; set; }

    public int ProductoId { get; set; }

    public decimal Stock { get; set; }

    public decimal? PuntoReorden { get; set; }

    public int? UnidadMedidaId { get; set; }

    public decimal CostoUnitario { get; set; }

    public decimal CostoVenta { get; set; }

    public DateTime? FechaUltimaActualizacion { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int EstadoId { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<HistorialInventario> HistorialInventarios { get; set; } = new List<HistorialInventario>();

    public virtual ICollection<MovimientoInventario> MovimientoInventarios { get; set; } = new List<MovimientoInventario>();

    public virtual Producto Producto { get; set; } = null!;

    public virtual Sucursal Sucursal { get; set; } = null!;

    public virtual UnidadMedidum? UnidadMedida { get; set; }
}

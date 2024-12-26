using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class Categorium
{
    public int CategoriaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int EstadoId { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    public virtual ICollection<Recetum> Receta { get; set; } = new List<Recetum>();
}

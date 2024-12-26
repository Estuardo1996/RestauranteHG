using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class MesaUnidum
{
    public int MesaUnidaId { get; set; }

    public int MesaPrincipalId { get; set; }

    public int MesaSecundariaId { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int EstadoId { get; set; }

    public virtual Mesa MesaPrincipal { get; set; } = null!;

    public virtual Mesa MesaSecundaria { get; set; } = null!;
}

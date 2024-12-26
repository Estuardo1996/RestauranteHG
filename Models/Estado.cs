using System;
using System.Collections.Generic;

namespace RestauranteHG.Models;

public partial class Estado
{
    public int EstadoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual ICollection<Alergeno> Alergenos { get; set; } = new List<Alergeno>();

    public virtual ICollection<Caja> Cajas { get; set; } = new List<Caja>();

    public virtual ICollection<Categorium> Categoria { get; set; } = new List<Categorium>();

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Combo> Combos { get; set; } = new List<Combo>();

    public virtual ICollection<CuentaPorPagar> CuentaPorPagars { get; set; } = new List<CuentaPorPagar>();

    public virtual ICollection<Cupon> Cupons { get; set; } = new List<Cupon>();

    public virtual ICollection<DetalleCombo> DetalleCombos { get; set; } = new List<DetalleCombo>();

    public virtual ICollection<DetalleEntrega> DetalleEntregas { get; set; } = new List<DetalleEntrega>();

    public virtual ICollection<DetalleOrdenCompra> DetalleOrdenCompras { get; set; } = new List<DetalleOrdenCompra>();

    public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; } = new List<DetalleOrden>();

    public virtual ICollection<DetallePago> DetallePagos { get; set; } = new List<DetallePago>();

    public virtual ICollection<DireccionCliente> DireccionClientes { get; set; } = new List<DireccionCliente>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual ICollection<FeedbackCliente> FeedbackClientes { get; set; } = new List<FeedbackCliente>();

    public virtual ICollection<HistorialPuntosFidelidad> HistorialPuntosFidelidads { get; set; } = new List<HistorialPuntosFidelidad>();

    public virtual ICollection<HorarioSucursal> HorarioSucursals { get; set; } = new List<HorarioSucursal>();

    public virtual ICollection<Impuesto> Impuestos { get; set; } = new List<Impuesto>();

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<ItemVendible> ItemVendibles { get; set; } = new List<ItemVendible>();

    public virtual ICollection<ListaEspera> ListaEsperas { get; set; } = new List<ListaEspera>();

    public virtual ICollection<Marca> Marcas { get; set; } = new List<Marca>();

    public virtual ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();

    public virtual ICollection<Mesa> Mesas { get; set; } = new List<Mesa>();

    public virtual ICollection<MetodoPago> MetodoPagos { get; set; } = new List<MetodoPago>();

    public virtual ICollection<MovimientoInventario> MovimientoInventarios { get; set; } = new List<MovimientoInventario>();

    public virtual ICollection<OrdenCompra> OrdenCompras { get; set; } = new List<OrdenCompra>();

    public virtual ICollection<OrdenPersona> OrdenPersonas { get; set; } = new List<OrdenPersona>();

    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    public virtual ICollection<Promocion> Promocions { get; set; } = new List<Promocion>();

    public virtual ICollection<Proveedor> Proveedors { get; set; } = new List<Proveedor>();

    public virtual ICollection<Recetum> Receta { get; set; } = new List<Recetum>();

    public virtual ICollection<RecetaDetalle> RecetaDetalles { get; set; } = new List<RecetaDetalle>();

    public virtual ICollection<Reservacion> Reservacions { get; set; } = new List<Reservacion>();

    public virtual ICollection<RolPermiso> RolPermisos { get; set; } = new List<RolPermiso>();

    public virtual ICollection<Rol> Rols { get; set; } = new List<Rol>();

    public virtual ICollection<Sucursal> Sucursals { get; set; } = new List<Sucursal>();

    public virtual ICollection<TipoItem> TipoItems { get; set; } = new List<TipoItem>();

    public virtual ICollection<TipoMovimientoInventario> TipoMovimientoInventarios { get; set; } = new List<TipoMovimientoInventario>();

    public virtual ICollection<TipoReservacion> TipoReservacions { get; set; } = new List<TipoReservacion>();

    public virtual ICollection<TurnoEmpleado> TurnoEmpleados { get; set; } = new List<TurnoEmpleado>();

    public virtual ICollection<UnidadMedidum> UnidadMedida { get; set; } = new List<UnidadMedidum>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}

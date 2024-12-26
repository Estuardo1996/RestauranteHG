using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RestauranteHG.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alergeno> Alergenos { get; set; }

    public virtual DbSet<Caja> Cajas { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Combo> Combos { get; set; }

    public virtual DbSet<CuentaPorPagar> CuentaPorPagars { get; set; }

    public virtual DbSet<Cupon> Cupons { get; set; }

    public virtual DbSet<DetalleCombo> DetalleCombos { get; set; }

    public virtual DbSet<DetalleEntrega> DetalleEntregas { get; set; }

    public virtual DbSet<DetalleOrden> DetalleOrdens { get; set; }

    public virtual DbSet<DetalleOrdenCompra> DetalleOrdenCompras { get; set; }

    public virtual DbSet<DetallePago> DetallePagos { get; set; }

    public virtual DbSet<DireccionCliente> DireccionClientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<FeedbackCliente> FeedbackClientes { get; set; }

    public virtual DbSet<HistorialInventario> HistorialInventarios { get; set; }

    public virtual DbSet<HistorialPuntosFidelidad> HistorialPuntosFidelidads { get; set; }

    public virtual DbSet<HorarioSucursal> HorarioSucursals { get; set; }

    public virtual DbSet<Impuesto> Impuestos { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<ItemVendible> ItemVendibles { get; set; }

    public virtual DbSet<ListaEspera> ListaEsperas { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuItem> MenuItems { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<MesaUnidum> MesaUnida { get; set; }

    public virtual DbSet<MetodoPago> MetodoPagos { get; set; }

    public virtual DbSet<MovimientoInventario> MovimientoInventarios { get; set; }

    public virtual DbSet<Orden> Ordens { get; set; }

    public virtual DbSet<OrdenCompra> OrdenCompras { get; set; }

    public virtual DbSet<OrdenPersona> OrdenPersonas { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Promocion> Promocions { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<RecetaDetalle> RecetaDetalles { get; set; }

    public virtual DbSet<Recetum> Receta { get; set; }

    public virtual DbSet<Reservacion> Reservacions { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolPermiso> RolPermisos { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<TipoItem> TipoItems { get; set; }

    public virtual DbSet<TipoMovimientoInventario> TipoMovimientoInventarios { get; set; }

    public virtual DbSet<TipoReservacion> TipoReservacions { get; set; }

    public virtual DbSet<TurnoEmpleado> TurnoEmpleados { get; set; }

    public virtual DbSet<UnidadMedidum> UnidadMedida { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alergeno>(entity =>
        {
            entity.HasKey(e => e.AlergenoId).HasName("PK__Alergeno__8FA44058E099D684");

            entity.ToTable("Alergeno");

            entity.Property(e => e.AlergenoId).HasColumnName("AlergenoID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.Alergenos)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alergeno_Estado");
        });

        modelBuilder.Entity<Caja>(entity =>
        {
            entity.HasKey(e => e.CajaId).HasName("PK__Caja__A74F8767B57638AB");

            entity.ToTable("Caja");

            entity.HasIndex(e => new { e.SucursalId, e.NumeroCaja }, "UQ_Caja_Sucursal_NumeroCaja").IsUnique();

            entity.Property(e => e.CajaId).HasColumnName("CajaID");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.Cajas)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Caja_Estado");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Cajas)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Caja_Sucursal");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1C584A0CECC");

            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.Categoria)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Categoria_Estado");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Cliente__71ABD0A77D61C6D7");

            entity.ToTable("Cliente");

            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.ConsentimientoDatos).HasDefaultValue(false);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nit).HasMaxLength(50);
            entity.Property(e => e.NivelFidelidad).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.PreferenciasDieteticas).HasMaxLength(255);
            entity.Property(e => e.PuntosFidelidad).HasDefaultValue(0);
            entity.Property(e => e.Telefono).HasMaxLength(15);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_Estado");
        });

        modelBuilder.Entity<Combo>(entity =>
        {
            entity.HasKey(e => e.ComboId).HasName("PK__Combo__DD42580E6D20688E");

            entity.ToTable("Combo");

            entity.Property(e => e.ComboId).HasColumnName("ComboID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.Combos)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Combo_Estado");
        });

        modelBuilder.Entity<CuentaPorPagar>(entity =>
        {
            entity.HasKey(e => e.CuentaPorPagarId).HasName("PK__CuentaPo__2C02C5173EA51F51");

            entity.ToTable("CuentaPorPagar");

            entity.Property(e => e.CuentaPorPagarId).HasColumnName("CuentaPorPagarID");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaEmision)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");
            entity.Property(e => e.MontoPendiente).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.MontoTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.CuentaPorPagars)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CuentaPorPagar_Estado");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.CuentaPorPagars)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CuentaPorPagar_Proveedor");
        });

        modelBuilder.Entity<Cupon>(entity =>
        {
            entity.HasKey(e => e.CuponId).HasName("PK__Cupon__C43568B727139389");

            entity.ToTable("Cupon");

            entity.HasIndex(e => e.Codigo, "UQ__Cupon__06370DAC6E2CDEEA").IsUnique();

            entity.Property(e => e.CuponId).HasColumnName("CuponID");
            entity.Property(e => e.Codigo).HasMaxLength(50);
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.DescuentoMonto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DescuentoPorcentaje).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.UsoMaximo).HasDefaultValue(1);
            entity.Property(e => e.UsosRealizados).HasDefaultValue(0);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.Cupons)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cupon_Estado");
        });

        modelBuilder.Entity<DetalleCombo>(entity =>
        {
            entity.HasKey(e => e.DetalleComboId).HasName("PK__DetalleC__BA93D32B7B0E821C");

            entity.ToTable("DetalleCombo");

            entity.Property(e => e.DetalleComboId).HasColumnName("DetalleComboID");
            entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ComboId).HasColumnName("ComboID");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Combo).WithMany(p => p.DetalleCombos)
                .HasForeignKey(d => d.ComboId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleCombo_Combo");

            entity.HasOne(d => d.Estado).WithMany(p => p.DetalleCombos)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleCombo_Estado");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleCombos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleCombo_Producto");
        });

        modelBuilder.Entity<DetalleEntrega>(entity =>
        {
            entity.HasKey(e => e.DetalleEntregaId).HasName("PK__DetalleE__800FB95A2BA8DC8A");

            entity.ToTable("DetalleEntrega");

            entity.Property(e => e.DetalleEntregaId).HasColumnName("DetalleEntregaID");
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.EstadoEntrega).HasMaxLength(50);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaEntrega).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.OrdenId).HasColumnName("OrdenID");
            entity.Property(e => e.RepartidorId)
                .HasDefaultValue(1)
                .HasColumnName("RepartidorID");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.DetalleEntregas)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleEntrega_Estado");

            entity.HasOne(d => d.Orden).WithMany(p => p.DetalleEntregas)
                .HasForeignKey(d => d.OrdenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleEntrega_Orden");
        });

        modelBuilder.Entity<DetalleOrden>(entity =>
        {
            entity.HasKey(e => e.DetalleOrdenId).HasName("PK__DetalleO__EE6A3AA15A80D80B");

            entity.ToTable("DetalleOrden");

            entity.Property(e => e.DetalleOrdenId).HasColumnName("DetalleOrdenID");
            entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descuento)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Impuesto)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ItemVendibleId).HasColumnName("ItemVendibleID");
            entity.Property(e => e.OrdenId).HasColumnName("OrdenID");
            entity.Property(e => e.OrdenPersonaId).HasColumnName("OrdenPersonaID");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PromocionId).HasColumnName("PromocionID");
            entity.Property(e => e.Subtotal)
                .HasComputedColumnSql("([Cantidad]*[PrecioUnitario])", false)
                .HasColumnType("decimal(21, 4)");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.DetalleOrdens)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleOrden_Estado");

            entity.HasOne(d => d.ItemVendible).WithMany(p => p.DetalleOrdens)
                .HasForeignKey(d => d.ItemVendibleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleOrden_ItemVendible");

            entity.HasOne(d => d.Orden).WithMany(p => p.DetalleOrdens)
                .HasForeignKey(d => d.OrdenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleOrden_Orden");

            entity.HasOne(d => d.OrdenPersona).WithMany(p => p.DetalleOrdens)
                .HasForeignKey(d => d.OrdenPersonaId)
                .HasConstraintName("FK_DetalleOrden_OrdenPersona");

            entity.HasOne(d => d.Promocion).WithMany(p => p.DetalleOrdens)
                .HasForeignKey(d => d.PromocionId)
                .HasConstraintName("FK_DetalleOrden_Promocion");
        });

        modelBuilder.Entity<DetalleOrdenCompra>(entity =>
        {
            entity.HasKey(e => e.DetalleOrdenCompraId).HasName("PK__DetalleO__3A46EB4460091E44");

            entity.ToTable("DetalleOrdenCompra");

            entity.Property(e => e.DetalleOrdenCompraId).HasColumnName("DetalleOrdenCompraID");
            entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.OrdenCompraId).HasColumnName("OrdenCompraID");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.Subtotal)
                .HasComputedColumnSql("([Cantidad]*[PrecioUnitario])", false)
                .HasColumnType("decimal(21, 4)");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.DetalleOrdenCompras)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleOrdenCompra_Estado");

            entity.HasOne(d => d.OrdenCompra).WithMany(p => p.DetalleOrdenCompras)
                .HasForeignKey(d => d.OrdenCompraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleOrdenCompra_OrdenCompra");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleOrdenCompras)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleOrdenCompra_Producto");
        });

        modelBuilder.Entity<DetallePago>(entity =>
        {
            entity.HasKey(e => e.DetallePagoId).HasName("PK__DetalleP__08BE1B9CF25A87FF");

            entity.ToTable("DetallePago");

            entity.Property(e => e.DetallePagoId).HasColumnName("DetallePagoID");
            entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DetalleOrdenId).HasColumnName("DetalleOrdenID");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PagoId).HasColumnName("PagoID");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);

            entity.HasOne(d => d.DetalleOrden).WithMany(p => p.DetallePagos)
                .HasForeignKey(d => d.DetalleOrdenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallePago_DetalleOrden");

            entity.HasOne(d => d.Estado).WithMany(p => p.DetallePagos)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallePago_Estado");

            entity.HasOne(d => d.Pago).WithMany(p => p.DetallePagos)
                .HasForeignKey(d => d.PagoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallePago_Pago");
        });

        modelBuilder.Entity<DireccionCliente>(entity =>
        {
            entity.HasKey(e => e.DireccionId).HasName("PK__Direccio__68906D44F7871BF2");

            entity.ToTable("DireccionCliente");

            entity.Property(e => e.DireccionId).HasColumnName("DireccionID");
            entity.Property(e => e.Ciudad).HasMaxLength(100);
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.CodigoPostal).HasMaxLength(20);
            entity.Property(e => e.Departamento).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Pais).HasMaxLength(100);
            entity.Property(e => e.Principal).HasDefaultValue(false);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Cliente).WithMany(p => p.DireccionClientes)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DireccionCliente_Cliente");

            entity.HasOne(d => d.Estado).WithMany(p => p.DireccionClientes)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DireccionCliente_Estado");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PK__Empleado__958BE6F020D7D97D");

            entity.ToTable("Empleado");

            entity.HasIndex(e => e.DocumentoIdentidad, "UQ__Empleado__049E81A927368B11").IsUnique();

            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.Cargo).HasMaxLength(100);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.DocumentoIdentidad).HasMaxLength(50);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Salario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Telefono).HasMaxLength(15);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleado_Estado");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.EmpresaId).HasName("PK__Empresa__7B9F2136E4B2A1A1");

            entity.ToTable("Empresa");

            entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");
            entity.Property(e => e.Contacto).HasMaxLength(200);
            entity.Property(e => e.Correo).HasMaxLength(200);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nit).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.RazonSocial).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(15);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_Estado");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.EstadoId).HasName("PK__Estado__FEF86B606E004FCB");

            entity.ToTable("Estado");

            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.FacturaId).HasName("PK__Factura__5C0248058A3738D2");

            entity.ToTable("Factura");

            entity.HasIndex(e => e.NumeroFactura, "UQ__Factura__CF12F9A6B0182287").IsUnique();

            entity.Property(e => e.FacturaId).HasColumnName("FacturaID");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaExpiracion).HasColumnType("datetime");
            entity.Property(e => e.FechaFactura)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.MontoTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.NumeroAutorizacion).HasMaxLength(50);
            entity.Property(e => e.NumeroFactura).HasMaxLength(50);
            entity.Property(e => e.OrdenId).HasColumnName("OrdenID");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_Estado");

            entity.HasOne(d => d.Orden).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.OrdenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_Orden");
        });

        modelBuilder.Entity<FeedbackCliente>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF6A18DFD9A");

            entity.ToTable("FeedbackCliente");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Comentarios).HasMaxLength(1000);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.OrdenId).HasColumnName("OrdenID");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Cliente).WithMany(p => p.FeedbackClientes)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_FeedbackCliente_Cliente");

            entity.HasOne(d => d.Estado).WithMany(p => p.FeedbackClientes)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FeedbackCliente_Estado");

            entity.HasOne(d => d.Orden).WithMany(p => p.FeedbackClientes)
                .HasForeignKey(d => d.OrdenId)
                .HasConstraintName("FK_FeedbackCliente_Orden");
        });

        modelBuilder.Entity<HistorialInventario>(entity =>
        {
            entity.HasKey(e => e.HistorialId).HasName("PK__Historia__975206EF634579E5");

            entity.ToTable("HistorialInventario");

            entity.Property(e => e.HistorialId).HasColumnName("HistorialID");
            entity.Property(e => e.CantidadActual).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CantidadAnterior).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaMovimiento)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.InventarioId).HasColumnName("InventarioID");
            entity.Property(e => e.Motivo).HasMaxLength(255);
            entity.Property(e => e.TipoMovimiento).HasMaxLength(50);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Inventario).WithMany(p => p.HistorialInventarios)
                .HasForeignKey(d => d.InventarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistorialInventario_Inventario");
        });

        modelBuilder.Entity<HistorialPuntosFidelidad>(entity =>
        {
            entity.HasKey(e => e.HistorialId).HasName("PK__Historia__975206EFD4DA2DAB");

            entity.ToTable("HistorialPuntosFidelidad");

            entity.Property(e => e.HistorialId).HasColumnName("HistorialID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Cliente).WithMany(p => p.HistorialPuntosFidelidads)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistorialPuntosFidelidad_Cliente");

            entity.HasOne(d => d.Estado).WithMany(p => p.HistorialPuntosFidelidads)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistorialPuntosFidelidad_Estado");
        });

        modelBuilder.Entity<HorarioSucursal>(entity =>
        {
            entity.HasKey(e => e.HorarioId).HasName("PK__HorarioS__BB881A9ED4CE8441");

            entity.ToTable("HorarioSucursal");

            entity.Property(e => e.HorarioId).HasColumnName("HorarioID");
            entity.Property(e => e.CerradoTemporal).HasDefaultValue(false);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.HorarioSucursals)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HorarioSucursal_Estado");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.HorarioSucursals)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HorarioSucursal_Sucursal");
        });

        modelBuilder.Entity<Impuesto>(entity =>
        {
            entity.HasKey(e => e.ImpuestoId).HasName("PK__Impuesto__CD9F45DEA5A33F4C");

            entity.ToTable("Impuesto");

            entity.Property(e => e.ImpuestoId).HasColumnName("ImpuestoID");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Porcentaje).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.Impuestos)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Impuesto_Estado");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.InventarioId).HasName("PK__Inventar__FB8A24B73F5A1649");

            entity.ToTable("Inventario");

            entity.Property(e => e.InventarioId).HasColumnName("InventarioID");
            entity.Property(e => e.CostoUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CostoVenta).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaUltimaActualizacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.PuntoReorden)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Stock).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
            entity.Property(e => e.UnidadMedidaId).HasColumnName("UnidadMedidaID");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventario_Estado");

            entity.HasOne(d => d.Producto).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventario_Producto");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventario_Sucursal");

            entity.HasOne(d => d.UnidadMedida).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.UnidadMedidaId)
                .HasConstraintName("FK_Inventario_UnidadMedida");
        });

        modelBuilder.Entity<ItemVendible>(entity =>
        {
            entity.HasKey(e => e.ItemVendibleId).HasName("PK__ItemVend__93DC2C9198F93B4E");

            entity.ToTable("ItemVendible");

            entity.Property(e => e.ItemVendibleId).HasColumnName("ItemVendibleID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.ImagenUrl)
                .HasMaxLength(100)
                .HasColumnName("ImagenURL");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ReferenciaId).HasColumnName("ReferenciaID");
            entity.Property(e => e.TipoItemId).HasColumnName("TipoItemID");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.ItemVendibles)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemVendible_Estado");

            entity.HasOne(d => d.TipoItem).WithMany(p => p.ItemVendibles)
                .HasForeignKey(d => d.TipoItemId)
                .HasConstraintName("FK_ItemVendible_TipoItem");
        });

        modelBuilder.Entity<ListaEspera>(entity =>
        {
            entity.HasKey(e => e.ListaEsperaId).HasName("PK__ListaEsp__EF5E33DE9237FEF0");

            entity.ToTable("ListaEspera");

            entity.Property(e => e.ListaEsperaId).HasColumnName("ListaEsperaID");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasDefaultValue("En Espera");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.HoraSolicitud)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreCliente).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(15);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.ListaEsperas)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ListaEspera_Estado");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.MarcaId).HasName("PK__Marca__D5B1CDEB871D934D");

            entity.ToTable("Marca");

            entity.Property(e => e.MarcaId).HasColumnName("MarcaID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.Marcas)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Marca_Estado");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PK__Menu__C99ED25098BCEC14");

            entity.ToTable("Menu");

            entity.Property(e => e.MenuId).HasColumnName("MenuID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.Menus)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Menu_Estado");
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.HasKey(e => e.MenuItemId).HasName("PK__MenuItem__8943F7023D1905CA");

            entity.ToTable("MenuItem");

            entity.Property(e => e.MenuItemId).HasColumnName("MenuItemID");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.MenuId).HasColumnName("MenuID");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.MenuItems)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MenuItem_Estado");

            entity.HasOne(d => d.Menu).WithMany(p => p.MenuItems)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MenuItem_Menu");

            entity.HasOne(d => d.Producto).WithMany(p => p.MenuItems)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MenuItem_Producto");
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.MesaId).HasName("PK__Mesa__6A4196C866D08B3A");

            entity.ToTable("Mesa");

            entity.HasIndex(e => new { e.SucursalId, e.NumeroMesa }, "UQ_Mesa_Sucursal_NumeroMesa").IsUnique();

            entity.Property(e => e.MesaId).HasColumnName("MesaID");
            entity.Property(e => e.Capacidad).HasDefaultValue(4);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.EstadoMesa)
                .HasMaxLength(50)
                .HasDefaultValue("Disponible");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.Mesas)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mesa_Estado");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Mesas)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mesa_Sucursal");
        });

        modelBuilder.Entity<MesaUnidum>(entity =>
        {
            entity.HasKey(e => e.MesaUnidaId).HasName("PK__MesaUnid__0A5EDCBB040F4946");

            entity.Property(e => e.MesaUnidaId).HasColumnName("MesaUnidaID");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.MesaPrincipalId).HasColumnName("MesaPrincipalID");
            entity.Property(e => e.MesaSecundariaId).HasColumnName("MesaSecundariaID");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.MesaPrincipal).WithMany(p => p.MesaUnidumMesaPrincipals)
                .HasForeignKey(d => d.MesaPrincipalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MesaUnida_MesaPrincipal");

            entity.HasOne(d => d.MesaSecundaria).WithMany(p => p.MesaUnidumMesaSecundaria)
                .HasForeignKey(d => d.MesaSecundariaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MesaUnida_MesaSecundaria");
        });

        modelBuilder.Entity<MetodoPago>(entity =>
        {
            entity.HasKey(e => e.MetodoPagoId).HasName("PK__MetodoPa__A8FEAF74309077D5");

            entity.ToTable("MetodoPago");

            entity.Property(e => e.MetodoPagoId).HasColumnName("MetodoPagoID");
            entity.Property(e => e.Descripcion).HasMaxLength(50);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.MetodoPagos)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MetodoPago_Estado");
        });

        modelBuilder.Entity<MovimientoInventario>(entity =>
        {
            entity.HasKey(e => e.MovimientoId).HasName("PK__Movimien__BF923FCCD5A66112");

            entity.ToTable("MovimientoInventario");

            entity.Property(e => e.MovimientoId).HasColumnName("MovimientoID");
            entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CostoTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.InventarioId).HasColumnName("InventarioID");
            entity.Property(e => e.Motivo).HasMaxLength(255);
            entity.Property(e => e.TipoMovimientoInventarioId).HasColumnName("TipoMovimientoInventarioID");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.MovimientoInventarios)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovimientoInventario_Estado");

            entity.HasOne(d => d.Inventario).WithMany(p => p.MovimientoInventarios)
                .HasForeignKey(d => d.InventarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovimientoInventario_Inventario");

            entity.HasOne(d => d.TipoMovimientoInventario).WithMany(p => p.MovimientoInventarios)
                .HasForeignKey(d => d.TipoMovimientoInventarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovimientoInventario_TipoMovimientoInventario");
        });

        modelBuilder.Entity<Orden>(entity =>
        {
            entity.HasKey(e => e.OrdenId).HasName("PK__Orden__C088A4E42886563D");

            entity.ToTable("Orden");

            entity.HasIndex(e => e.CodigoPedido, "UQ__Orden__72162F0AB0933908").IsUnique();

            entity.Property(e => e.OrdenId).HasColumnName("OrdenID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.CodigoPedido).HasMaxLength(20);
            entity.Property(e => e.DireccionEntrega).HasMaxLength(255);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FuenteOrden)
                .HasMaxLength(50)
                .HasDefaultValue("En Persona");
            entity.Property(e => e.MesaId).HasColumnName("MesaID");
            entity.Property(e => e.NotasEspeciales).HasMaxLength(150);
            entity.Property(e => e.TipoOrden)
                .HasMaxLength(50)
                .HasDefaultValue("En Restaurante");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Ordens)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_Orden_Cliente");

            entity.HasOne(d => d.Estado).WithMany(p => p.Ordens)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orden_Estado");

            entity.HasOne(d => d.Mesa).WithMany(p => p.Ordens)
                .HasForeignKey(d => d.MesaId)
                .HasConstraintName("FK_Orden_Mesa");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Ordens)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orden_Usuario");
        });

        modelBuilder.Entity<OrdenCompra>(entity =>
        {
            entity.HasKey(e => e.OrdenCompraId).HasName("PK__OrdenCom__0B556E16AC75EBA0");

            entity.ToTable("OrdenCompra");

            entity.Property(e => e.OrdenCompraId).HasColumnName("OrdenCompraID");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaEntrega).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaOrden)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MetodoPagoId).HasColumnName("MetodoPagoID");
            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.OrdenCompras)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdenCompra_Estado");

            entity.HasOne(d => d.MetodoPago).WithMany(p => p.OrdenCompras)
                .HasForeignKey(d => d.MetodoPagoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdenCompra_MetodoPago");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.OrdenCompras)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdenCompra_Proveedor");
        });

        modelBuilder.Entity<OrdenPersona>(entity =>
        {
            entity.HasKey(e => e.OrdenPersonaId).HasName("PK__OrdenPer__9A5DB08C298BFD74");

            entity.ToTable("OrdenPersona");

            entity.HasIndex(e => new { e.OrdenId, e.PersonaNumero }, "UQ_OrdenPersona_Orden_PersonaNumero").IsUnique();

            entity.Property(e => e.OrdenPersonaId).HasColumnName("OrdenPersonaID");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.OrdenId).HasColumnName("OrdenID");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.OrdenPersonas)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdenPersona_Estado");

            entity.HasOne(d => d.Orden).WithMany(p => p.OrdenPersonas)
                .HasForeignKey(d => d.OrdenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdenPersona_Orden");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.PagoId).HasName("PK__Pago__F00B6158D4E9DE4A");

            entity.ToTable("Pago");

            entity.Property(e => e.PagoId).HasColumnName("PagoID");
            entity.Property(e => e.CuponId).HasColumnName("CuponID");
            entity.Property(e => e.Descuento)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaPago)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MetodoPagoId).HasColumnName("MetodoPagoID");
            entity.Property(e => e.Moneda)
                .HasMaxLength(10)
                .HasDefaultValue("Q");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.MontoParcial).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.OrdenId).HasColumnName("OrdenID");
            entity.Property(e => e.Propina)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TipoCambio)
                .HasDefaultValue(1.0m)
                .HasColumnType("decimal(10, 4)");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Cupon).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.CuponId)
                .HasConstraintName("FK_Pago_Cupon");

            entity.HasOne(d => d.Estado).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pago_Estado");

            entity.HasOne(d => d.MetodoPago).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.MetodoPagoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pago_MetodoPago");

            entity.HasOne(d => d.Orden).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.OrdenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pago_Orden");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.PermisoId).HasName("PK__Permiso__96E0C703C98089D0");

            entity.ToTable("Permiso");

            entity.HasIndex(e => e.Nombre, "UQ__Permiso__75E3EFCFF7042979").IsUnique();

            entity.Property(e => e.PermisoId).HasColumnName("PermisoID");
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permiso_Estado");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__Producto__A430AE83C53053D0");

            entity.ToTable("Producto");

            entity.HasIndex(e => e.CodigoProducto, "UQ__Producto__785B009FE900DC0A").IsUnique();

            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.CodigoProducto).HasMaxLength(50);
            entity.Property(e => e.CostoProduccion).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.EsProducible).HasDefaultValue(false);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.MarcaId).HasColumnName("MarcaID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RecetaId).HasColumnName("RecetaID");
            entity.Property(e => e.Stock).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnidadMedidaId).HasColumnName("UnidadMedidaID");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK_Producto_Categoria");

            entity.HasOne(d => d.Estado).WithMany(p => p.Productos)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Producto_Estado");

            entity.HasOne(d => d.Marca).WithMany(p => p.Productos)
                .HasForeignKey(d => d.MarcaId)
                .HasConstraintName("FK_Producto_Marca");

            entity.HasOne(d => d.Receta).WithMany(p => p.Productos)
                .HasForeignKey(d => d.RecetaId)
                .HasConstraintName("FK_Producto_Receta");

            entity.HasOne(d => d.UnidadMedida).WithMany(p => p.Productos)
                .HasForeignKey(d => d.UnidadMedidaId)
                .HasConstraintName("FK_Producto_UnidadMedida");

            entity.HasMany(d => d.Alergenos).WithMany(p => p.Productos)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductoAlergeno",
                    r => r.HasOne<Alergeno>().WithMany()
                        .HasForeignKey("AlergenoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ProductoAlergeno_Alergeno"),
                    l => l.HasOne<Producto>().WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ProductoAlergeno_Producto"),
                    j =>
                    {
                        j.HasKey("ProductoId", "AlergenoId").HasName("PK__Producto__3CCAEA86AB879E03");
                        j.ToTable("ProductoAlergeno");
                        j.IndexerProperty<int>("ProductoId").HasColumnName("ProductoID");
                        j.IndexerProperty<int>("AlergenoId").HasColumnName("AlergenoID");
                    });
        });

        modelBuilder.Entity<Promocion>(entity =>
        {
            entity.HasKey(e => e.PromocionId).HasName("PK__Promocio__2DA61DBD19C6D186");

            entity.ToTable("Promocion");

            entity.Property(e => e.PromocionId).HasColumnName("PromocionID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.DescuentoMonto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DescuentoPorcentaje).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.Promocions)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Promocion_Estado");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.ProveedorId).HasName("PK__Proveedo__61266BB9EE6E630A");

            entity.ToTable("Proveedor");

            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");
            entity.Property(e => e.Contacto).HasMaxLength(200);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nit).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.RazonSocial).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(15);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Proveedors)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK_Proveedor_Empresa");

            entity.HasOne(d => d.Estado).WithMany(p => p.Proveedors)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proveedor_Estado");
        });

        modelBuilder.Entity<RecetaDetalle>(entity =>
        {
            entity.HasKey(e => e.RecetaDetalleId).HasName("PK__RecetaDe__AA109C645EE49A40");

            entity.ToTable("RecetaDetalle");

            entity.Property(e => e.RecetaDetalleId).HasColumnName("RecetaDetalleID");
            entity.Property(e => e.CantidadUsada).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.RecetaId).HasColumnName("RecetaID");
            entity.Property(e => e.UnidadMedidaId).HasColumnName("UnidadMedidaID");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.RecetaDetalles)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecetaDetalle_Estado");

            entity.HasOne(d => d.Producto).WithMany(p => p.RecetaDetalles)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecetaDetalle_Producto");

            entity.HasOne(d => d.Receta).WithMany(p => p.RecetaDetalles)
                .HasForeignKey(d => d.RecetaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecetaDetalle_Receta");

            entity.HasOne(d => d.UnidadMedida).WithMany(p => p.RecetaDetalles)
                .HasForeignKey(d => d.UnidadMedidaId)
                .HasConstraintName("FK_RecetaDetalle_UnidadMedida");
        });

        modelBuilder.Entity<Recetum>(entity =>
        {
            entity.HasKey(e => e.RecetaId).HasName("PK__Receta__03D077B84199A713");

            entity.Property(e => e.RecetaId).HasColumnName("RecetaID");
            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.CostoPorcion).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Foto).HasMaxLength(255);
            entity.Property(e => e.Instrucciones).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Categoria).WithMany(p => p.Receta)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK_Receta_Categoria");

            entity.HasOne(d => d.Estado).WithMany(p => p.Receta)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Receta_Estado");
        });

        modelBuilder.Entity<Reservacion>(entity =>
        {
            entity.HasKey(e => e.ReservacionId).HasName("PK__Reservac__145B3EB56E5E1220");

            entity.ToTable("Reservacion");

            entity.Property(e => e.ReservacionId).HasColumnName("ReservacionID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.EstadoReservacion)
                .HasMaxLength(50)
                .HasDefaultValue("Pendiente");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaReservacion).HasColumnType("datetime");
            entity.Property(e => e.MesaId).HasColumnName("MesaID");
            entity.Property(e => e.NombreCliente).HasMaxLength(100);
            entity.Property(e => e.Notas).HasMaxLength(255);
            entity.Property(e => e.TipoReservacionId).HasColumnName("TipoReservacionID");
            entity.Property(e => e.TodoRestaurante).HasDefaultValue(false);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservacions)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_Reservacion_Cliente");

            entity.HasOne(d => d.Estado).WithMany(p => p.Reservacions)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservacion_Estado");

            entity.HasOne(d => d.Mesa).WithMany(p => p.Reservacions)
                .HasForeignKey(d => d.MesaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservacion_Mesa");

            entity.HasOne(d => d.TipoReservacion).WithMany(p => p.Reservacions)
                .HasForeignKey(d => d.TipoReservacionId)
                .HasConstraintName("FK_Reservacion_TipoReservacion");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Rol__F92302D1383DFF21");

            entity.ToTable("Rol");

            entity.HasIndex(e => e.Nombre, "UQ__Rol__75E3EFCF32BC0DB6").IsUnique();

            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.Rols)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rol_Estado");
        });

        modelBuilder.Entity<RolPermiso>(entity =>
        {
            entity.HasKey(e => new { e.RolId, e.PermisoId }).HasName("PK__RolPermi__D04D0EA14C185D51");

            entity.ToTable("RolPermiso");

            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.PermisoId).HasColumnName("PermisoID");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.RolPermisos)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolPermiso_Estado");

            entity.HasOne(d => d.Permiso).WithMany(p => p.RolPermisos)
                .HasForeignKey(d => d.PermisoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolPermiso_Permiso");

            entity.HasOne(d => d.Rol).WithMany(p => p.RolPermisos)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolPermiso_Rol");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.SucursalId).HasName("PK__Sucursal__6CB48281713A890F");

            entity.ToTable("Sucursal");

            entity.HasIndex(e => new { e.EmpresaId, e.Nombre }, "UQ_Sucursal_Empresa_Nombre").IsUnique();

            entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(15);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Sucursals)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sucursal_Empresa");

            entity.HasOne(d => d.Estado).WithMany(p => p.Sucursals)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sucursal_Estado");
        });

        modelBuilder.Entity<TipoItem>(entity =>
        {
            entity.HasKey(e => e.TipoItemId).HasName("PK__TipoItem__FC89051B0B05E329");

            entity.ToTable("TipoItem");

            entity.Property(e => e.TipoItemId).HasColumnName("TipoItemID");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.TipoItems)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TipoItem_Estado");
        });

        modelBuilder.Entity<TipoMovimientoInventario>(entity =>
        {
            entity.HasKey(e => e.TipoMovimientoInventarioId).HasName("PK__TipoMovi__2A05BC5C301F6F2D");

            entity.ToTable("TipoMovimientoInventario");

            entity.Property(e => e.TipoMovimientoInventarioId).HasColumnName("TipoMovimientoInventarioID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.TipoMovimientoInventarios)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TipoMovimientoInventario_Estado");
        });

        modelBuilder.Entity<TipoReservacion>(entity =>
        {
            entity.HasKey(e => e.TipoReservacionId).HasName("PK__TipoRese__D2F56018330A775E");

            entity.ToTable("TipoReservacion");

            entity.Property(e => e.TipoReservacionId).HasColumnName("TipoReservacionID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.TipoReservacions)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TipoReservacion_Estado");
        });

        modelBuilder.Entity<TurnoEmpleado>(entity =>
        {
            entity.HasKey(e => e.TurnoEmpleadoId).HasName("PK__TurnoEmp__7B2F6AEECE92B617");

            entity.ToTable("TurnoEmpleado");

            entity.Property(e => e.TurnoEmpleadoId).HasColumnName("TurnoEmpleadoID");
            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);

            entity.HasOne(d => d.Empleado).WithMany(p => p.TurnoEmpleados)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TurnoEmpleado_Empleado");

            entity.HasOne(d => d.Estado).WithMany(p => p.TurnoEmpleados)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TurnoEmpleado_Estado");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.TurnoEmpleados)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TurnoEmpleado_Sucursal");
        });

        modelBuilder.Entity<UnidadMedidum>(entity =>
        {
            entity.HasKey(e => e.UnidadMedidaId).HasName("PK__UnidadMe__3397280102EB97B0");

            entity.Property(e => e.UnidadMedidaId).HasColumnName("UnidadMedidaID");
            entity.Property(e => e.Abreviatura).HasMaxLength(50);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.UnidadMedida)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UnidadMedida_Estado");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE798202E2E91");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Usuario1, "UQ__Usuario__E3237CF70B6A1BF3").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(100)
                .HasColumnName("Usuario");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Empleado).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK_Usuario_Empleado");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK_Usuario_Empresa");

            entity.HasOne(d => d.Estado).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Estado");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Rol");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.SucursalId)
                .HasConstraintName("FK_Usuario_Sucursal");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

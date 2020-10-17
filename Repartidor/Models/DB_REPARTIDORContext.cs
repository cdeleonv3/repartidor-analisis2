using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repartidor.Models
{
    public partial class DB_REPARTIDORContext : DbContext
    {
        public DB_REPARTIDORContext()
        {
        }

        public DB_REPARTIDORContext(DbContextOptions<DB_REPARTIDORContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCliente> TblCliente { get; set; }
        public virtual DbSet<TblEmpleado> TblEmpleado { get; set; }
        public virtual DbSet<TblEstado> TblEstado { get; set; }
        public virtual DbSet<TblMarca> TblMarca { get; set; }
        public virtual DbSet<TblPedido> TblPedido { get; set; }
        public virtual DbSet<TblPedidoDetalle> TblPedidoDetalle { get; set; }
        public virtual DbSet<TblProducto> TblProducto { get; set; }
        public virtual DbSet<TblRestaurante> TblRestaurante { get; set; }
        public virtual DbSet<TblTarjeta> TblTarjeta { get; set; }
        public virtual DbSet<TblTipoEmpleado> TblTipoEmpleado { get; set; }
        public virtual DbSet<TblTipoProducto> TblTipoProducto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-LLPAHDFQ\\MSSQL;Database=DB_REPARTIDOR;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK_ID_CLIIENTE");

                entity.ToTable("TBL_CLIENTE");

                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

                entity.Property(e => e.ApellidoCliente)
                    .HasColumnName("APELLIDO_CLIENTE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailCliente)
                    .HasColumnName("EMAIL_CLIENTE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCliente)
                    .HasColumnName("NOMBRE_CLIENTE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoCliente).HasColumnName("TELEFONO_CLIENTE");
            });

            modelBuilder.Entity<TblEmpleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK_ID_EMPLEADO");

                entity.ToTable("TBL_EMPLEADO");

                entity.Property(e => e.IdEmpleado).HasColumnName("ID_EMPLEADO");

                entity.Property(e => e.ActivoEmpleado)
                    .HasColumnName("ACTIVO_EMPLEADO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ApellidoEmpleado)
                    .IsRequired()
                    .HasColumnName("APELLIDO_EMPLEADO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionEmpleado)
                    .IsRequired()
                    .HasColumnName("DIRECCION_EMPLEADO")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.IdRestaurante).HasColumnName("ID_RESTAURANTE");

                entity.Property(e => e.IdTipoEmpleado).HasColumnName("ID_TIPO_EMPLEADO");

                entity.Property(e => e.NombreEmpleado)
                    .IsRequired()
                    .HasColumnName("NOMBRE_EMPLEADO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoEmpleado).HasColumnName("TELEFONO_EMPLEADO");

                entity.HasOne(d => d.IdRestauranteNavigation)
                    .WithMany(p => p.TblEmpleado)
                    .HasForeignKey(d => d.IdRestaurante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_RESTAURATE");

                entity.HasOne(d => d.IdTipoEmpleadoNavigation)
                    .WithMany(p => p.TblEmpleado)
                    .HasForeignKey(d => d.IdTipoEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_TIPO_EMPLEADO");
            });

            modelBuilder.Entity<TblEstado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK_ID_ESTADO");

                entity.ToTable("TBL_ESTADO");

                entity.Property(e => e.IdEstado).HasColumnName("ID_ESTADO");

                entity.Property(e => e.ActivoEstado)
                    .HasColumnName("ACTIVO_ESTADO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DescripcionEstado)
                    .HasColumnName("DESCRIPCION_ESTADO")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.NombreEstado)
                    .IsRequired()
                    .HasColumnName("NOMBRE_ESTADO")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMarca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK_ID_MARCA");

                entity.ToTable("TBL_MARCA");

                entity.Property(e => e.IdMarca).HasColumnName("ID_MARCA");

                entity.Property(e => e.ActivoMarca)
                    .HasColumnName("ACTIVO_MARCA")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DescripcionMarca)
                    .HasColumnName("DESCRIPCION_MARCA")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.NombreMarca)
                    .IsRequired()
                    .HasColumnName("NOMBRE_MARCA")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PK_ID_PEDIDO");

                entity.ToTable("TBL_PEDIDO");

                entity.Property(e => e.IdPedido).HasColumnName("ID_PEDIDO");

                entity.Property(e => e.ActivoPedido)
                    .HasColumnName("ACTIVO_PEDIDO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DetalleDireccion)
                    .HasColumnName("DETALLE_DIRECCION")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionPedido)
                    .IsRequired()
                    .HasColumnName("DIRECCION_PEDIDO")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.FechaPedido)
                    .HasColumnName("FECHA_PEDIDO")
                    .HasColumnType("date");

                entity.Property(e => e.HoraEntrega).HasColumnName("HORA_ENTREGA");

                entity.Property(e => e.HoraPedido).HasColumnName("HORA_PEDIDO");

                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

                entity.Property(e => e.IdEstado).HasColumnName("ID_ESTADO");

                entity.Property(e => e.IdRestaurante).HasColumnName("ID_RESTAURANTE");

                entity.Property(e => e.IdTarjeta).HasColumnName("ID_TARJETA");

                entity.Property(e => e.Total).HasColumnName("TOTAL");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.TblPedido)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_ESTADO");

                entity.HasOne(d => d.IdRestauranteNavigation)
                    .WithMany(p => p.TblPedido)
                    .HasForeignKey(d => d.IdRestaurante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_RESTAURANTE");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.TblPedido)
                    .HasForeignKey(d => new { d.IdTarjeta, d.IdCliente })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_TARJETA");
            });

            modelBuilder.Entity<TblPedidoDetalle>(entity =>
            {
                entity.HasKey(e => e.IdPedidoDetalle)
                    .HasName("PK_ID_PEDIDO_DETALLE");

                entity.ToTable("TBL_PEDIDO_DETALLE");

                entity.Property(e => e.IdPedidoDetalle).HasColumnName("ID_PEDIDO_DETALLE");

                entity.Property(e => e.ActivoPedidoDetalle)
                    .HasColumnName("ACTIVO_PEDIDO_DETALLE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CantidadPedidoDetalle)
                    .HasColumnName("CANTIDAD_PEDIDO_DETALLE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdPedido).HasColumnName("ID_PEDIDO");

                entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");

                entity.Property(e => e.PrecioPedidoDetalle).HasColumnName("PRECIO_PEDIDO_DETALLE");

                entity.Property(e => e.TotalPedidoDetalle).HasColumnName("TOTAL_PEDIDO_DETALLE");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.TblPedidoDetalle)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PEDIDO");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.TblPedidoDetalle)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PRODUCTO");
            });

            modelBuilder.Entity<TblProducto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK_ID_PRODUCTO");

                entity.ToTable("TBL_PRODUCTO");

                entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");

                entity.Property(e => e.ActivoProducto)
                    .HasColumnName("ACTIVO_PRODUCTO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.IdMarca).HasColumnName("ID_MARCA");

                entity.Property(e => e.IdTipoProducto).HasColumnName("ID_TIPO_PRODUCTO");

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasColumnName("NOMBRE_PRODUCTO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio)
                    .HasColumnName("PRECIO")
                    .HasColumnType("decimal(11, 2)");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.TblProducto)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK_ID_MARCA");

                entity.HasOne(d => d.IdTipoProductoNavigation)
                    .WithMany(p => p.TblProducto)
                    .HasForeignKey(d => d.IdTipoProducto)
                    .HasConstraintName("FK_ID_TIPO_PRODUCTO");
            });

            modelBuilder.Entity<TblRestaurante>(entity =>
            {
                entity.HasKey(e => e.IdRestaurante)
                    .HasName("PK_ID_RESTAURANTE");

                entity.ToTable("TBL_RESTAURANTE");

                entity.Property(e => e.IdRestaurante).HasColumnName("ID_RESTAURANTE");

                entity.Property(e => e.ActivoRestaurante)
                    .HasColumnName("ACTIVO_RESTAURANTE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DireccionRestaurante)
                    .IsRequired()
                    .HasColumnName("DIRECCION_RESTAURANTE")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.NombreRestaurante)
                    .IsRequired()
                    .HasColumnName("NOMBRE_RESTAURANTE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono).HasColumnName("TELEFONO");
            });

            modelBuilder.Entity<TblTarjeta>(entity =>
            {
                entity.HasKey(e => new { e.IdTarjeta, e.IdCliente })
                    .HasName("PK_ID_TARJETA");

                entity.ToTable("TBL_TARJETA");

                entity.Property(e => e.IdTarjeta)
                    .HasColumnName("ID_TARJETA")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

                entity.Property(e => e.ActivoTarjeta)
                    .HasColumnName("ACTIVO_TARJETA")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CvvTarjeta).HasColumnName("CVV_TARJETA");

                entity.Property(e => e.FechaVenceTarjeta)
                    .HasColumnName("FECHA_VENCE_TARJETA")
                    .HasColumnType("date");

                entity.Property(e => e.NombreTarjeta)
                    .IsRequired()
                    .HasColumnName("NOMBRE_TARJETA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroTarjeta).HasColumnName("NUMERO_TARJETA");

                entity.Property(e => e.ProveedorTarjeta)
                    .HasColumnName("PROVEEDOR_TARJETA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TblTarjeta)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CLIENTE");
            });

            modelBuilder.Entity<TblTipoEmpleado>(entity =>
            {
                entity.HasKey(e => e.IdTipoEmpleado)
                    .HasName("PK_ID_TIPO_EMPLEADO");

                entity.ToTable("TBL_TIPO_EMPLEADO");

                entity.Property(e => e.IdTipoEmpleado).HasColumnName("ID_TIPO_EMPLEADO");

                entity.Property(e => e.ActivoTipoEmpleado)
                    .HasColumnName("ACTIVO_TIPO_EMPLEADO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DescripcionTipoEmpleado)
                    .HasColumnName("DESCRIPCION_TIPO_EMPLEADO")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.NombreTipoEmpleado)
                    .IsRequired()
                    .HasColumnName("NOMBRE_TIPO_EMPLEADO")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTipoProducto>(entity =>
            {
                entity.HasKey(e => e.IdTipoProducto)
                    .HasName("PK_ID_TIPO_PRODUCTO");

                entity.ToTable("TBL_TIPO_PRODUCTO");

                entity.Property(e => e.IdTipoProducto).HasColumnName("ID_TIPO_PRODUCTO");

                entity.Property(e => e.ActivoTipoProducto)
                    .HasColumnName("ACTIVO_TIPO_PRODUCTO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DescripcionTipoProducto)
                    .HasColumnName("DESCRIPCION_TIPO_PRODUCTO")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.NombreTipoProducto)
                    .IsRequired()
                    .HasColumnName("NOMBRE_TIPO_PRODUCTO")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBP___Api.Models;

public partial class ZapatillasC : DbContext
{
    public ZapatillasC()
    {
    }

    public ZapatillasC(DbContextOptions<ZapatillasC> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetalleVenta> DetalleVentas { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Tbproducto> Tbproductos { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SQL8005.site4now.net;Initial Catalog=db_a9ad45_gabrielcq3004;User Id=db_a9ad45_gabrielcq3004_admin;Password=Gablu2730");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A10AD5836C7");

            entity.Property(e => e.Descripcion).HasMaxLength(50);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__D594664239EAF6E9");

            entity.Property(e => e.Apellidos).HasMaxLength(50);
            entity.Property(e => e.Clave).HasMaxLength(50);
            entity.Property(e => e.Correo).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.IdVentaDetalle).HasName("PK__DetalleV__2787211D1C2C38E8");

            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK_DetalleVenta_Tbproductos");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdVenta)
                .HasConstraintName("FK_DetalleVenta_Venta");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.IdMarca).HasName("PK__Marcas__4076A887A3E129A6");

            entity.Property(e => e.Descripcion).HasMaxLength(50);
        });

        modelBuilder.Entity<Tbproducto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Tbproduc__098892109C03B859");

            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RutaImagen).HasMaxLength(300);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Tbproductos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK_Tbproductos_Categorias");

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Tbproductos)
                .HasForeignKey(d => d.IdMarca)
                .HasConstraintName("FK_Tbproductos_Marcas");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__Venta__BC1240BDCDDEDDA4");

            entity.Property(e => e.Direccion).HasMaxLength(100);
            entity.Property(e => e.FechaVenta).HasColumnType("datetime");
            entity.Property(e => e.MontoTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_Ventas_Clientes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

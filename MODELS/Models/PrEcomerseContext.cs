using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MODELS.Models;

public partial class PrEcomerseContext : DbContext
{
    public PrEcomerseContext()
    {
    }

    public PrEcomerseContext(DbContextOptions<PrEcomerseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriaProducto> CategoriaProductos { get; set; }

    public virtual DbSet<PresentacionProducto> PresentacionProductos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<StockProducto> StockProductos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=pr_ecomerse;Persist Security Info=True;User ID=sa;Password=171922DentiXpress; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriaProducto>(entity =>
        {
            entity.HasKey(e => e.IntIdCategoriaProducto).HasName("PK_Categoria");

            entity.ToTable("categoria_producto");

            entity.Property(e => e.IntIdCategoriaProducto).HasColumnName("int_id_categoria_producto");
            entity.Property(e => e.StrNombreCategoria)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("str_nombre_categoria");
        });

        modelBuilder.Entity<PresentacionProducto>(entity =>
        {
            entity.HasKey(e => e.IntIdPresentacionProducto).HasName("PK_Presentacion");

            entity.ToTable("presentacion_producto");

            entity.Property(e => e.IntIdPresentacionProducto).HasColumnName("int_id_presentacion_producto");
            entity.Property(e => e.StrDescripcionPresentacion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("str_descripcion_presentacion");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IntIdProduto).HasName("PK_Producto");

            entity.ToTable("producto");

            entity.Property(e => e.IntIdProduto).HasColumnName("int_id_produto");
            entity.Property(e => e.BitActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("bit_activo");
            entity.Property(e => e.BitGravaIva).HasColumnName("bit_grava_iva");
            entity.Property(e => e.IntIdCategoriaProducto).HasColumnName("int_id_categoria_producto");
            entity.Property(e => e.IntIdPresentacionProducto).HasColumnName("int_id_presentacion_producto");
            entity.Property(e => e.IntPorcentajeGanancia).HasColumnName("int_porcentaje_ganancia");
            entity.Property(e => e.MonValorCostoUnitario)
                .HasColumnType("money")
                .HasColumnName("mon_valor_costo_unitario");
            entity.Property(e => e.StrDescripcionProducto)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("str_descripcion_producto");
            entity.Property(e => e.StrNombreProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("str_nombre_producto");

            entity.HasOne(d => d.IntIdCategoriaProductoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IntIdCategoriaProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Categoria");

            entity.HasOne(d => d.IntIdPresentacionProductoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IntIdPresentacionProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Presentacion");
        });

        modelBuilder.Entity<StockProducto>(entity =>
        {
            entity.HasKey(e => e.IntIdMovimientoStock).HasName("PK_Producto_STOCK");

            entity.ToTable("stock_producto");

            entity.Property(e => e.IntIdMovimientoStock).HasColumnName("int_id_movimiento_stock");
            entity.Property(e => e.IntCantidadMovimiento).HasColumnName("int_cantidad_movimiento");
            entity.Property(e => e.IntIdStockProducto).HasColumnName("int_id_stock_producto_");

            entity.HasOne(d => d.IntIdStockProductoNavigation).WithMany(p => p.StockProductos)
                .HasForeignKey(d => d.IntIdStockProducto)
                .HasConstraintName("FK_IdProducto");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

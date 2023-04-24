using System;
using System.Collections.Generic;
using API.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Data;

public partial class OrdersContext : DbContext
{
    public OrdersContext()
    {
    }

    public OrdersContext(DbContextOptions<OrdersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.HasIndex(e => e.CustomerName, "IndexCustomerName");

            entity.Property(e => e.CustomerAddress).HasMaxLength(100);
            entity.Property(e => e.CustomerName).HasMaxLength(20);
            entity.Property(e => e.TaxIdentifier).HasMaxLength(20);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.HasIndex(e => e.CustomerId, "IndexOrderCustomerId");

            entity.Property(e => e.OrderAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.ToTable("OrderDetail");

            entity.HasIndex(e => e.OrderId, "IX_OrderDetail_OrderId");

            entity.HasIndex(e => e.ProductId, "IX_OrderDetail_ProductId");

            entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.HasIndex(e => e.ProductCode, "IndexProductCode");

            entity.Property(e => e.ProductCode).HasMaxLength(20);
            entity.Property(e => e.ProductDescription).HasMaxLength(500);
            entity.Property(e => e.ProductName).HasMaxLength(100);
            entity.Property(e => e.ProductPrice).HasColumnType("decimal(12, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

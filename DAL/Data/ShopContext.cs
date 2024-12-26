using System;
using System.Collections.Generic;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data;

public partial class ShopContext : DbContext
{
    public ShopContext()
    {
    }

    public ShopContext(DbContextOptions<ShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<PickupPoint> PickupPoints { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source = F4T4LERR0R; Initial Catalog = tradedb; User ID = ispp3510; Password = 3510; Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BAFEA8B9369");

            entity.ToTable("Order");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(30);

            entity.HasOne(d => d.PickupPoint).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PickupPointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_PickupPoint");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Order_User");
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductArticleNumber }).HasName("PK__OrderPro__817A2662651DFEFA");

            entity.ToTable("OrderProduct");

            entity.Property(e => e.ProductArticleNumber).HasMaxLength(30);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderProd__Order__52593CB8");

            entity.HasOne(d => d.ProductArticleNumberNavigation).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.ProductArticleNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderProd__Produ__534D60F1");
        });

        modelBuilder.Entity<PickupPoint>(entity =>
        {
            entity.ToTable("PickupPoint");

            entity.Property(e => e.Address).HasMaxLength(200);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductArticleNumber).HasName("PK__Product__2EA7DCD53CA7D863");

            entity.ToTable("Product");

            entity.Property(e => e.ProductArticleNumber).HasMaxLength(30);
            entity.Property(e => e.Category).HasMaxLength(20);
            entity.Property(e => e.Cost).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Manufacturer).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Photo).HasColumnType("image");
            entity.Property(e => e.Status).HasMaxLength(30);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3A9C95F12A");

            entity.ToTable("Role");

            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCAC29940AA2");

            entity.ToTable("User");

            entity.Property(e => e.Login).HasMaxLength(30);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(30);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User__UserRole__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

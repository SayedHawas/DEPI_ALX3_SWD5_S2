using System;
using System.Collections.Generic;
using Day3EFCoreDbFirstDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace Day3EFCoreDbFirstDemo.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<LkpCity> LkpCities { get; set; }

    public virtual DbSet<LkpDepartment> LkpDepartments { get; set; }

    public virtual DbSet<LkpEmployee> LkpEmployees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<SupplyOrder> SupplyOrders { get; set; }

    public virtual DbSet<SupplyOrderDetail> SupplyOrderDetails { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SAYEDHAWAS\\DEPI2025R3G2;Initial Catalog=DbFirstDemoDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryName).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(500);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.Property(e => e.ClientName).HasMaxLength(50);
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LkpCity>(entity =>
        {
            entity.HasKey(e => e.CityId);

            entity.Property(e => e.CityName).HasMaxLength(50);
        });

        modelBuilder.Entity<LkpDepartment>(entity =>
        {
            entity.HasKey(e => e.DepartmentId);

            entity.Property(e => e.DepartmentId).HasColumnName("departmentId");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ManagerName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<LkpEmployee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);

            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Jobtitle).HasMaxLength(50);
            entity.Property(e => e.Mobile)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Photo).HasMaxLength(250);
            entity.Property(e => e.Salary).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.Department).WithMany(p => p.LkpEmployees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_LkpEmployees_LkpDepartments");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.TotalOrder).HasColumnType("decimal(9, 2)");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Clients");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetails);

            entity.Property(e => e.UnitPrice).HasColumnType("decimal(9, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Photo).HasMaxLength(250);
            entity.Property(e => e.Price).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Categories");
        });

        modelBuilder.Entity<SupplyOrder>(entity =>
        {
            entity.Property(e => e.SupplyDate).HasColumnType("datetime");
            entity.Property(e => e.Total).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.Employee).WithMany(p => p.SupplyOrders)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SupplyOrders_LkpEmployees");

            entity.HasOne(d => d.Vendor).WithMany(p => p.SupplyOrders)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SupplyOrders_Vendors");
        });

        modelBuilder.Entity<SupplyOrderDetail>(entity =>
        {
            entity.HasKey(e => e.SupplyOrderDetailsId);

            entity.Property(e => e.UnitPrice).HasColumnType("decimal(9, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.SupplyOrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SupplyOrderDetails_Products");

            entity.HasOne(d => d.SupplyOrder).WithMany(p => p.SupplyOrderDetails)
                .HasForeignKey(d => d.SupplyOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SupplyOrderDetails_SupplyOrders");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.Property(e => e.Creadit).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.IsDelete).HasDefaultValue(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.TotalBalance).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.VendorName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

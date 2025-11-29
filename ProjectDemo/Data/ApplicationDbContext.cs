using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ProjectDemo.Models;

namespace ProjectDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }



        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductImage> ProductImages { get; set; }

        public virtual DbSet<ProductVariant> ProductVariants { get; set; }

        public virtual DbSet<SupplyOrder> SupplyOrders { get; set; }

        public virtual DbSet<SupplyOrderDetail> SupplyOrderDetails { get; set; }

        public virtual DbSet<Vendor> Vendors { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //            => optionsBuilder.UseSqlServer("Data Source=SAYEDHAWAS\\DEPI2025R3G2;Initial Catalog=Vendora;Integrated Security=True");


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // base.OnConfiguring(optionsBuilder);
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Address>(entity =>
        //    {
        //        entity.Property(e => e.created_at).HasDefaultValueSql("(sysutcdatetime())");
        //        entity.Property(e => e.is_default).HasDefaultValue(false);

        //        entity.HasOne(d => d.Client).WithMany(p => p.Addresses)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Addresses_Clients");
        //    });

        //    modelBuilder.Entity<Category>(entity =>
        //    {
        //        entity.HasKey(e => e.CategoryID).HasName("PK__Categori__19093A2B3D9FEA2B");

        //        entity.Property(e => e.IsDeleted).HasDefaultValue(false);

        //        entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory).HasConstraintName("FK_Categories_Parent");
        //    });

        //    modelBuilder.Entity<Client>(entity =>
        //    {
        //        entity.HasKey(e => e.ClientID).HasName("PK__Clients__E67E1A040E1A00B2");

        //        entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
        //        entity.Property(e => e.IsDeleted).HasDefaultValue(false);
        //    });

        //    modelBuilder.Entity<Employee>(entity =>
        //    {
        //        entity.HasKey(e => e.EmployeeID).HasName("PK__Employee__7AD04FF1D34248E5");

        //        entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
        //        entity.Property(e => e.IsActive).HasDefaultValue(true);
        //    });

        //    modelBuilder.Entity<Order>(entity =>
        //    {
        //        entity.HasKey(e => e.OrderID).HasName("PK__Orders__C3905BAF885D7C46");

        //        entity.Property(e => e.OrderDate).HasDefaultValueSql("(sysdatetime())");

        //        entity.HasOne(d => d.Client).WithMany(p => p.Orders)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Orders_Clients");
        //    });

        //    modelBuilder.Entity<OrderDetail>(entity =>
        //    {
        //        entity.HasKey(e => e.OrderDetailsID).HasName("PK__OrderDet__9DD74D9D049E0E13");

        //        entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_OrderDetails_Orders");

        //        entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_OrderDetails_Products");
        //    });

        //    modelBuilder.Entity<Product>(entity =>
        //    {
        //        entity.HasKey(e => e.ProductID).HasName("PK__Products__B40CC6ED16C39044");

        //        entity.Property(e => e.IsDeleted).HasDefaultValue(false);

        //        entity.HasOne(d => d.Category).WithMany(p => p.Products)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Products_Categories");
        //    });

        //    modelBuilder.Entity<ProductImage>(entity =>
        //    {
        //        entity.Property(e => e.IsPrimary).HasDefaultValue(false);

        //        entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ProductImages_Products");
        //    });

        //    modelBuilder.Entity<ProductVariant>(entity =>
        //    {
        //        entity.HasKey(e => e.VariantID).HasName("PK__ProductV__0EA233E4FD2CFA21");

        //        entity.Property(e => e.IsActive).HasDefaultValue(true);

        //        entity.HasOne(d => d.Product).WithMany(p => p.ProductVariants)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ProductVariants_Products");
        //    });

        //    modelBuilder.Entity<SupplyOrder>(entity =>
        //    {
        //        entity.HasKey(e => e.SupplyOrderID).HasName("PK__SupplyOr__2D1FCC6D376CBBFB");

        //        entity.HasOne(d => d.Employee).WithMany(p => p.SupplyOrders)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_SupplyOrders_Employees");

        //        entity.HasOne(d => d.Vendor).WithMany(p => p.SupplyOrders)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_SupplyOrders_Vendors");
        //    });

        //    modelBuilder.Entity<SupplyOrderDetail>(entity =>
        //    {
        //        entity.HasKey(e => e.SupplyOrderDetailID).HasName("PK__SupplyOr__7CEB91194A00AD59");

        //        entity.HasOne(d => d.Product).WithMany(p => p.SupplyOrderDetails)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_SupplyOrderDetails_Products");

        //        entity.HasOne(d => d.SupplyOrder).WithMany(p => p.SupplyOrderDetails)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_SupplyOrderDetails_SupplyOrders");
        //    });

        //    modelBuilder.Entity<Vendor>(entity =>
        //    {
        //        entity.HasKey(e => e.VendorID).HasName("PK__Vendors__FC8618D322052160");

        //        entity.Property(e => e.ApprovedAt).HasDefaultValueSql("(sysdatetime())");
        //        entity.Property(e => e.Balance).HasDefaultValue(0m);
        //    });
        //}
    }
}

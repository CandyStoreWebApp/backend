using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SweetIncApi.BusinessModels
{
    public partial class CandyStore2Context : DbContext
    {
        public CandyStore2Context()
        {
        }

        public CandyStore2Context(DbContextOptions<CandyStore2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Box> Boxes { get; set; }
        public virtual DbSet<BoxPattern> BoxPatterns { get; set; }
        public virtual DbSet<BoxProduct> BoxProducts { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Origin> Origins { get; set; }
        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Database=CandyStore2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Box>(entity =>
            {
                entity.ToTable("Box");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BoxPatternId).HasColumnName("boxPatternId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.BoxPattern)
                    .WithMany(p => p.Boxes)
                    .HasForeignKey(d => d.BoxPatternId)
                    .HasConstraintName("FK_Box_BoxPattern");
            });

            modelBuilder.Entity<BoxPattern>(entity =>
            {
                entity.ToTable("BoxPattern");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("image");

                entity.Property(e => e.LowerAge).HasColumnName("lowerAge");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasDefaultValueSql("((100))");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpperAge).HasColumnName("upperAge");
            });

            modelBuilder.Entity<BoxProduct>(entity =>
            {
                entity.HasKey(e => new { e.BoxId, e.ProductId });

                entity.ToTable("BoxProduct");

                entity.Property(e => e.BoxId).HasColumnName("boxId");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("productName")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Box)
                    .WithMany(p => p.BoxProducts)
                    .HasForeignKey(d => d.BoxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BoxProduct_Box");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.BoxProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BoxProduct_Product");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.OriginId).HasColumnName("originId");

                entity.HasOne(d => d.Origin)
                    .WithMany(p => p.Brands)
                    .HasForeignKey(d => d.OriginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Brand_origin");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datetime)
                    .HasColumnType("datetime")
                    .HasColumnName("datetime");

                entity.Property(e => e.PaymentId).HasColumnName("paymentId");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK__Order__paymentId__4316F928");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.BoxId })
                    .HasName("PK_Orderdetail");

                entity.ToTable("OrderDetail");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.BoxId).HasColumnName("boxId");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Box)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.BoxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orderdetail_Box");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orderdetail_Order");
            });

            modelBuilder.Entity<Origin>(entity =>
            {
                entity.ToTable("Origin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PaymentDetail>(entity =>
            {
                entity.ToTable("PaymentDetail");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Provider)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("provider");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BrandId).HasColumnName("brandId");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Brand");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Catagory");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .HasColumnName("fullname");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

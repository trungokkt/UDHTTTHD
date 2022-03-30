using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DiChoThue.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartItems> CartItems { get; set; }
        public virtual DbSet<HistoryOrderStatus> HistoryOrderStatus { get; set; }
        public virtual DbSet<OrderEvaluation> OrderEvaluation { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<Shipper> Shipper { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-4H2CDN2;Initial Catalog=QuanLyDiChoThue;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("BR_PK");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Buyer)
                    .HasForeignKey<Buyer>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BR_UI");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithOne(p => p.Cart)
                    .HasForeignKey<Cart>(d => d.UserId)
                    .HasConstraintName("FK_CR_BR");
            });

            modelBuilder.Entity<CartItems>(entity =>
            {
                entity.HasKey(e => new { e.CartId, e.ProductId })
                    .HasName("CI_PK");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CI_CR");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CI_PR");
            });

            modelBuilder.Entity<HistoryOrderStatus>(entity =>
            {
                entity.HasKey(e => e.HistoryId)
                    .HasName("HOS_PK");

                entity.Property(e => e.HistoryId).ValueGeneratedNever();

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.HistoryOrderStatus)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_HOS_OR");
            });

            modelBuilder.Entity<OrderEvaluation>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.UserId })
                    .HasName("OE_PK");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderEvaluation)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OE_OR");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderEvaluation)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OE_UI");
            });

            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("OI_PK");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OI_OR");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OI_PR");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("OR_PK");

                entity.Property(e => e.OrderPhone).IsUnicode(false);

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BuyerId)
                    .HasConstraintName("FK_OR_BR");

                entity.HasOne(d => d.Shipper)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipperId)
                    .HasConstraintName("FK_OR_SP");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductTypeId)
                    .HasConstraintName("FK_PR_PT");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.HasOne(d => d.Store)
                    .WithMany(p => p.ProductType)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_PT_SR");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("SL_PK");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Seller)
                    .HasForeignKey<Seller>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SL_UI");
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("SP_PK");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Shipper)
                    .HasForeignKey<Shipper>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SP_UI");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.StorePhone).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Store)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_SR_SL");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("UI_PK");

                entity.HasIndex(e => e.UserAddress)
                    .HasName("UQ__UserInfo__C31EBD1003952E35")
                    .IsUnique();

                entity.Property(e => e.UserEmail).IsUnicode(false);

                entity.Property(e => e.UserLoginName).IsUnicode(false);

                entity.Property(e => e.UserPassword).IsUnicode(false);

                entity.Property(e => e.UserPhone).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

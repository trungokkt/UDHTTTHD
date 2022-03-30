using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DICHOTHUEAPI.Models
{
    public partial class QuanLyDiChoThueContext : DbContext
    {
        public QuanLyDiChoThueContext()
        {
        }

        public QuanLyDiChoThueContext(DbContextOptions<QuanLyDiChoThueContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartItems> CartItems { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<HibernateSequences> HibernateSequences { get; set; }
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
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=QuanLyDiChoThue;Integrated Security=True");
            //}
            optionsBuilder
                .UseLazyLoadingProxies()
                .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning))
                .UseSqlServer("Data Source=.;Initial Catalog=QuanLyDiChoThue;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Buyer)
                    .HasForeignKey<Buyer>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BR_UI");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CartPrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.CartQuantity).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_CR_BR");
            });

            modelBuilder.Entity<CartItems>(entity =>
            {
                entity.HasKey(e => new { e.CartId, e.ProductId });

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

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<HibernateSequences>(entity =>
            {
                entity.HasKey(e => e.SequenceName);

                entity.ToTable("hibernate_sequences");

                entity.Property(e => e.SequenceName)
                    .HasColumnName("sequence_name")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.NextVal).HasColumnName("next_val");
            });

            modelBuilder.Entity<HistoryOrderStatus>(entity =>
            {
                entity.HasKey(e => e.HistoryId);

                entity.Property(e => e.HistoryId).ValueGeneratedNever();

                entity.Property(e => e.OrderStatusDate).HasColumnType("date");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.HistoryOrderStatus)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_HOS_OR");

                entity.HasOne(d => d.OrderStatusNavigation)
                    .WithMany(p => p.HistoryOrderStatus)
                    .HasForeignKey(d => d.OrderStatus)
                    .HasConstraintName("FK_HistoryOrderStatus_Status");
            });

            modelBuilder.Entity<OrderEvaluation>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.UserId });

                entity.Property(e => e.Evaluation).HasMaxLength(100);

                entity.Property(e => e.EvaluationDate).HasColumnType("date");

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
                entity.HasKey(e => new { e.OrderId, e.ProductId });

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
                entity.HasKey(e => e.OrderId);

                entity.Property(e => e.OrderCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentType).HasMaxLength(50);

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
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductDescription).HasMaxLength(50);

                entity.Property(e => e.ProductName).HasMaxLength(50);

                entity.Property(e => e.ProductUnit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductTypeId)
                    .HasConstraintName("FK_PR_PT");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.Property(e => e.ProductTypeName).HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductType)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_C_PT");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.ProductType)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_PT_SR");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Seller)
                    .HasForeignKey<Seller>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SL_UI");
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Shipper)
                    .HasForeignKey<Shipper>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SP_UI");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .ValueGeneratedNever();

                entity.Property(e => e.Lable)
                    .HasColumnName("lable")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.StoreLat).HasMaxLength(50);

                entity.Property(e => e.StoreLng).HasMaxLength(50);

                entity.Property(e => e.StoreName).HasMaxLength(50);

                entity.Property(e => e.StorePhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Store)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_SR_SL");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserBirth).HasColumnType("date");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserLoginName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.HasSequence("hibernate_sequence");
        }
    }
}

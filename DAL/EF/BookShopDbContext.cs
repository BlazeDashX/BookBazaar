using System;
using System.Collections.Generic;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public partial class BookShopDbContext : DbContext
{
    public BookShopDbContext()
    {
    }

    public BookShopDbContext(DbContextOptions<BookShopDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=BookShopDB;TrustServerCertificate=True;Integrated Security=True;"
            );
        }
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC0744203BB2");

            entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EA1DA51B2B").IsUnique();

            entity.Property(e => e.Author).HasMaxLength(150);
            entity.Property(e => e.CoverImageUrl).HasMaxLength(500);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .HasColumnName("ISBN");
            entity.Property(e => e.Language)
                .HasMaxLength(50)
                .HasDefaultValue("English");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Publisher).HasMaxLength(150);
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Category).WithMany(p => p.Books)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_Categories");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07CD8BA926");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Coupons__3214EC071655FA76");

            entity.HasIndex(e => e.Code, "UQ__Coupons__A25C5AA7A335F933").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC071657AC21");

            entity.HasIndex(e => e.ReferenceId, "UQ__Orders__E1A99A18F6E5142F").IsUnique();

            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FinalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.PlacedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ReferenceId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ShippingAddress).HasMaxLength(400);
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasDefaultValue("Pending");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Coupon).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CouponId)
                .HasConstraintName("FK_Orders_Coupons");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Users");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC078DB47256");

            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Book).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_Books");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_Orders");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC075F4B6D4B");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105347EA98C3A").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(300);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.OauthId)
                .HasMaxLength(256)
                .HasColumnName("OAuthId");
            entity.Property(e => e.OauthProvider)
                .HasMaxLength(50)
                .HasColumnName("OAuthProvider");
            entity.Property(e => e.PasswordHash).HasMaxLength(256);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasDefaultValue("Customer");
            entity.Property(e => e.Token).HasMaxLength(256);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

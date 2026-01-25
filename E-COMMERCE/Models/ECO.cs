using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace E_COMMERCE.Models;

public partial class ECO : DbContext
{
    public ECO()
    {
    }

    public ECO(DbContextOptions<ECO> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }



    public virtual DbSet<Cetogery> Cetogeries { get; set; }

    //public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderdetial> Orderdetials { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Productimage> Productimages { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Review2> Review2s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-FM1M1N2\\SQLEXPRESS;Database=commerce;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.ToTable("cart");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Quntity).HasColumnName("quntity");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("FK_cart_product");
        });

      
        modelBuilder.Entity<Cetogery>(entity =>
        {
            entity.ToTable("cetogery");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Photos).HasColumnName("photos");
        });

        //modelBuilder.Entity<Order>(entity =>
        //{
        //    entity.ToTable("order");

        //    entity.Property(e => e.Id).HasColumnName("id");
        //    entity.Property(e => e.Adderss).HasColumnName("adderss");
        //    entity.Property(e => e.Email).HasColumnName("email");
        //    entity.Property(e => e.Name).HasColumnName("name");
        //    entity.Property(e => e.Onlinepaid).HasColumnName("onlinepaid");
        //    entity.Property(e => e.Phone).HasColumnName("phone");
        //    entity.Property(e => e.Userid).HasColumnName("userid");
        //});

        modelBuilder.Entity<Orderdetial>(entity =>
        {
            entity.ToTable("orderdetials");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Entitydata).HasColumnName("entitydata");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Totalprice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("totalprice");

            //entity.HasOne(d => d.Order).WithMany(p => p.Orderdetials)
            //    .HasForeignKey(d => d.Orderid)
            //    .HasConstraintName("FK_orderdetials_order");

            entity.HasOne(d => d.Product).WithMany(p => p.Orderdetials)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("FK_orderdetials_product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ceito).HasColumnName("ceito");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Entitydata).HasColumnName("entitydata");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
            entity.Property(e => e.Productquntity).HasColumnName("productquntity");
            entity.Property(e => e.Reviewurl).HasColumnName("reviewurl");
            entity.Property(e => e.Siplername).HasColumnName("siplername");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.CeitoNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Ceito)
                .HasConstraintName("FK_product_cetogery");
        });

        modelBuilder.Entity<Productimage>(entity =>
        {
            entity.ToTable("productimage");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Productid).HasColumnName("productid");

            entity.HasOne(d => d.Product).WithMany(p => p.Productimages)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("FK_productimage_product");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("review");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Subject).HasColumnName("subject");
        });

        modelBuilder.Entity<Review2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__review2__3214EC0702341674");

            entity.ToTable("review2");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Subject).HasMaxLength(150);

            entity.HasOne(d => d.Product).WithMany(p => p.Review2s)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reviews_Product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MinimalAPI.Entities;

public partial class ProductDbContext : DbContext
{
    public ProductDbContext()
    {
    }

    public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=pg-14b5c807-code-first.g.aivencloud.com;Port=21029;Database=Products;Username=avnadmin;Password=AVNS_ps0KiO6cGJgDYVqvfEl;SSL Mode=Require;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Products_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .HasColumnName("category");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Ratings)
                .HasPrecision(10)
                .HasColumnName("ratings");
            entity.Property(e => e.Warranty)
                .HasMaxLength(50)
                .HasColumnName("warranty");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

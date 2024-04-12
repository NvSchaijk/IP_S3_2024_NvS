using System;
using IP_Models.DTOs;
using Microsoft.EntityFrameworkCore;
namespace IP_DateLayer
{
    public class ToyShopAPIDBContext : DbContext
    {
        

        public DbSet<BrandDTO> Brandset { get; set; }
        public DbSet<CategoryDTO> Categoryset { get; set; }
        public DbSet<Category_ItemDTO> Category_Itemset { get; set; }
        public DbSet<ItemDTO> Itemset { get; set; }

        public ToyShopAPIDBContext(DbContextOptions<ToyShopAPIDBContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BrandDTO>(entity =>
            {
                entity.ToTable("Brand").HasKey("BrandID");

                entity.Property(e => e.BrandID)
                    .HasColumnName("BrandID");

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasColumnName("BrandName")
                    .HasMaxLength(100);

                entity.Property(e => e.BrandDescription)
                    .HasColumnName("BrandDescription")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CategoryDTO>(entity =>
            {
                entity.ToTable("Category").HasKey("CategoryID");

                entity.Property(e => e.CategoryID)
                .HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("CategoryName")
                    .HasMaxLength(100);

                entity.Property(e => e.CategoryDescription)
                    .HasColumnName("CategoryDescription")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Category_ItemDTO>(entity =>
            {
                entity.ToTable("Category_Item").HasKey("Category_ItemID");

                entity.Property(e => e.Category_ItemID)
                .HasColumnName("Category_ItemID");

                entity.Property(e => e.CategoryID)
                .HasColumnName("CategoryID");

                entity.Property(e => e.ItemID)
                .HasColumnName("ItemID");

            });

            modelBuilder.Entity<ItemDTO>(entity =>
            {
                entity.ToTable("Item").HasKey("ItemID");

                entity.Property(e => e.ItemID)
                .HasColumnName("ItemID");

                entity.Property(e => e.BrandID)
                .HasColumnName("BrandID");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("ItemName")
                    .HasMaxLength(100);

                entity.Property(e => e.ItemDescription)
                    .HasColumnName("ItemDescription")
                    .HasMaxLength(255);

                entity.Property(e => e.ItemPrice)
                    .HasColumnName("ItemPrice");

                entity.Property(e => e.ItemQuantity)
                    .HasColumnName("ItemQuantity");

                entity.Property(e => e.ItemQuantitySold)
                    .HasColumnName("ItemQuantitySold");
            });
        }
    }
}


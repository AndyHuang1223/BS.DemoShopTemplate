using BS.DemoShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DemoShop.Infrastructure.Data
{
    public partial class BSDemoShopContext : DbContext
    {
        public BSDemoShopContext(DbContextOptions<BSDemoShopContext> options) : base(options) { }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductDetail> ProductDetail { get; set; }
        public virtual DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .ToTable("Categories");

            #region CategorySeed

            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "預設分類1", Sort = 0, CreatedTime = DateTimeOffset.UtcNow });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Name = "預設分類2", Sort = 1, CreatedTime = DateTimeOffset.UtcNow });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, Name = "預設分類3", Sort = 2, CreatedTime = DateTimeOffset.UtcNow });

            #endregion
            
            modelBuilder.Entity<Product>()
               .ToTable("Products");

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            #region ProductSeed

            modelBuilder.Entity<Product>().HasData(new Product { Id = 1, CategoryId = 1, Name = "種子商品1", ImgPath = "https://picsum.photos/300/200/?random=1", IsOnTheMarket = true, CreatedTime = DateTime.UtcNow });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 2, CategoryId = 2, Name = "種子商品2", ImgPath = "https://picsum.photos/300/200/?random=2", IsOnTheMarket = false, CreatedTime = DateTime.UtcNow });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 3, CategoryId = 3, Name = "種子商品3", ImgPath = "https://picsum.photos/300/200/?random=3", IsOnTheMarket = true, CreatedTime = DateTime.UtcNow });

            #endregion

            modelBuilder.Entity<ProductDetail>()
               .Property(b => b.UnitPrice)
               .HasPrecision(18, 2);

            modelBuilder.Entity<ProductDetail>()
               .ToTable("ProductDetails");
            #region ProductDetailSeed

            modelBuilder.Entity<ProductDetail>().HasData(new ProductDetail { Id = 1, ProductId = 1, Name = "種子規格1", UnitPrice = 100, Inventory = 100, CreatedTime = DateTime.UtcNow });
            modelBuilder.Entity<ProductDetail>().HasData(new ProductDetail { Id = 2, ProductId = 1, Name = "種子規格2", UnitPrice = 100, Inventory = 10, CreatedTime = DateTime.UtcNow });
            modelBuilder.Entity<ProductDetail>().HasData(new ProductDetail { Id = 3, ProductId = 1, Name = "種子規格3", UnitPrice = 100, Inventory = 8, CreatedTime = DateTime.UtcNow });
            modelBuilder.Entity<ProductDetail>().HasData(new ProductDetail { Id = 4, ProductId = 2, Name = "種子規格4", UnitPrice = 100, Inventory = 18, CreatedTime = DateTime.UtcNow });
            modelBuilder.Entity<ProductDetail>().HasData(new ProductDetail { Id = 5, ProductId = 3, Name = "種子規格4", UnitPrice = 100, Inventory = 0, CreatedTime = DateTime.UtcNow });
            modelBuilder.Entity<ProductDetail>().HasData(new ProductDetail { Id = 6, ProductId = 3, Name = "種子規格4", UnitPrice = 100, Inventory = 120, CreatedTime = DateTime.UtcNow });
            modelBuilder.Entity<ProductDetail>().HasData(new ProductDetail { Id = 7, ProductId = 3, Name = "種子規格4", UnitPrice = 100, Inventory = 20, CreatedTime = DateTime.UtcNow });

            #endregion

            

           

           
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

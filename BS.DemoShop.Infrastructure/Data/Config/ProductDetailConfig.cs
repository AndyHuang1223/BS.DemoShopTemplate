using System;
using BS.DemoShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BS.DemoShop.Infrastructure.Data.Config
{
    public class ProductDetailConfig : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder
                .Property(b => b.UnitPrice)
                .HasPrecision(18, 2);

            builder
                .ToTable("ProductDetails");

            #region ProductDetailSeed

            builder.HasData(new ProductDetail { Id = 1, ProductId = 1, Name = "種子規格1", UnitPrice = 100, Inventory = 100, CreatedTime = DateTime.UtcNow });
            builder.HasData(new ProductDetail { Id = 2, ProductId = 1, Name = "種子規格2", UnitPrice = 100, Inventory = 10, CreatedTime = DateTime.UtcNow });
            builder.HasData(new ProductDetail { Id = 3, ProductId = 1, Name = "種子規格3", UnitPrice = 100, Inventory = 8, CreatedTime = DateTime.UtcNow });
            builder.HasData(new ProductDetail { Id = 4, ProductId = 2, Name = "種子規格4", UnitPrice = 100, Inventory = 18, CreatedTime = DateTime.UtcNow });
            builder.HasData(new ProductDetail { Id = 5, ProductId = 3, Name = "種子規格4", UnitPrice = 100, Inventory = 0, CreatedTime = DateTime.UtcNow });
            builder.HasData(new ProductDetail { Id = 6, ProductId = 3, Name = "種子規格4", UnitPrice = 100, Inventory = 120, CreatedTime = DateTime.UtcNow });
            builder.HasData(new ProductDetail { Id = 7, ProductId = 3, Name = "種子規格4", UnitPrice = 100, Inventory = 20, CreatedTime = DateTime.UtcNow });

            #endregion
        }
    }
}
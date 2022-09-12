using System;
using BS.DemoShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BS.DemoShop.Infrastructure.Data.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .ToTable("Products");
            
            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
            
            builder.HasData(new Product { Id = 1, CategoryId = 1, Name = "種子商品1", ImgPath = "https://picsum.photos/300/200/?random=1", IsOnTheMarket = true, CreatedTime = DateTime.UtcNow });
            builder.HasData(new Product { Id = 2, CategoryId = 2, Name = "種子商品2", ImgPath = "https://picsum.photos/300/200/?random=2", IsOnTheMarket = false, CreatedTime = DateTime.UtcNow });
            builder.HasData(new Product { Id = 3, CategoryId = 3, Name = "種子商品3", ImgPath = "https://picsum.photos/300/200/?random=3", IsOnTheMarket = true, CreatedTime = DateTime.UtcNow });

        }
    }
}
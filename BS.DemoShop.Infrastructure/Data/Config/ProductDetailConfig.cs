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
        }
    }
}
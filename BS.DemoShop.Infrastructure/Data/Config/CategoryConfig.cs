using System;
using BS.DemoShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BS.DemoShop.Infrastructure.Data.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .ToTable("Categories");

            #region CategorySeed

            builder.HasData(new Category { Id = 1, Name = "預設分類1", Sort = 0, CreatedTime = DateTimeOffset.UtcNow });
            builder.HasData(new Category { Id = 2, Name = "預設分類2", Sort = 1, CreatedTime = DateTimeOffset.UtcNow });
            builder.HasData(new Category { Id = 3, Name = "預設分類3", Sort = 2, CreatedTime = DateTimeOffset.UtcNow });

            #endregion
        }
    }
}
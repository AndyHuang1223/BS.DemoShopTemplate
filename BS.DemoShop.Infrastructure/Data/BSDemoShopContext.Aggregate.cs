using System.Reflection;
using BS.DemoShop.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BS.DemoShop.Infrastructure.Data
{
    public partial class BSDemoShopContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            // DbSet設定，也可以用原始的方式處理
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            // 建立需要的SeedData
            modelBuilder.Entity<Category>().HasData(SeedData.ProduceCategories());
            modelBuilder.Entity<Product>().HasData(SeedData.ProduceProducts());
            modelBuilder.Entity<ProductDetail>().HasData(SeedData.ProductDetails());
            modelBuilder.Entity<Role>().HasData(SeedData.ProduceRoles());
            modelBuilder.Entity<User>().HasData(SeedData.ProduceUsers());
            modelBuilder.Entity<UserRole>().HasData(SeedData.ProduceUserRoles());
        }

    }
}
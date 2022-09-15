using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BS.DemoShop.Core.Entities;
using BS.DemoShop.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BS.DemoShop.Infrastructure.Data
{
    public class BSDemoShopContextSeed
    {
        public static void SeedDevelopment(BSDemoShopContext context, ILogger logger, int retry = 0)
        {
            var retryForAvailability = retry;
            try
            {
                if (!context.Database.IsSqlServer())
                {
                    return;
                }

                //先刪除再建立，確保測試資料是乾淨的
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 5) throw;

                retryForAvailability++;

                logger.LogError(ex.Message);
                SeedDevelopment(context, logger, retryForAvailability);
                throw;
            }
        }

        public static void SeedForProduction(BSDemoShopContext context, ILogger logger, int retry = 0)
        {
            var retryForAvailability = retry;
            try
            {
                if (!context.Database.IsSqlServer())
                {
                    return;
                }

                //套用Migrations相關紀錄
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 5) throw;

                retryForAvailability++;

                logger.LogError(ex.Message);
                SeedForProduction(context, logger, retryForAvailability);
                throw;
            }
        }
    }

    /// <summary>
    /// SeedData相關資料靜態類別
    /// </summary>
    public static class SeedData
    {
        public static List<Category> ProduceCategories()
        {
            return new List<Category>()
            {
                new Category { Id = 1, Name = "預設分類1", Sort = 0, CreatedTime = DateTimeOffset.UtcNow },
                new Category { Id = 2, Name = "預設分類2", Sort = 1, CreatedTime = DateTimeOffset.UtcNow },
                new Category { Id = 3, Name = "預設分類3", Sort = 2, CreatedTime = DateTimeOffset.UtcNow }
            };
        }

        public static List<Product> ProduceProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, CategoryId = 1, Name = "種子商品1", ImgPath = "https://picsum.photos/300/200/?random=1", IsOnTheMarket = true, CreatedTime = DateTime.UtcNow },
                new Product { Id = 2, CategoryId = 2, Name = "種子商品2", ImgPath = "https://picsum.photos/300/200/?random=2", IsOnTheMarket = false, CreatedTime = DateTime.UtcNow },
                new Product { Id = 3, CategoryId = 3, Name = "種子商品3", ImgPath = "https://picsum.photos/300/200/?random=3", IsOnTheMarket = true, CreatedTime = DateTime.UtcNow }
            };
        }

        public static List<ProductDetail> ProductDetails()
        {
            return new List<ProductDetail>
            {
                new ProductDetail { Id = 1, ProductId = 1, Name = "種子規格1", UnitPrice = 100, Inventory = 100, CreatedTime = DateTime.UtcNow },
                new ProductDetail { Id = 2, ProductId = 1, Name = "種子規格2", UnitPrice = 100, Inventory = 10, CreatedTime = DateTime.UtcNow },
                new ProductDetail { Id = 3, ProductId = 1, Name = "種子規格3", UnitPrice = 100, Inventory = 8, CreatedTime = DateTime.UtcNow },
                new ProductDetail { Id = 4, ProductId = 2, Name = "種子規格4", UnitPrice = 100, Inventory = 18, CreatedTime = DateTime.UtcNow },
                new ProductDetail { Id = 5, ProductId = 3, Name = "種子規格4", UnitPrice = 100, Inventory = 0, CreatedTime = DateTime.UtcNow },
                new ProductDetail { Id = 6, ProductId = 3, Name = "種子規格4", UnitPrice = 100, Inventory = 120, CreatedTime = DateTime.UtcNow },
                new ProductDetail { Id = 7, ProductId = 3, Name = "種子規格4", UnitPrice = 100, Inventory = 20, CreatedTime = DateTime.UtcNow }
            };
        }

        public static List<Role> ProduceRoles()
        {
            return new List<Role>
            {
                new Role { Id = 1, Name = Core.Constants.AuthorizationConstants.NormalUser, RoleType = RoleType.NormalUser },
                new Role { Id = 2, Name = Core.Constants.AuthorizationConstants.Administrator, RoleType = RoleType.Administrator },
                new Role { Id = 3, Name = Core.Constants.AuthorizationConstants.Developer, RoleType = RoleType.Developer }
            };
        }

        public static List<User> ProduceUsers()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1, Name = "AdminUser", Email = "AdminUser@gmail.com", Password = "AdminUser".ToSHA256(), CreatedTime = DateTimeOffset.UtcNow, Gender = UserGender.None
                },
                new User
                {
                    Id = 2, Name = "Developer", Email = "Developer@gmail.com", Password = "Developer".ToSHA256(), CreatedTime = DateTimeOffset.UtcNow, Gender = UserGender.None
                }
            };
        }

        public static List<UserRole> ProduceUserRoles()
        {
            return new List<UserRole>
            {

                new UserRole { Id = 1, RoleId = 1, UserId = 1 },
                new UserRole { Id = 2, RoleId = 1, UserId = 2 },
                new UserRole { Id = 3, RoleId = 2, UserId = 1 },
                new UserRole { Id = 4, RoleId = 3, UserId = 2 }
            };
        }
    }
}
using BS.DemoShop.Core.Entities;
using BS.DemoShop.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BS.DemoShop.Infrastructure.Data
{
    public partial class BSDemoShopContext : DbContext
    {
        private readonly IAppPasswordHasher _passwordHasher;
        public BSDemoShopContext(DbContextOptions<BSDemoShopContext> options, IAppPasswordHasher passwordHasher) : base(options)
        {
            _passwordHasher = passwordHasher;
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductDetail> ProductDetail { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Category>()
            //     .ToTable("Categories");
            //
            // #region CategorySeed
            //
            // modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "預設分類1", Sort = 0, CreatedTime = DateTimeOffset.UtcNow });
            // modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Name = "預設分類2", Sort = 1, CreatedTime = DateTimeOffset.UtcNow });
            // modelBuilder.Entity<Category>().HasData(new Category { Id = 3, Name = "預設分類3", Sort = 2, CreatedTime = DateTimeOffset.UtcNow });
            //
            // #endregion
            //
            // modelBuilder.Entity<Product>()
            //    .ToTable("Products");
            //
            // modelBuilder.Entity<Product>()
            //     .HasOne(p => p.Category)
            //     .WithMany(c => c.Products)
            //     .HasForeignKey(p => p.CategoryId);
            //
            // #region ProductSeed
            //
            // modelBuilder.Entity<Product>().HasData(new Product { Id = 1, CategoryId = 1, Name = "種子商品1", ImgPath = "https://picsum.photos/300/200/?random=1", IsOnTheMarket = true, CreatedTime = DateTime.UtcNow });
            // modelBuilder.Entity<Product>().HasData(new Product { Id = 2, CategoryId = 2, Name = "種子商品2", ImgPath = "https://picsum.photos/300/200/?random=2", IsOnTheMarket = false, CreatedTime = DateTime.UtcNow });
            // modelBuilder.Entity<Product>().HasData(new Product { Id = 3, CategoryId = 3, Name = "種子商品3", ImgPath = "https://picsum.photos/300/200/?random=3", IsOnTheMarket = true, CreatedTime = DateTime.UtcNow });
            //
            // #endregion
            //
            // modelBuilder.Entity<ProductDetail>()
            //    .Property(b => b.UnitPrice)
            //    .HasPrecision(18, 2);
            //
            // modelBuilder.Entity<ProductDetail>()
            //    .ToTable("ProductDetails");
            // #region ProductDetailSeed
            //
            // modelBuilder.Entity<ProductDetail>().HasData(new ProductDetail { Id = 1, ProductId = 1, Name = "種子規格1", UnitPrice = 100, Inventory = 100, CreatedTime = DateTime.UtcNow });
            // modelBuilder.Entity<ProductDetail>().HasData(new ProductDetail { Id = 2, ProductId = 1, Name = "種子規格2", UnitPrice = 100, Inventory = 10, CreatedTime = DateTime.UtcNow });
            // modelBuilder.Entity<ProductDetail>().HasData(new ProductDetail { Id = 3, ProductId = 1, Name = "種子規格3", UnitPrice = 100, Inventory = 8, CreatedTime = DateTime.UtcNow });
            // modelBuilder.Entity<ProductDetail>().HasData(new ProductDetail { Id = 4, ProductId = 2, Name = "種子規格4", UnitPrice = 100, Inventory = 18, CreatedTime = DateTime.UtcNow });
            // modelBuilder.Entity<ProductDetail>().HasData(new ProductDetail { Id = 5, ProductId = 3, Name = "種子規格4", UnitPrice = 100, Inventory = 0, CreatedTime = DateTime.UtcNow });
            // modelBuilder.Entity<ProductDetail>().HasData(new ProductDetail { Id = 6, ProductId = 3, Name = "種子規格4", UnitPrice = 100, Inventory = 120, CreatedTime = DateTime.UtcNow });
            // modelBuilder.Entity<ProductDetail>().HasData(new ProductDetail { Id = 7, ProductId = 3, Name = "種子規格4", UnitPrice = 100, Inventory = 20, CreatedTime = DateTime.UtcNow });
            //
            // #endregion


            modelBuilder.Entity<User>()
                .ToTable("Users");
            #region UserSeed
            modelBuilder.Entity<User>().HasData(new User { Id = 1, Name = "AdminUser", Email = "AdminUser@gmail.com", Password = _passwordHasher.HashPassword("AdminUser"), CreatedTime = DateTimeOffset.UtcNow, Gender = UserGender.None });
            modelBuilder.Entity<User>().HasData(new User { Id = 2, Name = "Developer", Email = "Developer@gmail.com", Password = _passwordHasher.HashPassword("Developer"), CreatedTime = DateTimeOffset.UtcNow, Gender = UserGender.None });
            #endregion

            modelBuilder.Entity<Role>()
                .ToTable("Roles");
            #region RoleSeed
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = Core.Constants.AuthorizationConstants.NormalUser, RoleType = RoleType.NormalUser });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = Core.Constants.AuthorizationConstants.Administrator, RoleType = RoleType.Administrator });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = Core.Constants.AuthorizationConstants.Developer, RoleType = RoleType.Developer });
            #endregion

            modelBuilder.Entity<UserRole>()
                .ToTable("UserRoles");
            #region UserRoleSeed
            modelBuilder.Entity<UserRole>().HasData(new UserRole { Id = 1, RoleId = 1, UserId = 1 });
            modelBuilder.Entity<UserRole>().HasData(new UserRole { Id = 2, RoleId = 1, UserId = 2 });
            modelBuilder.Entity<UserRole>().HasData(new UserRole { Id = 3, RoleId = 2, UserId = 1 });
            modelBuilder.Entity<UserRole>().HasData(new UserRole { Id = 4, RoleId = 3, UserId = 2 });
            #endregion


            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
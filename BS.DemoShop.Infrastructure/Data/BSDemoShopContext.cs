using BS.DemoShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DemoShop.Infrastructure.Data
{
    public class BSDemoShopContext : DbContext
    {
        public BSDemoShopContext(DbContextOptions<BSDemoShopContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductDetail> ProductDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<ProductDetail>()
                .Property(b => b.UnitPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .ToTable("Products");

            modelBuilder.Entity<ProductDetail>()
                .ToTable("ProductDetails");
        }
    }
}

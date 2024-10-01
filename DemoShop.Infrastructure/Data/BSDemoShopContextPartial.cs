using DemoShop.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Infrastructure.Data
{
    public partial class BSDemoShopContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpecificationReference>()
                .HasData(SeedData.ProduceSpecificationReference());

            modelBuilder.Entity<Specification>()
                .HasData(SeedData.ProduceSpecification());

            modelBuilder.Entity<Product>()
                .HasData(SeedData.ProduceProduct());

            modelBuilder.Entity<ProductDetail>()
                .HasData(SeedData.ProduceProductDetail());

            modelBuilder.Entity<TodoItem>()
                .HasData(SeedData.ProduceTodoItem());

            modelBuilder.Entity<Catalog>()
                .HasData(SeedData.ProduceCatalogs());
        }
    }
}
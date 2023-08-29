using DemoShop.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoShop.Infrastructure.Data;

public partial class BSDemoShopContext : DbContext
{
    public BSDemoShopContext(DbContextOptions<BSDemoShopContext> options) : base(options)
    {
    }

    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductSpecification> ProductSpecifications { get; set; }
    public DbSet<Specification> Specifications { get; set; }
    public DbSet<SpecificationReference> SpecificationReferences { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Coupon>()
            .Property(c => c.DiscountPercentage)
            .HasPrecision(5, 2);
        modelBuilder.Entity<Coupon>()
            .ToTable("Coupons");
        
        modelBuilder.Entity<Member>()
            .ToTable("Members");
        
        modelBuilder.Entity<Order>()
            .Property(o => o.TotalAmount)
            .HasPrecision(14, 0);
        modelBuilder.Entity<Order>()
            .ToTable("Orders");

        modelBuilder.Entity<OrderItem>()
            .Property(oi => oi.Discount)
            .HasPrecision(5, 0); //TODO 修改 .HasPrecision(5, 2) 後，新增異動。
        modelBuilder.Entity<OrderItem>()
            .Property(oi => oi.UnitPrice)
            .HasPrecision(14, 2);
        modelBuilder.Entity<OrderItem>()
            .ToTable("OrderItems");
        
        modelBuilder.Entity<Product>()
            .ToTable("Products");
        
        modelBuilder.Entity<ProductSpecification>()
            .ToTable("ProductSpecifications");

        modelBuilder.Entity<Specification>()
            .Property(s => s.UnitPrice)
            .HasPrecision(14, 2);
        modelBuilder.Entity<Specification>()
            .ToTable("Specifications");
        
        modelBuilder.Entity<SpecificationReference>()
            .ToTable("SpecificationReferences");

        
        OnModelCreatingPartial(modelBuilder);

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
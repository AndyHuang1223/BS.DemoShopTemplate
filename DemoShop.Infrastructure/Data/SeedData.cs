using DemoShop.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Infrastructure.Data
{
    public class SeedData
    {
        public static List<SpecificationReference> ProductSpecificationReference()
        {
            return new List<SpecificationReference>()
            {
                new SpecificationReference{Id=1,SpecificationName="尺寸", CreateAt = new DateTime(2023,08,29)},
                new SpecificationReference{Id=2,SpecificationName="規格", CreateAt = new DateTime(2023,08,29)},
                new SpecificationReference{Id=3,SpecificationName="顏色", CreateAt = new DateTime(2023,08,29)},
            };
        }

        public static List<Specification> ProduceSpecification()
        {
            return new List<Specification>()
            {
                new Specification{Id = 1, SKU="Product1-XL", SpecificationValue="XL", Inventory = 10, UnitPrice = 10, SpecificationReferenceId = 1, CreateAt = new DateTime(2023,08,29)},
                new Specification{Id = 2, SKU="Product1-S", SpecificationValue="S", Inventory = 10, UnitPrice = 11, SpecificationReferenceId = 1, CreateAt = new DateTime(2023,08,29)},
                new Specification{Id = 3, SKU="Product222-Black", SpecificationValue="黑色", Inventory = 10, UnitPrice = 15, SpecificationReferenceId = 3, CreateAt = new DateTime(2023,08,29)},
                new Specification{Id = 4, SKU="Product222-White", SpecificationValue="白色", Inventory = 15, UnitPrice = 13, SpecificationReferenceId = 3, CreateAt = new DateTime(2023,08,29)},
                new Specification{Id = 5, SKU="Product000", SpecificationValue="單一規格", Inventory = 100, UnitPrice = 1.5m, SpecificationReferenceId = 2, CreateAt = new DateTime(2023,08,29)},
            };
        }

        public static List<Product> ProduceProduct()
        {
            return new List<Product>()
            {
                new Product { Id = 1, ProductName = "Product1",Description="Product1 DESC.", IsOnTheMarket = true, ImagePath="https://picsum.photos/300/200/?random=1", CreateAt = DateTime.UtcNow},
                new Product { Id = 2, ProductName = "Product222",Description="Product222 DESC.", IsOnTheMarket = true, ImagePath="https://picsum.photos/300/200/?random=1", CreateAt = DateTime.UtcNow},
                new Product { Id = 3, ProductName = "Product000",Description="Product000 DESC.", IsOnTheMarket = true, ImagePath="https://picsum.photos/300/200/?random=1", CreateAt = DateTime.UtcNow},
            };
        }

        public static List<ProductSpecification> ProduceProductSpecification()
        {
            return new List<ProductSpecification>
            {
                new ProductSpecification { Id = 1, ProductId = 1, SpecificationId=1, CreateAt = DateTime.UtcNow},
                new ProductSpecification { Id = 2, ProductId = 1, SpecificationId=2, CreateAt = DateTime.UtcNow},
                new ProductSpecification { Id = 3, ProductId = 2, SpecificationId=3, CreateAt = DateTime.UtcNow},
                new ProductSpecification { Id = 4, ProductId = 2, SpecificationId=4, CreateAt = DateTime.UtcNow},
                new ProductSpecification { Id = 5, ProductId = 3, SpecificationId=5, CreateAt = DateTime.UtcNow},
            };
        }
    }
}

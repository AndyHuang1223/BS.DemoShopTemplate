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
        public static List<SpecificationReference> ProduceSpecificationReference()
        {
            return new List<SpecificationReference>()
            {
                new SpecificationReference{Id=1,SpecificationName="尺寸", Seq = 1, CreateAt = new DateTime(2023,08,29)},
                new SpecificationReference{Id=2,SpecificationName="規格", Seq = 0, CreateAt = new DateTime(2023,08,29)},
                new SpecificationReference{Id=3,SpecificationName="顏色", Seq = 0, CreateAt = new DateTime(2023,08,29)},
                new SpecificationReference{Id=4,SpecificationName="口味", Seq = 0, CreateAt = new DateTime(2023,08,29)},
            };
        }
        public static List<Product> ProduceProduct()
        {
            return new List<Product>()
            {
                new Product { Id = 1, ProductName = "潮T", Description="米奇潮T", IsOnTheMarket = true, ImagePath="https://picsum.photos/300/200/?random=1", CreateAt = DateTime.UtcNow},
                new Product { Id = 2, ProductName = "圍巾", Description="圍巾 DESC.", IsOnTheMarket = true, ImagePath="https://picsum.photos/300/200/?random=2", CreateAt = DateTime.UtcNow},
                new Product { Id = 3, ProductName = "蛋糕", Description="蛋糕 DESC.", IsOnTheMarket = true, ImagePath="https://picsum.photos/300/200/?random=3", CreateAt = DateTime.UtcNow},
            };
        }

        public static List<ProductDetail> ProduceProductDetail()
        {
            return new List<ProductDetail>
            {
                new ProductDetail { Id = 1, ProductId = 1, Inventory = 10, SKU="Micky-Black-S", UnitPrice = 100, Seq = 1, CreateAt = DateTime.UtcNow},
                new ProductDetail { Id = 2, ProductId = 1, Inventory = 10, SKU="Micky-Black-M", UnitPrice = 100, Seq = 2, CreateAt = DateTime.UtcNow},
                new ProductDetail { Id = 3, ProductId = 1, Inventory = 10, SKU="Micky-Black-L", UnitPrice = 100, Seq = 1, CreateAt = DateTime.UtcNow},
                new ProductDetail { Id = 4, ProductId = 1, Inventory = 10, SKU="Micky-Black-XL", UnitPrice = 100, Seq = 1, CreateAt = DateTime.UtcNow},
                new ProductDetail { Id = 5, ProductId = 1, Inventory = 10, SKU="Micky-White-XL", UnitPrice = 100, Seq = 1, CreateAt = DateTime.UtcNow},
                new ProductDetail { Id = 6, ProductId = 1, Inventory = 10, SKU="Micky-White-M", UnitPrice = 100, Seq = 1, CreateAt = DateTime.UtcNow},
                new ProductDetail { Id = 7, ProductId = 1, Inventory = 10, SKU="Micky-Red-XS", UnitPrice = 100, Seq = 1, CreateAt = DateTime.UtcNow},
                new ProductDetail { Id = 8, ProductId = 1, Inventory = 10, SKU="Micky-Gray-S", UnitPrice = 100, Seq = 1, CreateAt = DateTime.UtcNow},
                new ProductDetail { Id = 9, ProductId = 2, Inventory = 5, SKU="Scarf", UnitPrice = 50, Seq = 0, CreateAt = DateTime.UtcNow},
                new ProductDetail { Id = 10, ProductId = 3, Inventory = 15, SKU="Cake-Banana", UnitPrice = 599, Seq = 0, CreateAt = DateTime.UtcNow},
                new ProductDetail { Id = 11, ProductId = 3, Inventory = 20, SKU="Cake-Chocolate", UnitPrice = 599, Seq = 1, CreateAt = DateTime.UtcNow},

            };
        }

        public static List<Specification> ProduceSpecification()
        {
            return new List<Specification>()
            {
                new Specification{Id = 1, ProductDetailId = 1, Seq=0, SpecificationReferenceId = 1,SpecificationValue="S",  CreateAt = new DateTime(2023,08,29)},
                new Specification{Id = 2, ProductDetailId = 2, Seq=1, SpecificationReferenceId = 1,SpecificationValue="M",  CreateAt = new DateTime(2023,08,29)},
                new Specification{Id = 3, ProductDetailId = 3, Seq=2, SpecificationReferenceId = 1,SpecificationValue="L",  CreateAt = new DateTime(2023,08,29)},
                new Specification{Id = 4, ProductDetailId = 4, Seq=3, SpecificationReferenceId = 1,SpecificationValue="XL",  CreateAt = new DateTime(2023,08,29)},
                new Specification{Id = 5, ProductDetailId = 1, Seq=0, SpecificationReferenceId = 3,SpecificationValue="黑色",  CreateAt = new DateTime(2023,08,29)},
                new Specification{Id = 6, ProductDetailId = 2, Seq=0, SpecificationReferenceId = 3,SpecificationValue="黑色",  CreateAt = new DateTime(2023,08,29)},
                new Specification{Id = 7, ProductDetailId = 3, Seq=0, SpecificationReferenceId = 3,SpecificationValue="黑色",  CreateAt = new DateTime(2023,08,29)},
                new Specification{Id = 8, ProductDetailId = 4, Seq=0, SpecificationReferenceId = 3,SpecificationValue="黑色",  CreateAt = new DateTime(2023,08,29)},
                new Specification{Id = 9, ProductDetailId = 5, Seq=1, SpecificationReferenceId = 3,SpecificationValue="白色",  CreateAt = new DateTime(2023,08,29)},
                new Specification{Id = 10, ProductDetailId = 6, Seq=1, SpecificationReferenceId = 3,SpecificationValue="白色",  CreateAt = new DateTime(2023,08,29)},
                new Specification{Id = 11, ProductDetailId = 5, Seq=0,  SpecificationReferenceId = 1,SpecificationValue="M",  CreateAt = new DateTime(2023,08,29)},
                new Specification{Id = 12, ProductDetailId = 6, Seq=1, SpecificationReferenceId = 1,SpecificationValue="XL",  CreateAt = new DateTime(2023,08,29)},
                new Specification{Id = 13, ProductDetailId = 7, Seq=2, SpecificationReferenceId = 3,SpecificationValue="紅色",  CreateAt = new DateTime(2023,08,29)},
                new Specification{Id = 14, ProductDetailId = 7, Seq=0,  SpecificationReferenceId = 1,SpecificationValue="XS",  CreateAt = new DateTime(2023,08,29)},
                new Specification{Id = 15, ProductDetailId = 8, Seq=3, SpecificationReferenceId = 3,SpecificationValue="灰色",  CreateAt = new DateTime(2023,08,29)},
                new Specification{Id = 16, ProductDetailId = 8, Seq=0, SpecificationReferenceId = 1,SpecificationValue="S",  CreateAt = new DateTime(2023,08,29)},
                new Specification{Id = 17, ProductDetailId = 9, Seq=0, SpecificationReferenceId = 2,SpecificationValue="單一規格",  CreateAt = new DateTime(2023,08,29)},
                new Specification{Id = 18, ProductDetailId = 10, Seq=1, SpecificationReferenceId = 4,SpecificationValue="香蕉",  CreateAt = new DateTime(2023,08,29)},
                new Specification{Id = 19, ProductDetailId = 11, Seq=0, SpecificationReferenceId = 4,SpecificationValue="巧克力",  CreateAt = new DateTime(2023,08,29)},
            };
        }
        
        public static List<TodoItem> ProduceTodoItem()
        {
            return new List<TodoItem>
            {
                new TodoItem { Id = 1, Description = "TodoItem 1", IsDone = false, CreateAt = DateTime.UtcNow},
                new TodoItem { Id = 2, Description = "TodoItem 2", IsDone = false, CreateAt = DateTime.UtcNow},
                new TodoItem { Id = 3, Description = "TodoItem 3", IsDone = false, CreateAt = DateTime.UtcNow},
                new TodoItem { Id = 4, Description = "TodoItem 4", IsDone = false, CreateAt = DateTime.UtcNow},
                new TodoItem { Id = 5, Description = "TodoItem 5", IsDone = false, CreateAt = DateTime.UtcNow},
                new TodoItem { Id = 6, Description = "TodoItem 6", IsDone = false, CreateAt = DateTime.UtcNow},
                new TodoItem { Id = 7, Description = "TodoItem 7", IsDone = false, CreateAt = DateTime.UtcNow},
                new TodoItem { Id = 8, Description = "TodoItem 8", IsDone = false, CreateAt = DateTime.UtcNow},
                new TodoItem { Id = 9, Description = "TodoItem 9", IsDone = false, CreateAt = DateTime.UtcNow},
                new TodoItem { Id = 10, Description = "TodoItem 10", IsDone = false, CreateAt = DateTime.UtcNow},
            };
        }

        public static List<Catalog> ProduceCatalogs()
        {
            return new List<Catalog>()
            {
                new Catalog { Id = 1, Name = "Catalog 1", ParentCatalogId = null, CreateAt = DateTime.UtcNow },
                new Catalog { Id = 2, Name = "Catalog 2", ParentCatalogId = null, CreateAt = DateTime.UtcNow },
                new Catalog { Id = 3, Name = "Catalog 3", ParentCatalogId = null, CreateAt = DateTime.UtcNow },
                new Catalog { Id = 4, Name = "Catalog 1-1", ParentCatalogId = 1, CreateAt = DateTime.UtcNow },
                new Catalog { Id = 5, Name = "Catalog 1-1-1", ParentCatalogId = 4, CreateAt = DateTime.UtcNow },
            };
        }

    }
}

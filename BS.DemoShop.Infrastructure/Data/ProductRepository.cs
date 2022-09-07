using BS.DemoShop.Core.Entities;
using BS.DemoShop.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DemoShop.Infrastructure.Data
{
    public class ProductRepository : EfRepository<Product>, IProductRepository
    {

        public ProductRepository(BSDemoShopContext dbContext) : base(dbContext)
        {
        }

        public void CreateProductAndDetails(Product product, IEnumerable<ProductDetail> productDetails)
        {
            using (var transaction = DbContext.Database.BeginTransaction())
            {
                try
                {
                    DbContext.Product.Add(product);
                    DbContext.SaveChanges();
                    var detailEntities = productDetails.ToList();
                    foreach(var entity in detailEntities)
                    {
                        entity.ProductId = product.Id;
                    }
                    DbContext.ProductDetail.AddRange(detailEntities);
                    DbContext.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }

        }

    }
}

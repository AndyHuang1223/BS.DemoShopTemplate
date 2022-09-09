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
    /// <summary>
    /// 專用型Repository
    /// </summary>
    public class ProductRepository : EfRepository<Product>, IProductRepository
    {
        /// <summary>
        /// 給泛型Repository使用的建構式
        /// </summary>
        /// <param name="dbContext">容器注入的DbContext</param>
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

        public async Task<Product> CreateProductWithDetail(string productName, string imgPath, string description, ProductDetail detail)
        {
            var details = new List<ProductDetail> { detail };
            var product = new Product(productName, imgPath, description, details);
            
            return await AddAsync(product);
        }
    }
}

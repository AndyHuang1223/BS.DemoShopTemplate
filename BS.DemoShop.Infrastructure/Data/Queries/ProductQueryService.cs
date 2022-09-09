using BS.DemoShop.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DemoShop.Infrastructure.Data.Queries
{
    public class ProductQueryService : IProductQueryService
    {
        private readonly BSDemoShopContext _demoShopContext;

        public ProductQueryService(BSDemoShopContext demoShopContext)
        {
            _demoShopContext = demoShopContext;
        }

        public async Task<int> GetProductTotalInventoryById(int productId)
        {
            //積極載入 https://docs.microsoft.com/zh-tw/ef/core/querying/related-data/eager
            var product = _demoShopContext.Product
                .Include(p => p.ProductDetails
                    .Where(pd => pd.ProductId == productId))
                .AsNoTracking();

            var totalInventory = await product.SelectMany(p => p.ProductDetails).SumAsync(pd => pd.Inventory);

            //var totalInventory = await _demoShopContext.Product
            //    .Where(product => product.Id == productId)
            //    .SelectMany(product => product.ProductDetails)
            //    .SumAsync(pd => pd.Inventory);

            return totalInventory;
        }
    }
}

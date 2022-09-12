using BS.DemoShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DemoShop.Core.Interfaces
{
    public interface IProductQueryService
    {
        Task<int> GetProductTotalInventoryById(int productId);

        Task<decimal> GetProductMaxPriceById(int productId);
    }
}

using BS.DemoShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DemoShop.Core.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        void CreateProductAndDetails(Product product, IEnumerable<ProductDetail> productDetails);

        Task<Product> CreateProductWithDetail(string productName, string imgPath, string description, ProductDetail detail);
    }
}

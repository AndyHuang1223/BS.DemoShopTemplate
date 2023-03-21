using DemoShop.ApplicationCore.Entities;
using DemoShop.ApplicationCore.Interfaces;
using DemoShop.ApplicationCore.Interfaces.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.ApplicationCore.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _porductRepository;

        public ProductService(IRepository<Product> porductRepository)
        {
            _porductRepository = porductRepository;
        }

        public List<Product> GetHotSellProductList(List<Product> productList, int count)
        {
            //庫存少的排在前面，取前count筆。
            return productList
                .OrderBy(prod => prod.ProductSpecifications.Sum(prodSpec => prodSpec.Specification.Inventory))
                .Take(count)
                .ToList();
        }

        public async Task<List<Product>> GetHotSellProductListAsync(int count)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetShelveProductByIdAsync(int productId)
        {
            var product = await _porductRepository.GetByIdAsync(productId);

            if (product == null || product.IsOnTheMarket == false)
            {
                return null;
            }

            return product;

        }

        public Task OffShelveProductAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task ShelveProductAsync(int productId)
        {
            throw new NotImplementedException();
        }
    }
}

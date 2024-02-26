using DemoShop.ApplicationCore.Entities;
using DemoShop.ApplicationCore.Interfaces;
using DemoShop.ApplicationCore.Interfaces.ProductService;
using DemoShop.ApplicationCore.Interfaces.ProductService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.ApplicationCore.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Specification> _specRepo;
        private readonly IRepository<ProductDetail> _prodDetailRepo;
        private readonly IRepository<SpecificationReference> _specRefRepo;

        public ProductService(
            IRepository<Product> productRepository,
            IRepository<Specification> specRepo,
            IRepository<ProductDetail> prodSpecRepo,
            IRepository<SpecificationReference> specRefRepo)
        {
            _productRepository = productRepository;
            _specRepo = specRepo;
            _prodDetailRepo = prodSpecRepo;
            _specRefRepo = specRefRepo;
        }

        public List<Product> GetHotSellProductList(List<Product> productList, int count)
        {
            //庫存少的排在前面，取前count筆。
            return productList
                .OrderBy(prod => prod.Seq)
                .Take(count)
                .ToList();
        }

        public async Task<List<Product>> GetHotSellProductListAsync(int count)
        {
            //你不應該直接全部拉出來, 這是範例而已。
            var productList = await _productRepository.ListAsync(x => true);

            return GetHotSellProductList(productList, count);
        }

        public async Task<GetProductInfoOutput> GetProductInfoAsync(int productId)
        {
            //var product = await _productRepository.GetByIdAsync(productId);
            var product = await _productRepository.FirstOrDefaultAsync(p => p.Id == productId);

            if (product is null || product.IsOnTheMarket == false)
            {
                return null;
            }

            var productDetails = await _prodDetailRepo.ListAsync(_ => _.ProductId == productId);
            var specs = (await _specRepo.ListAsync(_ => productDetails.Select(pd => pd.Id).Contains(_.ProductDetailId))).OrderBy(s => s.Seq);
            var specRefs = (await _specRefRepo.ListAsync(_ => specs.Select(s => s.SpecificationReferenceId).Contains(_.Id))).OrderBy(s => s.Seq);

            var result = new GetProductInfoOutput()
            {
                Name = product.ProductName,
                Desc = product.Description,
                MainPicture = product.ImagePath,
                ProductId = product.Id,
                MaxPrice = productDetails.Max(s => s.UnitPrice),
                MinPrice = productDetails.Min(s => s.UnitPrice),
                Spec = productDetails.Select(s => new ProductInfoSpec
                {
                    SpecId = s.Id,
                    Inventory = s.Inventory,
                    SKU = s.SKU,
                    UnitPrice = s.UnitPrice,
                    Value = string.Join(",", specs.Select(s => $"{s.Seq}:{s.SpecificationValue}")),
                    Title = string.Join(",", specRefs.Select(s => $"{s.Seq}:{s.SpecificationName}"))
                }).ToArray()
            };

            return result;
        }

        public async Task<Product> GetShelveProductByIdAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);

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

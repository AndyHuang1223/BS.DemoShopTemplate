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
        private readonly IRepository<ProductSpecification> _prodSpecRepo;
        private readonly IRepository<SpecificationReference> _specRefRepo;

        public ProductService(
            IRepository<Product> porductRepository,
            IRepository<Specification> specRepo,
            IRepository<ProductSpecification> prodSpecRepo,
            IRepository<SpecificationReference> specRefRepo)
        {
            _productRepository = porductRepository;
            _specRepo = specRepo;
            _prodSpecRepo = prodSpecRepo;
            _specRefRepo = specRefRepo;
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
            var specs = await _specRepo.ListAsync();//你不應該直接全部拉出來, 這是範例而已。
            var prodSpecs = await _prodSpecRepo.ListAsync(ps => specs.Select(s => s.Id).Contains(ps.SpecificationId));
            var porductList = await _productRepository.ListAsync(p => prodSpecs.Select(ps => ps.ProductId).Contains(p.Id));
            foreach (var prod in porductList)
            {
                var thisProdSpecs = prodSpecs.Where(ps => ps.ProductId == prod.Id).ToList();
                var thisSpecs = specs.Where(s => thisProdSpecs.Select(_ => _.SpecificationId).Contains(s.Id));
                thisProdSpecs.ForEach(ps => ps.Specification = thisSpecs.FirstOrDefault(s => s.Id == ps.SpecificationId));
                prod.ProductSpecifications = thisProdSpecs;
            }
            return GetHotSellProductList(porductList, count);
        }

        public async Task<GetProductInfoOutput> GetProductInfoAsync(int productId)
        {
            //var product = await _productRepository.GetByIdAsync(productId);
            var product = await _productRepository.FirstOrDefaultAsync(p => p.Id == productId);

            if(product is null || product.IsOnTheMarket == false)
            {
                return null;
            }

            var prodSpecs = await _prodSpecRepo.ListAsync(ps => ps.ProductId == productId);
            var specs = await _specRepo.ListAsync(s => prodSpecs.Select(ps => ps.SpecificationId).Contains(s.Id));
            var specRefs = await _specRefRepo.ListAsync(sr => specs.Select(s => s.SpecificationReferenceId).Contains(sr.Id));

            var result = new GetProductInfoOutput()
            {
                Name = product.ProductName,
                Desc = product.Description,
                MainPicture = product.ImagePath,
                ProductId = product.Id,
                MaxPrice = specs.Max(s => s.UnitPrice),
                MinPrice = specs.Min(s => s.UnitPrice),
                Spec = specs.Select(s => new ProductInfoSpec
                {
                    SpecId = s.Id,
                    Inventory = s.Inventory,
                    SKU = s.SKU,
                    UnitPrice = s.UnitPrice,
                    Value = s.SpecificationValue,
                    Title = specRefs.FirstOrDefault(sr => sr.Id == s.SpecificationReferenceId)?.SpecificationName ?? "預設規格"
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

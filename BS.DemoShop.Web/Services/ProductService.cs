using BS.DemoShop.Core.Entities;
using BS.DemoShop.Core.Extensions;
using BS.DemoShop.Core.Interfaces;
using BS.DemoShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BS.DemoShop.Web.Services
{
    public class ProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductDetail> _productDetailRepository;
        private readonly IProductRepository _productRepo;

        public ProductService(
            IRepository<Product> productRepository,
            IRepository<ProductDetail> productDetailRepository,
            IProductRepository productRepo
            )
        {
            _productRepository = productRepository;
            _productDetailRepository = productDetailRepository;
            _productRepo = productRepo;
        }

        public ProductViewModel GetById(int id)
        {

            var product = _productRepository.GetAll().FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return default;
            }

            var productDetails = _productDetailRepository.GetAll()
                .Where(x => x.ProductId == product.Id)
                .Select(pd => new ProductDetailViewModel { Id = pd.Id, Name = pd.Name, UnitPrice = pd.UnitPrice })
                .ToList();

            var result = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                ImgPath = product.ImgPath,
                ProductDetails = productDetails,
                CreatedTime = product.CreatedTime.ToTaiwaneseTime(),
                LastUpdatedTime = product.UpdatedTime?.ToTaiwaneseTime()
            };

            return result;
        }

        public IEnumerable<ProductViewModel> GetAllProduct()
        {
            var products = _productRepo.GetAll().Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                ImgPath = p.ImgPath,
                CreatedTime = p.CreatedTime.ToTaiwaneseTime()
            }).ToList();

            var productDetails = _productDetailRepository.GetAll().Where(pd => products.Select(p => p.Id).Contains(pd.ProductId)).ToList();

            foreach (var product in products)
            {
                if(productDetails.Any(pd=>pd.ProductId == product.Id))
                {
                    product.Price = productDetails.FirstOrDefault()?.UnitPrice ?? 0;
                }
                yield return product;
            }
        }

        public void CreateProduct(CreateProductViewModel input)
        {
            var product = new Product
            {
                Name = input.Name,
                ImgPath = input.ImgPath,
                CreatedTime = DateTime.UtcNow,
                ProductDetails = input.ProductDetail.Select(x => new ProductDetail { Name = x.SpecName, UnitPrice = x.UnitPrice, CreatedTime = DateTime.UtcNow }).ToList()

            };
            _productRepo.Add(product);
            _productRepo.SaveChanges();

        }

        public void CreateProductByRepository(CreateProductViewModel input)
        {
            var product = new Product
            {
                Name = input.Name,
                ImgPath = input.ImgPath,
                CreatedTime = DateTime.UtcNow
            };
            var productDetails = input.ProductDetail.Select(x => new ProductDetail { Name = x.SpecName, UnitPrice = x.UnitPrice, CreatedTime = DateTime.UtcNow });
            _productRepo.CreateProductAndDetails(product, productDetails);
        }

        public void CreateDetail(CreateDetailViewModel input)
        {
            _productDetailRepository.Add(new ProductDetail
            {
                Name = input.SpecName,
                UnitPrice = input.UnitPrice,
                CreatedTime = DateTime.UtcNow,
                ProductId = input.ProductId,
            });
            _productDetailRepository.SaveChanges();
        }

        public void UpdateProduct(ProductViewModel input)
        {
            var now = DateTime.UtcNow;
            var productSource = _productRepo.GetAll().First(x => x.Id == input.Id);

            productSource.Name = input.Name;
            productSource.ImgPath = input.ImgPath;
            productSource.UpdatedTime = now;


            var detailSource = _productDetailRepository.GetAll()
                .Where(x => x.ProductId == input.Id).ToList();

            foreach (var entity in detailSource)
            {
                var inputDetail = input.ProductDetails.First(x => x.Id == entity.Id);
                entity.Name = inputDetail.Name;
                entity.UnitPrice = inputDetail.UnitPrice;
                entity.UpdatedTime = now;
            }
            productSource.ProductDetails = detailSource;

            _productRepo.Update(productSource);
            _productRepo.SaveChanges();

        }

        public void DeleteProduct(ProductViewModel input)
        {

            var productEntity = _productRepo.GetAll().First(x => x.Id == input.Id);
            _productRepo.Delete(productEntity);
            _productRepo.SaveChanges();
        }
    }
}

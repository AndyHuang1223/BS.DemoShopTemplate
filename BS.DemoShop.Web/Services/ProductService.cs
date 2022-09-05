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

        public ProductService(
            IRepository<Product> productRepository,
            IRepository<ProductDetail> productDetailRepository
            )
        {
            _productRepository = productRepository;
            _productDetailRepository = productDetailRepository;
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
            return _productRepository.GetAll().Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                ImgPath = p.ImgPath,
                Price = _productDetailRepository.GetAll().First(x => x.ProductId == p.Id).UnitPrice,
                CreatedTime = p.CreatedTime.ToTaiwaneseTime()
            }).ToList();
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
            _productRepository.Add(product);
            _productRepository.SaveChanges();

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
            var productSource = _productRepository.GetAll().First(x => x.Id == input.Id);

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
            
            _productRepository.Update(productSource);
            _productRepository.SaveChanges();

        }

        public void DeleteProduct(ProductViewModel input)
        {
            
            var productEntity = _productRepository.GetAll().First(x => x.Id == input.Id);
            _productRepository.Delete(productEntity);
            _productRepository.SaveChanges();
        }
    }
}

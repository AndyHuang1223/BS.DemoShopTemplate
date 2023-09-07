using DemoShop.ApplicationCore.Entities;
using DemoShop.ApplicationCore.Interfaces;
using DemoShop.ApplicationCore.Services;
using Moq;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace UnitTests
{
    public class ProductServiceTests
    {
        private Mock<IRepository<Product>> _mockProductRepository;
        private Mock<IRepository<Specification>> _mockSpecificationRepository;
        private Mock<IRepository<ProductDetail>> _mockProductSpecificationRepository;
        private Mock<IRepository<SpecificationReference>> _mockSpecificationRefRepository;

        [SetUp]
        public void Setup()
        {
            _mockProductRepository = new();
            _mockSpecificationRepository = new();
            _mockProductSpecificationRepository = new();
            _mockSpecificationRefRepository = new();
        }

        [Test]
        public async Task GetShelveProductById_With_ShelvedProduct()
        {
            //Arrange
            var product = new Product { Id = 1, ProductName = "TestProduct", IsOnTheMarket = true };
            _mockProductRepository
                .Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(product);

            var productRepo = _mockProductRepository.Object;

            //Act
            var productService = new ProductService(productRepo, _mockSpecificationRepository.Object, _mockProductSpecificationRepository.Object, _mockSpecificationRefRepository.Object);
            var expected = new Product { Id = 1, ProductName = "TestProduct", IsOnTheMarket = true };

            //Assert
            var actual = await productService.GetShelveProductByIdAsync(product.Id);
            Assert.That(actual.Id, Is.EqualTo(expected.Id));

        }


        private class ProductEqualityCompare : IEqualityComparer<Product>
        {
            public bool Equals(Product? x, Product? y)
            {
                if(x == null || y == null)
                {
                    return false;
                }

                return x.Id == y.Id && x.ProductName == y.ProductName;
            }

            public int GetHashCode([DisallowNull] Product obj)
            {
                return obj.ProductName.GetHashCode();
                //throw new NotImplementedException();
            }
        }
        
        
    }
}

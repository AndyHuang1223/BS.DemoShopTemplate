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
        private Mock<IRepository<ProductSpecification>> _mockProductSpecificationRepository;

        [SetUp]
        public void Setup()
        {
            _mockProductRepository = new();
            _mockSpecificationRepository = new();
            _mockProductSpecificationRepository = new();
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
            var productService = new ProductService(productRepo, _mockSpecificationRepository.Object, _mockProductSpecificationRepository.Object);
            var expected = new Product { Id = 1, ProductName = "TestProduct", IsOnTheMarket = true };

            //Assert
            var actual = await productService.GetShelveProductByIdAsync(product.Id);
            Assert.That(actual.Id, Is.EqualTo(expected.Id));

        }

        [Test]
        public void GetHotSellProductList_With_ProductList()
        {
            //Arrange
            var prod1 = new Product
            {
                Id = 1,
                IsOnTheMarket = true,
                ProductName = "Product 1",
                ProductSpecifications = new List<ProductSpecification>
                    {
                        new ProductSpecification
                        {
                            Id = 1,
                            ProductId = 1,
                            Specification = new Specification
                            {
                                 Id= 1,
                                 Inventory = 10,
                            }
                        },
                        new ProductSpecification
                        {
                            Id = 2,
                            ProductId = 1,
                            Specification = new Specification
                            {
                                 Id= 2,
                                 Inventory = 20,
                            }
                        }
                    }
            };
            var prod2 = new Product
            {
                Id = 2,
                IsOnTheMarket = true,
                ProductName = "Product 2",
                ProductSpecifications = new List<ProductSpecification>
                    {
                        new ProductSpecification
                        {
                            Id = 3,
                            ProductId = 2,
                            Specification = new Specification
                            {
                                 Id= 3,
                                 Inventory = 10,
                            }
                        }
                    }
            };
            var prod3 = new Product
            {
                Id = 3,
                IsOnTheMarket = true,
                ProductName = "Product 3",
                ProductSpecifications = new List<ProductSpecification>
                    {
                        new ProductSpecification
                        {
                            Id = 4,
                            ProductId = 2,
                            Specification = new Specification
                            {
                                 Id= 4,
                                 Inventory = 1,
                            }
                        }
                    }
            };
            var productList = new List<Product>
            {
                prod1,
                prod2,
                prod3
            };
            
            var expected = new List<Product>()
            {
                prod3,
                prod2
            };

            //Act
            var productService = new ProductService(_mockProductRepository.Object, _mockSpecificationRepository.Object, _mockProductSpecificationRepository.Object);
            var actual = productService.GetHotSellProductList(productList, expected.Count);
            
            //Assert
            Assert.That(actual, Is.EqualTo(expected).Using(new ProductEqualityCompare()));
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
        
        [Test]
        public async Task GetHotSellProductList_With_ProductRepo()
        {
            //Arrange
            var prod1 = new Product
            {
                Id = 1,
                IsOnTheMarket = true,
                ProductName = "Product 1",
                ProductSpecifications = new List<ProductSpecification>
                    {
                        new ProductSpecification
                        {
                            Id = 1,
                            ProductId = 1,
                            Specification = new Specification
                            {
                                 Id= 1,
                                 Inventory = 10,
                            }
                        },
                        new ProductSpecification
                        {
                            Id = 2,
                            ProductId = 1,
                            Specification = new Specification
                            {
                                 Id= 2,
                                 Inventory = 20,
                            }
                        }
                    }
            };
            var prod2 = new Product
            {
                Id = 2,
                IsOnTheMarket = true,
                ProductName = "Product 2",
                ProductSpecifications = new List<ProductSpecification>
                    {
                        new ProductSpecification
                        {
                            Id = 3,
                            ProductId = 2,
                            Specification = new Specification
                            {
                                 Id= 3,
                                 Inventory = 10,
                            }
                        }
                    }
            };
            var prod3 = new Product
            {
                Id = 3,
                IsOnTheMarket = true,
                ProductName = "Product 3",
                ProductSpecifications = new List<ProductSpecification>
                    {
                        new ProductSpecification
                        {
                            Id = 4,
                            ProductId = 2,
                            Specification = new Specification
                            {
                                 Id= 4,
                                 Inventory = 1,
                            }
                        }
                    }
            };
            var productList = new List<Product>
            {
                prod1,
                prod2,
                prod3
            };

            _mockProductRepository.Setup(repo => repo.ListAsync())
                .ReturnsAsync(productList);
            var expected = new List<Product>()
            {
                prod3,
                prod2
            };

            //Act
            var productService = new ProductService(_mockProductRepository.Object, _mockSpecificationRepository.Object, _mockProductSpecificationRepository.Object);
            var actual = await productService.GetHotSellProductListAsync(expected.Count);

            //Assert
            Assert.That(actual, Is.EqualTo(expected).Using(new ProductEqualityCompare()));
        }
    }
}

using DemoShop.ApplicationCore.Entities;
using DemoShop.ApplicationCore.Interfaces;
using DemoShop.ApplicationCore.Services;
using Moq;
using NUnit.Framework;

namespace UnitTests;

public class OrderServiceTests
{
    private Mock<IRepository<Order>> _mockOrderRepository;
    private Mock<IRepository<OrderItem>> _mockOrderItemRepository;
    private Mock<IRepository<Coupon>> _mockCouponRepository;

    [SetUp]
    public void Setup()
    {
        _mockOrderRepository = new();
        _mockOrderItemRepository = new();
        _mockCouponRepository = new();
    }

    [Test]
    public async Task CalculateOrderAmount_Without_Discount()
    {
        // Arrange
        var order = new Order
        {
            Id = 1,
            BuyerName = "Test Buyer",
            BuyerEmail = "TestEmail@email.com",
            BuyerAddress = "TestAddress",
            TotalAmount = 0,
            OrderStatus = OrderStatus.Created,
            OrderItems = new List<OrderItem>()
            {
                new OrderItem()
                {
                    Id = 1,
                    ItemName = "Item1",
                    Units = 1,
                    UnitPrice = 100,
                    OrderId = 1
                },
                new OrderItem()
                {
                    Id = 2,
                    ItemName = "Item2",
                    Units = 2,
                    UnitPrice = 50,
                    OrderId = 1
                },
                new OrderItem()
                {
                    Id = 3,
                    ItemName = "Item3",
                    Units = 3,
                    UnitPrice = 33,
                    OrderId = 1
                }
            }
        };

        decimal expected = 1 * 100 + 2 * 50 + 3 * 33;

        // Act
        var orderService = new OrderService(_mockOrderRepository.Object, _mockOrderItemRepository.Object,
            _mockCouponRepository.Object);

        var actual = await orderService.CalculateTotalPriceAsync(order);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public async Task CalculateOrderAmount_With_Discount()
    {
        // Arrange
        var order = new Order
        {
            Id = 1,
            BuyerName = "Test Buyer",
            BuyerEmail = "TestEmail@email.com",
            BuyerAddress = "TestAddress",
            TotalAmount = 0,
            OrderStatus = OrderStatus.Created,
            OrderItems = new List<OrderItem>()
            {
                new OrderItem()
                {
                    Id = 1,
                    ItemName = "Item1",
                    Units = 1,
                    UnitPrice = 100,
                    Discount = 10,
                    OrderId = 1
                },
                new OrderItem()
                {
                    Id = 2,
                    ItemName = "Item2",
                    Units = 2,
                    UnitPrice = 50,
                    OrderId = 1
                },
                new OrderItem()
                {
                    Id = 3,
                    ItemName = "Item3",
                    Units = 3,
                    UnitPrice = 33,
                    Discount = 9,
                    OrderId = 1
                }
            }
        };
        decimal expected = 1 * 100 - 10 + 2 * 50 + 3 * 33 - 9;
        // Act
        var orderService = new OrderService(_mockOrderRepository.Object, _mockOrderItemRepository.Object,
            _mockCouponRepository.Object);

        var actual = await orderService.CalculateTotalPriceAsync(order);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public async Task CalculateOrderAmount_With_Coupon()
    {
        // Arrange
        var coupon = new Coupon
        {
            Id = 1,
            DiscountPercentage = 10
        };
        var orderItems = new List<OrderItem>()
        {
            new OrderItem()
            {
                Id = 1,
                ItemName = "Item1",
                Units = 1,
                UnitPrice = 100,
                OrderId = 1
            },
            new OrderItem()
            {
                Id = 2,
                ItemName = "Item2",
                Units = 2,
                UnitPrice = 50,
                OrderId = 1
            },
            new OrderItem()
            {
                Id = 3,
                ItemName = "Item3",
                Units = 3,
                UnitPrice = 33,
                OrderId = 1
            }
        };
        var order = new Order
        {
            Id = 1,
            BuyerName = "Test Buyer",
            BuyerEmail = "TestEmail@email.com",
            BuyerAddress = "TestAddress",
            TotalAmount = 0,
            OrderStatus = OrderStatus.Created,
            OrderItems = orderItems,
            CouponId = coupon.Id
        };

        _mockCouponRepository.Setup(repo => repo.GetByIdAsync(coupon.Id)).ReturnsAsync(coupon);
        decimal expected = (1 * 100 + 2 * 50 + 3 * 33) * (100 - coupon.DiscountPercentage) / 100;
        // Act
        var orderService = new OrderService(_mockOrderRepository.Object, _mockOrderItemRepository.Object, _mockCouponRepository.Object);

        var actual = await orderService.CalculateTotalPriceAsync(order);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public async Task CalculateOrderAmount_With_DiscountAndCoupon()
    {
        // Arrange
        var coupon = new Coupon
        {
            Id = 1,
            DiscountPercentage = 10
        };
        var orderItems = new List<OrderItem>()
        {
            new OrderItem()
            {
                Id = 1,
                ItemName = "Item1",
                Units = 1,
                UnitPrice = 100,
                Discount = 10,
                OrderId = 1
            },
            new OrderItem()
            {
                Id = 2,
                ItemName = "Item2",
                Units = 2,
                UnitPrice = 50,
                OrderId = 1
            },
            new OrderItem()
            {
                Id = 3,
                ItemName = "Item3",
                Units = 3,
                UnitPrice = 33,
                Discount = 9,
                OrderId = 1
            }
        };
        var order = new Order
        {
            Id = 1,
            BuyerName = "Test Buyer",
            BuyerEmail = "TestEmail@email.com",
            BuyerAddress = "TestAddress",
            TotalAmount = 0,
            OrderStatus = OrderStatus.Created,
            OrderItems = orderItems,
            CouponId = coupon.Id
        };

        _mockCouponRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(coupon);

        decimal expected = (1 * 100 - 10 + 2 * 50 + 3 * 33 - 9) * (100 - coupon.DiscountPercentage) / 100;
        // Act
        var orderService = new OrderService(_mockOrderRepository.Object, _mockOrderItemRepository.Object, _mockCouponRepository.Object);

        var actual = await orderService.CalculateTotalPriceAsync(order);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}
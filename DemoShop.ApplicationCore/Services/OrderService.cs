using DemoShop.ApplicationCore.Entities;
using DemoShop.ApplicationCore.Interfaces;
using DemoShop.ApplicationCore.Interfaces.OrderService;
using DemoShop.ApplicationCore.Interfaces.OrderService.Dto;

namespace DemoShop.ApplicationCore.Services;

public class OrderService : IOrderService
{
    

    private readonly IRepository<Order> _orderRepository;
    private readonly IRepository<OrderItem> _orderItemRepository;
    private readonly IRepository<Coupon> _couponRepository;

    public OrderService(IRepository<Order> orderRepository, IRepository<OrderItem> orderItemRepository, IRepository<Coupon> couponRepository)
    {
        _orderRepository = orderRepository;
        _orderItemRepository = orderItemRepository;
        _couponRepository = couponRepository;
    }


    public async Task<CreateOrderOutput> CreateOrderAsync(CreateOrderInput input)
    {
        throw new NotImplementedException();
    }

    public async Task<GetOrderOutput> GetOrderByOrderIdAsync(int orderId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        var orderItems = await _orderItemRepository.ListAsync(item => item.OrderId == orderId);
        var coupon = await _couponRepository.GetByIdAsync(order.CouponId);
        var result = new GetOrderOutput
        {
            Order = new Order
            {
                Id = order.Id,
                IsDelete = order.IsDelete,
                CreateAt = order.CreateAt,
                UpdateAt = order.UpdateAt,
                BuyerName = order.BuyerName,
                BuyerEmail = order.BuyerEmail,
                BuyerAddress = order.BuyerAddress,
                TotalAmount = order.TotalAmount,
                OrderStatus = order.OrderStatus,
                MemberId = order.MemberId,
                OrderItems = orderItems,
            },
            Coupon = coupon
        };
        return result;
    }

    public async Task<List<GetOrderOutput>> GetOrderListByMemberIdAsync(int memberId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<GetOrderOutput>> GetOrderListByMemberIdAsync(int memberId, OrderStatus orderStatus)
    {
        throw new NotImplementedException();
    }


    public async Task UpdateOrderStatusAsync(int orderId, OrderStatus orderStatus)
    {
        throw new NotImplementedException();
    }
    public async Task<decimal> CalculateTotalPriceAsync(Order order)
    {
        decimal total = 0;
        var orderOriginAmount = order.OrderItems.Sum(item => item.UnitPrice * item.Units - item.Discount);
        total = orderOriginAmount;
        
        if (!order.CouponId.HasValue) 
            return total;
        
        var coupon = await _couponRepository.GetByIdAsync(order.CouponId.Value);
        if (coupon != null)
        {
            total = total * (100 - coupon.DiscountPercentage) / 100;
        }

        return total;
    }
}
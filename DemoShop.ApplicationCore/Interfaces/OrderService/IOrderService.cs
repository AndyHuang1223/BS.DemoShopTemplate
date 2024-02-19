using DemoShop.ApplicationCore.Entities;
using DemoShop.ApplicationCore.Interfaces.OrderService.Dto;

namespace DemoShop.ApplicationCore.Interfaces.OrderService;

public interface IOrderService
{
    /// <summary>
    /// 成立訂單
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<CreateOrderOutput> CreateOrderAsync(CreateOrderInput input);

    /// <summary>
    /// 取得訂單資料（含訂單明細及Coupon資料）
    /// </summary>
    /// <param name="orderId"></param>
    /// <returns></returns>
    Task<GetOrderOutput> GetOrderByOrderIdAsync(int orderId);
    /// <summary>
    /// 取得會員所有訂單
    /// </summary>
    /// <param name="memberId"></param>
    /// <returns></returns>
    Task<List<GetOrderOutput>> GetOrderListByMemberIdAsync(int memberId);
    /// <summary>
    /// 取得會員特定狀態所有訂單
    /// </summary>
    /// <param name="memberId"></param>
    /// <param name="orderStatus"></param>
    /// <returns></returns>
    Task<List<GetOrderOutput>> GetOrderListByMemberIdAsync(int memberId, OrderStatus orderStatus);

    /// <summary>
    /// 更新訂單狀態
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="orderStatus"></param>
    /// <returns></returns>
    Task UpdateOrderStatusAsync(int orderId, OrderStatus orderStatus);
    /// <summary>
    /// 計算訂單總額
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    Task<decimal> CalculateTotalPriceAsync(Order order);
}
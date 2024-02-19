namespace DemoShop.ApplicationCore.Interfaces.OrderService.Dto;

public class GetOrderOutput
{
    public Entities.Order Order { get; set; }
    public Entities.Coupon Coupon { get; set; }
}
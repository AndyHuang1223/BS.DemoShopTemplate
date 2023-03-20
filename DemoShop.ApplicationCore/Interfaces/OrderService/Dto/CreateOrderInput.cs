namespace DemoShop.ApplicationCore.Interfaces.OrderService.Dto;

public class CreateOrderInput
{
    public string BuyerName { get; set; }
    public string BuyerEmail { get; set; }
    public string BuyerAddress { get; set; }
    public int? CouponId { get; set; }
}
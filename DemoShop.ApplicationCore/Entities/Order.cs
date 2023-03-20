using System.ComponentModel.DataAnnotations;

namespace DemoShop.ApplicationCore.Entities;

public class Order : BaseEntity
{
    [Required]
    public string BuyerName { get; set; }
    [Required]
    public string BuyerEmail { get; set; }
    [Required]
    public string BuyerAddress { get; set; }
    
    public decimal TotalAmount { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public int MemberId { get; set; }
    public Member Member { get; set; }

    public int? CouponId { get; set; }
    public Coupon Coupon { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; }

}

public enum OrderStatus
{
    Created = 0,
    Paid = 1,
    Complete = 2
}
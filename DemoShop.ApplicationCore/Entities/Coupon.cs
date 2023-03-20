using System.ComponentModel.DataAnnotations;

namespace DemoShop.ApplicationCore.Entities;

public class Coupon : BaseEntity
{
    [Required]
    public string CouponCode { get; set; }
    public decimal DiscountPercentage { get; set; }
}
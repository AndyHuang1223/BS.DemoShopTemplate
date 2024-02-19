using System.ComponentModel.DataAnnotations;

namespace DemoShop.ApplicationCore.Entities;

public class Product : BaseEntity
{
    [Required]
    public string ProductName { get; set; }
    public string Description { get; set; }
    public bool IsOnTheMarket { get; set; }
    public string ImagePath { get; set; }
    
    public ICollection<ProductDetail> ProductDeatils { get; set; }
}
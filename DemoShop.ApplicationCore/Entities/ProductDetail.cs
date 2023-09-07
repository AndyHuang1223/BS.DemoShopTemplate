using System.ComponentModel.DataAnnotations;

namespace DemoShop.ApplicationCore.Entities;

public class ProductDetail : BaseEntity
{
    
    public int ProductId { get; set; }
    [Required]
    public string SKU { get; set; }
    public int Inventory { get; set; }
    public decimal UnitPrice { get; set; }

    public Product Product { get; set; }
    public ICollection<Specification> Specifications { get; set; }

}
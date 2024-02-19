namespace DemoShop.ApplicationCore.Entities;

public class OrderItem : BaseEntity
{
    public string ItemName { get; set; }
    public int Units { get; set; }
    public decimal UnitPrice { get; set; }

    public decimal Discount { get; set; }
    
    public int OrderId { get; set; }
    public Order Order { get; set; }
}
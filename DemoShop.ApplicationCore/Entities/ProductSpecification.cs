using System.ComponentModel.DataAnnotations;

namespace DemoShop.ApplicationCore.Entities;

public class ProductSpecification : BaseEntity
{
    
    public int ProductId { get; set; }
    public int SpecificationId { get; set; }

    public Product Product { get; set; }
    public Specification Specification { get; set; }
    
}
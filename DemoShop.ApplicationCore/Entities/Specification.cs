using System.ComponentModel.DataAnnotations;

namespace DemoShop.ApplicationCore.Entities;

public class Specification : BaseEntity
{
    [Required]
    public string SpecificationValue { get; set; }
    [Required]
    public string SKU { get; set; }
    public int Inventory { get; set; }
    public decimal UnitPrice { get; set; }

    public int SpecificationReferenceId { get; set; }
    public SpecificationReference SpecificationReference { get; set; }
    
    public ICollection<ProductSpecification> ProductSpecifications { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace DemoShop.ApplicationCore.Entities;

public class Specification : BaseEntity
{
    [Required]
    public string SpecificationValue { get; set; }
    public int SpecificationReferenceId { get; set; }
    public int ProductDetailId { get; set; }
    public SpecificationReference SpecificationReference { get; set; }
    public ProductDetail ProductDetail { get; set; }
}
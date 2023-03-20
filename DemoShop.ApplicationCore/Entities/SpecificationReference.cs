using System.ComponentModel.DataAnnotations;

namespace DemoShop.ApplicationCore.Entities;

public class SpecificationReference : BaseEntity
{
    [Required]
    public string SpecificationName { get; set; }

    public ICollection<Specification> Specifications { get; set; }
}
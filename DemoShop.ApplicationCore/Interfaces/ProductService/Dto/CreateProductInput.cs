using DemoShop.ApplicationCore.Entities;

namespace DemoShop.ApplicationCore.Interfaces.ProductService.Dto;

public class CreateProductInput
{
    public string ProductName { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public Specification Specification { get; set; }
}
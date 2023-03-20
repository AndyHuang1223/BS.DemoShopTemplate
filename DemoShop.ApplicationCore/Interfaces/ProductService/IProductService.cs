using DemoShop.ApplicationCore.Entities;
using DemoShop.ApplicationCore.Interfaces.ProductService.Dto;

namespace DemoShop.ApplicationCore.Interfaces.ProductService;

public interface IProductService
{
    Task<Product> GetShelveProductByIdAsync(int productId);
    Task<List<Product>> GetHotSellProductListByCategoryIdAsync(int categoryId, int count);
    Task<Product> CreateProductAsync(CreateProductInput input);
    Task<Specification> CreateProductSpecAsync(int productId,string specificationName, string specificationValue);
    Task ShelveProductAsync(int productId);
    Task OffShelveProductAsync(int productId);
}
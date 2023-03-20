using DemoShop.ApplicationCore.Entities;
using DemoShop.ApplicationCore.Interfaces.ProductService.Dto;

namespace DemoShop.ApplicationCore.Interfaces.ProductService;

public interface IProductService
{
    Task<Product> GetShelveProductByIdAsync(int productId);
    Task<List<Product>> GetHotSellProductListByCategoryIdAsync(int categoryId, int count);
    Task ShelveProductAsync(int productId);
    Task OffShelveProductAsync(int productId);
}
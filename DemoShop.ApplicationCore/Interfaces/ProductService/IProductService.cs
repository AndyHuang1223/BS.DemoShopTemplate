using DemoShop.ApplicationCore.Entities;
using DemoShop.ApplicationCore.Interfaces.ProductService.Dto;

namespace DemoShop.ApplicationCore.Interfaces.ProductService;

public interface IProductService
{
    Task<Product> GetShelveProductByIdAsync(int productId);
    List<Product> GetHotSellProductList(List<Product> productList, int count);
    Task<List<Product>> GetHotSellProductListAsync(int count);
    Task ShelveProductAsync(int productId);
    Task OffShelveProductAsync(int productId);
    //TODO 新增一個取得商品資訊的Product
    Task<GetProductInfoOutput> GetProductInfoAsync(int productId);
}
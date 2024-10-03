using DemoShop.ApplicationCore.Interfaces.CatalogService.Dto;

namespace DemoShop.ApplicationCore.Interfaces.CatalogService;

public interface ICatalogService
{
    Task<List<CatalogItem>> GetCatalogItemsAsync();
    Task<CatalogItem> GetCatalogItemByIdAsync(int id);
}
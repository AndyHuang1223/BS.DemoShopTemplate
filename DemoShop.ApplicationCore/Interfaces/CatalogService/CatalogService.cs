using DemoShop.ApplicationCore.Entities;
using DemoShop.ApplicationCore.Interfaces.CatalogService.Dto;

namespace DemoShop.ApplicationCore.Interfaces.CatalogService;

public class CatalogService : ICatalogService
{
    private readonly IRepository<Catalog> _catalogRepository;

    public CatalogService(IRepository<Catalog> catalogRepository)
    {
        _catalogRepository = catalogRepository;
    }

    public async Task<List<CatalogItem>> GetCatalogItemsAsync()
    {
        var catalogsEntities = await _catalogRepository.ListAsync();

        return GetCategories(catalogsEntities, null);
    }

    public async Task<CatalogItem> GetCatalogItemByIdAsync(int id)
    {
        var catalogEntity = await _catalogRepository.GetByIdAsync(id);
        if (catalogEntity is null)
            return default;

        return GetCategories(new List<Catalog>() { catalogEntity }, null)?.FirstOrDefault();
    }

    private static List<CatalogItem> GetCategories(List<Catalog> catalogs, int? parentCatalogId)
    {
        if (catalogs == null || catalogs.Count < 1) return null;
        var catalogItems = new List<CatalogItem>();
        var categories =
            catalogs.OrderBy(c => c.Seq)
                .Where(c => c.ParentCatalogId == parentCatalogId)
                .ToList();
        foreach (var category in categories)
        {
            var catalogItem = new CatalogItem
            {
                Id = category.Id,
                Name = category.Name,
                ParentCatalogId = parentCatalogId,
                SubCatalog = GetCategories(catalogs, category.Id)
            };
            catalogItems.Add(catalogItem);
        }

        return catalogItems;
    }
}
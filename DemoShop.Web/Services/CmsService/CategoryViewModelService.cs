using DemoShop.ApplicationCore.Interfaces.CatalogService;
using DemoShop.ApplicationCore.Interfaces.CatalogService.Dto;
using DemoShop.Web.Models.ViewModels.Home;

namespace DemoShop.Web.Services.CmsService;

public class CategoryViewModelService : ICategoryViewModelService
{
    private readonly ICatalogService _catalogService;

    public CategoryViewModelService(ICatalogService catalogService)
    {
        _catalogService = catalogService;
    }

    public async Task<CategoryViewModel> GetCategoryViewModelAsync()
    {
        var catalogItems = await _catalogService.GetCatalogItemsAsync();
        return new CategoryViewModel
        {
            Title = "分類目錄頁測試",
            CategoryItems = GetCategories(catalogItems, null)
        };
    }

    public async Task<CategoryItem> GetCategoryByIdAsync(int categoryId)
    {
        var catalogItem = await _catalogService.GetCatalogItemByIdAsync(categoryId);
        if (catalogItem is null)
            return default;

        return GetCategories(new List<CatalogItem>() { catalogItem }, null)?.FirstOrDefault();
    }

    private static List<CategoryItem> GetCategories(List<CatalogItem> catalogItems, int? parentCatalogId)
    {
        if (catalogItems == null || catalogItems.Count < 1) return null;
        var categoryItems = new List<CategoryItem>();
        var categories = catalogItems
            .Where(c => c.ParentCatalogId == parentCatalogId)
            .ToList();
        foreach (var category in categories)
        {
            var categoryItem = new CategoryItem
            {
                CategoryId = category.Id,
                CategoryName = category.Name,
                ParentCategoryId = category.ParentCatalogId,
                SubCategories = GetCategories(category.SubCatalog, category.Id),
            };
            categoryItems.Add(categoryItem);
        }

        return categoryItems;
    }
}
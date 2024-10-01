using DemoShop.Web.Models.ViewModels.Home;
using DemoShop.Web.Services.CmsService;
using Microsoft.Extensions.Caching.Memory;

namespace DemoShop.Web.CacheServices;

public class MemoryCacheCategoryService : ICategoryViewModelService
{
    private readonly CategoryViewModelService _categoryViewModelService;
    private readonly IMemoryCache _memoryCache;

    public MemoryCacheCategoryService(CategoryViewModelService categoryViewModelService, IMemoryCache memoryCache)
    {
        _categoryViewModelService = categoryViewModelService;
        _memoryCache = memoryCache;
    }

    public async Task<CategoryViewModel> GetCategoryViewModelAsync()
    {
        // 原本資料是這樣傳出去(有去請求資料庫)
        // return await _categoryViewModelService.GetCategoryViewModelAsync();

        var cacheKey = "Category-ViewModel-Key";
        
        return await _memoryCache.GetOrCreateAsync(cacheKey, async entry =>
        {
            // 設定快取過期時間 5 分鐘(絕對到期時間)
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
            
            // 設定快取過期時間 1 分鐘(滑動到期時間, 1 分鐘內沒有存取就會過期)
            entry.SlidingExpiration = TimeSpan.FromMinutes(5);
            return await _categoryViewModelService.GetCategoryViewModelAsync();
        });
    }
}
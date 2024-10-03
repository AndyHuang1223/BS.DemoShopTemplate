using System.Text.Json;
using DemoShop.Web.Models.ViewModels.Home;
using DemoShop.Web.Services.CmsService;
using Microsoft.Extensions.Caching.Distributed;

namespace DemoShop.Web.CacheServices;

public class RedisCacheCategoryViewModelService : ICategoryViewModelService
{
    private readonly CategoryViewModelService _categoryViewModelService;
    private readonly IDistributedCache _distributedCache;

    public RedisCacheCategoryViewModelService(CategoryViewModelService categoryViewModelService,
        IDistributedCache distributedCache)
    {
        _categoryViewModelService = categoryViewModelService;
        _distributedCache = distributedCache;
    }

    public async Task<CategoryViewModel> GetCategoryViewModelAsync()
    {
        const string cacheKey = "CategoryViewModel-Redis";
        var cacheValue = await _distributedCache.GetAsync(cacheKey);
        var cachedCategoryViewModel = ByteArrayToObj<CategoryViewModel>(cacheValue);

        if (cachedCategoryViewModel != null)
            return cachedCategoryViewModel;

        var realCategoryViewModel = await _categoryViewModelService.GetCategoryViewModelAsync();
        var byteResult = ObjectToByteArray(realCategoryViewModel);
        await _distributedCache.SetAsync(cacheKey, byteResult, new DistributedCacheEntryOptions()
        {
            SlidingExpiration = TimeSpan.FromMinutes(1),
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        });

        return realCategoryViewModel;
    }

    public async Task<CategoryItem> GetCategoryByIdAsync(int categoryId)
    {
        var cacheKey = $"CategoryItem-Redis-{categoryId}";
        var cacheValue = await _distributedCache.GetAsync(cacheKey);
        var cachedCategoryItem = ByteArrayToObj<CategoryItem>(cacheValue);
        
        if (cachedCategoryItem != null)
            return cachedCategoryItem;
        
        var realCategoryItem = await _categoryViewModelService.GetCategoryByIdAsync(categoryId);
        var byteResult = ObjectToByteArray(realCategoryItem);
        await _distributedCache.SetAsync(cacheKey, byteResult, new DistributedCacheEntryOptions()
        {
            SlidingExpiration = TimeSpan.FromSeconds(10),
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        });
        
        return realCategoryItem;
    }

    /// <summary>
    /// 將物件轉換為 Byte Array (分散式快取只支援此格式)
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    private static byte[] ObjectToByteArray(object obj)
    {
        return JsonSerializer.SerializeToUtf8Bytes(obj);
    }

    /// <summary>
    /// 將Byte Array 轉成物件 （從分散式記憶體取得的ByteArray轉回物件） 
    /// </summary>
    /// <param name="byteArr"></param>
    /// <typeparam name="T">參考型別</typeparam>
    /// <returns></returns>
    private static T ByteArrayToObj<T>(byte[] byteArr) where T : class
    {
        return byteArr is null ? null : JsonSerializer.Deserialize<T>(byteArr);
    }
}
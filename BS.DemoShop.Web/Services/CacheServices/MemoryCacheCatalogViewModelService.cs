using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BS.DemoShop.Web.Interfaces;
using BS.DemoShop.Web.ViewModels.Catalog;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;

namespace BS.DemoShop.Web.Services.CacheServices
{
    public class MemoryCacheCatalogViewModelService : ICatalogViewModelService
    {
        private readonly IMemoryCache _cache;
        private readonly CatalogViewModelService _catalogViewModelService;
        private static readonly string _categoryKey = "category";
        private static readonly TimeSpan _defaultCacheDuration = TimeSpan.FromSeconds(30);

        public MemoryCacheCatalogViewModelService(IMemoryCache cache, CatalogViewModelService catalogViewModelService)
        {
            _cache = cache;
            _catalogViewModelService = catalogViewModelService;
        }

        public async Task<CatalogIndexViewModel> GetCatelogItems(int? categoryId)
        {
            var cacheKey = $"items-{categoryId}";
            return await _cache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                entry.SlidingExpiration = _defaultCacheDuration;
                return await _catalogViewModelService.GetCatelogItems(categoryId);
            });
        }

        public IEnumerable<SelectListItem> GetCategories()
        {
            return _cache.GetOrCreate(_categoryKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                entry.SlidingExpiration = _defaultCacheDuration;
                return _catalogViewModelService.GetCategories();
            });
        }

        public IEnumerable<SelectListItem> GetCategories(int categoryId)
        {
            var cacheKey = $"category-{categoryId}";
            return _cache.GetOrCreate(cacheKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                entry.SlidingExpiration = _defaultCacheDuration;
                return _catalogViewModelService.GetCategories(categoryId);
            });
        }
    }
}
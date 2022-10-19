using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using BS.DemoShop.Web.Interfaces;
using BS.DemoShop.Web.ViewModels.Catalog;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Distributed;

namespace BS.DemoShop.Web.Services.CacheServices
{
    public class RedisCacheCatalogViewModelService : ICatalogViewModelService
    {
        private readonly IDistributedCache _cache;
        private readonly CatalogViewModelService _catalogViewModelService;
        private static readonly string _categoryKey = "category";
        private static readonly TimeSpan _defaultCacheDuration = TimeSpan.FromSeconds(30);

        public RedisCacheCatalogViewModelService(IDistributedCache cache, CatalogViewModelService catalogViewModelService)
        {
            _cache = cache;
            _catalogViewModelService = catalogViewModelService;
        }

        public async Task<CatalogIndexViewModel> GetCatelogItems(int? categoryId)
        {
            var cacheKey = $"items-{categoryId}";
            var cacheItems = ByteArrayToObj<CatalogIndexViewModel>(await _cache.GetAsync(cacheKey));
            if (cacheItems is null)
            {
                var realItems = await _catalogViewModelService.GetCatelogItems(categoryId);
                var byteArrResult = ObjectToByteArray(realItems);
                await _cache.SetAsync(cacheKey, byteArrResult, new DistributedCacheEntryOptions
                {
                    SlidingExpiration = _defaultCacheDuration,
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                });
                return realItems;
            }

            return cacheItems;
        }

        public IEnumerable<SelectListItem> GetCategories()
        {
            var cacheItems = ByteArrayToObj<IEnumerable<SelectListItem>>(_cache.Get(_categoryKey));
            if (cacheItems is null)
            {
                var realItems = _catalogViewModelService.GetCategories();
                var byteArrResult = ObjectToByteArray(realItems);
                _cache.Set(_categoryKey, byteArrResult, new DistributedCacheEntryOptions
                {
                    SlidingExpiration = _defaultCacheDuration,
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                });
                return realItems;
            }

            return cacheItems;
        }

        public IEnumerable<SelectListItem> GetCategories(int categoryId)
        {
            var cacheKey = $"category-{categoryId}";
            var cacheItems = ByteArrayToObj<IEnumerable<SelectListItem>>(_cache.Get(cacheKey));
            if (cacheItems is null)
            {
                var realItems = _catalogViewModelService.GetCategories(categoryId);
                var byteArrResult = ObjectToByteArray(realItems);
                _cache.Set(cacheKey, byteArrResult, new DistributedCacheEntryOptions
                {
                    SlidingExpiration = _defaultCacheDuration,
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                });
                return realItems;
            }

            return cacheItems;
        }
        
        /// <summary>
        /// 將物件轉換為 Byte Array (分散式快取只支援此格式)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private byte[] ObjectToByteArray(object obj)
        {
            return JsonSerializer.SerializeToUtf8Bytes(obj);
        }

        /// <summary>
        /// 將Byte Array 轉成物件 （從分散式記憶體取得的ByteArray轉回物件） 
        /// </summary>
        /// <param name="byteArr"></param>
        /// <typeparam name="T">參考型別</typeparam>
        /// <returns></returns>
        private T ByteArrayToObj<T>(byte[] byteArr) where T : class
        {
            return byteArr is null ? null : JsonSerializer.Deserialize<T>(byteArr);
        }
    }
}
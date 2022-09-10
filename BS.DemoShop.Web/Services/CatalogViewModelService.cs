using BS.DemoShop.Core.Entities;
using BS.DemoShop.Core.Interfaces;
using BS.DemoShop.Web.Interfaces;
using BS.DemoShop.Web.ViewModels.Catalog;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BS.DemoShop.Web.Services
{
    public class CatalogViewModelService : ICatalogViewModelService
    {
        private readonly IRepository<Category> _categoryRepo;
        private readonly IRepository<Product> _productRepo;
        private readonly IProductQueryService _productQueryService;

        public CatalogViewModelService(
            IRepository<Category> categoryRepo,
            IRepository<Product> productRepo,
            IProductQueryService productQueryService)
        {
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
            _productQueryService = productQueryService;
        }

        public async Task<IEnumerable<SelectListItem>> GetCategories()
        {
            var categoryItems = await _categoryRepo.GetAllReadOnly()
                 .OrderBy(c => c.Sort)
                 .ThenBy(c => c.CreatedTime)
                 .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                 .ToListAsync();

            var allItem = new SelectListItem { Value = null, Text = "全部分類", Selected = true };
            categoryItems.Insert(0, allItem);
            
            return categoryItems;
        }

        public async Task<IEnumerable<SelectListItem>> GetCategories(int categoryId)
        {
            var items = (await GetCategories()).ToList();
            foreach (var item in items)
            {
                if (item.Value == categoryId.ToString())
                {
                    item.Selected = true;
                }
                else
                {
                    item.Selected = false;
                }
            }

            return items;
        }

        public async Task<CatalogIndexViewModel> GetCatelogItems(int? categoryId)
        {
            var productEntities = _productRepo.GetAllReadOnly();
            if (categoryId.HasValue)
            {
                productEntities = productEntities.Where(p => p.CategoryId == categoryId);

            }
            var products = await productEntities
                .Select(p => new { p.Id, p.Name, p.ImgPath })
                .ToListAsync();

            var productCards = new List<ProductCardViewModel>();
            foreach (var item in products)
            {
                var maxPrice = await _productQueryService.GetProductMaxPriceById(item.Id);
                var temp = new ProductCardViewModel { Id = item.Id, ImageUrl = item.ImgPath, Name = item.Name, Price = maxPrice };
                productCards.Add(temp);
            }

            var categoryItems = (await GetCategories()).ToList();
            var result = new CatalogIndexViewModel { ProductCards = productCards, CategoryItemList = categoryItems };
            
            return result;

        }
    }
}

using BS.DemoShop.Web.ViewModels.Catalog;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BS.DemoShop.Web.Interfaces
{
    public interface ICatalogViewModelService
    {
        Task<CatalogIndexViewModel> GetCatelogItems(int? categoryId);

        Task<IEnumerable<SelectListItem>> GetCategories();
        Task<IEnumerable<SelectListItem>> GetCategories(int categoryId);
    }
}

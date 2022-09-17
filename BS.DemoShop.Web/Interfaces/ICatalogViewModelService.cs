using BS.DemoShop.Web.ViewModels.Catalog;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BS.DemoShop.Web.Interfaces
{
    public interface ICatalogViewModelService
    {
        Task<CatalogIndexViewModel> GetCatelogItems(int? categoryId);

        IEnumerable<SelectListItem> GetCategories();
        IEnumerable<SelectListItem> GetCategories(int categoryId);
    }
}

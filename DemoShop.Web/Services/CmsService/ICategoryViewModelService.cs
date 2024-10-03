using DemoShop.Web.Models.ViewModels.Home;

namespace DemoShop.Web.Services.CmsService;

public interface ICategoryViewModelService
{
    Task<CategoryViewModel> GetCategoryViewModelAsync();

    Task<CategoryItem> GetCategoryByIdAsync(int categoryId);
}
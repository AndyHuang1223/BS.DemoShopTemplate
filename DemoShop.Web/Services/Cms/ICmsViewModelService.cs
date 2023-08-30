using DemoShop.Web.ViewModels.Cms;

namespace DemoShop.Web.Services.Cms
{
    public interface ICmsViewModelService
    {
        Task<IndexViewModel> GetHomepageViewModel();
    }
}
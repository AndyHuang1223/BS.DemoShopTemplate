using DemoShop.Web.Models.ViewModels.Home;

namespace DemoShop.Web.Services.CmsService
{
    public interface ICmsViewModelService
    {
        Task<IndexViewModel> GetHomepageViewModel();
    }
}
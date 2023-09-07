using DemoShop.Web.ViewModels.Cms;

namespace DemoShop.Web.Services.CmsService
{
    public interface ICmsViewModelService
    {
        Task<IndexViewModel> GetHomepageViewModel();
    }
}
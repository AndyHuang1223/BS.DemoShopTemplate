using DemoShop.Web.Models.ViewModels.Home;
using DemoShop.Web.Models.ViewModels.Partial;

namespace DemoShop.Web.Services.CmsService
{
    public class FakeCmsViewModelService : ICmsViewModelService
    {
        public async Task<IndexViewModel> GetHomepageViewModel()
        {
            return new IndexViewModel
            {
                HotSellWidget = await GetHotSellArea()
            };
        }
        private async Task<WidgetPartialViewModel> GetHotSellArea()
        {
            return new WidgetPartialViewModel()
            {
                Title = "熱銷專區",
                ProductCards = new List<ProductCardViewModel>
                {
                    new ProductCardViewModel
                    {
                        Id = 1,
                        Name = "Name1",
                        ShowPrice = 1100.ToString("#,#"),
                        ImgUrl = "https://picsum.photos/300/200/?random=10",
                        Link = "/product/1"
                    },
                    new ProductCardViewModel
                    {
                        Id = 2,
                        Name = "Name2",
                        ShowPrice = 1200.ToString("#,#"),
                        ImgUrl = "https://picsum.photos/300/200/?random=20",
                        Link = "/product/2"
                    },
                    new ProductCardViewModel
                    {
                        Id = 3,
                        Name = "Name",
                        ShowPrice = 1300.ToString("#,#"),
                        ImgUrl = "https://picsum.photos/300/200/?random=30",
                        Link = "/product/3"
                    },
                }
            };
        }
    }
}

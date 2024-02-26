using DemoShop.ApplicationCore.Entities;
using DemoShop.ApplicationCore.Interfaces;
using DemoShop.ApplicationCore.Interfaces.ProductService;
using DemoShop.Web.Models.ViewModels.Home;
using DemoShop.Web.Models.ViewModels.Partial;

namespace DemoShop.Web.Services.CmsService
{
    public class CmsService : ICmsViewModelService
    {
        private readonly IProductService _productService;
        private readonly IRepository<ProductDetail> _prodDetailRepo;

        public CmsService(IProductService productService, IRepository<ProductDetail> prodSpecRepo)
        {
            _productService = productService;
            _prodDetailRepo = prodSpecRepo;
        }



        public async Task<IndexViewModel> GetHomepageViewModel()
        {
            var hotSellProds = await _productService.GetHotSellProductListAsync(5);
            var prodDetails = await _prodDetailRepo.ListAsync(ps => hotSellProds.Select(p => p.Id).Contains(ps.ProductId));

            var prodCards = hotSellProds.Select(p => new ProductCardViewModel
            {
                Id = p.Id,
                Name = p.ProductName,
                ImgUrl = p.ImagePath,
                Link = $"/product/{p.Id}",
                ShowPrice = prodDetails.FirstOrDefault(pd => pd.ProductId == p.Id)?.UnitPrice.ToString("#,#.00") ?? "隱藏價格"
            }).ToList();
            IndexViewModel vm = new IndexViewModel()
            {
                HotSellWidget = new WidgetPartialViewModel
                {
                    Title = "熱銷商品(從DB來的)",
                    ProductCards = prodCards
                }
            };


            return vm;
        }
    }
}

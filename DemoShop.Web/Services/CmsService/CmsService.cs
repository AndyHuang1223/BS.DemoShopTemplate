using DemoShop.ApplicationCore.Entities;
using DemoShop.ApplicationCore.Interfaces;
using DemoShop.ApplicationCore.Interfaces.ProductService;
using DemoShop.Web.ViewModels.Cms;
using DemoShop.Web.ViewModels.Partial;

namespace DemoShop.Web.Services.CmsService
{
    public class CmsService : ICmsViewModelService
    {
        private readonly IProductService _productService;
        private readonly IRepository<Product> _productRepo;
        private readonly IRepository<ProductDetail> _prodDetailRepo;
        private readonly IRepository<Specification> _specRepo;

        public CmsService(IProductService productService, IRepository<Product> productRepo, IRepository<ProductDetail> prodSpecRepo, IRepository<Specification> specRepo)
        {
            _productService = productService;
            _productRepo = productRepo;
            _prodDetailRepo = prodSpecRepo;
            _specRepo = specRepo;
        }



        public async Task<IndexViewModel> GetHomepageViewModel()
        {
            var hotsellProds = await _productService.GetHotSellProductListAsync(5);
            var prodDeatils = await _prodDetailRepo.ListAsync(ps => hotsellProds.Select(p => p.Id).Contains(ps.ProductId));

            var prodCards = hotsellProds.Select(p => new ProductCardViewModel
            {
                Id = p.Id,
                Name = p.ProductName,
                ImgUrl = p.ImagePath,
                Link = $"/product/{p.Id}",
                ShowPrice = prodDeatils.FirstOrDefault(pd => pd.ProductId == p.Id)?.UnitPrice.ToString("#,#.00") ?? "隱藏價格"
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

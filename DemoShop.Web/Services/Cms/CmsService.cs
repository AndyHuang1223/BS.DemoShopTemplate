using DemoShop.ApplicationCore.Entities;
using DemoShop.ApplicationCore.Interfaces;
using DemoShop.ApplicationCore.Interfaces.ProductService;
using DemoShop.Web.ViewModels.Cms;
using DemoShop.Web.ViewModels.Partial;

namespace DemoShop.Web.Services.Cms
{
    public class CmsService : ICmsViewModelService
    {
        private readonly IProductService _productService;
        private readonly IRepository<Product> _productRepo;
        private readonly IRepository<ProductSpecification> _prodSpecRepo;
        private readonly IRepository<Specification> _specRepo;

        public CmsService(IProductService productService, IRepository<Product> productRepo, IRepository<ProductSpecification> prodSpecRepo, IRepository<Specification> specRepo)
        {
            _productService = productService;
            _productRepo = productRepo;
            _prodSpecRepo = prodSpecRepo;
            _specRepo = specRepo;
        }

        

        public async Task<IndexViewModel> GetHomepageViewModel()
        {
            var hotsellProds = await _productService.GetHotSellProductListAsync(5);
            var prodSpecs = await _prodSpecRepo.ListAsync(ps => hotsellProds.Select(p => p.Id).Contains(ps.ProductId));
            var specs = await _specRepo.ListAsync(s => prodSpecs.Select(ps => ps.SpecificationId).Contains(s.Id));

            var prodCards = hotsellProds.Select(p => new ProductCardViewModel
            {
                Id = p.Id,
                Name = p.ProductName,
                ImgUrl = p.ImagePath,
                Link = $"/product/{p.Id}",
                ShowPrice = specs.Where(s => s.Id == prodSpecs.Where(ps=> ps.ProductId == p.Id).First().SpecificationId).First().UnitPrice.ToString("#,#.00")
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

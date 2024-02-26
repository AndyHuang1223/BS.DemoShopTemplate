using DemoShop.ApplicationCore.Interfaces.ProductService;
using DemoShop.Web.Models.ViewModels.Product;

namespace DemoShop.Web.Services.ProductService
{
    public class ProductViewModelService
    {
        private readonly IProductService _productService;

        public ProductViewModelService(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductInfoViewModel> GetProductInfoAsync(int id)
        {
            var product = await _productService.GetProductInfoAsync(id);
            if (product == null)
            {
                return null;
            }

            return new ProductInfoViewModel
            {
                ProductId = product.ProductId,
                Desc = product.Desc,
                Name = product.Name,
                MainPicture = product.MainPicture,
                MaxPrice = product.MaxPrice,
                MinPrice = product.MinPrice,
                Spec = product.Spec.Select(s => new SpecVM
                {
                    Inventory = s.Inventory,
                    SKU = s.SKU,
                    SpecId = s.SpecId,
                    Title = s.Title,
                    UnitPrice = s.UnitPrice,
                    Value = s.Value,
                }).ToArray()
            };
        }
    }
}

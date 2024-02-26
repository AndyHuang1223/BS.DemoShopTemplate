using DemoShop.ApplicationCore.Interfaces.ProductService;
using DemoShop.ApplicationCore.Interfaces.ProductService.Dto;
using DemoShop.Web.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductViewModelService _productService;

        public ProductController(ProductViewModelService productService)
        {
            _productService = productService;
        }
        [Route("/product/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var product = await _productService.GetProductInfoAsync(id);

            if (product == null)
            {
                return View("ProductNotFound");
            }

            var vm = product;

            return View(vm);
        }
    }
}

using System.Linq;
using System.Threading.Tasks;
using BS.DemoShop.Core.Entities;
using BS.DemoShop.Web.Interfaces;
using BS.DemoShop.Web.Services;
using BS.DemoShop.Web.ViewModels.Catalog;
using BS.DemoShop.Web.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BS.DemoShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductViewModelService _productService;
        private readonly ICatalogViewModelService _catalogViewModelService;

        public ProductController(ProductViewModelService productService, ICatalogViewModelService catalogViewModelService)
        {
            _productService = productService;
            _catalogViewModelService = catalogViewModelService;
        }
        public async Task<IActionResult> CatalogIndex(CatalogIndexViewModel input)
        {
            var result = await _catalogViewModelService.GetCatelogItems(input.CategoryId);
            return View("CatalogIndex", result);
        }
        public IActionResult Index()
        {
            var products = _productService.GetAllProduct();
            return View(products);
        }
        [Authorize]
        public IActionResult Detail(int id)
        {
            var product = _productService.GetById(id);
            if (product is null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }
        public IActionResult CreateProduct()
        {
            var result = new CreateProductViewModel()
            {
                CategoryItems = _catalogViewModelService.GetCategories().ToList()
            };
            return View(result);
        }
        [HttpPost]
        public IActionResult CreateProductDetail(CreateProductViewModel input)
        {
            var items = _catalogViewModelService.GetCategories(input.CategoryId).ToList();
            input.CategoryItems = items;
            input.ProductDetail.Add(new CreateDetailViewModel());
            return View("CreateProduct", input);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductViewModel input)
        {
            if (!ModelState.IsValid)
            {
                //有坑，https://stackoverflow.com/questions/43281345/mvc-net-core-model-validation-the-value-is-invalid-error
                return View(input);
            }

            _productService.CreateProduct(input);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult CreateProductByRepo(CreateProductViewModel input)
        {
            if (!ModelState.IsValid)
            {
                //有坑，https://stackoverflow.com/questions/43281345/mvc-net-core-model-validation-the-value-is-invalid-error
                return View("CreateProduct", input);
            }

            _productService.CreateProductByRepository(input);

            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult Update(ProductViewModel input)
        {
            _productService.UpdateProduct(input);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(ProductViewModel input)
        {
            _productService.DeleteProduct(input);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateDefaultProduct()
        {
            CreateDefaultProductDTO source = new CreateDefaultProductDTO
            {
                Name = "測試預設商品",
                ImgPath = "https://fakeimg.pl/300x200/200"
            };
            var result = await _productService.CreateProductWithDetail(source);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetAllInventory(int id)
        {
            var result = await _productService.GetProductInventory(id);
            return Content(result.ToString());
        }
        
    }
}

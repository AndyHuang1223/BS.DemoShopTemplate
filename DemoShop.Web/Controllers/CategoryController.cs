using DemoShop.Web.Services.CmsService;
using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Web.Controllers;

public class CategoryController : Controller
{
    private readonly CategoryViewModelService _categoryViewModelService;

    public CategoryController(CategoryViewModelService categoryViewModelService)
    {
        _categoryViewModelService = categoryViewModelService;
    }

    public async Task<IActionResult> Index()
    {
        var vm = await _categoryViewModelService.GetCategoryViewModelAsync();
        return Json(vm);
    }
}
using DemoShop.Web.Services.CmsService;
using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Web.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryViewModelService _categoryViewModelService;

    public CategoryController(ICategoryViewModelService categoryViewModelService)
    {
        _categoryViewModelService = categoryViewModelService;
    }

    public async Task<IActionResult> Index()
    {
        var vm = await _categoryViewModelService.GetCategoryViewModelAsync();
        return Json(vm);
    }
    
    public async Task<IActionResult> Item(int id)
    {
        var vm = await _categoryViewModelService.GetCategoryByIdAsync(id);
        return Json(vm);
    }
}
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoShop.Web.Models;
using DemoShop.Web.Services.CmsService;

namespace DemoShop.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICmsViewModelService _cmsViewModelService;

    public HomeController(ILogger<HomeController> logger, ICmsViewModelService cmsViewModelService)
    {
        _logger = logger;
        _cmsViewModelService = cmsViewModelService;
    }

    public async Task<IActionResult> Index()
    {
        var vm = await _cmsViewModelService.GetHomepageViewModel();
        return View(vm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
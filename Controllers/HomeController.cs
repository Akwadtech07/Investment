using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using New_folder.Models;

namespace New_folder.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Contact()
    {
        return View();
    }
    public IActionResult Customer()
    {
        return View();
    }
    public IActionResult About()
    {
        return View();
    }
    public IActionResult Testimonia()
    {
        return View();
    }

    public IActionResult Services()
    {
        return View();
    }public IActionResult News()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

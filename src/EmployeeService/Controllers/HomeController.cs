using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmployeeService.Models;

namespace EmployeeService.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _configuration;

    public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public string Message => _configuration["APP_MESSAGE"] ?? "'APP_MESSAGE' is not configured.";

    public IActionResult Index()
    {
        return View(new {
            Message 
        });
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

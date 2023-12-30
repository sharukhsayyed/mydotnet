using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;
using BLL;
using BOL;

namespace Portal.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        CatlogManager cm= new CatlogManager();
        List<Product> list = new List<Product>();
        list= cm.GetAllProducts();
        ViewData["Product"]=list;
        return View();
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

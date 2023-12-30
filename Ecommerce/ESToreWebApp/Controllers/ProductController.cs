using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ESToreWebApp.Models;
using BLL;
using BOL;

namespace Pro.Controllers;
 
public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        CatlogManager cm = new CatlogManager();
        List<Product> list = new List<Product>();
        list=cm. GetAllProducts();
        ViewData["Product"]=list;
        return View();
    }

    
}

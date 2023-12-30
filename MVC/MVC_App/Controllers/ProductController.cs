using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_App.Models;

using BLL;
using BOL;
using DAL;

namespace MVC_App.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    public IActionResult Product()
    {
        ProductManager pm = new ProductManager();
        List<Product> allProducts = pm.showAll();
        ViewData["myViewData"] = allProducts;
        return View();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Insert(int pid, string pname, int pqty, int price)
    {
        Product p = new Product(pid,pname,pqty,price);
        // p.pid = pid;
        // p.pname = pname;
        // p.pqty = pqty;
        // p.price = price;

        DBManager.insertProduct(p);
        return View();

    }
    public IActionResult Delete(int pid){
        Product p=new Product(pid);
        // p.pid=pid;

        DBManager.Delete(p);
        return View(); 
    }

      public IActionResult Update(int pid,int pqty){
        Product p=new Product(pid,pqty);
       

        DBManager.Update(p);
        return View(); 
    }
    
}

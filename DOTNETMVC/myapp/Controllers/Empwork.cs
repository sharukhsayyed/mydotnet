using System.ComponentModel;
using System.Diagnostics;
using BLL;
using BOL;
using Microsoft.AspNetCore.Mvc;
using myapp.Models;

namespace myapp.Controllers;

public class EmpworkController : Controller
{
    private readonly ILogger<EmpworkController> _logger;

    public EmpworkController(ILogger<EmpworkController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Empwork> work = CatalogManager.GetWork();
        ViewData["work"] = work;
        return View();
    }

    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(string date1, string des, int duration, int status)
    {
        bool status1 = CatalogManager.AddEmpWork(date1, des, duration, status);
        if (status1)
        {
            return this.RedirectToAction("Index");
        }
        return View();
    }
    public IActionResult Details(string date1)

    {
        Empwork workdone = CatalogManager.GetWorkByDate(date1);
        ViewBag.work = workdone;
        return View();
    }
    [HttpPost]
    public IActionResult Details()

    {

        return this.RedirectToAction("Index");
    }

    public IActionResult Error()
    {
        return View();
    }
}

using System.Diagnostics;
using BOL;
using Microsoft.AspNetCore.Mvc;
using TimeSheetManagement.Models;
using BLL;
using DAL.Connected;

namespace TimeSheetManagement.Controllers;

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
    [HttpGet]
    public IActionResult GetSheets()
    {
        TimeSheetManager tsm = new TimeSheetManager();
        List<TimeSheet> ts = tsm.GetTimeSheets();
        ViewData["alltimesheets"] = ts;
        return View();
    }
    [HttpGet]
    public IActionResult AddSheet()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AddSheet(int id, string date, string workDescription, int duration, string status)
    {
        TimeSheetManager tsm = new TimeSheetManager();
        tsm.AddSheet(id, date, workDescription, duration, status);
        if (@id == id)
        {
            return this.RedirectToAction("Welcome");
        }
        return View();
    }
    public IActionResult Welcome()
    {
        return View();
    }
    [HttpGet]
    public IActionResult DeleteSheet()
    {
        return View();
    }
    [HttpPost]
    public IActionResult DeleteSheet(int id)
    {
        TimeSheetManager tsm = new TimeSheetManager();
        tsm.DeleteSheet(id);
        if (@id == id)
        {
            return this.RedirectToAction("Deleted");
        }
        return View();
    }
      public IActionResult Deleted()
    {
        return View();
    }
}

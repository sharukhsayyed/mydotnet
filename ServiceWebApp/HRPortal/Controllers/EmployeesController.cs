using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HRPortal.Models;
using BLL;
using DAL;
using BOL;
namespace HRPortal.Controllers;

public class EmployeesController : Controller
{
    private readonly ILogger<EmployeesController> _logger;

    public EmployeesController(ILogger<EmployeesController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(int empno, string empname, string job)
    {
        // Console.WriteLine(empno+" "+empname+" "+job);
        HRDBManager.insertemp(empno, empname, job);
        return View();
    }

    [HttpGet]
    public IActionResult ShowAll()
    {
        List<Employees> emplist= HRDBManager.GetAllEmployees();
        ViewData["Employee"] = emplist;
        // Console.WriteLine(emplist);
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

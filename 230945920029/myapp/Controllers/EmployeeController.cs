using System.Diagnostics;
using BLL;
using BOL;
using DAL;
using Microsoft.AspNetCore.Mvc;
using myapp.Models;

namespace myapp.Controllers;

public class EmployeeController : Controller
{
    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(ILogger<EmployeeController> logger)
    {
        _logger = logger;
    }

    public IActionResult GetAllEmp()
    {
        List<Employee> ls=DBManager.GetAllEmp();
        ViewBag.list=ls;
        return View();

    }

    public IActionResult AddEmp(){
        return View();
    }

    public IActionResult Insert(string fname,string mail,string no){
         Employee e=new Employee{
            
            ename=fname,
            eemail=mail,
            contactNumber=no
          };
     EmployeeService.Insert(e);
     return View();

    }
    [HttpGet]

    public IActionResult  Edit([FromQuery]int empId){
        Console.WriteLine(empId);
        Employee e=EmployeeService.GetEmployeeById(empId);
        ViewBag.obj=e;
        return View();
    }


     [HttpPost]
     public IActionResult Edit(int id,string name,string email,string pnumber){
          Employee e=new Employee{
            eid=id,
            ename=name,
            eemail=email,
            contactNumber=pnumber
          };

          if(EmployeeService.Edit(e)){
            return RedirectToAction("GetAllEmp");
          }

          return View();
     }

      [HttpPost]
      
    //  public IActionResult DeleteById([FromQuery]int empId){
        

    //       if(EmployeeService.DeleteById(empId)){
    //         return RedirectToAction("GetAllEmp");
    //       }

    //       return View();
    //  }

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

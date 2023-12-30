using Microsoft.AspNetCore.Mvc;
using BOL;
using BLL;
using System.Diagnostics;
namespace PlainWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeControllers : ControllerBase{
    private readonly ILogger<EmployeeControllers> _logger;
    public EmployeeControllers(ILogger<EmployeeControllers> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Employees> Get() {
        EmployeesData empdata = new EmployeesData();
        List<Employees> list = empdata.GetAllEmployees();

        return list.ToArray();
    }

    public IEnumerable<Employees> Index() {
        return [];
    }
}








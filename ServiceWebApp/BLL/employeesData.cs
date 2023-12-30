namespace BLL;

using BOL;
using DAL;

public static class EmployeesData{
    public static List<Employees> GetAllEmployees(){
        List<Employees> employeesList = new List<Employees>();

        employeesList = HRDBManager.GetAllEmployees();

        return employeesList;
    }
}


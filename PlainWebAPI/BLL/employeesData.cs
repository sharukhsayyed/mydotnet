namespace BLL;

using BOL;
using DAL;

public class EmployeesData{
    public List<Employees> GetAllEmployees(){
        List<Employees> employeesList = new List<Employees>();

        employeesList = HRDBManager.GetAllEmployees();

        return employeesList;
    }
}


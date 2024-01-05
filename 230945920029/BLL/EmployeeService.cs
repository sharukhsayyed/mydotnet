using BOL;
using DAL;

namespace BLL;



public class EmployeeService{

  public static List<Employee> GetAllEmp(){
    return DBManager.GetAllEmp();
  }

   public static Employee GetEmployeeById(int id){
    return DBManager.GetEmployeeById(id);
  }

    public static bool Edit(Employee e){
        Console.WriteLine("Inside edit service");
    return DBManager.Edit(e);
  }
   public static bool Insert(Employee e){
        Console.WriteLine("Inside edit service");
    return DBManager.Insert(e);
  }

//    public static bool DeleteById(int id){
//     return DBManager.DeleteById(id);
//   }
}
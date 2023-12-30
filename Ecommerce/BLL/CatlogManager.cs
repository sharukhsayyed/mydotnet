namespace BLL;
using BOL;
using DAL.Connected;

public class CatlogManager{

    public List<Product> GetAllProducts(){
      List<Product> list = new List<Product>();
      list=dbManager.GetAllProducts();
      return list;
    }
}

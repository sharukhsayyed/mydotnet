namespace BLL;

using BOL;

using DAL;

public class ProductManager
{
    public List<Product>showAll()
    {
        List<Product>allProducts=new List<Product>();

        allProducts=DBManager.showAllPro();
        return allProducts;
    }

}

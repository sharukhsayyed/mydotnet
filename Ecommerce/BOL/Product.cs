namespace BOL;

public class Product
{
 

  
  
  public int pid{
    get;set;
  }
  public string title{
    get;set;
  }
  public double unitPrice{
    get;set;
  }
  
  public override string ToString(){
    return "Product Id : "+this.pid+" Title : "+this.title+" UnitPrice "+this.unitPrice;
  }
    public Product(){
        this.pid=0;
        this.title=null;
        this.unitPrice=0;
    }
    public Product(int id,string title,double unitPrice){
        this.pid=id;
        this.title=title;
        this.unitPrice=unitPrice;
    }
  
} 

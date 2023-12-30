namespace BOL;

public class Product
{
    public int pid{get;set;}

    public string pname{get;set;}

    public int pqty{get;set;}

    public int price{get;set;}


    // public Product()
    // {
    //     this.pid=0;
    //     this.pname="";
    //     this.pqty=0;
    //     this.price=0;
    // }

    public Product(int pid ,string pname,int pqty,int price)
    {
         this.pid=pid;
        this.pname=pname;
        this.pqty=pqty;
        this.price=price;
    }

    public Product(int pid)
    {
        this.pid=pid;
    }

    public Product(int pid,int pqty)
    {
        this.pid=pid;
        this.pqty=pqty;
    }

}

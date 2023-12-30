namespace BOL;

public class Product{
    public int Id{get; set;}
    public string Name{get; set;}
    public int Rate{get; set;}

    public Product() {
        this.Id = 0;
        this.Name = null;
        this.Rate = 0; 
    }   

    public Product(int id, string name, int rate) {
        this.Id=id;
        this.Name=name;
        this.Rate=rate;
    }

    public override string ToString(){
    return "Product Id: "+this.Id+" Name: "+this.Name+" Rate:"+this.Rate;
  }

}

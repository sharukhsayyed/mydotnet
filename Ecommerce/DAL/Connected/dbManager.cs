namespace DAL.Connected;
using BOL;
using MySql.Data.MySqlClient;


public class dbManager{
    public static string conString="server=192.168.150.10;port=3306;user=dac22;password=welcome;database=dac22";

    public static List<Product> GetAllProducts(){
        List<Product> list = new List<Product>();
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString=conString;
        String query = "Select  * from menucard";
         MySqlCommand command =new  MySqlCommand(query,conn);
        

        try{
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            
            while(reader.Read()){
                int id = int.Parse(reader["ID"].ToString());
                String name = reader["name"].ToString();
                double Rate = double.Parse(reader["Rate"].ToString());

                Product p = new Product(id,name,Rate);
                list.Add(p);
            }
            reader.Close();
           
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }finally{
            conn.Close();
        }
        return list;
    }
}
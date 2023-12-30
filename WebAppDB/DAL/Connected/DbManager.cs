namespace DAL.Connected;
using BOL;
using MySql.Data.MySqlClient;

public class DbManager {
    public static string connection_string="server=192.168.10.150;port=3306;user=dac19;password=welcome;database=dac19";

    public static List<Product> GetAllProducts() {
        List<Product> list = new List<Product>();
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString=connection_string;
        String query = "select  * from menucard";
        MySqlCommand command =new  MySqlCommand(query,conn);

        try {
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            while(reader.Read()){
                int Id = int.Parse(reader["ID"].ToString());
                string Name = reader["NAME"].ToString();
                int Rate = int.Parse(reader["RATE"].ToString());

                Product p1 = new Product(Id,Name,Rate);
                list.Add(p1);
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



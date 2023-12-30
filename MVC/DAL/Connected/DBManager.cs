namespace DAL;
using BOL;


using MySql.Data.MySqlClient;


public static class DBManager
{
    public static string conString = "server=192.168.10.150;port=3306;user=dac45;password=welcome;database=dac45";
    public static List<Product> showAllPro()
    {

        List<Product> pList = new List<Product>();
        MySqlConnection conn = new MySqlConnection();

        conn.ConnectionString = conString;

        string query = "select * from cart";

        try
        {

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = query;

            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                int id1 = int.Parse(rd["pid"].ToString());
                string name1 = rd["pname"].ToString();

                int qty1 = int.Parse(rd["pqty"].ToString());

                int price1 = int.Parse(rd["price"].ToString());

                Product pobj = new Product(id1,name1,qty1,price1);
                // {
                //     pid = id1,
                //     pname = name1,
                //     pqty = qty1,
                //     price = price1
                // };

                pList.Add(pobj);


                Console.WriteLine(id1 + " " + name1 + " " + qty1 + " " + price1);


            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            conn.Close();
        }

        return pList;
    }

        public static void insertProduct(Product p)
        {
            MySqlConnection conn = new MySqlConnection();

            conn.ConnectionString = conString;

            string query = "insert into cart values(@pid,@pname,@pqty,@price)";

            MySqlCommand cmd = new MySqlCommand(query,conn);

            cmd.Parameters.AddWithValue("@pid", p.pid);
            cmd.Parameters.AddWithValue("@pname", p.pname);
            cmd.Parameters.AddWithValue("@pqty", p.pqty);

            cmd.Parameters.AddWithValue("@price", p.price);

            try
            {

                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();

            }

        }

        public static void Delete(Product p)
        {
            MySqlConnection conn=new MySqlConnection();
           conn.ConnectionString=conString;
            string que="delete from cart where pid=@pid";

            MySqlCommand cmd= new MySqlCommand(que,conn);

            cmd.Parameters.AddWithValue("@pid",p.pid);
            try{
                conn.Open();
                cmd.ExecuteNonQuery();
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }finally{
                conn.Close();
            }
        }


        public static void Update(Product p)
        {
            MySqlConnection conn=new MySqlConnection();
            conn.ConnectionString=conString;
            string query="update cart set pqty=@pqty where pid=@pid ";

            MySqlCommand cmd=new MySqlCommand(query,conn);

            cmd.Parameters.AddWithValue("@pid",p.pid);
            cmd.Parameters.AddWithValue("@pqty",p.pqty);

            try{
                conn.Open();
                cmd.ExecuteNonQuery();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally{
                conn.Close();
            }
        }

}
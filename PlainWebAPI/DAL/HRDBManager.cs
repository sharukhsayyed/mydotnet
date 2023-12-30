namespace DAL;

using MySql.Data.MySqlClient;
using BOL;

public class HRDBManager{
    public static string connection = "server=192.168.10.150; port=3306; user=dac19; password=welcome; database=dac19";

    public static List<Employees> GetAllEmployees()
    {
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString=connection;
        string query = "select * from employees";
        List<Employees> empList = new List<Employees>();

        MySqlCommand cmd = new MySqlCommand(query,con);
        try{
            con.Open();
            MySqlDataReader reader= cmd.ExecuteReader();
        while (reader.Read())
            {
                int empid = int.Parse(reader["empno"].ToString());
                string ename = reader["ename"].ToString();
                string job = reader["job"].ToString();
                Employees emp = new Employees(empid, ename, job);
                empList.Add(emp); 
            }
            reader.Close();
            
        }
        catch(Exception e){
                Console.WriteLine(e.Message);
            }finally{
                con.Close();
            }
            return empList;
        }

    public static void insertemp(int empno, string empname, string job){
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString=connection;
        string query = "insert into employees(empno, ename, job) values('" + empno +"', '" + empname +"','"+ job + "')";
        MySqlCommand cmd = new MySqlCommand(query,con);
        

        try{
            con.Open();
            // int empid = int.Parse([empno]);
            cmd.ExecuteNonQuery();            
        }
        catch(Exception e){
                Console.WriteLine(e.Message);
            }
        finally{
                con.Close();
            }
        }

}

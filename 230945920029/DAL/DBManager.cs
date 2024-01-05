namespace DAL;

using System.Security.Cryptography.X509Certificates;
using BOL;
using MySql.Data.MySqlClient;




public class DBManager{

public static string connString="server=192.168.10.150;port=3306;user=dac29;password=welcome;database=dac29";

    public static List<Employee> GetAllEmp(){
        List<Employee> ls=new List<Employee>();
        MySqlConnection conn=new MySqlConnection();

        conn.ConnectionString=connString;

        string query="select * from empy";

        MySqlCommand comm=new MySqlCommand(query,conn);

        try{
            conn.Open();

            MySqlDataReader reader=comm.ExecuteReader();

            while(reader.Read()){
                int id=int.Parse(reader["id"].ToString());
                string name=reader["name"].ToString();
                string email=reader["email"].ToString();
                string phone=reader["phone"].ToString();

                Employee e=new Employee{
                    eid=id,
                    ename=name,
                    eemail=email,
                    contactNumber=phone
                };
                ls.Add(e);
            }
            reader.Close();
        }
        catch(Exception e){
            Console.WriteLine(e.Message);

        }finally{
            conn.Close();
        }

        return ls;



    }

    public static Employee GetEmployeeById(int id){
        Employee obj=null;
         MySqlConnection conn=new MySqlConnection();

        conn.ConnectionString=connString;

        string query="select * from empy where id='"+id+"'";

        MySqlCommand comm=new MySqlCommand(query,conn);

        try{
            conn.Open();

            MySqlDataReader reader=comm.ExecuteReader();

            while(reader.Read()){
                int iid=int.Parse(reader["id"].ToString());
                string name=reader["name"].ToString();
                string email=reader["email"].ToString();
                string phone=reader["phone"].ToString();

                 obj=new Employee{
                    eid=iid,
                    ename=name,
                    eemail=email,
                    contactNumber=phone
                };
            
            }
             reader.Close();
             return obj;
        }
        catch(Exception e){
            Console.WriteLine(e.Message);

        }finally{
            conn.Close();
        }

        return obj;

        
    }

    public static bool Edit(Employee e){
         MySqlConnection conn=new MySqlConnection();
          Console.WriteLine("Inside edit DB");

        conn.ConnectionString=connString;

        string query="update empy set name='"+e.ename+"',email='"+e.eemail+"',phone='"+e.contactNumber+"' where id='"+e.eid+"'";

        MySqlCommand comm=new MySqlCommand(query,conn);


           try{
            conn.Open();
            comm.ExecuteNonQuery();
            return true;


            
                
            
             
    
        }
        catch(Exception s){
            Console.WriteLine(s.Message);
            return false;

        }finally{
            conn.Close();
        }

        return true;

    }

    public static bool Insert(Employee e){
         MySqlConnection conn=new MySqlConnection();
          Console.WriteLine("Inside edit DB");

        conn.ConnectionString=connString;

        string query="insert into empy(name,email,phone) values('"+e.ename+"','"+e.eemail+"','"+e.contactNumber+"')";

        MySqlCommand comm=new MySqlCommand(query,conn);

        try{
            conn.Open();
            comm.ExecuteNonQuery();
            return true;
        }
        catch(Exception s){
            Console.WriteLine(s.Message);
            return false;
        }
        finally{
            conn.Close();
        }
     
    }

    //    public static bool DeleteById(int id){
    //      MySqlConnection conn=new MySqlConnection();
    //       Console.WriteLine("Inside edit DB");

    //     conn.ConnectionString=connString;

    //     string query="delete from empy where id='"+id+"'";

    //     MySqlCommand comm=new MySqlCommand(query,conn);

    //     try{
    //         conn.Open();
    //         comm.ExecuteNonQuery();
    //         return true;
    //     }
    //     catch(Exception s){
    //         Console.WriteLine(s.Message);
    //         return false;
    //     }
    //     finally{
    //         conn.Close();
    //     }
     
    // }
}
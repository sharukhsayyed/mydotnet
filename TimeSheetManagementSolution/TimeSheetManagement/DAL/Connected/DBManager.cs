namespace DAL.Connected;
using BOL;
using BLL;
using MySql.Data.MySqlClient;
public class DBManager
{
    public static string constring = @"server=192.168.10.150;port=3306;user=dac31;password=welcome;database=dac31";
    public static List<TimeSheet> GetAll()
    {
        List<TimeSheet> ls = new List<TimeSheet>();
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString = constring;
        string query = "select * from timesheet";
        MySqlCommand command = new MySqlCommand(query, conn);
        try
        {
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = int.Parse(reader["id"].ToString());
                string date = reader["date"].ToString();
                string workDescription = reader["workDescription"].ToString();
                int duration = int.Parse(reader["duration"].ToString());
                string status = reader["status"].ToString();
                ls.Add(new TimeSheet(id, date, workDescription, duration, status));
            }
            reader.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            conn.Close();
        }
        return ls;
    }

    public static void Insert(int id, string date, string workDescription, int duration, string status)
    {
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString = constring;
        string query = "insert into timesheet values(@id, @date, @workDescription, @duration, @status)";
        MySqlCommand command = new MySqlCommand(query, conn);
        try
        {
            conn.Open();
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.AddWithValue("@workDescription", workDescription);
            command.Parameters.AddWithValue("@duration", duration);
            command.Parameters.AddWithValue("@status", status);
            command.ExecuteNonQuery();
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

    internal static void delete(int id)
    {
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString = constring;
        string query = "delete from timesheet where @id = id";
        MySqlCommand command = new MySqlCommand(query, conn);
        try
        {
            conn.Open();
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
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
}
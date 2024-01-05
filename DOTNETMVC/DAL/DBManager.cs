using BOL;
using MySql.Data.MySqlClient;

namespace DAL;

public static class DBManger
{
    public static string cont = @"server=192.168.10.150; port=3306; user=dac18; password=welcome; database=dac18;";

    public static bool AddRecord(string date1, string des, int duration, int status)
    {
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = cont;
        string query = "insert into empwork values('" + date1 + "','" + des + "','" + duration + "','" + status + "')";
        MySqlCommand cmd = new MySqlCommand(query, connection);
        try
        {
            connection.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            connection.Close();
        }
        return false;
    }

    public static Empwork GetWork(string date1)
    {
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = cont;
        string query = "select * from empwork where date1='" + date1 + "'";
        MySqlCommand cmd = new MySqlCommand(query, connection);
        try
        {
            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string day = reader["date1"].ToString();
                string description = reader["work"].ToString();
                int duration = int.Parse(reader["duration"].ToString());
                int status = int.Parse(reader["status"].ToString());
                return new Empwork { Date1 = day, Description = description, Duration = duration, Status = status };
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            connection.Close();
        }
        return null;
    }

    public static List<Empwork> Timesheet()
    {
        List<Empwork> empls = new List<Empwork>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = cont;
        string query = "select * from empwork";
        MySqlCommand cmd = new MySqlCommand(query, connection);
        try
        {
            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string day = reader["date1"].ToString();
                string description = reader["work"].ToString();
                int duration = int.Parse(reader["duration"].ToString());
                int status = int.Parse(reader["status"].ToString());
                empls.Add(new Empwork { Date1 = day, Description = description, Duration = duration, Status = status });
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            connection.Close();
        }
        return empls;
    }
}
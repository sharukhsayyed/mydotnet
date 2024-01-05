using BOL;
using DAL;

namespace BLL;

public static class CatalogManager
{
    public static bool AddEmpWork(string date1, string des, int duration, int status)
    {
        return DBManger.AddRecord(date1, des, duration, status);
    }

    public static List<Empwork> GetWork()
    {
        return DBManger.Timesheet();
    }

    public static Empwork GetWorkByDate(string date1)
    {
        return DBManger.GetWork(date1);
    }
}
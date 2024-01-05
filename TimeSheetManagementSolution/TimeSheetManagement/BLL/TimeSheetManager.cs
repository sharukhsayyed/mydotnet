namespace BLL;

using System;
using BOL;
using DAL.Connected;
public class TimeSheetManager
{
    public List<TimeSheet> GetTimeSheets()
    {
        List<TimeSheet> tlist = DBManager.GetAll();
        return tlist;
    }
    public void AddSheet(int id, string date, string workDescription, int duration, string status){
        DBManager.Insert(id, date, workDescription, duration, status);
    }

    public void DeleteSheet(int id)
    {
        DBManager.delete(id);
    }
}
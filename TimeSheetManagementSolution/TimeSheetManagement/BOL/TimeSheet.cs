namespace BOL;
public class TimeSheet
{
    public int id { get; set; }
    public string date { get; set; }
    public string workDescription { get; set; }
    public int duration { get; set; }
    public string status { get; set; }
    public TimeSheet(int id, string date, string workDescription, int duration, string status)
    {
        this.id = id;
        this.date = date;
        this.workDescription = workDescription;
        this.duration = duration;
        this.status = status;
    }
}
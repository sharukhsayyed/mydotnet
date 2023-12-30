namespace BOL;

public class Employees{
    public int Empno{get;set;}
    public string Ename{get;set;}
    public string Job{get;set;}

    public Employees():this(01,"Employee", "Employee"){}
    public Employees(int empno, string ename, string job)
    {
        this.Empno=empno;
        this.Ename=ename;
        this.Job=job;
    }

    public override string ToString(){
        return "EmployeeNo:"+Empno+" EmployeeName:"+Ename+" Job:"+Job;
    }
}
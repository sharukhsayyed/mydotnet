namespace BOL;

public class User{

    public string uname{get;set;}
    public string password{get;set;}

    public string emailId{get;set;}


    public User(string uname,string password,string emailId)
    {
        this.uname=uname;

        this.password=password;

        this.emailId=emailId;
    }
     public User(string uname,string password)
    {
        this.uname=uname;

        this.password=password;

        
    }


    public User()
    {
         this.uname="Default";

        this.password="password";

        this.emailId="emailId";
    }



}
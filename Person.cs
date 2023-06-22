using System.Text.Json.Serialization;

namespace Project;

public class Person
{
    [JsonIgnore]
    private string? firstname;
    [JsonIgnore]
    private string? lastname;
    public string? Firstname 
    { 
        get
        {
            if(firstname is not null)
                return Format.Pascal(firstname);
            else
                return null;
        } 
        init
        {
            if(value is not null)
                firstname = Format.Pascal(value);
        } 
    }
    public string? Lastname 
    { 
        get
        {
            if(lastname is not null)
                return lastname.ToUpper();
            else
                return null;
        } 
        init
        {
            if(value is not null)
                lastname = value.ToUpper();
        }     
    }
    [JsonIgnore]
    public DateTime Birthday { get; init; }
    public Job Job { get; init; } 
    public Service Service { get; init; }
    [JsonIgnore]
    public string? Fullname => $"{Firstname} {Lastname}";
    [JsonIgnore]
    public string? Initials => $"{Firstname![0]}{Lastname![0]}{Lastname[1]}".ToUpper();
    [JsonIgnore]
    private int age => (int)(DateTime.Now.Subtract(Birthday).Days / (365.25));

    public Person(string? firstname, string? lastname, DateTime birthday, Job job, Service service)
    {
        Firstname = firstname;
        Lastname = lastname;
        Birthday = birthday;
        Job = job;
        Service = service;
    }

    public void Display()
    {
        Console.WriteLine(@$"Name: {Fullname} alias {Initials}
Age: {age} yo
Job: {Job} at {Service} service");
    }
}

public enum Job
{
    Operator,
    Technician,
    Secretary,
    Manager,
    Director
}

public enum Service
{
    Home,
    SMD,
    Integration,
    Finishing,
    Wave,  
    AfterSales,
    Purchasing,
    QualitySecurity,
    HumanResources,
    Office
}
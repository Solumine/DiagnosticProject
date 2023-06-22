using System.Text.Json.Serialization;

namespace Project;

public class Card
{
      [JsonIgnore]
    private string? name;
    public string? Name 
    { 
        get
        {
            if(name is not null)
                return Format.Pascal(name);
            else
                return null;
        } 
        init
        {   
            if(value is not null)
                name = Format.Pascal(value);
        } 
    }
    public string? SerialNumber { get; set; }
    public Card(string name, string serialNumber = "Unknow")
    {
        Name = name;
        SerialNumber = serialNumber;
    }

    public void Display()
    {
        Console.WriteLine($"{Name} ({SerialNumber})");
    }

    public void ModifySerialNumber(string newSerialNumber)
    {
        SerialNumber = newSerialNumber;
    }
}

using System.Text.Json.Serialization;

namespace Project;

public class Client
{
    [JsonIgnore]
    private string? name;
    public string? Name 
    { 
        get
        {
            if(name is not null)
                return name.ToUpper();
            else
                return null;
        } 
        init
        {   
            if(value is not null)
                name = Format.Pascal(value);
        } 
    }
    [JsonIgnore]
    public List<Card>? Cards { get; set; }

    public Client(string? name, List<Card>? cards = null)
    {
        Name = name;
        Cards = cards;
    }

    public void Display()
    {
        Console.WriteLine($"Client: {Name}");

        if(Cards is not null )
        {
            foreach(Card card in Cards.OrderBy(x => x.Name))
            {
                Console.Write("- ");
                card.Display();
            }                
        }
        else
            System.Console.WriteLine("Cards: Unknow");  
        Console.WriteLine();
    }

    public void AddCard(Card card)
    {
        if(Cards is null)
            Cards = new List<Card>();

        Cards.Add(card);
    }
    public void AddCard(string name, string? serialNumber = "Unknow")
    {
        if(Cards is null)
            Cards = new List<Card>();
            
        Cards.Add(new Card(name, serialNumber!));
    }
}
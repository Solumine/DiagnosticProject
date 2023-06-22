using System;

namespace Project;

public class Diagnostic
{
    public Client? Client { get; init; }
    public Card? Card { get; init; }
    public Person? Repairer { get; init; }
    public DateTime Date { get; init; }
    public string? Description { get; set; }
    public int Ok { get; init; }
    public int Err { get; init; }
    public double Score => Math.Round((double)(Ok * 100) / (Ok + Err), 2); 
    public Diagnostic(Client? client, Card? card, Person? repairer, DateTime date, int ok, int err)
    {
        Client = client;
        Card = card;
        Repairer = repairer;
        Date = date;
        Ok = ok;
        Err = err;
    }

    public void Display()
    {
        Console.WriteLine(@$"Client: {Client!.Name}
Card: {Card!.Name} ({Card!.SerialNumber})
Repairer: {Repairer!.Initials} ({Repairer!.Fullname})
Date: {Date.ToShortDateString()}");

if(Description is not null)
    Console.WriteLine($"Description: {Description}");

        Console.WriteLine(@$"Ok: {Ok}
Err: {Err}
Score: {Score} %
");
    }
}

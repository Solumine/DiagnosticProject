using System;

namespace Project;

public delegate string ValidationString(string input);

public static class Validation
{
    // Demande à l'utilisateur une chaîne de caractères avec validation optionnelle
    public static string AskTheUser(string message, ValidationString? validationString = null)
    {
        Console.Write($"{message} ");
        string? answer = Console.ReadLine();

        if (string.IsNullOrEmpty(answer))
            throw new ArgumentException("File path cannot be null or empty.");

        if (validationString != null)
        {
            string error = validationString(answer);
            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine($"Erreur: {error}");
                return AskTheUser(message, validationString);
            }
        }

        return answer;
    }

    // Vérifie la validité d'un trigramme
    public static string CheckValidationTrigram(string trigram)
    {
        if (string.IsNullOrWhiteSpace(trigram))
            return string.Empty;

        if (trigram.Length != 3 || trigram.Any(char.IsDigit))
            return "Le trigramme doit être composé de 3 lettres : la 1ère lettre du prénom et les 2 premières lettres du nom";

        return string.Empty;
    }

    // Vérifie la validité d'un nom
    public static string CheckValidationName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return "Le nom ne peut pas être vide";

        if (name.All(char.IsDigit))
            return "Le nom ne peut pas contenir que des chiffres";

        return string.Empty;
    }

    // Vérifie la validité d'un nombre
    public static string CheckValidationNumber(string number)
    {
        if (string.IsNullOrWhiteSpace(number))
            return "Le nombre ne peut pas être vide";

        if (!number.All(char.IsDigit))
            return "La réponse doit être un chiffre ou un nombre";

        return string.Empty;
    }

    // Vérifie la validité d'une date
    public static string CheckValidationDate(string date)
    {
        if (string.IsNullOrWhiteSpace(date))
            return string.Empty;

        if (date.Length != 10)
            return "Le format doit être comme suit : \"JJ/MM/AAAA\"";

        return string.Empty;
    }
}
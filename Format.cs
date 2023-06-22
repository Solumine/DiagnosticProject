using System;

namespace Project;

public static class Format
{
    public static string Pascal(string word)
    {
        string minuscule = word.ToLower();
        string majuscule = word.ToUpper();

        return $"{majuscule[0]}{minuscule[1..]}";
    }
}

using static System.Console;

namespace Project;

public static class Other
{
    static void ColorWL(string message, ConsoleColor color = ConsoleColor.Gray)
    {
        ForegroundColor = color;
        WriteLine(message);
        ResetColor();
    }

    static void ColorW(string message, ConsoleColor color = ConsoleColor.Gray)
    {
        ForegroundColor = color;
        Write(message);
        ResetColor();
    }
}

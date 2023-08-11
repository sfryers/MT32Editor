namespace MT32Edit;

/// <summary>
/// Filter and send debug/status messages to console
/// </summary>
internal static class ConsoleMessage
{
    // MT32Edit: ConsoleMessage class (static) S.Fryers Apr 2023 Filter and send debug/status
    // messages to console
    private static bool consoleEnabled = false;

    public static void Enable()
    {
        consoleEnabled = true;
    }

    public static void Disable()
    {
        consoleEnabled = false;
    }

    public static bool Enabled()
    {
        return consoleEnabled;
    }

    public static void SendString(string message, ConsoleColor color = ConsoleColor.Gray)
    {
        if (consoleEnabled)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    public static void SendLine(string message, ConsoleColor color = ConsoleColor.Gray)
    {
        if (consoleEnabled)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
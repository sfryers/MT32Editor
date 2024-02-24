namespace MT32Edit;

/// <summary>
/// Filter and send debug/status messages to console
/// </summary>
internal static class ConsoleMessage
{
    // MT32Edit: ConsoleMessage class (static)
    // S.Fryers Jan 2024
    private static bool verboseEnabled = false; //Determines whether messages are sent to console.
    private static bool consoleVisible = false; //Determines whether entire console is visible or not.

    public static void EnableVerbose()
    {
        verboseEnabled = true;
    }

    public static void DisableVerbose()
    {
        verboseEnabled = false;
    }

    public static bool Verbose()
    {
        return verboseEnabled;
    }

    public static void SetVerbose(bool state)
    {
        verboseEnabled = state;
    }

    public static void Show()
    {
        consoleVisible = true;
    }

    public static void Hide()
    {
        consoleVisible = false;
    }

    public static bool Visible()
    {
        return consoleVisible;
    }

    public static void SetVisibility(bool state)
    {
        consoleVisible = state;
    }

    public static void SendString(string message, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.ForegroundColor = color;
        Console.Write(message);
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public static void SendVerboseString(string message, ConsoleColor color = ConsoleColor.Gray)
    {
        if (verboseEnabled)
        {
            SendString(message, color);
        }
    }

    public static void SendLine(string message, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public static void SendVerboseLine(string message, ConsoleColor color = ConsoleColor.Gray)
    {
        if (verboseEnabled)
        {
            SendLine(message, color);
        }
    }
}
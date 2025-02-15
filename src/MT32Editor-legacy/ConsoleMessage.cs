using System;
#if NET5_0_OR_GREATER
namespace MT32Edit;
#else
namespace MT32Edit_legacy;
#endif

/// <summary>
/// Filter and send debug/status messages to console
/// </summary>
internal static class ConsoleMessage
{
    // MT32Edit: ConsoleMessage class (static)
    // S.Fryers Mar 2024
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

    /// <summary>
    /// Sends text in the specified colour to the console, including new line character.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="color"></param>
    public static void SendString(string message, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.ForegroundColor = color;
        Console.Write(message);
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    /// <summary>
    /// If verboseEnabled is true, sends text in the specified colour to the console, including new line character.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="color"></param>
    public static void SendVerboseString(string message, ConsoleColor color = ConsoleColor.Gray)
    {
        if (verboseEnabled)
        {
            SendString(message, color);
        }
    }
    /// <summary>
    /// Sends text in the specified colour to the console.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="color"></param>
    public static void SendLine(string message, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    /// <summary>
    /// If verboseEnabled is true, sends text in the specified colour to the console.
    /// </summary>
    public static void SendVerboseLine(string message, ConsoleColor color = ConsoleColor.Gray)
    {
        if (verboseEnabled)
        {
            SendLine(message, color);
        }
    }
}
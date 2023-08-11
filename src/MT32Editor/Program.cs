namespace MT32Edit;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main(string[] args)
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        try
        {
            Application.Run(new FormMainMenu(args));
        }
        catch
        {
            //Application failed to open, probably closed prematurely by failure to open MIDI device;
        }
    }
}
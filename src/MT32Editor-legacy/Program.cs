using System.Windows.Forms;
using System;
namespace MT32Edit_legacy;

/// <summary>
/// Main entry point for the MT-32 Editor application.
/// </summary>
internal static class Program
{
    [STAThread]
    private static void Main(string[] args)
    {

#if NET6_0_OR_GREATER
        ApplicationConfiguration.Initialize();
#else
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
#endif
        try
        {
            Application.Run(new FormMainMenu(args));
            Environment.Exit(0);
        }
        catch (Exception)
        {
            //Application failed to open, probably closed prematurely by failure to open MIDI device;
        }
    }
}
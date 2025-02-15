using System.Windows.Forms;
using System;
#if NET5_0_OR_GREATER
namespace MT32Edit;
#else
namespace MT32Edit_legacy;
#endif

/// <summary>
/// Main entry point for the MT-32 Editor application.
/// </summary>
internal static class Program
{
    [STAThread]
    private static void Main(string[] args)
    {

#if NET5_0_OR_GREATER
        ApplicationConfiguration.Initialize();
#else
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
#endif

        try
        {
            Application.Run(new FormMainMenu(args));
#if NET5_0_OR_GREATER
#else
            Environment.Exit(0);
#endif
        }
        catch (Exception)
        {
            //Application failed to open, probably closed prematurely by failure to open MIDI device;
        }
    }
}
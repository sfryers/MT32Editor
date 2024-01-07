using System.Reflection;

namespace MT32Edit;

/// <summary>
/// Saves and load system parameters from .ini file
/// </summary>
internal static class ConfigFile
{
    // MT32Edit: ConfigFile class (static)
    // S.Fryers Jan 2024

    private static readonly string applicationPath = Path.GetDirectoryName(Application.ExecutablePath);
    private static readonly string iniFileLocation = Path.Combine(applicationPath, "MT32Edit.ini");

    public static string[] Load()
    {
        string[] midiDevices = { "", "" };
        if (!File.Exists(iniFileLocation))
        {
            //return blank device names if no config file found
            Console.WriteLine("ini file not found- using default MIDI devices.");
            return midiDevices; 
        }

        StreamReader fs = new StreamReader(iniFileLocation);
        Console.WriteLine($"Loading MIDI device settings from {iniFileLocation}");
        while (!fs.EndOfStream)
        {
            string? fileLine = fs.ReadLine();
            if (fileLine == null)
            {
                continue;
            }

            fileLine = ParseTools.RemoveLeadingSpaces(fileLine);
            if (ParseTools.LeftMost(fileLine, 1) == "#")
            {
                continue;
            }
            else if (ParseTools.LeftMost(fileLine, 7) == "Midi In")
            {
                fileLine = ParseTools.RightOfChar(fileLine, '[');
                fileLine = ParseTools.LeftMost(fileLine, fileLine.Length - 1);
                midiDevices[0] = fileLine;
            }
            else if (ParseTools.LeftMost(fileLine, 8) == "Midi Out")
            {
                fileLine = ParseTools.RightOfChar(fileLine, '[');
                fileLine = ParseTools.LeftMost(fileLine, fileLine.Length - 1);
                midiDevices[1] = fileLine;
            }
        }
        fs.Close();
        return midiDevices;
    }

    public static void Save()
    {
        try
        {
            //create new config file if it doesn't already exist
            if (!File.Exists(iniFileLocation))
            { 
                File.Create(iniFileLocation).Dispose(); 
            }
            ConsoleMessage.SendLine($"Saving MIDI device settings to {iniFileLocation}");
            StreamWriter fs = new StreamWriter(iniFileLocation, false);
            fs.WriteLine("##### MT-32 Timbre Editor configuration settings #####");
            fs.WriteLine("Midi In = [" + Midi.GetInputDeviceName(Midi.InDeviceIndex) + "]");
            fs.WriteLine("Midi Out = [" + Midi.GetOutputDeviceName(Midi.OutDeviceIndex) + "]");
            fs.Close();
        }
        catch
        {
            MessageBox.Show("Couldn't create MT32Edit.ini: Check that you have read/write access to the folder that MT32Edit.exe is running from. MIDI device settings have not been saved.", "MT-32 Editor");
        }
    }
}
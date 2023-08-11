namespace MT32Edit;

internal static class ConfigFile
{
    //
    // MT32Edit: ConfigFile class (static)
    // S.Fryers Mar 2023
    // Save and load system parameters from .ini file
    //
    public static readonly string fileName = "MT32Edit.ini";

    public static string[] Load()
    {
        string[] midiDevices = { "", "" };
        if (!File.Exists(fileName))
        {
            return midiDevices; //return blank device names if no config file found
        }

        StreamReader fs = new StreamReader(fileName);
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
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Dispose(); //create new config file if it doesn't already exist
            }

            StreamWriter fs = new StreamWriter(fileName, false);
            fs.WriteLine("##### MT-32 Timbre Editor configuration settings #####");
            fs.WriteLine("Midi In = [" + Midi.GetInputDeviceName(Midi.InDeviceIndex) + "]");
            fs.WriteLine("Midi Out = [" + Midi.GetOutputDeviceName(Midi.OutDeviceIndex) + "]");
            fs.Close();
        }
        catch
        {
            MessageBox.Show("Couldn't create MT32Edit.ini: Check that you have read/write access to the folder that MT32Edit.exe is running from. Application settings have not been saved.", "MT-32 Editor");
        }
    }
}
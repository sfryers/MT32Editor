namespace MT32Edit;

/// <summary>
/// Saves and load system parameters from .ini file
/// </summary>
internal static class ConfigFile
{
    // MT32Edit: ConfigFile class (static)
    // S.Fryers Feb 2024

    private const string MIDI_IN = "Midi In";
    private const string MIDI_OUT = "Midi Out";
    private const string SHOW_CONSOLE = "Show Console";
    private const string VERBOSE_MESSAGES = "Verbose messages";
    private const string HARDWARE_CONNECTED = "Hardware MT-32 connected";
    private const string ALLOW_RESET = "Allow MT-32 reset";
    private const string SEND_MESSAGES = "Send messages to MT-32";
    private const string IGNORE_SYSTEM_ON_LOAD = "Ignore system area on SysEx load";
    private const string EXCLUDE_SYSTEM_ON_SAVE = "Exclude system area on SysEx save";
    private const string AUTOSAVE = "Autosave every 5 mins";

    private static readonly string iniFileName = "MT32Edit.ini";
    private static readonly string iniFileLocation = Path.Combine($"{FileTools.applicationPath}", iniFileName);

    public static string[] Load()
    {
        string[] midiDeviceNames = { "", "" };
        if (!File.Exists(iniFileLocation))
        {
            //return blank device names if no config file found
            ConsoleMessage.SendLine("ini file not found- using default MIDI devices.");
            return midiDeviceNames; 
        }

        StreamReader fs = new StreamReader(iniFileLocation);
        ConsoleMessage.SendLine($"Loading settings from {iniFileLocation}");
        while (!fs.EndOfStream)
        {
            string? fileLine = fs.ReadLine();
            if (fileLine is null)
            {
                continue;
            }

            fileLine = ParseTools.RemoveLeadingSpaces(fileLine);
            if (ParseTools.LeftMost(fileLine, 1) == "#")
            {
                continue;
            }

            else if (ParseTools.LeftMost(fileLine, MIDI_IN.Length).ToLower() == MIDI_IN.ToLower())
            {
                midiDeviceNames[0] = GetMidiDeviceName(fileLine);
            }

            else if (ParseTools.LeftMost(fileLine, MIDI_OUT.Length).ToLower() == MIDI_OUT.ToLower())
            {
                midiDeviceNames[1] = GetMidiDeviceName(fileLine);
            }

            else if (ParseTools.LeftMost(fileLine, SHOW_CONSOLE.Length).ToLower() == SHOW_CONSOLE.ToLower())
            {
                CheckConsoleSetting(fileLine);
            }

            else if (ParseTools.LeftMost(fileLine, VERBOSE_MESSAGES.Length).ToLower() == VERBOSE_MESSAGES.ToLower())
            {
                CheckVerboseMessagesSetting(fileLine);
            }

            else if (ParseTools.LeftMost(fileLine, HARDWARE_CONNECTED.Length).ToLower() == HARDWARE_CONNECTED.ToLower())
            {
                CheckHardwareConnectedSetting(fileLine);
            }

            else if (ParseTools.LeftMost(fileLine, ALLOW_RESET.Length).ToLower() == ALLOW_RESET.ToLower())
            {
                CheckAllowResetSetting(fileLine);
            }

            else if (ParseTools.LeftMost(fileLine, SEND_MESSAGES.Length).ToLower() == SEND_MESSAGES.ToLower())
            {
                CheckSendMessagesSetting(fileLine);
            }

            else if (ParseTools.LeftMost(fileLine, IGNORE_SYSTEM_ON_LOAD.Length).ToLower() == IGNORE_SYSTEM_ON_LOAD.ToLower())
            {
                CheckIgnoreOnLoadSetting(fileLine);
            }

            else if (ParseTools.LeftMost(fileLine, EXCLUDE_SYSTEM_ON_SAVE.Length).ToLower() == EXCLUDE_SYSTEM_ON_SAVE.ToLower())
            {
                CheckExcludeOnSaveSetting(fileLine);
            }

            else if (ParseTools.LeftMost(fileLine, AUTOSAVE.Length).ToLower() == AUTOSAVE.ToLower())
            {
                CheckAutoSaveSetting(fileLine);
            }
        }

        fs.Close();
        return midiDeviceNames;

        string GetMidiDeviceName(string inputString)
        {
            string deviceName = inputString;
            deviceName = ParseTools.RightOfChar(deviceName, '[');
            deviceName = ParseTools.LeftMost(deviceName, deviceName.Length - 1);
            return deviceName;
        }

        void CheckIgnoreOnLoadSetting(string fileLine)
        {
            bool? status = ParseTools.StringToBool(fileLine);
            if (status.HasValue)
            {
                LoadSysExFile.ignoreSystemArea = (bool)status;
            }
        }

        void CheckExcludeOnSaveSetting(string fileLine)
        {
            bool? status = ParseTools.StringToBool(fileLine);
            if (status.HasValue)
            {
                SaveSysExFile.excludeSystemArea = (bool)status;
            }
        }

        void CheckConsoleSetting(string fileLine)
        {
            bool? status = ParseTools.StringToBool(fileLine);
            if (status.HasValue)
            {
                ConsoleMessage.SetVisibility((bool)status);
            }
        }

        void CheckVerboseMessagesSetting(string fileLine)
        {
            bool? status = ParseTools.StringToBool(fileLine);
            if (status.HasValue)
            {
                ConsoleMessage.SetVerbose((bool)status);
            }
        }

        void CheckHardwareConnectedSetting(string fileLine)
        {
            bool? status = ParseTools.StringToBool(fileLine);
            if (status.HasValue)
            {
                Midi.hardwareMT32Connected = (bool)status;
            }
        }

        void CheckAllowResetSetting(string fileLine)
        {
            bool? status = ParseTools.StringToBool(fileLine);
            if (status.HasValue)
            {
                MT32SysEx.allowReset = (bool)status;
            }
        }

        void CheckSendMessagesSetting(string fileLine)
        {
            bool? status = ParseTools.StringToBool(fileLine);
            if (status.HasValue)
            {
                MT32SysEx.sendTextToMT32 = (bool)status;
            }
        }


        void CheckAutoSaveSetting(string fileLine)
        {
            bool? status = ParseTools.StringToBool(fileLine);
            if (status.HasValue)
            {
                SaveSysExFile.autoSave = (bool)status;
            }
        }
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
            ConsoleMessage.SendVerboseLine($"Saving settings to {iniFileLocation}");
            StreamWriter fs = new StreamWriter(iniFileLocation, false);
            fs.WriteLine("##### MT-32 Editor configuration settings #####");
            fs.WriteLine($"{MIDI_IN} = [{Midi.GetInputDeviceName(Midi.InDeviceIndex)}]");
            fs.WriteLine($"{MIDI_OUT} = [{Midi.GetOutputDeviceName(Midi.OutDeviceIndex)}]");
            fs.WriteLine($"{SHOW_CONSOLE} = {ConsoleMessage.Visible()}");
            fs.WriteLine($"{VERBOSE_MESSAGES} = {ConsoleMessage.Verbose()}");
            fs.WriteLine($"{HARDWARE_CONNECTED} = {Midi.hardwareMT32Connected}");
            fs.WriteLine($"{ALLOW_RESET} = {MT32SysEx.allowReset}");
            fs.WriteLine($"{SEND_MESSAGES} = {MT32SysEx.sendTextToMT32}");
            fs.WriteLine($"{IGNORE_SYSTEM_ON_LOAD} = {LoadSysExFile.ignoreSystemArea}");
            fs.WriteLine($"{EXCLUDE_SYSTEM_ON_SAVE} = {SaveSysExFile.excludeSystemArea}");
            fs.WriteLine($"{AUTOSAVE} = {SaveSysExFile.autoSave}");
            fs.Close();
        }
        catch
        {
            MessageBox.Show($"Unable to create {iniFileName}.{Environment.NewLine}{Environment.NewLine}Check that you have read/write access to the folder that the application is running from ({FileTools.applicationPath}){Environment.NewLine}{Environment.NewLine}MIDI device settings have not been saved.", "MT-32 Editor");
        }
    }
}
namespace MT32Edit;

/// <summary>
/// Saves and load system parameters from .ini file
/// </summary>
internal static class ConfigFile
{
    // MT32Edit: ConfigFile class (static)
    // S.Fryers Apr 2024

    private const string COMMENT_CHARACTER = "#";
    private const string TEXT_MIDI_IN = "Midi In";
    private const string TEXT_MIDI_OUT = "Midi Out";
    private const string TEXT_UNIT_NO = "Unit No. (should normally be set to 17)";
    private const string TEXT_AUTOSAVE = "Autosave every 5 mins";
    private const string TEXT_DARK_MODE = "Dark Mode";
    private const string TEXT_SHOW_CONSOLE = "Show Console";
    private const string TEXT_VERBOSE_MESSAGES = "Verbose messages";
    private const string TEXT_HARDWARE_CONNECTED = "Hardware MT-32 connected";
    private const string TEXT_ALLOW_RESET = "Allow MT-32 reset";
    private const string TEXT_SEND_MESSAGES = "Send messages to MT-32";
    private const string TEXT_IGNORE_SYSTEM_ON_LOAD = "Ignore system area on SysEx load";
    private const string TEXT_EXCLUDE_SYSTEM_ON_SAVE = "Exclude system area on SysEx save";
    private const string TEXT_SEND_SYSEX_DATA_TO_CONSOLE = "Show SysEx data in console";

    private static readonly string iniFileName = "MT32Edit.ini";
    private static readonly string iniFileLocation = Path.Combine($"{FileTools.applicationPath}", iniFileName);

    /// <summary>
    /// Opens and parses MT32Edit.ini to determine saved user settings from previous session.
    /// </summary>
    /// <returns>Array of two strings containing names of MIDI In and MIDI Out devices.</returns>
    public static string[] Load()
    {
        string[] midiDeviceNames = { "", "" };
        string[] parameterNames = {
                                    TEXT_MIDI_IN, TEXT_MIDI_OUT, TEXT_UNIT_NO, TEXT_AUTOSAVE, TEXT_DARK_MODE,
                                    TEXT_SHOW_CONSOLE, TEXT_VERBOSE_MESSAGES, TEXT_HARDWARE_CONNECTED, TEXT_ALLOW_RESET,
                                    TEXT_SEND_MESSAGES, TEXT_IGNORE_SYSTEM_ON_LOAD, TEXT_EXCLUDE_SYSTEM_ON_SAVE,
                                    TEXT_SEND_SYSEX_DATA_TO_CONSOLE
                                  };

        if (!File.Exists(iniFileLocation))
        {
            //return blank device names if no config file found
            ConsoleMessage.SendLine("ini file not found- using default MIDI devices.");
            return midiDeviceNames; 
        }

        StreamReader fs = new StreamReader(iniFileLocation);
        ConsoleMessage.SendVerboseLine($"Loading settings from {iniFileLocation}");
        while (!fs.EndOfStream)
        {
            //parse config file one line at a time until end of file is reached
            string? fileLine = fs.ReadLine();
            if (fileLine is null || fileLine.Length < 10 || fileLine.StartsWith(COMMENT_CHARACTER))
            {
                continue;
            }
            fileLine = ParseTools.RemoveLeadingSpaces(fileLine);
            string parameter = FindParameterName(fileLine);
            CheckParameter(fileLine, parameter);
        }
        fs.Close();
        return midiDeviceNames;

        string FindParameterName(string inputText)
        {
            for (int i = 0; i < parameterNames.Length; i++)
            {
                if (inputText.StartsWith(parameterNames[i]))
                {
                    return parameterNames[i];
                }
            }
            return string.Empty;
        }

        void CheckParameter(string inputText, string parameter)
        {
            bool? status = ParseTools.StringToBool(inputText);
            switch (parameter)
            {
                case TEXT_MIDI_IN:
                    midiDeviceNames[0] = GetMidiDeviceName(inputText);
                    break;
                case TEXT_MIDI_OUT:
                    midiDeviceNames[1] = GetMidiDeviceName(inputText);
                    break;
                case TEXT_UNIT_NO:
                    CheckUnitNoSetting(inputText);
                    break;
                case TEXT_AUTOSAVE:
                    CheckAutoSaveSetting(status);
                    break;
                case TEXT_DARK_MODE:
                    CheckDarkModeSetting(status);
                    break;
                case TEXT_SHOW_CONSOLE:
                    CheckConsoleSetting(status);
                    break;
                case TEXT_VERBOSE_MESSAGES:
                    CheckVerboseMessagesSetting(status);
                    break;
                case TEXT_HARDWARE_CONNECTED:
                    CheckHardwareConnectedSetting(status);
                    break;
                case TEXT_ALLOW_RESET:
                    CheckAllowResetSetting(status);
                    break;
                case TEXT_SEND_MESSAGES:
                    CheckSendMessagesSetting(status);
                    break;
                case TEXT_IGNORE_SYSTEM_ON_LOAD:
                    CheckIgnoreOnLoadSetting(status);
                    break;
                case TEXT_EXCLUDE_SYSTEM_ON_SAVE:
                    CheckExcludeOnSaveSetting(status);
                    break;
                case TEXT_SEND_SYSEX_DATA_TO_CONSOLE:
                    CheckSysExConsoleSetting(status);
                    break;
                default:
                    break;
            }
        }

        string GetMidiDeviceName(string inputString)
        {
            string deviceName = inputString;
            deviceName = ParseTools.RightOfChar(deviceName, '[');
            deviceName = ParseTools.LeftMost(deviceName, deviceName.Length - 1);
            return deviceName;
        }

        void CheckUnitNoSetting(string inputString)
        {
            int.TryParse(ParseTools.RightOfChar(inputString, '='), out int unitNo);
            if (unitNo > 0 && unitNo < 33)
            {
                MT32SysEx.DeviceID = (byte)(unitNo - 1);
            }
        }

        void CheckAutoSaveSetting(bool? status)
        {
            if (status.HasValue)
            {
                SaveSysExFile.autoSave = (bool)status;
            }
        }

        void CheckDarkModeSetting(bool? status)
        {
            if (status.HasValue)
            {
                UITools.DarkMode = (bool)status;
            }
        }

        void CheckIgnoreOnLoadSetting(bool? status)
        {
            if (status.HasValue)
            {
                LoadSysExFile.ignoreSystemArea = (bool)status;
            }
        }

        void CheckExcludeOnSaveSetting(bool? status)
        {
            if (status.HasValue)
            {
                SaveSysExFile.excludeSystemArea = (bool)status;
            }
        }

        void CheckConsoleSetting(bool? status)
        {
            if (status.HasValue)
            {
                ConsoleMessage.SetVisibility((bool)status);
            }
        }

        void CheckVerboseMessagesSetting(bool? status)
        {
            if (status.HasValue)
            {
                ConsoleMessage.SetVerbose((bool)status);
            }
        }

        void CheckHardwareConnectedSetting(bool? status)
        {
            if (status.HasValue)
            {
                MT32SysEx.hardwareMT32Connected = (bool)status;
            }
        }

        void CheckAllowResetSetting(bool? status)
        { 
            if (status.HasValue)
            {
                MT32SysEx.allowReset = (bool)status;
            }
        }

        void CheckSendMessagesSetting(bool? status)
        {
            if (status.HasValue)
            {
                MT32SysEx.sendTextToMT32 = (bool)status;
            }
        }

        void CheckSysExConsoleSetting(bool? status)
        {
            if (status.HasValue)
            {
                MT32SysEx.echoSysExData = (bool)status;
            }
        }
    }

    /// <summary>
    /// Opens MT32Edit.ini to save current user settings.
    /// </summary>
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
            fs.WriteLine($"{TEXT_MIDI_IN} = [{Midi.GetCurrentInputDeviceName()}]");
            fs.WriteLine($"{TEXT_MIDI_OUT} = [{Midi.GetCurrentOutputDeviceName()}]");
            fs.WriteLine($"{TEXT_UNIT_NO} = {MT32SysEx.DeviceID + 1}");
            fs.WriteLine($"{TEXT_AUTOSAVE} = {SaveSysExFile.autoSave}");
            fs.WriteLine($"{TEXT_DARK_MODE} = {UITools.DarkMode}");
            fs.WriteLine($"{TEXT_SHOW_CONSOLE} = {ConsoleMessage.Visible()}");
            fs.WriteLine($"{TEXT_VERBOSE_MESSAGES} = {ConsoleMessage.Verbose()}");
            fs.WriteLine($"{TEXT_SEND_SYSEX_DATA_TO_CONSOLE} = {MT32SysEx.echoSysExData}");
            fs.WriteLine($"{TEXT_HARDWARE_CONNECTED} = {MT32SysEx.hardwareMT32Connected}");
            fs.WriteLine($"{TEXT_ALLOW_RESET} = {MT32SysEx.allowReset}");
            fs.WriteLine($"{TEXT_SEND_MESSAGES} = {MT32SysEx.sendTextToMT32}");
            fs.WriteLine($"{TEXT_IGNORE_SYSTEM_ON_LOAD} = {LoadSysExFile.ignoreSystemArea}");
            fs.WriteLine($"{TEXT_EXCLUDE_SYSTEM_ON_SAVE} = {SaveSysExFile.excludeSystemArea}");
            fs.Close();
        }
        catch (Exception)
        {
            MessageBox.Show($"Unable to create {iniFileName}.{Environment.NewLine}{Environment.NewLine}Check that you have read/write access to the folder that the application is running from ({FileTools.applicationPath}){Environment.NewLine}{Environment.NewLine}MIDI device settings have not been saved.", "MT-32 Editor");
        }
    }
}
using NAudio.Midi;

namespace MT32Edit;

/// <summary>
/// Simple tools to interface with NAudio MIDI library.
/// </summary>
internal static class Midi
{
    // MT32Edit: Midi class (static)
    // S.Fryers Mar 2024

    public const string MUNT_DEVICE_NAME = "MT-32 Synth Emulator";

    private static int OutDeviceIndex = -1;
    private static int InDeviceIndex = -1;
    private static MidiIn? In;
    private static MidiOut? Out;

    /// <summary>
    /// Displays an error message if invalid MIDI In data is received.
    /// </summary>
    private static void InputErrorReceived(object? sender, MidiInMessageEventArgs e)
    {
        MessageBox.Show(string.Format("MIDI Input error: Message 0x{0:X8} Event {1}", e.RawMessage, e.MidiEvent));
    }

    /// <summary>
    /// Returns the name of the MIDI In device specified by deviceNo.
    /// </summary>
    public static string GetInputDeviceName(int deviceNo)
    {
        if (deviceNo < 0 || deviceNo >= MidiIn.NumberOfDevices)
        {
            return "none";
        }
        string deviceName = MidiIn.DeviceInfo(deviceNo).ProductName;
        return deviceName;
    }

    /// <summary>
    /// Returns the name of the MIDI Out device specified by deviceNo.
    /// </summary>
    public static string GetOutputDeviceName(int deviceNo)
    {
        if (deviceNo < 0 || deviceNo >= MidiOut.NumberOfDevices)
        {
            return "none";
        }
        string deviceName = MidiOut.DeviceInfo(deviceNo).ProductName;
        return deviceName;
    }

    /// <summary>
    /// Returns the name of the open MIDI In device.
    /// </summary>
    public static string GetCurrentInputDeviceName()
    {
        return GetInputDeviceName(InDeviceIndex);
    }

    /// <summary>
    /// Returns the name of the open MIDI Out device.
    /// </summary>
    public static string GetCurrentOutputDeviceName()
    {
        return GetOutputDeviceName(OutDeviceIndex);
    }

    /// <summary>
    /// Returns the number of identified MIDI In devices on the current system.
    /// </summary>
    public static int CountInputDevices()
    {
        return MidiIn.NumberOfDevices;
    }

    /// <summary>
    /// Returns the number of identified MIDI In devices on the current system.
    /// </summary>
    public static int CountOutputDevices()
    {
        return MidiOut.NumberOfDevices;
    }

    /// <summary>
    /// Forwards any MIDI In data to the active MIDI Out port, unless a SysEx upload is in progress.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private static void InputMessageReceived(object? sender, MidiInMessageEventArgs e)

    //echo any note data received from MIDI In port thru to MIDI Out port
    {
        if (MT32SysEx.uploadInProgress)
        {
            return; // only echo data if a sysEx upload is not in progress
        }

        if (Out is not null)
        {
            try
            {
                Out.Send(e.RawMessage); //send MIDI In data to MIDI Out
            }
            catch
            {
                ShowMidiOutErrorMessage();
                Out = null;
            }
        }
    }

    /// <summary>
    /// Opens the specified MIDI In device
    /// </summary>
    /// <returns>True if successful, false if unsuccessful</returns>
    public static bool OpenInputDevice(int device)
    {
        if (In is not null) 
        {
            try
            {
                //close any existing MIDI In connection
                In.Stop();
                In.Dispose();
            }
            catch
            {
                ConsoleMessage.SendLine("Error- MIDI device disconnected.");
                return false;
            }
        }
        InDeviceIndex = device;
        try
        {
            In = new MidiIn(InDeviceIndex); //open new MIDI In connection
            In.MessageReceived += InputMessageReceived;
            In.ErrorReceived += InputErrorReceived;
            In.Start(); //MIDI handler will start and continue running in background
            return true;
        }
        catch { return false; }
    }

    /// <summary>
    /// Opens the specified MIDI Out device
    /// </summary>
    /// <returns>True if successful, false if unsuccessful</returns>
    public static bool OpenOutputDevice(int device)
    {
        if (Out is not null)
        {
            Out.Dispose(); //close any existing MIDI Out connection
        }

        OutDeviceIndex = device;
        try                //test for errors
        {
            Out = new MidiOut(OutDeviceIndex);
            return true;
        }
        catch { return false; }
    }

    /// <summary>
    /// Lists all available MIDI In devices on the current system.
    /// </summary>
    /// <returns>An array of strings containing device names.</returns>
    public static string[] ListInputDevices() 
    {
        List<string> deviceList = new List<string>();
        for (int device = 0; device < MidiIn.NumberOfDevices; device++)
        {
            deviceList.Add(MidiIn.DeviceInfo(device).ProductName);
        }
        return deviceList.ToArray();
    }

    /// <summary>
    /// Lists all available MIDI Out devices on the current system.
    /// </summary>
    /// <returns>An array of strings containing device names.</returns>
    public static string[] ListOutputDevices() //List available MIDI Out devices
    {
        List<string> deviceList = new List<string>();
        for (int device = 0; device < MidiOut.NumberOfDevices; device++)
        {
            deviceList.Add(MidiOut.DeviceInfo(device).ProductName);
        }
        return deviceList.ToArray();
    }

    /// <summary>
    /// Returns true if the current MIDI Out device is an MT-32 Emulator
    /// </summary>
    public static bool EmulatorPresent(int deviceIndex)
    {
        if (Out is not null && GetOutputDeviceName(deviceIndex) == MUNT_DEVICE_NAME)
        {
            return true;
        }
        else
        { 
            return false; 
        }
    }

    /// <summary>
    /// Closes the connection to the active MIDI Out device.
    /// </summary>
    public static void CloseOutputDevice()
    {
        if (Out is not null)
        {
            try
            {
                Out.Dispose();
            }
            catch
            {
                ConsoleMessage.SendLine("MIDI Out device already closed.");
                Out = null;
            }
        }
    }

    /// <summary>
    /// Closes the connection to the active MIDI In device.
    /// </summary>
    public static void CloseInputDevice()
    {
        if (In is not null)
        {
            try
            {
                In.Stop();
                In.Dispose();
                In = null;
            }
            catch
            {
                ConsoleMessage.SendLine("MIDI In device already closed.");
                In = null;
            }
        }
    }

    /// <summary>
    /// Sends a MIDI 'note on' message
    /// </summary>
    /// <param name="note"></param>
    /// <param name="midiChannel"></param>

    public static void NoteOn(int note, int midiChannel, int volume = 100)
    {
        if (midiChannel == 16)
        {
            return; //Part is disabled
        }
        LogicTools.ValidateRange("Midi Channel", midiChannel, 0, 15, autoCorrect: false);
        try
        {
            if (Out is not null)
            {
                Out.Send(MidiMessage.StartNote(note, volume, midiChannel + 1).RawData);
            }
        }
        catch
        {
            ConsoleMessage.SendLine("Error opening MIDI Out device.");
            Out = null;
        }
    }

    /// <summary>
    /// Sends a MIDI 'note off' message
    /// </summary>
    /// <param name="note"></param>
    /// <param name="midiChannel"></param>
    public static void NoteOff(int note, int midiChannel, int volume = 100)
    {
        if (midiChannel == 16)
        {
            return; //Part is disabled
        }
        LogicTools.ValidateRange("Midi Channel", midiChannel, 0, 15, autoCorrect: false);
        try
        {
            if (Out is not null)
            {
                Out.Send(MidiMessage.StopNote(note, volume, midiChannel + 1).RawData);
            }
        }
        catch
        {
            ShowMidiOutErrorMessage();
            Out = null;
        }
    }

    public static void SendProgramChange(int patchNo, int channelNo)
    {
        //program change
        byte status = (byte)(0xC0 + channelNo);
        if (patchNo < 0 || patchNo > 127)
        {
            return;
        }

        byte programNo = (byte)patchNo;
        byte[] message = { status, programNo };
        try
        {
            if (Out is not null)
            {
                Out.SendBuffer(message);
            }
        }
        catch
        {
            ShowMidiOutErrorMessage();
            Out = null;
        }
    }

    public static void SendSysExMessage(byte[] sysExMessage)
    {
        try
        {
            if (Out is not null)
            {
                Out.SendBuffer(sysExMessage);
            }
        }
        catch
        {
            ShowMidiOutErrorMessage();
        }
    }

    private static void ShowMidiOutErrorMessage()
    {
        ConsoleMessage.SendLine("Error: Cannot open selected MIDI Out device\\nPlease close any conflicting MIDI applications and restart MT-32 Editor.");
    }
}
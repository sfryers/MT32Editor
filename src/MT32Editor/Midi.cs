using NAudio.Midi;

namespace MT32Edit;

/// <summary>
/// Simple tools to interface with NAudio MIDI library.
/// </summary>
internal static class Midi
{
    // MT32Edit: Midi class (static)
    // S.Fryers Feb 2024

    public static int OutDeviceIndex = -1;
    public static int InDeviceIndex = -1;
    public static bool hardwareMT32Connected = true;
    public static MidiIn? In = null;
    public static MidiOut? Out = null;

    public const string MUNT_DEVICE_NAME = "MT-32 Synth Emulator";

    public static void InputErrorReceived(object sender, MidiInMessageEventArgs e)
    {
        MessageBox.Show(string.Format("MIDI Input error: Message 0x{0:X8} Event {1}", e.RawMessage, e.MidiEvent));
    }

    public static string GetInputDeviceName(int deviceNo)
    {
        if (deviceNo < 0 || deviceNo >= MidiIn.NumberOfDevices)
        {
            return "none";
        }

        string deviceName = MidiIn.DeviceInfo(deviceNo).ProductName;
        return deviceName;
    }

    public static string GetOutputDeviceName(int deviceNo)
    {
        if (deviceNo < 0 || deviceNo >= MidiOut.NumberOfDevices)
        {
            return "none";
        }

        string deviceName = MidiOut.DeviceInfo(deviceNo).ProductName;
        return deviceName;
    }

    public static int CountInputDevices()
    {
        return MidiIn.NumberOfDevices;
    }

    public static int CountOutputDevices()
    {
        return MidiOut.NumberOfDevices;
    }

    public static void InputMessageReceived(object sender, MidiInMessageEventArgs e)

    //echo any note data received from MIDI In port thru to MIDI Out port
    {
        if (MT32SysEx.uploadInProgress)
        {
            return; // only echo data if a sysEx upload is not in progress
        }

        if (Out != null)
        {
            try
            {
                Out.Send(e.RawMessage); //send MIDI In data to MIDI Out
            }
            catch
            {
                ConsoleMessage.SendLine("Error opening MIDI Out device.");
                Out = null;
            }
        }
    }

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

    public static bool ReopenInputDevice()
    {
        //restart Midi In monitoring
        if (InDeviceIndex < 0)
        {
            return false;
        }

        try
        {
            //reopen MIDI In connection if a device is selected
            In = new MidiIn(InDeviceIndex);
            In.MessageReceived += InputMessageReceived;
            In.ErrorReceived += InputErrorReceived;
            In.Start(); //MIDI handler will start and continue running in background
            return true;
        }
        catch { return false; }
    }

    public static bool OpenOutputDevice(int device)
    {
        if (Out != null)
        {
            Out.Dispose(); //close any existing MIDI Out connection
        }

        OutDeviceIndex = device;
        try                             //test for errors
        {
            Out = new MidiOut(OutDeviceIndex);
            return true;
        }
        catch { return false; }
    }

    public static string[] ListInputDevices() //List available MIDI In devices
    {
        List<string> deviceList = new List<string>();
        for (int device = 0; device < MidiIn.NumberOfDevices; device++)
        {
            deviceList.Add(MidiIn.DeviceInfo(device).ProductName);
        }
        return deviceList.ToArray();
    }

    public static string[] ListOutputDevices() //List available MIDI Out devices
    {
        List<string> deviceList = new List<string>();
        for (int device = 0; device < MidiOut.NumberOfDevices; device++)
        {
            deviceList.Add(MidiOut.DeviceInfo(device).ProductName);
        }
        return deviceList.ToArray();
    }

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

    public static void CloseOutputDevice()
    {
        if (Out != null)
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

    public static void CloseInputDevice()
    {
        if (In != null)
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

    public static void PlayRhythmNote(int note, int midiChannel)
    {
        LogicTools.ValidateRange("Midi Channel", midiChannel, 0, 15, autoCorrect: false);
        try
        {
            if (Out != null)
            {
                Out.Send(MidiMessage.StartNote(note, 120, midiChannel + 1).RawData);
            }
        }
        catch
        {
            ConsoleMessage.SendLine("Error opening MIDI Out device.");
            Out = null;
        }
    }

    public static void StopRhythmNote(int note, int midiChannel)
    {
        LogicTools.ValidateRange("Midi Channel", midiChannel, 0, 15, autoCorrect: false);
        try
        {
            if (Out != null)
            {
                Out.Send(MidiMessage.StopNote(note, 120, midiChannel + 1).RawData);
            }
        }
        catch
        {
            ConsoleMessage.SendLine("Error opening MIDI Out device.");
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
            if (Out != null)
            {
                Out.SendBuffer(message);
            }
        }
        catch
        {
            ConsoleMessage.SendLine("Error opening MIDI Out device.");
            Out = null;
        }
    }
}
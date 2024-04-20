using Sanford.Multimedia.Midi;

namespace MT32Edit_legacy;
/// <summary>
/// Simple tools to interface with Sanford.Multimedia.Midi library.
/// </summary>
internal static class Midi
{

    // MT32Edit: Midi class (static)
    // S.Fryers Apr 2024

    public static int OutDeviceIndex = -1;
    public static int InDeviceIndex = -1;
    public static bool hardwareMT32Connected = true;

    public static InputDevice? midiInDevice = null;
    public static OutputDevice? midiOutDevice = null;

    public static SynchronizationContext context = new SynchronizationContext();
    //public static MidiInPort In = null;
    //public static MidiOutPort Out = null;

    public const string MUNT_DEVICE_NAME = "MT-32 Synth Emulator";


    public static string GetInputDeviceName(int deviceNo)
    {
        if (deviceNo < 0 || deviceNo >= CountInputDevices())
        {
            return "none";
        }
        return InputDevice.GetDeviceCapabilities(deviceNo).name;
    }

    public static string GetOutputDeviceName(int deviceNo)
    {
        if (deviceNo < 0 || deviceNo >= CountOutputDevices())
        {
            return "none";
        }
        return OutputDevice.GetDeviceCapabilities(deviceNo).name;
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


    public static int CountInputDevices()
    {
        return InputDevice.DeviceCount;
    }

    public static int CountOutputDevices()
    {
        return OutputDevice.DeviceCount;
    }

    private static void inDevice_Error(object sender, Sanford.Multimedia.ErrorEventArgs e)
    {
        MessageBox.Show(e.Error.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
    }

    private static void HandleShortMessageReceived(object sender, ShortMessageEventArgs e)
    {
        if (MT32SysEx.uploadInProgress || midiOutDevice is null)
        {
            return; // only continue if midiOutDevice is connected and a sysEx upload is not in progress
        }
        //echo to midi out
        ShortMessage shortMessage = new ShortMessage();
        int message = shortMessage.Message;
        try
        {
            midiOutDevice.SendShort(message);
        }
        catch
        {
            Console.WriteLine("Midi Out Error");
        }

    }

    private static void HandleChannelMessageReceived(object sender, ChannelMessageEventArgs e)
    {
        if (MT32SysEx.uploadInProgress || midiOutDevice is null)
        {
            return; // only continue if midiOutDevice is connected and a sysEx upload is not in progress
        }
        //echo to midi out
        try
        {
            midiOutDevice.Send(e.Message);
        }
        catch
        {
            Console.WriteLine("Midi Out Error");
        }

    }

    public static bool OpenInputDevice(int deviceNo)
    {
        if (!(midiInDevice is null) && !midiInDevice.IsDisposed)
        {
            try
            {
                //close any existing MIDI In connection
                midiInDevice.StopRecording();
                midiInDevice.Close();
                midiInDevice.Dispose();
            }
            catch
            {
                ConsoleMessage.SendLine("Error- MIDI device disconnected.");
                return false;
            }
        }

        InDeviceIndex = deviceNo;
        try
        {
            SynchronizationContext context = SynchronizationContext.Current;
            midiInDevice = new InputDevice(deviceNo);
            midiInDevice.ShortMessageReceived += HandleShortMessageReceived;
            midiInDevice.ChannelMessageReceived += HandleChannelMessageReceived;
            midiInDevice.Error += new EventHandler<Sanford.Multimedia.ErrorEventArgs>(inDevice_Error);
            midiInDevice.StartRecording();
            return true;
        }
        catch { return false; }
    }

    public static bool OpenOutputDevice(int deviceNo)
    {
        if (!(midiOutDevice is null) && !midiOutDevice.IsDisposed)
        {
            try
            {
                midiOutDevice.Dispose(); //close any existing MIDI Out connection
            }
            catch
            {
                ConsoleMessage.SendLine("MIDI error- device already closed.");
            }
            //midiOutDevice.Close();
            midiOutDevice = null;
        }

        OutDeviceIndex = deviceNo;
        try                             //test for errors
        {
            midiOutDevice = new OutputDevice(deviceNo);
            return true;
        }
        catch { return false; }
    }

    public static string[] ListInputDevices() //List available MIDI In devices
    {
        List<string> deviceList = new List<string>();
        for (int deviceNo = 0; deviceNo < CountInputDevices(); deviceNo++)
        {
            deviceList.Add(InputDevice.GetDeviceCapabilities(deviceNo).name);
        }
        return deviceList.ToArray();
    }

    public static string[] ListOutputDevices() //List available MIDI Out devices
    {
        List<string> deviceList = new List<string>();
        for (int deviceNo = 0; deviceNo < CountOutputDevices(); deviceNo++)
        {
            deviceList.Add(OutputDevice.GetDeviceCapabilities(deviceNo).name);
        }
        return deviceList.ToArray();
    }

    public static bool EmulatorPresent(int deviceNo)
    {
        if (midiOutDevice != null && OutputDevice.GetDeviceCapabilities(deviceNo).name == MUNT_DEVICE_NAME)
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
        if (!(midiOutDevice is null) && !midiOutDevice.IsDisposed)
        {
            try
            {
                //midiOutDevice.Close();
                midiOutDevice.Dispose();
                midiOutDevice = null;
            }
            catch
            {
                ConsoleMessage.SendLine("MIDI Out device already closed.");
                midiOutDevice = null;
            }
        }
    }

    public static void CloseInputDevice()
    {
        if (!(midiInDevice is null) && !midiInDevice.IsDisposed)
        {
            try
            {
                midiInDevice.StopRecording();
                midiInDevice.Close();
                midiInDevice.Dispose();
                midiInDevice = null;
            }
            catch
            {
                ConsoleMessage.SendLine("MIDI In device already closed.");
                midiInDevice = null;
            }
        }
    }

    /// <summary>
    /// Sends a MIDI 'note on' message.
    /// </summary>
    /// <param name="note"></param>
    /// <param name="midiChannel"></param>
    public static void NoteOn(int note, int midiChannel, int volume = 100)
    {
        LogicTools.ValidateRange("Midi Channel", midiChannel, 0, 15, autoCorrect: false);
        ChannelMessageBuilder messageWrapper = new ChannelMessageBuilder();
        messageWrapper.MidiChannel = midiChannel;
        messageWrapper.Command = ChannelCommand.NoteOn;
        messageWrapper.Data1 = note;
        messageWrapper.Data2 = volume;
        messageWrapper.Build();
        ChannelMessage message = messageWrapper.Result;

        try
        {
            if (!(midiOutDevice is null) && !midiOutDevice.IsDisposed)
            {
                midiOutDevice.Send(message);
            }
        }
        catch
        {
            ConsoleMessage.SendLine("Error opening MIDI Out device.");
            midiOutDevice = null;
        }
    }

    /// <summary>
    /// Sends a MIDI 'note off' message.
    /// </summary>
    /// <param name="note"></param>
    /// <param name="midiChannel"></param>
    public static void NoteOff(int note, int midiChannel)
    {
        LogicTools.ValidateRange("Midi Channel", midiChannel, 0, 15, autoCorrect: false);
        ChannelMessageBuilder messageWrapper = new ChannelMessageBuilder();
        messageWrapper.MidiChannel = midiChannel;
        messageWrapper.Command = ChannelCommand.NoteOff;
        messageWrapper.Data1 = note;
        messageWrapper.Data2 = 0;
        messageWrapper.Build();
        ChannelMessage message = messageWrapper.Result;
        try
        {
            if (!(midiOutDevice is null) && !midiOutDevice.IsDisposed)
            {
                midiOutDevice.Send(message);
            }
        }
        catch
        {
            ConsoleMessage.SendLine("Error opening MIDI Out device.");
            midiOutDevice = null;
        }
    }

    public static void SendProgramChange(int patchNo, int channelNo)
    {
        //program change
        //byte status = (byte)(0xC0 + channelNo);
        if (patchNo < 0 || patchNo > 127)
        {
            return;
        }
        ChannelMessageBuilder messageWrapper = new ChannelMessageBuilder();
        messageWrapper.MidiChannel = channelNo;
        messageWrapper.Command = ChannelCommand.ProgramChange;
        messageWrapper.Data1 = patchNo;
        messageWrapper.Build();
        ChannelMessage message = messageWrapper.Result;
        try
        {
            if (!(midiOutDevice is null) && !midiOutDevice.IsDisposed)
            {
                midiOutDevice.Send(message);
            }
        }
        catch
        {
            ConsoleMessage.SendLine("Error opening MIDI Out device.");
            midiOutDevice = null;
        }
    }

    public static void SendSysExMessage(byte[] sysExBytes)
    {
        SysExMessage message = new SysExMessage(sysExBytes);

        try
        {
            if (!(midiOutDevice is null) && !midiOutDevice.IsDisposed)
            {
                midiOutDevice.Send(message);
            }
        }
        catch
        {
            ConsoleMessage.SendLine("Error opening MIDI Out device.");
            midiOutDevice = null;
        }
    }
}
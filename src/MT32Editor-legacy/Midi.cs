using System;
using System.Collections.Generic;
using System.Windows.Forms;
#if NET5_0_OR_GREATER
using NAudio.Midi;
namespace MT32Edit;

/// <summary>
/// Simple tools to interface with NAudio MIDI library or Sanford.Multimedia.Midi library as approprate for targetted .NET version. 
/// Uses conditional compilation to select correct library and methods depending on whether Main or Legacy version is being compiled.
/// This is the Main version.
/// </summary>

internal static class Midi
{
    // MT32Edit: Midi class (static)
    // S.Fryers Feb 2025

    public const string MUNT_DEVICE_NAME = "MT-32 Synth Emulator";

    private static int OutDeviceIndex = 0;
    private static int InDeviceIndex = 0;
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
        if (deviceNo <=0 || deviceNo > MidiIn.NumberOfDevices)
        {
            return MT32Strings.NONE;
        }
        string deviceName = MidiIn.DeviceInfo(deviceNo - 1).ProductName;
        return deviceName;
    }

    /// <summary>
    /// Returns the name of the MIDI Out device specified by deviceNo.
    /// </summary>
    public static string GetOutputDeviceName(int deviceNo)
    {
        if (deviceNo <=0 || deviceNo > MidiOut.NumberOfDevices)
        {
            return MT32Strings.NONE;
        }
        string deviceName = MidiOut.DeviceInfo(deviceNo - 1).ProductName;
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

        if (OutDeviceIndex > 0 && Out is not null)
        {
            try
            {
                Out.Send(e.RawMessage); //send MIDI In data to MIDI Out
            }
            catch (Exception)
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
        if (InDeviceIndex > 0 && In is not null) 
        {
            try
            {
                //close any existing MIDI In connection
                In.Stop();
                In.Dispose();
            }
            catch (Exception)
            {
                ConsoleMessage.SendLine("MIDI In device error.");
                return false;
            }
        }
        InDeviceIndex = device;
        if (device <= 0)
        {
            ConsoleMessage.SendLine($"No MIDI In device connected.");
            return true;
        }
        try
        {
            In = new MidiIn(InDeviceIndex - 1); //open new MIDI In connection
            In.MessageReceived += InputMessageReceived;
            In.ErrorReceived += InputErrorReceived;
            In.Start(); //MIDI handler will start and continue running in background
            ConsoleMessage.SendLine($"MIDI In device connected: {GetInputDeviceName(device)}");
            return true;
        }
        catch (Exception) 
        {
            ConsoleMessage.SendLine($"Cannot open MIDI In device: {GetInputDeviceName(device)}");
            return false; 
        }
    }

    /// <summary>
    /// Opens the specified MIDI Out device
    /// </summary>
    /// <returns>True if successful, false if unsuccessful</returns>
    public static bool OpenOutputDevice(int device)
    {
        if (OutDeviceIndex > 0 && Out is not null)
        {
            if (In is not null && InDeviceIndex > 0)
            {
                In.Stop(); //pause existing MIDI In connection
            }  
            Out.Dispose(); //close any existing MIDI Out connection
        }
        OutDeviceIndex = device;
        if (device <= 0)
        {
            ConsoleMessage.SendLine($"No MIDI Out device connected.");
            return true;
        }
        try                //test for errors
        {
            Out = new MidiOut(OutDeviceIndex - 1);
            ConsoleMessage.SendLine($"MIDI Out device connected: {GetOutputDeviceName(device)}");
            if (InDeviceIndex > 0 && In is not null)
            {
                In.Start(); //restart existing MIDI In connection
            }
            return true;
        }
        catch (Exception)
        {
            ConsoleMessage.SendLine($"Cannot open MIDI Out device: {GetOutputDeviceName(device)}");
            return false; 
        }
    }

    /// <summary>
    /// Lists all available MIDI In devices on the current system.
    /// </summary>
    /// <returns>An array of strings containing device names.</returns>
    public static string[] ListInputDevices() 
    {
        var deviceList = new List<string> { MT32Strings.NONE };
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
        var deviceList = new List<string> { MT32Strings.NONE };
        for (int device = 0; device < MidiOut.NumberOfDevices; device++)
        {
            deviceList.Add(MidiOut.DeviceInfo(device).ProductName);
        }
        return deviceList.ToArray();
    }

    /// <summary>
    /// Returns true if the current MIDI Out device is a MUNT MT-32 Emulator.
    /// </summary>
    public static bool EmulatorPresent(int deviceIndex)
    {
        return Out is not null && GetOutputDeviceName(deviceIndex) == MUNT_DEVICE_NAME;
    }

    /// <summary>
    /// Closes the connection to the active MIDI Out device.
    /// </summary>
    public static void CloseOutputDevice()
    {
        if (OutDeviceIndex > 0 && Out is not null)
        {
            try
            {
                Out.Dispose();
            }
            catch (Exception)
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
        if (InDeviceIndex > 0 && In is not null)
        {
            try
            {
                In.Stop();
                In.Dispose();
                In = null;
            }
            catch (Exception)
            {
                ConsoleMessage.SendLine("MIDI In device already closed.");
                In = null;
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
        catch (Exception)
        {
            ShowMidiOutErrorMessage();
            Out = null;
        }
    }

    /// <summary>
    /// Sends a MIDI 'note off' message.
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
        catch (Exception)
        {
            ShowMidiOutErrorMessage();
            Out = null;
        }
    }

    /// <summary>
    /// Sends a MIDI program change message.
    /// </summary>
    /// <param name="patchNo"></param>
    /// <param name="midiChannel"></param>
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
        catch (Exception)
        {
            ShowMidiOutErrorMessage();
            Out = null;
        }
    }

    /// <summary>
    /// Sends an array of bytes as a MIDI SysEx message.
    /// </summary>
    /// <param name="sysExMessage"></param>
    public static void SendSysExMessage(byte[] sysExMessage)
    {
        try
        {
            if (Out is not null)
            {
                Out.SendBuffer(sysExMessage);
            }
        }
        catch (Exception)
        {
            ShowMidiOutErrorMessage();
            Out = null;
        }
    }

    private static void ShowMidiOutErrorMessage()
    {
        ConsoleMessage.SendLine("Error: Cannot open selected MIDI Out device. Please close any conflicting MIDI applications and restart MT-32 Editor.");
        MessageBox.Show($"Error: Cannot open selected MIDI Out device.{Environment.NewLine}Please close any conflicting MIDI applications and restart MT-32 Editor.", "MT32 Editor");
    }
}

#else
using Sanford.Multimedia;
using Sanford.Multimedia.Midi;
namespace MT32Edit_legacy;

/// Simple tools to interface with NAudio MIDI library or Sanford.Multimedia.Midi library as approprate for targetted .NET version. 
/// Uses conditional compilation to select correct library and methods depending on whether Main or Legacy version is being compiled.
/// This is the Legacy version.

internal static class Midi
{
    // MT32Edit: Midi class (static)
    // S.Fryers Feb 2025

    public const string MUNT_DEVICE_NAME = "MT-32 Synth Emulator";

    private static int OutDeviceIndex = 0;
    private static int InDeviceIndex = 0;
    private static InputDevice? midiInDevice;
    private static OutputDevice? midiOutDevice;
    //private static SynchronizationContext? context;

    /// <summary>
    /// Returns the name of the MIDI In device specified by deviceNo.
    /// </summary>
    public static string GetInputDeviceName(int deviceNo)
    {
        if (deviceNo <= 0 || deviceNo > CountInputDevices())
        {
            return MT32Strings.NONE;
        }
        return InputDevice.GetDeviceCapabilities(deviceNo - 1).name;
    }

    /// <summary>
    /// Returns the name of the MIDI Out device specified by deviceNo.
    /// </summary>
    public static string GetOutputDeviceName(int deviceNo)
    {
        if (deviceNo <= 0 || deviceNo > CountOutputDevices())
        {
            return MT32Strings.NONE;
        }
        return OutputDevice.GetDeviceCapabilities(deviceNo - 1).name;
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
        return InputDevice.DeviceCount;
    }

    /// <summary>
    /// Returns the number of identified MIDI In devices on the current system.
    /// </summary>
    public static int CountOutputDevices()
    {
        return OutputDevice.DeviceCount;
    }

    /// <summary>
    /// Displays an error message if invalid MIDI In data is received.
    /// </summary>
    private static void inDevice_Error(object sender, Sanford.Multimedia.ErrorEventArgs e)
    {
        MessageBox.Show(e.Error.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
    }

    /// <summary>
    /// Forwards any MIDI In short message data to the active MIDI Out port, unless a SysEx upload is in progress.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private static void HandleShortMessageReceived(object sender, ShortMessageEventArgs e)
    {
        if (MT32SysEx.uploadInProgress || midiOutDevice is null)
        {
            return; // only continue if midiOutDevice is connected and a sysEx upload is not in progress
        }
        //echo to midi out
        byte[] message = e.Message.Bytes;
        try
        {
            for (int i = 0; i < message.Length; i++)
            {
                midiOutDevice.SendShort(message[i]);
            }
        }
        catch
        {
            Console.WriteLine("Midi Out Error");
        }
    }

    /// <summary>
    /// Forwards any MIDI In channel data to the active MIDI Out port, unless a SysEx upload is in progress.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private static void HandleChannelMessageReceived(object sender, ChannelMessageEventArgs e)
    {
        if (MT32SysEx.uploadInProgress || midiOutDevice is null)
        {
            // only continue if midiOutDevice is connected and a sysEx upload is not in progress
            return;
        }
        try
        {
            midiOutDevice.Send(e.Message);
        }
        catch
        {
            Console.WriteLine("Midi Out Error");
        }
    }

    /// <summary>
    /// Opens the specified MIDI In device
    /// </summary>
    /// <returns>True if successful, false if unsuccessful</returns>
    public static bool OpenInputDevice(int deviceNo)
    {
        CloseInputDevice();
        InDeviceIndex = deviceNo;
        if (deviceNo <= 0)
        {
            ConsoleMessage.SendLine($"No MIDI In device connected.");
            return true;
        }
        try
        {
            midiInDevice = new InputDevice(deviceNo - 1);
            midiInDevice.ShortMessageReceived += HandleShortMessageReceived;
            midiInDevice.ChannelMessageReceived += HandleChannelMessageReceived;
            midiInDevice.Error += new EventHandler<Sanford.Multimedia.ErrorEventArgs>(inDevice_Error);
            midiInDevice.StartRecording();
            ConsoleMessage.SendLine($"MIDI In device connected: {InputDevice.GetDeviceCapabilities(deviceNo - 1).name}");
            return true;
        }
        catch { return false; }
    }

    /// <summary>
    /// Opens the specified MIDI Out device
    /// </summary>
    /// <returns>True if successful, false if unsuccessful</returns>
    public static bool OpenOutputDevice(int deviceNo)
    {
        CloseOutputDevice();
        OutDeviceIndex = deviceNo;
        if (deviceNo == 0)
        {
            ConsoleMessage.SendLine($"No MIDI Out device connected.");
            return true;
        }
        try                             //test for errors
        {
            midiOutDevice = new OutputDevice(deviceNo - 1);
            ConsoleMessage.SendLine($"MIDI Out device connected: {OutputDevice.GetDeviceCapabilities(deviceNo - 1).name}");
            return true;
        }
        catch { return false; }
    }

    /// <summary>
    /// Lists all available MIDI In devices on the current system.
    /// </summary>
    /// <returns>An array of strings containing device names.</returns>
    public static string[] ListInputDevices() //List available MIDI In devices
    {
        var deviceList = new List<string> { MT32Strings.NONE };
        for (int deviceNo = 0; deviceNo < CountInputDevices(); deviceNo++)
        {
            deviceList.Add(InputDevice.GetDeviceCapabilities(deviceNo).name);
        }
        return deviceList.ToArray();
    }

    /// <summary>
    /// Lists all available MIDI Out devices on the current system.
    /// </summary>
    /// <returns>An array of strings containing device names.</returns>
    public static string[] ListOutputDevices() //List available MIDI Out devices
    {
        var deviceList = new List<string> { MT32Strings.NONE };
        for (int deviceNo = 0; deviceNo < CountOutputDevices(); deviceNo++)
        {
            deviceList.Add(OutputDevice.GetDeviceCapabilities(deviceNo).name);
        }
        return deviceList.ToArray();
    }

    /// <summary>
    /// Returns true if the current MIDI Out device is a MUNT MT-32 Emulator.
    /// </summary>
    public static bool EmulatorPresent(int deviceNo)
    {
        return midiOutDevice is not null && OutputDevice.GetDeviceCapabilities(deviceNo - 1).name == MUNT_DEVICE_NAME;
    }

    /// <summary>
    /// Closes the connection to the active MIDI Out device.
    /// </summary>
    public static void CloseOutputDevice()
    {
        if (OutDeviceIndex > 0 && midiOutDevice is not null && !midiOutDevice.IsDisposed)
        {
           try
           {
                midiOutDevice.Reset();
                midiOutDevice.Close();
           }
           catch
           {
                ConsoleMessage.SendVerboseLine("MIDI Out device closed.");
                midiOutDevice = null;
           }
        }
    }

    /// <summary>
    /// Closes the connection to the active MIDI In device.
    /// </summary>
    public static void CloseInputDevice()
    {
        if (InDeviceIndex > 0 && midiInDevice is not null && !midiInDevice.IsDisposed)
        {
           try
           {
                midiInDevice.StopRecording();
                midiInDevice.Reset();
                midiInDevice.Close();
                midiInDevice = null;
           }
           catch
           {
                ConsoleMessage.SendVerboseLine("MIDI In device closed.");
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
        var messageWrapper = new ChannelMessageBuilder();
        messageWrapper.MidiChannel = midiChannel;
        messageWrapper.Command = ChannelCommand.NoteOn;
        messageWrapper.Data1 = note;
        messageWrapper.Data2 = volume;
        messageWrapper.Build();
        ChannelMessage message = messageWrapper.Result;

        try
        {
            if (midiOutDevice is not null && !midiOutDevice.IsDisposed)
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
        var messageWrapper = new ChannelMessageBuilder();
        messageWrapper.MidiChannel = midiChannel;
        messageWrapper.Command = ChannelCommand.NoteOff;
        messageWrapper.Data1 = note;
        messageWrapper.Data2 = 0;
        messageWrapper.Build();
        ChannelMessage message = messageWrapper.Result;
        try
        {
            if (midiOutDevice is not null && !midiOutDevice.IsDisposed)
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
    /// Sends a MIDI program change message.
    /// </summary>
    /// <param name="patchNo"></param>
    /// <param name="midiChannel"></param>
    public static void SendProgramChange(int patchNo, int channelNo)
    {
        if (patchNo < 0 || patchNo > 127)
        {
            return;
        }
        var messageWrapper = new ChannelMessageBuilder();
        messageWrapper.MidiChannel = channelNo;
        messageWrapper.Command = ChannelCommand.ProgramChange;
        messageWrapper.Data1 = patchNo;
        messageWrapper.Build();
        ChannelMessage message = messageWrapper.Result;
        try
        {
            if (OutDeviceIndex > 0 && !(midiOutDevice is null) && !midiOutDevice.IsDisposed)
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
    /// Sends an array of bytes as a MIDI SysEx message.
    /// </summary>
    /// <param name="sysExMessage"></param>
    public static void SendSysExMessage(byte[] sysExBytes)
    {
        SysExMessage message = new SysExMessage(sysExBytes);
        try
        {
            if (InDeviceIndex > 0 && midiOutDevice is not null && !midiOutDevice.IsDisposed)
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
#endif
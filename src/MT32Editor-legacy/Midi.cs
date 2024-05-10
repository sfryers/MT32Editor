using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sanford.Multimedia.Midi;
namespace MT32Edit_legacy;
/// <summary>
/// Simple tools to interface with Sanford.Multimedia.Midi library.
/// </summary>
internal static class Midi
{
    // MT32Edit: Midi class (static)
    // S.Fryers Apr 2024

    public const string MUNT_DEVICE_NAME = "MT-32 Synth Emulator";

    private static int OutDeviceIndex = -1;
    private static int InDeviceIndex = -1;
    private static InputDevice? midiInDevice;
    private static OutputDevice? midiOutDevice;
    //private static SynchronizationContext? context;

    /// <summary>
    /// Returns the name of the MIDI In device specified by deviceNo.
    /// </summary>
    public static string GetInputDeviceName(int deviceNo)
    {
        if (deviceNo < 0 || deviceNo >= CountInputDevices())
        {
            return "none";
        }
        return InputDevice.GetDeviceCapabilities(deviceNo).name;
    }

    /// <summary>
    /// Returns the name of the MIDI Out device specified by deviceNo.
    /// </summary>
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
        try
        {
            midiInDevice = new InputDevice(deviceNo);
            midiInDevice.ShortMessageReceived += HandleShortMessageReceived;
            midiInDevice.ChannelMessageReceived += HandleChannelMessageReceived;
            midiInDevice.Error += new EventHandler<Sanford.Multimedia.ErrorEventArgs>(inDevice_Error);
            midiInDevice.StartRecording();
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
        try                             //test for errors
        {
            midiOutDevice = new OutputDevice(deviceNo);
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
        var deviceList = new List<string>();
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
        var deviceList = new List<string>();
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
        return midiOutDevice != null && OutputDevice.GetDeviceCapabilities(deviceNo).name == MUNT_DEVICE_NAME;
    }

    /// <summary>
    /// Closes the connection to the active MIDI Out device.
    /// </summary>
    public static void CloseOutputDevice()
    {
        if (midiOutDevice is not null && !midiOutDevice.IsDisposed)
        {
           try
           {
                midiOutDevice.Reset();
                midiOutDevice.Close();
           }
           catch
           {
                ConsoleMessage.SendVerboseLine("MIDI Out device closed.");
           }
        }
    }

    /// <summary>
    /// Closes the connection to the active MIDI In device.
    /// </summary>
    public static void CloseInputDevice()
    {
        if (midiInDevice is not null && !midiInDevice.IsDisposed)
        {
           try
           {
                midiInDevice.StopRecording();
                midiInDevice.Reset();
                midiInDevice.Close();
           }
           catch
           {
                ConsoleMessage.SendVerboseLine("MIDI In device closed.");
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
        var messageWrapper = new ChannelMessageBuilder();
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
    /// Sends an array of bytes as a MIDI SysEx message.
    /// </summary>
    /// <param name="sysExMessage"></param>
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
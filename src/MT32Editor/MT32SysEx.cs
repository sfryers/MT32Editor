﻿using System.Text;

namespace MT32Edit;

/// <summary>
/// Tools to create and send MT32-compatible system exclusive messages
/// </summary>
internal static class MT32SysEx
{
    // MT32Edit: MT32SysEx class (static)
    // S.Fryers Mar 2023

    public const byte START_OF_DATA_BLOCK = 0xF0;   //SysEx message blocks start with F0

    public const byte MANUFACTURER_ID = 0x41;       //Manufacturer ID (Roland)
    public const byte DEVICE_ID = 0x10;             //Default device ID - might be helpful to allow user to alter this value in a future release
    public const byte MODEL_ID = 0x16;              //Model ID for MT-32
    public const byte RX = 0x11;                    //Receive SysEx data from device
    public const byte TX = 0x12;                    //Transmit SysEx data to device
    public const byte RESET = 0x7F;                 //MT-32 reset
    public const byte END_OF_DATA_BLOCK = 0xF7;     //SysEx message blocks terminate with F7

    public const int MAX_BLOCK_LENGTH = 264;        //maximum length (in bytes) of SysEx data block
    public const int PARAMETER_COUNT = 58;          //no of parameters in each partial
    public const int PARTIAL_ADDRESS_OFFSET = 0x0E; //partial parameters start at address offset 0E

    public static bool uploadInProgress = false;
    //user configurable option- when true, parameter changes will be displayed on MT-32 text display.
    public static bool sendTextToMT32 = true;
    //if set to true, blocks all text messages from being sent regardless of sendTextToMT32 status.
    public static bool blockMT32text = false;
    //if set to true, no system exclusive data will be sent to the selected MIDI Out device.
    public static bool blockSysExMessages = false;
    //if set to true, will pass any MT-32 reset messages to the selected MIDI Out device.
    public static bool allowReset = false;
    private static readonly int channelNo = 1;

    /// <summary>
    /// Calculate Roland SysEx checksum value
    /// </summary>
    public static byte RolandChecksum(int sumOfSysExValues)
    {
        //round to 7-bit value
        byte checkSum = (byte)(sumOfSysExValues % 0x80);
        //invert
        checkSum = (byte)(0x80 - checkSum);
        if (checkSum == 0x80)
        {
            checkSum = 0x00;
        }

        return checkSum;
    }

    private static int[] WrapBytes(int[] Addr)
    {
        //if value exceeds 7-bit maximum, wrap value and increment next significant byte
        while (Addr[1] > 0x7F)
        {
            Addr[0] += 0x01;
            Addr[1] -= 0x80;
        }
        return Addr;
    }

    /// <summary>
    /// Calculates address of specific patch memory area
    /// </summary>
    public static byte[] PatchAddress(int patchNo)
    {
        int[] Addr = new int[2];
        Addr[0] = 0x00;
        Addr[1] = patchNo * 8;
        Addr = WrapBytes(Addr);
        byte[] sysExAddr = { 0x05, Convert.ToByte(Addr[0]), Convert.ToByte(Addr[1]) };
        return sysExAddr;
    }

    /// <summary>
    /// Calculates address of specific rhythm bank key area
    /// </summary>
    public static byte[] RhythmKeyAddress(int keyNo)
    {
        int[] Addr = new int[2];
        Addr[0] = 0x01;
        Addr[1] = 0x10 + ((keyNo - 24) * 4);
        Addr = WrapBytes(Addr);
        byte[] sysExAddr = { 0x03, Convert.ToByte(Addr[0]), Convert.ToByte(Addr[1]) };
        return sysExAddr;
    }

    /// <summary>
    /// Calculates address of specific memory timbre
    /// </summary>
    public static byte[] MemoryTimbreAddress(int timbreNo)
    {
        if (timbreNo < 0 || timbreNo > 63)
        {
            timbreNo = 0;
        }

        byte[] Addr = new byte[2];
        Addr[0] = Convert.ToByte(timbreNo * 2);
        Addr[1] = 0x00;
        byte[] sysExAddr = { 0x08, Addr[0], Addr[1] };
        return sysExAddr;
    }

    /// <summary>
    /// Calculates address of specific temporary timbre area partial parameter
    /// </summary>
    public static byte[] TempPartialAddress(int parameter, int partial)
    {
        int[] Addr = new int[2];
        Addr[0] = 0x00;
        Addr[1] = parameter + PARTIAL_ADDRESS_OFFSET + (PARAMETER_COUNT * partial);
        Addr = WrapBytes(Addr);
        byte[] sysExAddr = { 0x04, Convert.ToByte(Addr[0]), Convert.ToByte(Addr[1]) };
        return sysExAddr;
    }

    public static void SendSystemParameters(SystemLevel system)
    {
        byte[] sysExAddr = { 0x10, 0x00, 0x00 };
        byte[] sysExData = new byte[23];
        sysExData[0] = (byte)system.GetMasterTune();
        sysExData[1] = (byte)system.GetReverbMode();
        sysExData[2] = (byte)system.GetReverbTime();
        sysExData[3] = (byte)system.GetReverbLevel();
        for (int partNo = 0; partNo < 9; partNo++)
        {
            sysExData[partNo + 4] = (byte)system.GetPartialReserve(partNo);
            sysExData[partNo + 13] = (byte)system.GetSysExMidiChannel(partNo);
        }
        sysExData[22] = (byte)system.GetMasterLevel();
        SendMessage(sysExAddr, sysExData);
    }

    public static void SendPatchBlock(Patch[] patchData, int firstPatchNo, int lastPatchNo)
    {
        //send multiple patches to device
        for (int patchNo = firstPatchNo; patchNo < lastPatchNo + 1; patchNo++)
        {
            SendPatchData(patchData, patchNo);
        }
    }

    public static void SendPatchData(Patch[] patchData, int patchNo)
    {
        //send patch parameters to device
        byte[] sysExAddr = PatchAddress(patchNo);
        byte[] sysExData = new byte[8];
        for (int parameterNo = 0; parameterNo < 8; parameterNo++)
        {
            sysExData[parameterNo] = (byte)patchData[patchNo].GetParameterSysExValue(parameterNo);
        }
        SendMessage(sysExAddr, sysExData);
    }

    public static void SendPatchParameterData(Patch[] patchData, int patchNo, int parameterNo)
    {
        //send patch parameters to device
        byte[] sysExAddr = PatchAddress(patchNo);
        byte[] sysExData = new byte[8];
        for (int param = 0; param < 8; param++)
        {
            sysExData[param] = (byte)patchData[patchNo].GetParameterSysExValue(param);
        }
        SendMessage(sysExAddr, sysExData);
        Midi.SendProgramChange(patchNo, channelNo);
        SendText(MT32Strings.patchParameterNames[parameterNo] + ": " + MT32Strings.PatchParameterValueText(parameterNo, patchData[patchNo].GetParameterUIValue(parameterNo)));
    }

    public static void UpdateTimbreParameters(TimbreStructure t)
    {
        blockMT32text = true;
        SendTimbreName(t.GetTimbreName());
        UpdatePartialStructures(t.GetPart12Structure(), t.GetPart34Structure());
        UpdatePartialMuteStatus(t.GetPartialMuteStatus(), 0);
        SendSustainValue(t.GetSustainStatus());
        blockMT32text = false;
    }

    /// <summary>
    /// Sends parameter change to device and show text on device display
    /// </summary>
    public static void SendPartialParameter(int partialNo, byte parameterNo, int parameterValue)
    {
        string parameterName = MT32Strings.partialParameterNames[parameterNo];
        int sysExParameterValue = parameterValue + PartialConstants.offset[parameterNo];
        LogicTools.ValidateRange("sysEx parameter", sysExParameterValue, 0, 127, autoCorrect: false);
        byte[] sysExAddr = TempPartialAddress(parameterNo, partialNo);
        // ensure no negative values are passed to device
        byte[] sysExData = { Convert.ToByte(sysExParameterValue) };
        SendMessage(sysExAddr, sysExData);
        SendText(parameterName + ": " + MT32Strings.PartialParameterValueText(parameterNo, parameterValue));
    }

    public static void SendAllPartialParameters(TimbreStructure t)
    {
        blockMT32text = true;
        for (int partialNo = 0; partialNo < 4; partialNo++)
        {
            ApplyPartialParameters(t, partialNo);
        }
        blockMT32text = false;
        SendText("Loaded " + t.GetTimbreName());
    }

    //send all partial parameters to device
    public static void ApplyPartialParameters(TimbreStructure t, int partialNo)
    {
        byte[] sysExAddr = TempPartialAddress(parameter: 0x00, partialNo);
        byte[] sysExData = new byte[PARAMETER_COUNT];
        for (int parameterNo = 0; parameterNo < PARAMETER_COUNT; parameterNo++)
        {
            sysExData[parameterNo] = t.GetSysExParameter(partialNo, parameterNo);
        }
        SendMessage(sysExAddr, sysExData);
        if (Midi.hardwareMT32)
        {
            //avoid buffer overflow on hardware MT-32
            Thread.Sleep(50);
        }
    }

    /// <summary>
    /// Sends parameter change to device and show text on device display
    /// </summary>
    public static void SendPCMBankNo(int partialNo, int sysExValue)
    {
        string bankNo = "1";
        if (sysExValue > 1)
        {
            bankNo = "2";
        }

        byte[] sysExAddr = TempPartialAddress(parameter: 0x04, partialNo);
        byte[] sysExData = { (byte)sysExValue };
        SendMessage(sysExAddr, sysExData);
        SendText("PCM Bank Select = " + bankNo);
    }

    /// <summary>
    /// Sends updated partial structures to device
    /// </summary>
    public static void UpdatePartialStructures(int partial1Structure, int partial2Structure)
    {
        //temporary timbre area, partial mute status
        byte[] sysExAddr = { 0x04, 0x00, 0x0A };
        byte[] sysExData = { (byte)partial1Structure, (byte)partial2Structure };
        SendMessage(sysExAddr, sysExData);
    }

    public static void UpdatePartialMuteStatus(bool[] partialMuteStatus, int activePartialNo)
    {
        //temporary timbre area, partial mute status
        byte[] sysExAddr = { 0x04, 0x00, 0x0C };
        byte[] sysExData = { PartialMuteValue(partialMuteStatus) };
        //send updated partial mute status to device
        SendMessage(sysExAddr, sysExData);
        //send partial status to MT-32 screen
        DisplayPartialMuteStatus(partialMuteStatus, activePartialNo);

        static void DisplayPartialMuteStatus(bool[] partialMuteStatus, int activePartialNo)
        {
            SendText("Partial " + (activePartialNo + 1).ToString() + " " + MT32Strings.OnOffStatus(!partialMuteStatus[activePartialNo]) + " (" + MT32Strings.PartialStatus(partialMuteStatus) + ")");
        }
    }

    public static byte PartialMuteValue(bool[] partialMuteStatus)
    {
        //order right to left
        Array.Reverse(partialMuteStatus);
        byte sum = 0;
        //convert boolean bits representing individual partial mute states into byte value for sysex message
        foreach (bool partialMuted in partialMuteStatus)
        {
            sum <<= 1;
            if (!partialMuted)
            {
                sum |= 1;
            }
        }
        //order left to right
        Array.Reverse(partialMuteStatus);
        return sum;
    }

    /// <summary>
    /// Send text string of exactly 20 characters to MT-32 LED matrix display
    /// </summary>
    public static void SendText(string textMessage)
    {
        if (blockMT32text || !sendTextToMT32)
        {
            return;
        }

        textMessage = ParseTools.MakeNCharsLong(textMessage, 20);
        // start of text display register
        byte[] sysExAddr = { 0x20, 0x00, 0x00 };
        byte[] sysExData = Encoding.ASCII.GetBytes(textMessage);
        SendMessage(sysExAddr, sysExData);
    }

    public static void SendTimbreName(string timbreName)
    {
        timbreName = ParseTools.MakeNCharsLong(timbreName, 10);
        // start of temp patch name register
        byte[] sysExAddr = { 0x04, 0x00, 0x00 };
        // convert string to ASCII values
        byte[] sysExData = Encoding.ASCII.GetBytes(timbreName);
        SendMessage(sysExAddr, sysExData);
    }

    public static void SendSustainValue(bool sustainStatus)
    {
        string parameterName = "Sustain";
        //temporary timbre area, sustain on/off register
        byte[] sysExAddr = { 0x04, 0x00, 0x0D };
        byte[] sysExData = { (byte)LogicTools.BoolToInt(!sustainStatus) };
        SendMessage(sysExAddr, sysExData);
        SendText(parameterName + " " + MT32Strings.OnOffStatus(sustainStatus));
    }

    public static void SendMT32Reset()
    {
        if (!allowReset)
        {
            ConsoleMessage.SendLine("Device reset ignored");
            return;
        }
        byte[] sysExData = { START_OF_DATA_BLOCK, MANUFACTURER_ID, DEVICE_ID, MODEL_ID, TX, 0x7F, 0x01, END_OF_DATA_BLOCK };
        SendSysExData(sysExData);
        SendText("Device reset");
        ConsoleMessage.SendLine("Device reset");
    }

    /// <summary>
    /// Collates MT32 SysEx message from constant parameters, address and data bytes plus Roland checksum
    /// </summary>
    public static void SendMessage(byte[] sysExAddr, byte[] sysExData)
    {
        //determine length (in bytes) of full SysEx message
        int sysExMessageLength = sysExData.Length + 10;
        byte[] sysExMessage = new byte[sysExMessageLength];
        //set fixed parameters
        sysExMessage[0] = START_OF_DATA_BLOCK;
        sysExMessage[1] = MANUFACTURER_ID;
        sysExMessage[2] = DEVICE_ID;
        sysExMessage[3] = MODEL_ID;
        sysExMessage[4] = TX;
        for (int i = 0; i < 3; i++)
        {
            //set address bytes
            sysExMessage[i + 5] = sysExAddr[i];
        }
        for (int i = 0; i < sysExData.Length; i++)
        {
            //set data bytes
            sysExMessage[i + 8] = sysExData[i];
        }
        //calculate checksum byte
        sysExMessage[sysExData.Length + 8] = CheckSum(sysExAddr, sysExData);
        //set message end byte
        sysExMessage[sysExData.Length + 9] = END_OF_DATA_BLOCK;
        //send to MIDI Out
        SendSysExData(sysExMessage);

        static byte CheckSum(byte[] sysExAddr, byte[] sysExData)
        {
            int valueSum = 0x00;

            //calculate sum of all values in sysExAddr[] and sysExData[]
            for (int i = 0; i < 3; i++)
            {
                valueSum += sysExAddr[i];
            }
            for (int i = 0; i < sysExData.Length; i++)
            {
                valueSum += sysExData[i];
            }
            return RolandChecksum(valueSum);
        }
    }

    /// <summary>
    /// Sends sysex data package to active MIDI Out device
    /// </summary>
    private static void SendSysExData(byte[] sysExMessage)
    {
        if (blockSysExMessages)
        {
            return;
        }

        uploadInProgress = true;
        
        //close any existing MIDI connections to prevent clash between SysEx data and note on/off data
        Midi.CloseInputDevice();

        //Midi.CloseOutputDevice();
        
        try
        {
            //Midi.Out = new MidiOut(Midi.OutDeviceIndex);
            if (Midi.Out != null)
            {
                Midi.Out.SendBuffer(sysExMessage);
            }

            //Midi.Out.Dispose();
        }
        catch
        {
            ConsoleMessage.SendLine("Error: Cannot open selected MIDI Out device\\nPlease close any conflicting MIDI applications and restart MT-32 Editor.");

            //midiOutError = true;
        }

        uploadInProgress = false;
        Midi.ReopenInputDevice();
    }

    public static void SendMemoryTimbre(int timbreNo, TimbreStructure timbre)
    {
        byte[] sysExAddress = MemoryTimbreAddress(timbreNo);
        SendTimbre(timbreNo, timbre, sysExAddress);
    }

    public static void PreviewTimbre(int timbreNo, TimbreStructure timbre)
    {
        //timbre temp area 1
        byte[] sysExAddress = { 0x04, 0x00, 0x00 };
        SendTimbre(timbreNo, timbre, sysExAddress);
        if (Midi.hardwareMT32)
        {
            Thread.Sleep(100);
        }
    }

    public static void SendTimbre(int timbreNo, TimbreStructure timbre, byte[] sysExAddress)
    {
        byte[] sysExData = new byte[246];
        byte[] timbreName = Encoding.ASCII.GetBytes(ParseTools.MakeNCharsLong(timbre.GetTimbreName(), 10));
        for (int i = 0; i < 10; i++)
        {
            sysExData[i] = timbreName[i];
        }
        ConsoleMessage.SendLine("Timbre #" + (timbreNo + 1).ToString() + " [" + timbre.GetTimbreName() + "] sent to device.");
        sysExData[10] = (byte)timbre.GetPart12Structure();
        sysExData[11] = (byte)timbre.GetPart34Structure();
        sysExData[12] = PartialMuteValue(timbre.GetPartialMuteStatus());
        if (timbre.GetSustainStatus())
        {
            sysExData[13] = 0;
        }
        else
        {
            sysExData[13] = 1;
        }

        int byteNo = 14;
        for (int partialNo = 0; partialNo < 4; partialNo++)
        {
            for (int parameterNo = 0; parameterNo < 58; parameterNo++)
            {
                sysExData[byteNo] = timbre.GetSysExParameter(partialNo, parameterNo);
                byteNo++;
            }
        }
        SendMessage(sysExAddress, sysExData);
    }

    /// <summary>
    /// Sends rhythm bank parameters to device
    /// </summary>
    public static void SendRhythmKey(Rhythm rhythmKey, int keyNo)
    {
        byte[] sysExAddr = RhythmKeyAddress(keyNo);
        byte[] sysExData = new byte[4];
        for (int parameterNo = 0; parameterNo < 4; parameterNo++)
        {
            sysExData[parameterNo] = (byte)rhythmKey.GetParameterSysExValue(parameterNo);
        }
        SendMessage(sysExAddr, sysExData);
    }

    /// <summary>
    /// Send multiple rhythm keys to device
    /// </summary>
    public static void SendRhythmKeyBlock(Rhythm[] rhythmData, int firstKeyNo, int lastKeyNo)
    {
        for (int keyNo = firstKeyNo; keyNo < lastKeyNo + 1; keyNo++)
        {
            int bankNo = keyNo - 24;
            SendRhythmKey(rhythmData[bankNo], keyNo);
        }
    }
}
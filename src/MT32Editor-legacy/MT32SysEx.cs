using System.Text;
using System;
using System.Threading;
namespace MT32Edit_legacy;

/// <summary>
/// Tools to create and send MT32-compatible system exclusive messages
/// </summary>
internal static class MT32SysEx
{
    // MT32Edit: MT32SysEx class (static)
    // S.Fryers Apr 2024

    public const byte START_OF_DATA_BLOCK = 0xF0;   //SysEx message blocks start with F0
    public const byte MANUFACTURER_ID = 0x41;       //Manufacturer ID (Roland)
    public const byte DEFAULT_DEVICE_ID = 0x10;     //Default device ID (17)
    public const byte MODEL_ID = 0x16;              //Model ID for MT-32
    public const byte RX = 0x11;                    //Receive SysEx data from device
    public const byte TX = 0x12;                    //Transmit SysEx data to device
    public const byte RESET = 0x7F;                 //MT-32 reset
    public const byte END_OF_DATA_BLOCK = 0xF7;     //SysEx message blocks terminate with F7

    public const int MAX_BLOCK_LENGTH = 270;        //maximum length (in bytes) of SysEx data block
    public const int NO_OF_PARTIAL_PARAMETERS = TimbreStructure.NO_OF_PARAMETERS;  
                                                    //no. of parameters in each partial
    public const int PARTIAL_ADDRESS_OFFSET = 0x0E; //partial parameters start at address offset 0x0E

    public const int NO_OF_SYSTEM_PARAMETERS = 0x17;//no of parameters in system area
    public const int MT32_DELAY = 150;              //no of milliseconds to delay between SysEx messages to avoid MT-32 hardware buffer overflow



    /// <summary>
    /// Set to true whilst long SysEx uploads are occurring. MIDI Thru functionality will be disabled.
    /// </summary>
    public static bool uploadInProgress { get; set; } = false;

    /// <summary>
    /// If set to true, short delay will be added between SysEx messages to avoid MT-32 hardware buffer overflow
    /// </summary>
    public static bool hardwareMT32Connected { get; set; } = true;

    /// <summary>
    /// If set to true, parameter changes will be displayed on MT-32 text display.
    /// </summary>
    public static bool sendTextToMT32 { get; set; } = true;

    /// <summary>
    /// If set to true, blocks all text messages from being sent regardless of sendTextToMT32 status.
    /// </summary>
    public static bool blockMT32text { get; set; } = false;

    /// <summary>
    /// If set to true, no system exclusive data will be sent to the selected MIDI Out device
    /// </summary>
    public static bool blockSysExMessages { get; set; } = false;

    /// <summary>
    /// If set to true, will pass any MT-32 reset messages to the selected MIDI Out device.
    /// </summary>
    public static bool allowReset { get; set; } = false;

    /// <summary>
    /// User-configurable device ID. Devices other than hardware MT-32 will only respond to the default value.
    /// </summary>
    public static byte DeviceID { get; set; } = DEFAULT_DEVICE_ID;

    /// <summary>
    /// If set to true, will show content of SysEx messages in the console window to assist with debugging.
    /// </summary>
    public static bool echoSysExData {  get; set; } = false;

    private static readonly int channelNo = 1;
    private static byte[]? previousSysExMessage;

    /// <summary>
    /// Returns Roland-compatible SysEx checksum value
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

    /// <summary>
    /// If value of least significant byte exceeds 0x7F (7-bit maximum), wrap value and increment next significant byte
    /// </summary>
    private static int[] WrapBytes(int[] addr)
    {
        while (addr[addr.Length - 1] > 0x7F)
        {
            addr[addr.Length - 2] += 0x01;
            addr[addr.Length - 1] -= 0x80;
        }
        return addr;
    }

    /// <summary>
    /// Calculates address of specific patch memory area
    /// </summary>
    public static byte[] PatchAddress(int patchNo)
    {
        LogicTools.ValidateRange("Patch No", patchNo, 0, MT32State.NO_OF_PATCHES - 1, autoCorrect: false);
        int[] addr = new int[2];
        addr[0] = 0x00;
        addr[1] = patchNo * 8;
        addr = WrapBytes(addr);
        byte[] sysExAddr = { 0x05, Convert.ToByte(addr[0]), Convert.ToByte(addr[1]) };
        return sysExAddr;
    }

    /// <summary>
    /// Calculates address of specific rhythm bank key area
    /// </summary>
    private static byte[] RhythmKeyAddress(int keyNo)
    {
        int[] addr = new int[2];
        addr[0] = 0x01;
        addr[1] = 0x10 + ((keyNo - RhythmConstants.KEY_OFFSET) * 4);
        addr = WrapBytes(addr);
        byte[] sysExAddr = { 0x03, Convert.ToByte(addr[0]), Convert.ToByte(addr[1]) };
        return sysExAddr;
    }

    /// <summary>
    /// Calculates address of specific memory timbre
    /// </summary>
    public static byte[] MemoryTimbreAddress(int timbreNo)
    {
        LogicTools.ValidateRange("Timbre No", timbreNo, 0, MT32State.NO_OF_MEMORY_TIMBRES - 1, autoCorrect: false);
        byte[] addr = new byte[2];
        addr[0] = Convert.ToByte(timbreNo * 2);
        addr[1] = 0x00;
        byte[] sysExAddr = { 0x08, addr[0], addr[1] };
        return sysExAddr;
    }

    /// <summary>
    /// Calculates starting address of a specific timbre's partial
    /// </summary>
    public static byte[] PartialAddress(int timbreNo, int partialNo)
    {
        LogicTools.ValidateRange("Timbre No", timbreNo, 0, MT32State.NO_OF_MEMORY_TIMBRES - 1, autoCorrect: false);
        LogicTools.ValidateRange("Partial No", partialNo, 0, TimbreStructure.NO_OF_PARTIALS - 1, autoCorrect: false);
        int[] addr = new int[2];
        addr[0] = 0x00;
        addr[1] = PARTIAL_ADDRESS_OFFSET + partialNo * NO_OF_PARTIAL_PARAMETERS;
        addr[1] += timbreNo * 2;
        WrapBytes(addr);
        byte[] sysExAddr = { 0x08, Convert.ToByte(addr[0]), Convert.ToByte(addr[1]) };
        return sysExAddr;
    }

    /// <summary>
    /// Calculates address of specific temporary timbre area partial parameter
    /// </summary>
    private static byte[] TempPartialAddress(int parameter, int partial)
    {
        LogicTools.ValidateRange("Parameter No", parameter, 0, NO_OF_PARTIAL_PARAMETERS - 1, autoCorrect: false);
        LogicTools.ValidateRange("Partial No", partial, 0, 3, autoCorrect: false);
        int[] addr = new int[2];
        addr[0] = 0x00;
        addr[1] = parameter + PARTIAL_ADDRESS_OFFSET + (NO_OF_PARTIAL_PARAMETERS * partial);
        addr = WrapBytes(addr);
        byte[] sysExAddr = { 0x04, Convert.ToByte(addr[0]), Convert.ToByte(addr[1]) };
        return sysExAddr;
    }

    /// <summary>
    /// Returns system parameters in sysEx format
    /// </summary>
    public static byte[] GetSystemParameters(SystemLevel system)
    {
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
        return sysExData;
    }

    /// <summary>
    /// Packages system area data for delivery to MIDI device
    /// </summary>
    public static void SendSystemParameters(SystemLevel system)
    {
        byte[] sysExAddr = { 0x10, 0x00, 0x00 };
        byte[] sysExData = GetSystemParameters(system);
        SendMessage(sysExAddr, sysExData);
    }

    /// <summary>
    /// Packages a specified range of patch data for delivery to MIDI device
    /// </summary>
    public static void SendPatchBlock(Patch[] patchData, int firstPatchNo, int lastPatchNo)
    {
        //send multiple patches to device
        for (int patchNo = firstPatchNo; patchNo < lastPatchNo + 1; patchNo++)
        {
            SendPatchData(patchData, patchNo);
        }
    }

    /// <summary>
    /// Packages a single block of patch data for delivery to MIDI device
    /// </summary>
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

    /// <summary>
    /// Packages a single block of patch data for delivery to MIDI device, along with program change and text showing changed parameter value
    /// </summary>
    public static void SendPatchParameterData(Patch[] patchData, int patchNo, int parameterNo)
    {
        LogicTools.ValidateRange("Parameter No", parameterNo, 0, 7, autoCorrect: false);
        //send patch parameters to device
        SendPatchData(patchData, patchNo);
        Midi.SendProgramChange(patchNo, channelNo);
        SendText($"{MT32Strings.patchParameterNames[parameterNo]}: {MT32Strings.PatchParameterValueText(parameterNo, patchData[patchNo].GetParameterUIValue(parameterNo))}");
    }

    /// <summary>
    /// Sends timbre name, partial mute status and sustain status sysEx data to MIDI device
    /// </summary>
    private static void UpdateTimbreParameters(TimbreStructure timbre)
    {
        blockMT32text = true;
        SendTimbreName(timbre.GetTimbreName());
        UpdatePartialStructures(timbre.GetPart12Structure(), timbre.GetPart34Structure());
        UpdatePartialMuteStatus(timbre.GetPartialMuteStatus(), 0);
        SendSustainValue(timbre.GetSustainStatus());
        blockMT32text = false;
    }

    /// <summary>
    /// Sends whole timbre's sysEx data to MIDI device
    /// </summary>
    public static void SendAllSysExParameters(TimbreStructure timbre)
    {
        UpdateTimbreParameters(timbre);
        SendAllPartialParameters(timbre);
    }

    /// <summary>
    /// Sends parameter change to device and shows text on device display
    /// </summary>
    public static void SendPartialParameter(int partialNo, byte parameterNo, int parameterValue)
    {
        string parameterName = MT32Strings.partialParameterNames[parameterNo];
        int sysExParameterValue = parameterValue + PartialConstants.offset[parameterNo];
        LogicTools.ValidateRange("Partial No", partialNo, 0, 3, autoCorrect: false);
        LogicTools.ValidateRange("Parameter No", parameterNo, 0, NO_OF_PARTIAL_PARAMETERS  - 1, autoCorrect: false);
        LogicTools.ValidateRange("Parameter Value", sysExParameterValue, 0, 127, autoCorrect: false);
        byte[] sysExAddr = TempPartialAddress(parameterNo, partialNo);
        // ensure no negative values are passed to device
        byte[] sysExData = { Convert.ToByte(sysExParameterValue) };
        SendMessage(sysExAddr, sysExData);
        SendText($"{parameterName}: {MT32Strings.PartialParameterValueText(parameterNo, parameterValue)}");
    }

    /// <summary>
    /// Sends all partial parameters to device
    /// </summary>
    private static void SendAllPartialParameters(TimbreStructure timbre)
    {
        bool keepBlocking = blockMT32text;
        blockMT32text = true;
        for (int partialNo = 0; partialNo < TimbreStructure.NO_OF_PARTIALS; partialNo++)
        {
            ApplyPartialParameters(timbre, partialNo);
        }
        if (!keepBlocking)
        {
            blockMT32text = false;
        }
        SendText("Loaded " + timbre.GetTimbreName());
    }

    /// <summary>
    /// Sends all parameters for specified partial to device
    /// </summary>
    public static void ApplyPartialParameters(TimbreStructure timbre, int partialNo)
    {
        byte[] sysExAddr = TempPartialAddress(parameter: 0x00, partialNo);
        byte[] sysExData = new byte[NO_OF_PARTIAL_PARAMETERS];
        for (int parameterNo = 0; parameterNo < NO_OF_PARTIAL_PARAMETERS; parameterNo++)
        {
            sysExData[parameterNo] = timbre.GetSysExParameter(partialNo, parameterNo);
        }
        SendMessage(sysExAddr, sysExData);
        MT32Delay();
    }

    /// <summary>
    /// Adds short delay to avoid buffer overflow on hardware MT-32
    /// </summary>
    private static void MT32Delay()
    {
        if (hardwareMT32Connected)
        {   
            Thread.Sleep(MT32_DELAY);
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
        SendText($"PCM Bank Select = {bankNo}");
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

    /// <summary>
    /// Sends updated partialMuteStatus to device
    /// </summary>
    public static void UpdatePartialMuteStatus(bool[] partialMuteStatus, int activePartialNo)
    {
        //temporary timbre area, partial mute status
        byte[] sysExAddr = { 0x04, 0x00, 0x0C };
        byte[] sysExData = { PartialMuteValue(partialMuteStatus) };
        //send updated partial mute status to device
        SendMessage(sysExAddr, sysExData);
        //send partial status to MT-32 screen
        SendText($"Partial {activePartialNo + 1} {MT32Strings.OnOffStatus(!partialMuteStatus[activePartialNo])} ({MT32Strings.PartialStatus(partialMuteStatus)})");
    }

    /// <summary>
    /// Returns sysEx byte value equivalent of 4-bit partialMuteStatus array
    /// </summary>
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

    /// <summary>
    /// Sends timbreName to device
    /// </summary>
    public static void SendTimbreName(string timbreName)
    {
        timbreName = ParseTools.MakeNCharsLong(timbreName, 10);
        // start of temp patch name register
        byte[] sysExAddr = { 0x04, 0x00, 0x00 };
        // convert string to ASCII values
        byte[] sysExData = Encoding.ASCII.GetBytes(timbreName);
        SendMessage(sysExAddr, sysExData);
    }

    /// <summary>
    /// Sends sustainStatus to device
    /// </summary>
    public static void SendSustainValue(bool sustainStatus)
    {
        string parameterName = "Sustain";
        //temporary timbre area, sustain on/off register
        byte[] sysExAddr = { 0x04, 0x00, 0x0D };
        byte[] sysExData = { (byte)LogicTools.BoolToInt(!sustainStatus) };
        SendMessage(sysExAddr, sysExData);
        SendText($"{parameterName} {MT32Strings.OnOffStatus(sustainStatus)}");
    }

    /// <summary>
    /// Sends MT-32 reset message to device, if permitted to do so
    /// </summary>
    public static bool RequestMT32Reset()
    {
        if (!allowReset)
        {
            return false;
        }
        ResetMT32();
        return true;
    }

    /// <summary>
    /// Sends MT-32 reset message to device
    /// </summary>
    public static void ResetMT32()
    {
        byte[] sysExData = { START_OF_DATA_BLOCK, MANUFACTURER_ID, DeviceID, MODEL_ID, TX, 0x7F, 0x01, END_OF_DATA_BLOCK };
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
        sysExMessage[2] = DeviceID;
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
    /// Returns true if sysExMessage matches global previousSysExMessage
    /// </summary>

    private static bool MatchesPreviousMessage(byte[] sysExMessage)
    {
        if (sysExMessage is null || previousSysExMessage is null || sysExMessage.Length != previousSysExMessage.Length)
        {
            return false;
        }
        for (int i = 0; i < sysExMessage.Length; i++)
        {
            if (sysExMessage[i] != previousSysExMessage[i])
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Sends sysex data package to active MIDI Out device
    /// </summary>
    private static void SendSysExData(byte[] sysExMessage)
    {
        if (blockSysExMessages || MatchesPreviousMessage(sysExMessage))
        {
            return;
        }
        uploadInProgress = true;
        Midi.SendSysExMessage(sysExMessage);
        if (echoSysExData)
        {
            SendSysExDataToConsole(sysExMessage);
        }
        uploadInProgress = false;
        previousSysExMessage = (byte[])sysExMessage.Clone();
    }

    /// <summary>
    /// Sends SysEx data to text console in hex format- useful for debugging
    /// </summary>
    private static void SendSysExDataToConsole(byte[] sysExMessage)
    {
        ConsoleMessage.SendVerboseString($"Sending data to device: ", ConsoleColor.Green);
        ConsoleMessage.SendVerboseString($"{sysExMessage.Length} bytes [", ConsoleColor.Cyan);
        for (int i = 0; i < sysExMessage.Length; i++)
        {
            string hexString = sysExMessage[i].ToString("X");
            if (hexString.Length == 1)
            {
                hexString = $"0{hexString}";
            }
            ConsoleMessage.SendVerboseString($"{hexString}", ConsoleColor.White);
            if (i < sysExMessage.Length - 1)
            {
                ConsoleMessage.SendVerboseString(" ");
            }
        }
        ConsoleMessage.SendVerboseLine("]", ConsoleColor.Cyan);
    }

    public static void SendMemoryTimbre(int timbreNo, TimbreStructure timbre)
    {
        byte[] sysExAddress = MemoryTimbreAddress(timbreNo);
        SendTimbre(timbreNo, timbre, sysExAddress);
    }

    /// <summary>
    /// Sends timbre parameters to device,
    /// targeting timbre temp area 1
    /// </summary>
    public static void PreviewTimbre(int timbreNo, TimbreStructure timbre)
    {
        byte[] sysExAddress = { 0x04, 0x00, 0x00 };
        SendTimbre(timbreNo, timbre, sysExAddress);
        MT32Delay();
    }

    /// <summary>
    /// Sends timbre parameters to device
    /// </summary>
    private static void SendTimbre(int timbreNo, TimbreStructure timbre, byte[] sysExAddress)
    {
        byte[] sysExData = new byte[(TimbreStructure.NO_OF_PARTIALS * NO_OF_PARTIAL_PARAMETERS) + PARTIAL_ADDRESS_OFFSET]; //246
        byte[] timbreName = Encoding.ASCII.GetBytes(ParseTools.MakeNCharsLong(timbre.GetTimbreName(), 10));
        for (int i = 0; i < 10; i++)
        {
            sysExData[i] = timbreName[i];
        }
        if (timbre.GetTimbreName() != MT32Strings.EMPTY && sysExAddress[0] != 0x08)
        {
            ConsoleMessage.SendLine($"Timbre #{timbreNo + 1} [{timbre.GetTimbreName()}] sent to device.", ConsoleColor.Blue);
        }
        sysExData[10] = (byte)timbre.GetPart12Structure();
        sysExData[11] = (byte)timbre.GetPart34Structure();
        sysExData[12] = PartialMuteValue(timbre.GetPartialMuteStatus());
        sysExData[13] = (byte)(timbre.GetSustainStatus() ? 0 : 1);
        int byteNo = PARTIAL_ADDRESS_OFFSET;
        for (int partialNo = 0; partialNo < TimbreStructure.NO_OF_PARTIALS; partialNo++)
        {
            for (int parameterNo = 0; parameterNo < NO_OF_PARTIAL_PARAMETERS; parameterNo++)
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
            int bankNo = keyNo - RhythmConstants.KEY_OFFSET;
            SendRhythmKey(rhythmData[bankNo], keyNo);
        }
    }
}
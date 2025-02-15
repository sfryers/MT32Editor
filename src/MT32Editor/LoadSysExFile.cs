using System.Text;
using System.IO;
using System.Windows.Forms;
using System;
#if NET5_0_OR_GREATER
namespace MT32Edit;
#else
namespace MT32Edit_legacy;
#endif

/// <summary>
/// Tools to load MT-32 System Exclusive data files from local filesystem
/// </summary>

internal static class LoadSysExFile
{
    // MT32Edit: LoadSysExFile class (static)
    // S.Fryers May 2024 

    /// <summary>
    /// If true, ignores system area data when loading SysEx file
    /// </summary>
    public static bool ignoreSystemArea { get; set; } = false;

    private static bool validSysExDataFound = false;
    private static MT32State memoryState = new MT32State();

    // Define expected byte positions for each partial definition
    private const int FIRST_PARTIAL_START = MT32SysEx.PARTIAL_ADDRESS_OFFSET; //14
    private const int SECOND_PARTIAL_START = MT32SysEx.PARTIAL_ADDRESS_OFFSET + MT32SysEx.NO_OF_PARTIAL_PARAMETERS; //72
    private const int FIRST_PARTIAL_END = SECOND_PARTIAL_START - 1; //71
    private const int SECOND_PARTIAL_END = FIRST_PARTIAL_END + MT32SysEx.NO_OF_PARTIAL_PARAMETERS; //129
    private const int THIRD_PARTIAL_START = SECOND_PARTIAL_START + MT32SysEx.NO_OF_PARTIAL_PARAMETERS; //130
    private const int THIRD_PARTIAL_END = SECOND_PARTIAL_END + MT32SysEx.NO_OF_PARTIAL_PARAMETERS; //187
    private const int FOURTH_PARTIAL_START = THIRD_PARTIAL_START + MT32SysEx.NO_OF_PARTIAL_PARAMETERS; //188
    private const int FOURTH_PARTIAL_END = THIRD_PARTIAL_END + MT32SysEx.NO_OF_PARTIAL_PARAMETERS - 1; //245

    private const int INVALID = -1;

    /// <summary>
    /// Loads SysEx data into the currentMemoryState. If successful, return the name of the opened file, otherwise "Cancelled" or "Error".
    /// Overloaded method: if no filename is provided, then a file browser window will be opened
    /// </summary>
    public static string Load(MT32State currentMemoryState)
    {
        using (var loadSysExDialog = new OpenFileDialog())
        {
            loadSysExDialog.Filter = $"MIDI & SysEx files|*.syx; *.mid|SysEx files|*.syx|MIDI files|*.mid|All files|*.*";
            loadSysExDialog.Title = "Load SysEx File";
            loadSysExDialog.CheckFileExists = true;
            loadSysExDialog.CheckPathExists = true;
            if (loadSysExDialog.ShowDialog() != DialogResult.OK)
            {
                return FileTools.CANCELLED; //file error or dialogue cancelled
            }

            if (ParseTools.IsNullOrWhiteSpace(loadSysExDialog.FileName))
            {
                return FileTools.ERROR; //No file specified, abort loading process
            }
            string fileName = loadSysExDialog.FileName;
            Load(currentMemoryState, fileName);
            return fileName;
        }
    }

    /// <summary>
    /// Loads SysEx data into the currentMemoryState. If successful, return the name of the opened file, otherwise "Cancelled" or "Error".
    /// Overloaded method: if no filename is provided, then a file browser window will be opened
    /// </summary>
    public static string Load(MT32State currentMemoryState, string fileName)
    {
        FileStream file = File.OpenRead(fileName);
        memoryState = currentMemoryState;
        validSysExDataFound = false;
        ConsoleMessage.SendLine($"Loading {fileName}");
        validSysExDataFound = ReadSysExFile(file);
        file.Close();

        if (!validSysExDataFound)
        {
            MessageBox.Show($"File '{Path.GetFileName(fileName)}' does not contain any valid MT-32 SysEx data.", "MT-32 Editor");
            return FileTools.EMPTY; //Not a valid file, abort loading process
        }
        //All ok, continue loading process
        MT32SysEx.blockMT32text = true;
        using (Form loadSysExForm = new FormLoadSysEx(memoryState, requestClearMemory: false))
        {
            try
            {
                loadSysExForm.ShowDialog();
            }
            catch (Exception)
            {
                return FileTools.ERROR;
            }
            memoryState.SetUpdateTime();
            MT32SysEx.blockMT32text = false;
            return fileName;
        }
    }

    private static bool IsMidiFile(FileStream file)
    {
        return Path.GetExtension(file.Name).ToLower() == FileTools.MIDI_FILE;
    }

    private static bool ReadSysExFile(FileStream file)
    {
        bool validDataFound = false;
        MT32SysEx.blockSysExMessages = true;
        int fileDataValue = 0;
        while (fileDataValue != -1)
        {
            fileDataValue = file.ReadByte();
            if (fileDataValue == MT32SysEx.START_OF_DATA_BLOCK && ReadSysExDataBlock(file) && !validDataFound)
            {
                validDataFound = true;
            }
        }
        if (validDataFound)
        {
            ConsoleMessage.SendVerboseLine("End of SysEx File", ConsoleColor.Red);
        }
        else
        {
            ConsoleMessage.SendLine("No SysEx data found", ConsoleColor.Red);
        }
        MT32SysEx.blockSysExMessages = false;
        return validDataFound;
    }

    private static bool ReadSysExDataBlock(FileStream file)
    {
        int[] sysExDataBlock = new int[MT32SysEx.MAX_BLOCK_LENGTH];
        int filePointer = 0;
        int fileDataValue = 0;
        while (fileDataValue != -1)
        {
            fileDataValue = file.ReadByte();
            if (filePointer >= MT32SysEx.MAX_BLOCK_LENGTH)
            {
                //Data block too long, abort
                ConsoleMessage.SendVerboseLine("Data block too long, skipping.");
                return false;
            }
            if (fileDataValue == MT32SysEx.END_OF_DATA_BLOCK)
            {
                if (filePointer < 2)
                {
                    //Data block too short, abort
                    ConsoleMessage.SendVerboseLine("Data block too short, skipping.");
                    return false;
                }

                //remove checksum from end of array
                Array.Resize(ref sysExDataBlock, filePointer - 1);
                return ProcessSysExDataBlock(sysExDataBlock, IsMidiFile(file));
            }

            sysExDataBlock[filePointer] = fileDataValue;
            filePointer++;
        }
        return false;
    }

    private static bool ProcessSysExDataBlock(int[] sysExDataBlock, bool isMidiFile)
    {
        int dataBlockLength = sysExDataBlock.Length;
        int minBlockLength = 6;
        int offsetBytes = 0;
        if (IsMT32ResetCommand(sysExDataBlock))
        {
            ConsoleMessage.SendVerboseLine("MT-32 reset message found.");
            AttemptReset();
            return true;
        }
        if (isMidiFile)
        {
            offsetBytes = FindMidiDataOffset(dataBlockLength, sysExDataBlock);
        }

        if (sysExDataBlock.Length < (minBlockLength + offsetBytes))
        {
            ConsoleMessage.SendVerboseLine("Short data block found, ignoring.");
            return false;
        }
        if ((sysExDataBlock.Length < 8) || (sysExDataBlock[offsetBytes] != MT32SysEx.MANUFACTURER_ID) ||
            (sysExDataBlock[offsetBytes + 2] != MT32SysEx.MODEL_ID) || (sysExDataBlock[offsetBytes + 3] != MT32SysEx.TX))
        {
            ConsoleMessage.SendVerboseLine("non MT32-compatible data block found, ignoring.");
            return false;
        }

        int[] sysExAddress = new int[3];
        int[] sysExData = new int[sysExDataBlock.Length - 7];
        for (int i = 0; i < 3; i++)
        {
            //get memory address bytes
            sysExAddress[i] = (byte)sysExDataBlock[i + 4 + offsetBytes];
        }

        SendSysExDataToConsole(sysExDataBlock, offsetBytes);
        SendSysExAddressToConsole(sysExAddress);

        for (int i = 7; i < dataBlockLength - offsetBytes; i++)
        {
            //get data bytes
            sysExData[i - 7] = (byte)sysExDataBlock[i + offsetBytes];
        }

        if (!validSysExDataFound)
        {
            //reset memory state as soon as the first valid MT-32 sysex message is found
            memoryState.ResetAll(MT32SysEx.cm32LMode);
            validSysExDataFound = true;
        }

        switch (sysExAddress[0])
        {
            case 0x03:
                //Rhythm data starts at address {0x03, 0x01, 0x10}
                if (((sysExAddress[1] * 128) + sysExAddress[2]) > 137)
                {
                    ConsoleMessage.SendVerboseLine("[RHYTHM] ", ConsoleColor.Green);
                    ExtractRhythmData(sysExData, sysExAddress);
                }
                else
                {
                    ConsoleMessage.SendVerboseLine("[PATCH TEMP] - ignoring", ConsoleColor.Green);
                }
                break;

            case 0x05:
                ConsoleMessage.SendVerboseLine("[PATCH] ", ConsoleColor.Cyan);
                ExtractPatchData(sysExData, sysExAddress);
                break;

            case 0x08:
                ConsoleMessage.SendVerboseLine("[TIMBRE] ", ConsoleColor.Blue);
                ExtractTimbreData(sysExData, sysExAddress);
                break;

            case 0x10:
                if (ignoreSystemArea)
                {
                    ConsoleMessage.SendVerboseLine("[SYSTEM] - ignoring by user request", ConsoleColor.Red);
                }
                else
                {
                    ConsoleMessage.SendVerboseLine("[SYSTEM] ", ConsoleColor.Red);
                    ExtractSystemData(sysExData, sysExAddress);
                }
                break;

            case 0x20:
                ConsoleMessage.SendVerboseLine("[TEXT] ", ConsoleColor.Yellow);
                ExtractTextData(sysExData);
                break;

            default:
                break;
        }
        return true;
    }

    private static int FindMidiDataOffset(int dataBlockLength, int[] sysExDataBlock)
    {
        //For MIDI files, the first 1 or 2 byte values of SysExBlock should match SysExBlock.Length
        int offsetBytes = dataBlockLength > 127 ? 2 : 1;
        ConsoleMessage.SendVerboseLine($"MIDI file- SysEx block length {dataBlockLength - offsetBytes}");
        return offsetBytes;
    }

    private static void CheckDataBlockLength(int dataBlockLength, int statedLength)
    {
        if (dataBlockLength == (statedLength - 1))
        {
            ConsoleMessage.SendVerboseLine($"Data block length matches MIDI SysEx data ({statedLength - 1} bytes).");
        }
        else
        {
            //if check fails, show warning
            ConsoleMessage.SendVerboseLine($"Warning: Data block length mismatch: MIDI SysEx data suggests {statedLength - 1} bytes, actual block size {dataBlockLength} bytes.");
        }
    }

    private static void SendSysExAddressToConsole(int[] sysExAddress)
    {
        ConsoleMessage.SendLine($"SysEx Address = [{sysExAddress[0].ToString("X")} {sysExAddress[1].ToString("X")} {sysExAddress[2].ToString("X")}]", ConsoleColor.Magenta);
    }

    private static void SendSysExDataToConsole(int[] sysExDataBlock, int offsetBytes)
    {
        if (!MT32SysEx.echoSysExData)
        {
            return;
        }
        ConsoleMessage.SendVerboseString($"{Environment.NewLine}Processing data block, {(sysExDataBlock.Length - offsetBytes)} bytes [");
        for (int i = offsetBytes; i < sysExDataBlock.Length; i++)
        {
            string hexString = sysExDataBlock[i].ToString("X");
            if (hexString.Length == 1)
            {
                hexString = $"0{hexString}";
            }
            ConsoleMessage.SendVerboseString($"{hexString}", ConsoleColor.White);
            if (i < sysExDataBlock.Length - 1)
            {
                ConsoleMessage.SendVerboseString(" ");
            }
        }
        ConsoleMessage.SendVerboseLine("]");
    }

    private static bool IsMT32ResetCommand(int[] sysExData)
    {
        if (sysExData.Length != 5)
        {
            return false; //too short
        }

        if ((sysExData[0] != MT32SysEx.MANUFACTURER_ID) ||
            (sysExData[2] != MT32SysEx.MODEL_ID) ||
            (sysExData[3] != MT32SysEx.TX) ||
            (sysExData[4] != MT32SysEx.RESET))
        {
            return false; //not an MT-32 reset command
        }

        return true;
    }

    private static void AttemptReset()
    {
        if (MT32SysEx.RequestMT32Reset())
        {
            memoryState.ResetAll(MT32SysEx.cm32LMode);
        }
        else
        {
            ConsoleMessage.SendVerboseLine("Device reset ignored");
        }
    }

    private static void ExtractSystemData(int[] sysExData, int[] sysExAddress)
    {
        if (sysExAddress[1] != 0 || sysExAddress[2] > 0x16)
        {
            ConsoleMessage.SendVerboseLine("System data address invalid, ignoring.");
            return;
        }
        if (sysExData.Length + sysExAddress[2] > MT32SysEx.NO_OF_SYSTEM_PARAMETERS)
        {
            //remove any superfluous sysEx data values
            Array.Resize(ref sysExData, MT32SysEx.NO_OF_SYSTEM_PARAMETERS - sysExAddress[2]);
        }

        int[] systemData = GetCurrentSystemAreaStateAsArray();
        for (int parameterNo = 0; parameterNo < sysExData.Length; parameterNo++)
        {
            systemData[parameterNo + sysExAddress[2]] = sysExData[parameterNo];
        }
        SystemLevel systemConfig = memoryState.GetSystem();
        ConsoleMessage.SendLine("System data found, extracting...");
        systemConfig.SetMasterTune(systemData[0], autoCorrect: true);
        systemConfig.SetReverbMode(systemData[1], autoCorrect: true);
        systemConfig.SetReverbTime(systemData[2], autoCorrect: true);
        systemConfig.SetReverbLevel(systemData[3], autoCorrect: true);
        for (int part = 0; part < 9; part++)
        {
            systemConfig.SetPartialReserve(part, systemData[part + 4], autoCorrect: true);
            systemConfig.SetSysExMidiChannel(part, systemData[part + 13], autoCorrect: true);
        }
        systemConfig.SetMasterLevel(systemData[22], autoCorrect: true);
        return;
    }

    private static int[] GetCurrentSystemAreaStateAsArray()
    {
        int[] systemData = new int[MT32SysEx.NO_OF_SYSTEM_PARAMETERS];
        SystemLevel systemConfig = memoryState.GetSystem();
        systemData[0] = systemConfig.GetMasterTune();
        systemData[1] = systemConfig.GetReverbMode();
        systemData[2] = systemConfig.GetReverbTime();
        systemData[3] = systemConfig.GetReverbLevel();
        for (int part = 0; part < 9; part++)
        {
            systemData[part + 4] = systemConfig.GetPartialReserve(part);
            systemData[part + 13] = systemConfig.GetSysExMidiChannel(part);
        }
        systemData[22] = systemConfig.GetMasterLevel();
        return systemData;
    }

    private static void ExtractTextData(int[] sysExData)
    {
        int textLength = sysExData.Length;
        if (textLength > 20)
        {
            textLength = 20;
        }
        byte[] textChars = new byte[textLength];
        for (int charNo = 0; charNo < textLength; charNo++)
        {
            textChars[charNo] = (byte)sysExData[charNo];
        }
        string textMessage = Encoding.ASCII.GetString(textChars).Substring(0, textLength);
        bool message1Present = ParseTools.IsNullOrWhiteSpace(memoryState.GetSystem().GetMessage(0));
        int messageNo = LogicTools.BoolToInt(!message1Present);
        memoryState.GetSystem().SetMessage(messageNo, textMessage);
        if (!ParseTools.IsNullOrWhiteSpace(textMessage))
        {
            ConsoleMessage.SendLine($"Text found: {textMessage}", ConsoleColor.Yellow);
        }
    }

    private static void ExtractPatchData(int[] sysExData, int[] sysExAddress)
    {
        //A complete patch definition is 8 bytes, although the 8th byte is a dummy value.
        int patchLength = 8;
        //One 256-byte SysEx block can therefore contain up to 32 patches
        //Ignore data block if start address is not divisible by 8
        if (sysExAddress[2] % patchLength != 0)
        {
            ConsoleMessage.SendVerboseLine($"Patch data starting address is not divisible by 8, ignoring...");
            return;
        }
        int startingPatchNo = ((sysExAddress[1] * 128) + sysExAddress[2]) / 8;
        int noOfPatches = sysExData.Length / 8;
        if (sysExData.Length > 1 && sysExData.Length < 8)
        {
            //if the block only contains data for a single patch then try to extract it even if it's incomplete
            noOfPatches = 1;
            patchLength = sysExData.Length;
        }
        ConsoleMessage.SendLine($"{noOfPatches} patches found.");
        int byteNo = 0;
        for (int patchNo = startingPatchNo; patchNo < (noOfPatches + startingPatchNo); patchNo++)
        {
            for (int parameterNo = 0; parameterNo < patchLength; parameterNo++)
            {
                memoryState.GetPatch(patchNo).SetParameterSysExValue(parameterNo, sysExData[byteNo], autoCorrect: true);
                byteNo++;
            }
        }
        if (noOfPatches > 0)
        {
            ConsoleMessage.SendVerboseLine($"Patch {startingPatchNo + 1}-{startingPatchNo + noOfPatches} data found, extracting...");
        }
        else
        {
            ConsoleMessage.SendVerboseLine($"Incomplete data for Patch {startingPatchNo + 1}, ignoring...");
        }
    }

    /// <summary>
    /// Process rhythm settings:
    /// One 256-byte SysEx block can contain up to 64 rhythm keys.
    /// Bank 0 is located at address {0x03, 0x01, 0x10}
    /// </summary>
    /// <param name="sysExData"></param>
    /// <param name="sysExAddress"></param>
    private static void ExtractRhythmData(int[] sysExData, int[] sysExAddress)
    {

        int startingbankNo = ((sysExAddress[1] * 128) + sysExAddress[2] - 144) / 4;
        ConsoleMessage.SendVerboseLine($"Address {sysExAddress[0]} {sysExAddress[1]} {sysExAddress[2]}: Bank No {startingbankNo + 1}");
        int noOfKeys = sysExData.Length / 4;
        ConsoleMessage.SendVerboseLine($"{noOfKeys} keys found.");
        int byteNo = 0;
        int bankTotal = noOfKeys + startingbankNo;
        if (bankTotal > 84)
        {
            bankTotal = 84;
        }
        for (int bankNo = startingbankNo; bankNo < bankTotal; bankNo++)
        {
            for (int parameterNo = 0; parameterNo < 4; parameterNo++)
            {
                memoryState.GetRhythmBank(bankNo).SetParameterSysExValue(parameterNo, sysExData[byteNo], autoCorrect: true);
                byteNo++;
            }
        }
        ConsoleMessage.SendLine($"Data for keys {startingbankNo + 24}-{bankTotal + 23} found, extracting...");
    }

    private static void ExtractTimbreData(int[] sysExData, int[] sysExAddress)
    {
        //check whether timbre data contains data for some or all partials
        string timbreName;
        int startingAddress = GetStartPosition(sysExAddress);

        if (startingAddress == INVALID)
        {
            ConsoleMessage.SendVerboseLine($"Start address {startingAddress} does not align with partial data structure, ignoring.", ConsoleColor.Red);
            return;
        }

        int timbreNo = GetTimbreNo(sysExAddress);
        if (timbreNo < 0 || timbreNo > 63)
        {
            ConsoleMessage.SendVerboseLine("Timbre address invalid, ignoring.", ConsoleColor.Red);
            return;
        }

        SetTimbreParameters(sysExData, startingAddress, timbreNo);
        timbreName = memoryState.GetMemoryTimbre(timbreNo).GetTimbreName();
        if (timbreName != MT32Strings.EMPTY)
        {
            ConsoleMessage.SendLine($"Timbre #{timbreNo + 1} data found, extracting {timbreName}...", ConsoleColor.Blue);
        }
    }

    private static int GetTimbreNo(int[] sysExAddress)
    {
        return sysExAddress[1] / 2;
    }

    private static void SetTimbreParameters(int[] sysExData, int startAddress, int timbreNo)
    {
        string timbreName;
        TimbreStructure memoryTimbre = memoryState.GetMemoryTimbre(timbreNo);

        int firstPartial = FirstPartialNo(startAddress);
        int lastPartial = LastPartialNo(startAddress, sysExData.Length);

        if (startAddress == 0)
        {
            timbreName = ExtractTimbreName(sysExData);
            memoryTimbre.SetTimbreName(timbreName);
        }
        if (sysExData.Length + startAddress < (MT32SysEx.PARTIAL_ADDRESS_OFFSET - 1))
        {
            //exit if partial structure data is incomplete
            return;
        }
        SetPartialStatus(memoryTimbre, sysExData, startAddress);

        if (lastPartial == INVALID || firstPartial == INVALID)
        {
            //data block does not contain any valid partial definitions
            return;
        }
        ConsoleMessage.SendVerboseLine($"Analysing partials {firstPartial + 1} to {lastPartial + 1}", ConsoleColor.Red);
        for (int partialNo = firstPartial; partialNo < lastPartial + 1; partialNo++)
        {
            SetPartialParameters(memoryTimbre, sysExData, firstPartial, partialNo, startAddress);
        }
    }

    private static string ExtractTimbreName(int[] sysExData)
    {
        int nameLength = 10;
        if (sysExData.Length < nameLength)
        {
            nameLength = sysExData.Length;
        }
        byte[] timbreNameChars = new byte[10];
        for (int i = 0; i < nameLength; i++)
        {
            timbreNameChars[i] = (byte)sysExData[i];
        }
        string timbreName = Encoding.ASCII.GetString(timbreNameChars).Substring(0, 10);
        timbreName = ParseTools.RemoveTrailingSpaces(timbreName);
        return timbreName;
    }

    private static void SetPartialStatus(TimbreStructure memoryTimbre, int[] sysExData, int startAddress)
    {
        if (startAddress >= MT32SysEx.PARTIAL_ADDRESS_OFFSET)
        {
            return;
        }
        memoryTimbre.SetPart12Structure(sysExData[10 - startAddress], autoCorrect: true);
        memoryTimbre.SetPart34Structure(sysExData[11 - startAddress], autoCorrect: true);
        //need to invert value to get correct sustain state
        memoryTimbre.SetSustainStatus(!LogicTools.IntToBool(sysExData[13 - startAddress]));
        for (int partialNo = 0; partialNo < TimbreStructure.NO_OF_PARTIALS; partialNo++)
        {
            if ((sysExData[12 - startAddress] & (1 << partialNo)) != 0)
            {
                memoryTimbre.SetPartialMuteStatus(partialNo, false);
            }
            else
            {
                memoryTimbre.SetPartialMuteStatus(partialNo, true);
            }
        }
    }

    private static void SetPartialParameters(TimbreStructure memoryTimbre, int[] sysExData, int firstPartial, int partialNo, int startAddress)
    {
        for (int parameterNo = 0; parameterNo < MT32SysEx.NO_OF_PARTIAL_PARAMETERS; parameterNo++)
        {
            int byteNo = ((partialNo - firstPartial) * MT32SysEx.NO_OF_PARTIAL_PARAMETERS) + parameterNo;
            if (startAddress < MT32SysEx.PARTIAL_ADDRESS_OFFSET)
            {
                byteNo += MT32SysEx.PARTIAL_ADDRESS_OFFSET - startAddress;
            }
            if (byteNo >= sysExData.Length)
            {
                return;
            }
            memoryTimbre.SetSysExParameter(partialNo, parameterNo, sysExData[byteNo]);
        }
    }

    /// <summary>
    /// Returns position of sysExAddress relative to start position
    /// </summary>
    /// <param name="sysExAddress"></param>
    /// <returns></returns>
    private static int GetStartPosition(int[] sysExAddress)
    {
        int startPosition = 0;

        if (!LogicTools.DivisibleBy(sysExAddress[1], 2))
        {
            //middle byte has odd-numbered value, start position must be at least 128
            startPosition = 128;
        }
        startPosition += sysExAddress[2];
        switch (startPosition)
        {
            //verify that starting position aligns with start of either timbre name data, partial structure data, or partial 1-4 data.
            case 0:
            case 0x0A:
            case FIRST_PARTIAL_START:
            case SECOND_PARTIAL_START:
            case THIRD_PARTIAL_START:
            case FOURTH_PARTIAL_START:
                return startPosition; //start address is a valid position
            default:
                return INVALID; //start address does not align with structure- ignore block
        }
    }

    private static int FirstPartialNo(int startPosition)
    {
        //determine which partial no. the startPosition relates to.
        switch (startPosition)
        {
            case <= FIRST_PARTIAL_START:
                return 0; //partial no. 1
            case SECOND_PARTIAL_START:
                return 1; //partial no. 2
            case THIRD_PARTIAL_START:
                return 2; //partial no. 3
            case FOURTH_PARTIAL_START:
                return 3; //partial no. 4
            default:
                return INVALID; //start address does not align with structure- ignore block
        }
    }

    private static int LastPartialNo(int startPosition, int dataBlockLength)
    {
        //determine the last partial no. defined in the data block;
        switch (dataBlockLength + startPosition)
        {
            case >= FOURTH_PARTIAL_END:
                return 3; //partial no. 4
            case >= THIRD_PARTIAL_END:
                return 2; //partial no. 3
            case >= SECOND_PARTIAL_END:
                return 1; //partial no. 2
            case >= FIRST_PARTIAL_END:
                return 0; //partial no. 1
            default:
                return INVALID;
        }
    }
}

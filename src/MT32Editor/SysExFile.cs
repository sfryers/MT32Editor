using System.Text;

namespace MT32Edit;

internal static class SysExFile
{
    //
    // MT32Edit: SysExFile class (static)
    // S.Fryers Apr 2023
    // Tools to load/save MT-32 System Exclusive data files from/to local filesystem
    //

    private const int NO_OF_SYSTEM_PARAMS = 0x17;

    public static void Load(OpenFileDialog loadSysExDialog, MT32State memoryState)
    {
        int timbreNo = 0;
        loadSysExDialog.Filter = "MIDI System Exclusive message file|*.syx";
        loadSysExDialog.Title = "Load SysEx File";
        loadSysExDialog.CheckFileExists = true;
        loadSysExDialog.CheckPathExists = true;
        if (loadSysExDialog.ShowDialog() != DialogResult.OK) return; //file error or dialogue cancelled
        if (loadSysExDialog.FileName == "") return; //No file specified, abort loading process
        FileStream file = (FileStream)loadSysExDialog.OpenFile();
        MT32SysEx.blockMT32text = true;
        ReadSysExFile();
        file.Close();
        Form loadSysExForm = new FormLoadSysEx(memoryState, clearMemoryState: false);
        loadSysExForm.ShowDialog();
        memoryState.SetUpdateTime();
        MT32SysEx.blockMT32text = false;
        return;

        void ReadSysExFile()
        {
            memoryState.ResetAll();
            MT32SysEx.blockSysExMessages = true;
            int fileDataValue = 0;

            while (fileDataValue != -1)
            {
                fileDataValue = file.ReadByte();
                if (fileDataValue == MT32SysEx.START_OF_DATA_BLOCK) ReadSysExDataBlock();
            }
            ConsoleMessage.SendLine("End of SysEx File", ConsoleColor.Red);
            MT32SysEx.blockSysExMessages = false;
        }

        void ReadSysExDataBlock()
        {
            int[] sysExDataBlock = new int[MT32SysEx.MAX_BLOCK_LENGTH];
            int filePointer = 0;
            int fileDataValue = 0;
            while (fileDataValue != -1)
            {
                fileDataValue = file.ReadByte();
                if (filePointer > MT32SysEx.MAX_BLOCK_LENGTH)
                {
                    ConsoleMessage.SendLine("Data block too long, skipping.");
                    return;
                }
                if (fileDataValue == MT32SysEx.END_OF_DATA_BLOCK)
                {
                    if (filePointer < 2) return;
                    Array.Resize(ref sysExDataBlock, filePointer - 1); //remove checksum from end of array
                    ProcessSysExDataBlock(sysExDataBlock);
                    return;
                }
                sysExDataBlock[filePointer] = fileDataValue;
                filePointer++;
            }
        }

        void ProcessSysExDataBlock(int[] sysExDataBlock)
        {
            int dataBlockLength = sysExDataBlock.Length;
            if (IsMT32ResetCommand(sysExDataBlock))
            {
                ConsoleMessage.SendLine("MT-32 reset message found.");
                DoReset();
                return;
            }
            if (sysExDataBlock.Length < 6)
            {
                ConsoleMessage.SendLine("Short data block found, ignoring.");
                return;
            }
            if ((sysExDataBlock.Length < 8) || (sysExDataBlock[0] != MT32SysEx.MANUFACTURER_ID) || (sysExDataBlock[1] != MT32SysEx.DEVICE_ID) || (sysExDataBlock[2] != MT32SysEx.MODEL_ID) || (sysExDataBlock[3] != MT32SysEx.TX))
            {
                ConsoleMessage.SendLine("non MT32-compatible data block found, ignoring.");
                return;
            }
            ConsoleMessage.SendLine("Processing data block, " + sysExDataBlock.Length.ToString() + " bytes.");
            int[] sysExAddress = new int[3];
            int[] sysExData = new int[sysExDataBlock.Length - 7];
            for (int i = 4; i < 7; i++)
            {
                sysExAddress[i - 4] = (byte)sysExDataBlock[i];      //get memory address bytes
            }
            for (int i = 7; i < dataBlockLength; i++)
            {
                sysExData[i - 7] = (byte)sysExDataBlock[i];         //get data bytes
            }
            switch (sysExAddress[0])
            {
                case 0x03:
                    if (((sysExAddress[1] * 128) + sysExAddress[2]) > 137) //Rhythm data starts at address {0x03, 0x01, 0x10}
                    {
                        ConsoleMessage.SendLine("[RHYTHM] ", ConsoleColor.Green);
                        ExtractRhythmData(sysExData, sysExAddress);
                    }
                    break;

                case 0x05:
                    ConsoleMessage.SendLine("[PATCH] ", ConsoleColor.Cyan);
                    ExtractPatchData(sysExData, sysExAddress);
                    break;

                case 0x08:
                    ConsoleMessage.SendLine("[TIMBRE] ", ConsoleColor.Blue);
                    ExtractTimbreData(sysExData, sysExAddress);
                    break;

                case 0x10:
                    ConsoleMessage.SendLine("[SYSTEM] ", ConsoleColor.Red);
                    ExtractSystemData(sysExData, sysExAddress);
                    break;

                case 0x20:
                    ConsoleMessage.SendLine("[TEXT] ", ConsoleColor.Yellow);
                    ExtractTextData(sysExData);
                    break;

                default:
                    break;
            }
        }

        bool IsMT32ResetCommand(int[] sysExData)
        {
            if (sysExData.Length != 5) return false;
            if ((sysExData[0] != MT32SysEx.MANUFACTURER_ID) || (sysExData[1] != MT32SysEx.DEVICE_ID) || (sysExData[2] != MT32SysEx.MODEL_ID) || (sysExData[3] != MT32SysEx.TX) || (sysExData[4] != MT32SysEx.RESET)) return false;
            return true;
        }

        void DoReset()
        {
            MT32SysEx.SendMT32Reset();
            if (MT32SysEx.allowReset) memoryState.ResetAll();
        }

        void ExtractSystemData(int[] sysExData, int[] sysExAddress)
        {
            if (sysExAddress[1] != 0 || sysExAddress[2] > 0x16)
            {
                ConsoleMessage.SendLine("System data address invalid, ignoring.");
                return;
            }
            if (sysExData.Length + sysExAddress[2] > NO_OF_SYSTEM_PARAMS) Array.Resize(ref sysExData, NO_OF_SYSTEM_PARAMS - sysExAddress[2]); //remove any superfluous sysEx data values
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

        int[] GetCurrentSystemAreaStateAsArray()
        {
            int[] systemData = new int[NO_OF_SYSTEM_PARAMS];
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

        void ExtractTextData(int[] sysExData)
        {
            int textLength = sysExData.Length;
            if (textLength > 20) textLength = 20;
            byte[] textChars = new byte[textLength];
            for (int charNo = 0; charNo < textLength; charNo++)
            {
                textChars[charNo] = (byte)sysExData[charNo];
            }
            string textMessage = Encoding.ASCII.GetString(textChars).Substring(0, textLength);
            int messageNo = 1;
            if (memoryState.GetSystem().GetMessage(0) == "") messageNo = 0;
            memoryState.GetSystem().SetMessage(messageNo, textMessage);
            ConsoleMessage.SendLine("Message " + (messageNo + 1).ToString() + " = [" + textMessage + "]");
        }

        void ExtractPatchData(int[] sysExData, int[] sysExAddress)
        {
            if (!LogicTools.DivisibleBy(sysExData.Length, 8)) //ignore block if patch data array length is not divisible by 8
            {
                ConsoleMessage.SendLine("Patch data (length " + sysExData.Length + ") incomplete, ignoring.", ConsoleColor.Red);
                return;
            }
            //one 256-byte SysEx block can contain up to 32 patches
            int startingPatchNo = ((sysExAddress[1] * 128) + sysExAddress[2]) / 8;
            int noOfPatches = sysExData.Length / 8;
            ConsoleMessage.SendLine(noOfPatches.ToString() + " patches found.");
            int byteNo = 0;
            for (int patchNo = startingPatchNo; patchNo < (noOfPatches + startingPatchNo); patchNo++)
            {
                for (int parameterNo = 0; parameterNo < 8; parameterNo++)
                {
                    memoryState.GetPatch(patchNo).SetParameterSysExValue(parameterNo, sysExData[byteNo], autoCorrect: true);
                    byteNo++;
                }
            }
            ConsoleMessage.SendLine("Patch " + (startingPatchNo + 1).ToString() + "-" + (startingPatchNo + noOfPatches).ToString() + " data found, extracting...");
        }

        void ExtractRhythmData(int[] sysExData, int[] sysExAddress)
        {
            //process rhythm settings
            if (!LogicTools.DivisibleBy(sysExData.Length, 4)) //ignore block if rhythm data array length is not divisible by 4
            {
                ConsoleMessage.SendLine("Rhythm data incomplete, ignoring.", ConsoleColor.Red);
                return;
            }
            //one 256-byte SysEx block can contain up to 64 rhythm keys
            int startingbankNo = ((sysExAddress[1] * 128) + sysExAddress[2] - 144) / 4; // Bank 0 is located at address {0x03, 0x01, 0x10}
            ConsoleMessage.SendLine("Address " + sysExAddress[0].ToString() + " " + sysExAddress[1].ToString() + " " + sysExAddress[2].ToString() + ": Bank No " + (startingbankNo + 1).ToString());
            int noOfKeys = sysExData.Length / 4;
            ConsoleMessage.SendLine(noOfKeys.ToString() + " keys found.");
            int byteNo = 0;
            for (int bankNo = startingbankNo; bankNo < (noOfKeys + startingbankNo); bankNo++)
            {
                if (bankNo > 83) break; //avoid array overflow
                for (int parameterNo = 0; parameterNo < 4; parameterNo++)
                {
                    memoryState.GetRhythm(bankNo).SetParameterSysExValue(parameterNo, sysExData[byteNo], autoCorrect: true);
                    byteNo++;
                }
            }
            ConsoleMessage.SendLine("Data for keys " + (startingbankNo + 24).ToString() + "-" + (startingbankNo + noOfKeys + 23).ToString() + " found, extracting...");
        }

        void ExtractTimbreData(int[] sysExData, int[] sysExAddress)
        {
            //check whether timbre data contains data for some or all partials
            int noOfPartials;
            int dataLength = sysExData.Length;
            const int ONE_PARTIAL = 71;
            const int TWO_PARTIALS = 129;
            const int THREE_PARTIALS = 187;
            const int FOUR_PARTIALS = 245;

            switch (dataLength)
            {
                case >= ONE_PARTIAL and < TWO_PARTIALS:
                    ConsoleMessage.SendLine("Timbre data found, only 1 partial defined.", ConsoleColor.Red);
                    noOfPartials = 1;
                    break;

                case >= TWO_PARTIALS and < THREE_PARTIALS:
                    ConsoleMessage.SendLine("Timbre data found, only 2 partials defined.", ConsoleColor.Red);
                    noOfPartials = 2;
                    break;

                case >= THREE_PARTIALS and < FOUR_PARTIALS:
                    ConsoleMessage.SendLine("Timbre data found, only 3 partials defined.", ConsoleColor.Red);
                    noOfPartials = 3;
                    break;

                case >= FOUR_PARTIALS:
                    ConsoleMessage.SendLine("Timbre data found, all partials defined.", ConsoleColor.Red);
                    noOfPartials = 4;
                    break;

                default:
                    ConsoleMessage.SendLine("Timbre data incomplete, ignoring.", ConsoleColor.Red);
                    return;
            }

            timbreNo = GetTimbreNo(sysExAddress);
            if (timbreNo < 0 || timbreNo > 63)
            {
                ConsoleMessage.SendLine("Timbre address invalid, ignoring.", ConsoleColor.Red);
                return;
            }

            string timbreName = ExtractTimbreName(sysExData);
            SetTimbreParameters();
            ConsoleMessage.SendLine("Timbre #" + (timbreNo + 1).ToString() + " data found, extracting " + timbreName + "...", ConsoleColor.Blue);

            int GetTimbreNo(int[] sysExAddress)
            {
                if (sysExAddress[2] != 0) return -1; //address suggests incomplete timbre data, ignore.
                if (!LogicTools.DivisibleBy(sysExAddress[1], 2)) return -1; //odd value suggests incomplete timbre data, ignore;
                return sysExAddress[1] / 2;
            }

            string ExtractTimbreName(int[] sysExData)
            {
                byte[] timbreNameChars = new byte[10];
                for (int i = 0; i < 10; i++)
                {
                    timbreNameChars[i] = (byte)sysExData[i];
                }
                string timbreName = Encoding.ASCII.GetString(timbreNameChars).Substring(0, 10);
                timbreName = ParseTools.RemoveTrailingSpaces(timbreName);
                return timbreName;
            }

            void SetTimbreParameters()
            {
                TimbreStructure memoryTimbre = memoryState.GetMemoryTimbre(timbreNo);
                memoryTimbre.SetTimbreName(timbreName);
                memoryTimbre.SetPart12Structure(sysExData[10], autoCorrect: true);
                memoryTimbre.SetPart34Structure(sysExData[11], autoCorrect: true);
                memoryTimbre.SetSustainStatus(!LogicTools.IntToBool(sysExData[13])); //use inverse value

                for (int partialNo = 0; partialNo < noOfPartials; partialNo++)
                {
                    if ((sysExData[12] & (1 << partialNo)) != 0) memoryTimbre.SetPartialMuteStatus(partialNo, false);
                    else memoryTimbre.SetPartialMuteStatus(partialNo, true);

                    for (int parameterNo = 0; parameterNo < MT32SysEx.PARAMETER_COUNT; parameterNo++)
                    {
                        int byteNo = ((partialNo * MT32SysEx.PARAMETER_COUNT) + parameterNo + MT32SysEx.PARTIAL_ADDRESS_OFFSET);
                        memoryTimbre.SetSysExParameter(partialNo, parameterNo, sysExData[byteNo]);
                    }
                }
            }
        }
    }

    public static void SaveSystemOnly(SystemLevel systemConfig, SaveFileDialog saveDialog, bool level, bool tuning, bool reverb, bool channels, bool reserve, bool messages)
    {
        saveDialog.Title = "Save SysEx File";
        saveDialog.Filter = "MIDI System Exclusive message file|*.syx";
        if (saveDialog.FileName == "" || saveDialog.FileName == null) saveDialog.FileName = "New MT32 system settings file.syx";
        if (saveDialog.ShowDialog() != DialogResult.OK) return; //file error
        if (saveDialog.FileName == "" || saveDialog.FileName == null) return; //user left filename blank
        FileStream sysExFile;
        try
        {
            sysExFile = (FileStream)saveDialog.OpenFile();
        }
        catch
        {
            MessageBox.Show("Could not write SysEx file. Please ensure you have write access to the selected folder path.", "MT-32 Editor");
            return;
        }
        if (messages) SaveMessage(sysExFile, systemConfig, 0);
        if (level && tuning && reverb && channels && reserve) SaveAllSystemData(sysExFile, systemConfig);
        else
        {   //if not all options are selected, save separate SysEx block for each set of parameters
            if (tuning)
            {
                byte[] sysExAddr = { 0x10, 0x00, 0x00 };
                SaveSingleSysExValue(sysExAddr, systemConfig.GetMasterTune());
            }
            if (reverb)
            {
                byte[] sysExAddr = { 0x10, 0x00, 0x01 };
                byte[] sysExData = systemConfig.GetReverbSysExValues();
                SaveMultipleSysExValues(sysExAddr, sysExData);
            }
            if (reserve)
            {
                byte[] sysExAddr = { 0x10, 0x00, 0x04 };
                byte[] sysExData = systemConfig.GetPartialReserveSysExValues();
                SaveMultipleSysExValues(sysExAddr, sysExData);
            }
            if (channels)
            {
                byte[] sysExAddr = { 0x10, 0x00, 0x0D };
                byte[] sysExData = systemConfig.GetMidiChannelSysExValues();
                SaveMultipleSysExValues(sysExAddr, sysExData);
            }
            if (level)
            {
                byte[] sysExAddr = { 0x10, 0x00, 0x16 };
                SaveSingleSysExValue(sysExAddr, systemConfig.GetMasterLevel());
            }
        }
        if (messages) SaveMessage(sysExFile, systemConfig, 1);
        sysExFile.Close();
        MessageBox.Show("Saved system settings to " + saveDialog.FileName, "MT-32 System Settings");

        void SaveSingleSysExValue(byte[] sysExAddr, int sysExValue)
        {
            int sumOfSysExValues = 0;
            SaveSysExHeader(sysExFile);
            sumOfSysExValues += SaveSysExAddress(sysExFile, sysExAddr);
            byte[] sysExData = { (byte)sysExValue };
            sysExFile.Write(sysExData, 0, 1);
            sumOfSysExValues += sysExValue;
            SaveSysExFooter(sysExFile, sumOfSysExValues);
        }

        void SaveMultipleSysExValues(byte[] sysExAddr, byte[] sysExData)
        {
            int sumOfSysExValues = 0;
            SaveSysExHeader(sysExFile);
            sumOfSysExValues += SaveSysExAddress(sysExFile, sysExAddr);
            sysExFile.Write(sysExData, 0, sysExData.Length);
            for (int i = 0; i < sysExData.Length; i++)
            {
                sumOfSysExValues += sysExData[i];
            }
            SaveSysExFooter(sysExFile, sumOfSysExValues);
        }
    }

    public static void Save(MT32State memoryState, SaveFileDialog saveDialog)
    {
        if (saveDialog.ShowDialog() != DialogResult.OK) return; //file error or cancelled dialogue
        if (saveDialog.FileName == "" || saveDialog.FileName == null) return; //user didn't select a file
        FileStream sysExFile;

        try
        {
            sysExFile = (FileStream)saveDialog.OpenFile();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Could not write SysEx file. Please ensure you have write access to the selected folder path.", "MT-32 Editor");
            return;
        }
        SystemLevel systemConfig = memoryState.GetSystem();
        SaveMessage(sysExFile, systemConfig, 0);
        SaveAllSystemData(sysExFile, systemConfig);
        SaveAllPatches();
        SaveAllMemoryTimbres();
        SaveAllRhythmKeys();
        SaveMessage(sysExFile, systemConfig, 1);
        sysExFile.Close();
        MessageBox.Show("Saved SysEx data to " + saveDialog.FileName, "MT-32 Editor");

        void SaveAllMemoryTimbres()
        {
            for (int timbreNo = 0; timbreNo < 64; timbreNo++)
            {
                int sumOfSysExValues = 0; //values of all parameters need to be totalled in order to calculate checksum
                byte[] sysExAddr = MT32SysEx.MemoryTimbreAddress(timbreNo);
                SaveSysExHeader(sysExFile);
                sumOfSysExValues += SaveSysExAddress(sysExFile, sysExAddr);
                sumOfSysExValues += TimbreFile.SaveTimbreParameters(memoryState.GetMemoryTimbre(timbreNo), sysExFile);
                sumOfSysExValues += TimbreFile.SavePartials(memoryState.GetMemoryTimbre(timbreNo), sysExFile);
                SaveSysExFooter(sysExFile, sumOfSysExValues);
            }
        }

        void SaveAllPatches()
        {
            //one 256-byte SysEx block can contain up to 32 patches
            for (int blockNo = 0; blockNo < 4; blockNo++)
            {
                int sumOfSysExValues = 0;
                byte[] sysExAddr = MT32SysEx.PatchAddress(blockNo * 32);
                SaveSysExHeader(sysExFile);
                sumOfSysExValues += SaveSysExAddress(sysExFile, sysExAddr);
                sumOfSysExValues += SavePatchBlock(blockNo);
                SaveSysExFooter(sysExFile, sumOfSysExValues);
            }
        }

        int SavePatchBlock(int blockNo)
        {
            int startingPatchNo = blockNo * 32;
            int noOfPatches = 32;
            int sumOfSysExValues = 0;
            for (int patchNo = startingPatchNo; patchNo < (noOfPatches + startingPatchNo); patchNo++)
            {
                byte[] parameterData = new byte[8];
                for (int parameterNo = 0; parameterNo < 8; parameterNo++)
                {
                    parameterData[parameterNo] = (byte)memoryState.GetPatch(patchNo).GetParameterSysExValue(parameterNo);
                    sumOfSysExValues += parameterData[parameterNo];
                }
                sysExFile.Write(parameterData, 0, parameterData.Length);
            }
            return sumOfSysExValues;
        }

        void SaveAllRhythmKeys()
        {
            for (int blockNo = 0; blockNo < 2; blockNo++)
            {
                byte[] sysExAddr = { 0x03, 0x01, 0x10 };
                if (blockNo == 1) sysExAddr[1] = 0x03;
                int sumOfSysExValues = 0;
                SaveSysExHeader(sysExFile);
                sumOfSysExValues += SaveSysExAddress(sysExFile, sysExAddr);
                sumOfSysExValues += SaveRhythmBlock(blockNo);
                SaveSysExFooter(sysExFile, sumOfSysExValues);
            }
        }

        int SaveRhythmBlock(int blockNo)
        {
            int sumOfSysExValues = 0;
            int startingBankNo = blockNo * 64;
            int[] finalBankNo = { 64, 84 };
            for (int bankNo = startingBankNo; bankNo < finalBankNo[blockNo]; bankNo++)
            {
                byte[] parameterData = new byte[4];
                for (int parameterNo = 0; parameterNo < 4; parameterNo++)
                {
                    parameterData[parameterNo] = (byte)memoryState.GetRhythm(bankNo).GetParameterSysExValue(parameterNo);
                    sumOfSysExValues += parameterData[parameterNo];
                }
                sysExFile.Write(parameterData, 0, parameterData.Length);
            }
            return sumOfSysExValues;
        }
    }

    private static int SaveSysExAddress(FileStream sysExFile, byte[] sysExAddr)
    {
        sysExFile.Write(sysExAddr, 0, sysExAddr.Length);
        return sysExAddr[0] + sysExAddr[1] + sysExAddr[2];
    }

    private static void SaveSysExHeader(FileStream sysExFile)
    {
        byte[] sysExData = new byte[5];
        sysExData[0] = MT32SysEx.START_OF_DATA_BLOCK;
        sysExData[1] = MT32SysEx.MANUFACTURER_ID;
        sysExData[2] = MT32SysEx.DEVICE_ID;
        sysExData[3] = MT32SysEx.MODEL_ID;
        sysExData[4] = MT32SysEx.TX;
        sysExFile.Write(sysExData, 0, sysExData.Length);
    }

    private static void SaveSysExFooter(FileStream sysExFile, int sumOfSysExValues)
    {
        byte[] sysExData = new byte[2];
        sysExData[0] = MT32SysEx.RolandChecksum(sumOfSysExValues);
        sysExData[1] = MT32SysEx.END_OF_DATA_BLOCK;
        sysExFile.Write(sysExData, 0, sysExData.Length);
    }

    private static void SaveAllSystemData(FileStream sysExFile, SystemLevel systemConfig)
    {
        int sumOfSysExValues = 0;
        byte[] sysExAddr = { 0x10, 0x00, 0x00 };
        SaveSysExHeader(sysExFile);
        sumOfSysExValues += SaveSysExAddress(sysExFile, sysExAddr);
        sumOfSysExValues += SaveSystemData(sysExFile, systemConfig, sumOfSysExValues);
        SaveSysExFooter(sysExFile, sumOfSysExValues);
    }

    private static int SaveSystemData(FileStream sysExFile, SystemLevel systemConfig, int sumOfSysExValues)
    {
        byte[] sysExData = new byte[NO_OF_SYSTEM_PARAMS];
        sysExData[0] = (byte)systemConfig.GetMasterTune();
        sysExData[1] = (byte)systemConfig.GetReverbMode();
        sysExData[2] = (byte)systemConfig.GetReverbTime();
        sysExData[3] = (byte)systemConfig.GetReverbLevel();
        for (int part = 0; part < 9; part++)
        {
            sysExData[part + 4] = (byte)systemConfig.GetPartialReserve(part);
            sysExData[part + 13] = (byte)systemConfig.GetSysExMidiChannel(part);
        }
        sysExData[22] = (byte)systemConfig.GetMasterLevel();
        for (int param = 0; param < NO_OF_SYSTEM_PARAMS; param++)
        {
            sumOfSysExValues += sysExData[param];
        }
        sysExFile.Write(sysExData, 0, sysExData.Length);
        return sumOfSysExValues;
    }

    private static void SaveMessage(FileStream sysExFile, SystemLevel systemConfig, int messageNo)
    {
        int sumOfSysExValues = 0; //values of all parameters need to be totalled in order to calculate checksum
        string message = ParseTools.MakeNCharsLong(systemConfig.GetMessage(messageNo), 20);
        byte[] messageASCIIChars = Encoding.ASCII.GetBytes(message);
        byte[] sysExAddr = { 0x20, 0x00, 0x00 };
        SaveSysExHeader(sysExFile);
        sumOfSysExValues += SaveSysExAddress(sysExFile, sysExAddr);
        sumOfSysExValues += ParseTools.CharacterSum(messageASCIIChars, 20);
        sysExFile.Write(messageASCIIChars, 0, 20);
        SaveSysExFooter(sysExFile, sumOfSysExValues);
    }
}
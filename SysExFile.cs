using MT32Edit;
using System.Text;

namespace MT32Edit
{
    internal static class SysExFile
    {
        //
        // MT32Edit: SysExFile class (static)
        // S.Fryers Mar 2023
        // Tools to load/save MT-32 System Exclusive data files from/to local filesystem
        //

        public static void Load(MT32State memoryState)
        {
            int timbreNo = 0;
            OpenFileDialog loadSysExDialog = new OpenFileDialog();
            loadSysExDialog.Filter = "MIDI System Exclusive message file|*.syx";
            loadSysExDialog.Title = "Load SysEx File";
            loadSysExDialog.CheckFileExists = true;
            loadSysExDialog.CheckPathExists = true;
            loadSysExDialog.ShowDialog();
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
                        ProcessSysExDataBlock(sysExDataBlock, filePointer);
                        return;
                    }
                    sysExDataBlock[filePointer] = fileDataValue;
                    filePointer++;
                }
            }

            void ProcessSysExDataBlock(int[] sysExDataBlock, int dataBlockLength)
            {
                ConsoleMessage.SendLine("Processing data block, " + dataBlockLength.ToString() + " bytes.");
                int[] sysExAddress = new int[3];
                int[] sysExData = new int[dataBlockLength - 7];
                if ((dataBlockLength < 9) || (sysExDataBlock[0] != MT32SysEx.MANUFACTURER_ID) || (sysExDataBlock[1] != MT32SysEx.DEVICE_ID) || (sysExDataBlock[2] != MT32SysEx.MODEL_ID) || (sysExDataBlock[3] != MT32SysEx.TX))
                {
                    ConsoleMessage.SendLine("MT32 non-compatible data block found, ignoring.");
                    return;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                for (int i = 4; i < 7; i++) 
                {
                    sysExAddress[i - 4] = (byte)sysExDataBlock[i];      //get memory address bytes
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                for (int i = 7; i < dataBlockLength; i++)
                {
                    sysExData[i - 7] = (byte)sysExDataBlock[i];         //get data bytes
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                switch (sysExAddress[0])
                {
                    case 0x03:
                        if (((sysExAddress[1] * 128) + sysExAddress[2]) > 137) //Rhythm data starts at address {0x03, 0x01, 0x10}
                        {
                            ConsoleMessage.SendLine("[RHYTHM] ");
                            ExtractRhythmData(sysExData, sysExAddress);
                        }
                        break;
                    case 0x05:
                        ConsoleMessage.SendLine("[PATCH] ");
                        ExtractPatchData(sysExData, sysExAddress);
                        break;
                    case 0x08:
                        ConsoleMessage.SendLine("[TIMBRE] ");
                        ExtractTimbreData(sysExData, sysExAddress);
                        break;
                    case 0x10:
                        ConsoleMessage.SendLine("[SYSTEM] ");
                        ExtractSystemData(sysExData);
                        break;
                    case 0x20:
                        ConsoleMessage.SendLine("[TEXT] ");
                        ExtractTextData(sysExData);
                        break;
                    default:
                        break;
                }
            }

            void ExtractSystemData(int[] sysExData)
            {
                if (sysExData.Length < 0x17)
                {
                    ConsoleMessage.SendLine("System data incomplete (" + sysExData.Length.ToString() + " parameters were found)");
                    return; //only process system data block if all parameters are present
                }
                SystemLevel systemConfig = memoryState.GetSystem();
                ConsoleMessage.SendLine("System data found, extracting...");
                systemConfig.SetMasterTune(sysExData[0], autoCorrect: true);
                systemConfig.SetReverbType(sysExData[1], autoCorrect: true);
                systemConfig.SetReverbTime(sysExData[2], autoCorrect: true);
                systemConfig.SetReverbLevel(sysExData[3], autoCorrect: true);
                for (int part = 0; part < 9; part++)
                {
                    systemConfig.SetPartialReserve(part, sysExData[part + 4], autoCorrect: true);
                    systemConfig.SetSysExMidiChannel(part, sysExData[part + 13], autoCorrect: true);
                }
                systemConfig.SetMasterLevel(sysExData[22], autoCorrect: true);
                return;
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
                
                if (!LogicTools.DivisibleBy(sysExData.Length - 1, 8)) //ignore block if patch data array length (minus last byte) is not divisible by 8
                {
                    ConsoleMessage.SendLine("Patch data (length " + sysExData.Length +") incomplete, ignoring.", ConsoleColor.Red);
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
                if (!LogicTools.DivisibleBy(sysExData.Length - 1, 4)) //ignore block if rhythm data array length (minus last byte) is not divisible by 4
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
                //only proceed if full timbre data exists
                if (sysExData.Length < 245)
                {
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

                    for (int partialNo = 0; partialNo < 4; partialNo++)
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

        public static void Save(MT32State memoryState, SaveFileDialog saveDialog)
        {
            if (saveDialog.ShowDialog() != DialogResult.OK) return; //file error
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
            SaveMessage(0);
            SaveAllSystemData();
            SaveAllPatches();
            SaveAllMemoryTimbres();
            SaveAllRhythmKeys();
            SaveMessage(1);
            sysExFile.Close();
            MessageBox.Show("Saved SysEx data to " + saveDialog.FileName);

            void SaveAllMemoryTimbres()
            {
                for (int timbreNo = 0; timbreNo < 64; timbreNo++)
                {
                    int sumOfSysExValues = 0; //values of all parameters need to be totalled in order to calculate checksum
                    byte[] sysExAddr = MT32SysEx.MemoryTimbreAddress(timbreNo);
                    SaveSysExHeader();
                    sumOfSysExValues += SaveSysExAddress(sysExAddr);
                    sumOfSysExValues += TimbreFile.SaveTimbreParameters(memoryState.GetMemoryTimbre(timbreNo), sysExFile);
                    sumOfSysExValues += TimbreFile.SavePartials(memoryState.GetMemoryTimbre(timbreNo), sysExFile);
                    SaveSysExFooter(sumOfSysExValues);
                }
            }

            void SaveSysExHeader()
            {
                byte[] sysExData = new byte[5];
                sysExData[0] = MT32SysEx.START_OF_DATA_BLOCK;
                sysExData[1] = MT32SysEx.MANUFACTURER_ID;
                sysExData[2] = MT32SysEx.DEVICE_ID;
                sysExData[3] = MT32SysEx.MODEL_ID;
                sysExData[4] = MT32SysEx.TX;
                sysExFile.Write(sysExData, 0, sysExData.Length);
            }

            int SaveSysExAddress(byte[] sysExAddr)
            {
                sysExFile.Write(sysExAddr, 0, sysExAddr.Length);
                return sysExAddr[0] + sysExAddr[1] + sysExAddr[2];
            }

            void SaveSysExFooter(int sumOfSysExValues)
            {
                byte[] sysExData = new byte[2];
                sysExData[0] = MT32SysEx.RolandChecksum(sumOfSysExValues);
                sysExData[1] = MT32SysEx.END_OF_DATA_BLOCK;
                sysExFile.Write(sysExData, 0, sysExData.Length);
            }

            void SaveAllSystemData()
            {
                int sumOfSysExValues = 0;
                byte[] sysExAddr = { 0x10, 0x00, 0x00 };
                SaveSysExHeader();
                sumOfSysExValues += SaveSysExAddress(sysExAddr);
                sumOfSysExValues += SaveSystemData(sumOfSysExValues);
                SaveSysExFooter(sumOfSysExValues);
            }

            int SaveSystemData(int sumOfSysExValues)
            {
                byte[] sysExData = new byte[23];
                SystemLevel systemConfig = memoryState.GetSystem();
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
                for (int param = 0; param < 23; param++)
                {
                    sumOfSysExValues += sysExData[param];
                }
                sysExFile.Write(sysExData, 0, sysExData.Length);
                return sumOfSysExValues;
            }

            void SaveAllPatches()
            {
                //one 256-byte SysEx block can contain up to 32 patches
                for (int blockNo = 0; blockNo < 4; blockNo++)
                {
                    int valueSum = 0;
                    byte[] sysExAddr = MT32SysEx.PatchAddress(blockNo * 32);
                    SaveSysExHeader();
                    valueSum += SaveSysExAddress(sysExAddr);
                    valueSum += SavePatchBlock(blockNo);
                    SaveSysExFooter(valueSum);
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
                    SaveSysExHeader();
                    sumOfSysExValues += SaveSysExAddress(sysExAddr);
                    sumOfSysExValues += SaveRhythmBlock(blockNo);
                    SaveSysExFooter(sumOfSysExValues);
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

            void SaveMessage(int messageNo)
            {
                int sumOfSysExValues = 0; //values of all parameters need to be totalled in order to calculate checksum
                string message = ParseTools.MakeNCharsLong(memoryState.GetSystem().GetMessage(messageNo), 20);
                byte[] messageASCIIChars = Encoding.ASCII.GetBytes(message);
                byte[] sysExAddr = { 0x20, 0x00, 0x00 };
                SaveSysExHeader();
                sumOfSysExValues += SaveSysExAddress(sysExAddr);
                sumOfSysExValues += ParseTools.CharacterSum(messageASCIIChars, 20);
                sysExFile.Write(messageASCIIChars, 0, 20);
                SaveSysExFooter(sumOfSysExValues);
            }
        }
    }
}

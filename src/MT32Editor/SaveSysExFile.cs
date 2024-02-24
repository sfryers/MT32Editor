using System.Text;
using System.Windows.Forms.Design;
namespace MT32Edit;

/// <summary>
/// Tools to save MT-32 System Exclusive data files to local filesystem
/// </summary>
/// 
internal static class SaveSysExFile
{
    // MT32Edit: SaveSysExFile class (static)
    // S.Fryers Feb 2024 

    public static bool excludeSystemArea = false;
    public static bool autoSave = true;
    private static readonly string? applicationPath = Path.GetDirectoryName(Application.ExecutablePath);
    private static readonly string iniFileName = "MT32Edit.ini";
    private static readonly string iniFileLocation = Path.Combine($"{applicationPath}", iniFileName);

    /// <summary>
    /// Allows user to browse for a file in which to save sysEx data from the currentMemoryState. If successful, returns the name of the saved file, otherwise "Cancelled" or "Empty".
    /// </summary>

    public static string SaveAs(MT32State memorystate, string fileName = "New SysEx file.syx")
    {
        SaveFileDialog saveDialog = new SaveFileDialog();
        fileName = Path.ChangeExtension(fileName, FileTools.SYSEX_FILE);
        saveDialog.FileName = Path.GetFileName(fileName);
        saveDialog.Title = "Save SysEx File";
        saveDialog.Filter = "MIDI System Exclusive message file|*.syx";
        if (saveDialog.ShowDialog() != DialogResult.OK)
        {
            //file error or cancelled dialogue
            return FileTools.CANCELLED;
        }

        if (string.IsNullOrWhiteSpace(saveDialog.FileName))
        {
            //user didn't select a file
            return FileTools.EMPTY;
        }
        fileName = saveDialog.FileName;
        saveDialog.Dispose();
        return Save(memorystate, fileName, checkBeforeOverwriting: false);
    }

    /// <summary>
    /// Saves SysEx data from the currentMemoryState to the specified fileName. If successful, returns the name of the saved file, otherwise "Cancelled" or "Error".
    /// If checkBeforeOverwriting is set to false, will automatically save without asking the user.
    /// </summary>

    public static string Save(MT32State memoryState, string fileName, bool checkBeforeOverwriting = true)
    {
        if (Path.GetExtension(fileName).ToLower() != FileTools.SYSEX_FILE)
        {
            fileName = Path.ChangeExtension(fileName, FileTools.SYSEX_FILE);
            checkBeforeOverwriting = true;
        }
        if (checkBeforeOverwriting && File.Exists(fileName) && !UITools.AskUserToConfirm($"Overwrite {fileName}?", "MT-32 Editor"))
        { 
            return FileTools.CANCELLED;
        }
        FileStream sysExFile;
        try
        {
            sysExFile = File.OpenWrite(fileName);
        }
        catch(Exception e)
        {
            MessageBox.Show($"Could not write SysEx file: {e.GetBaseException().Message}{Environment.NewLine}Please ensure you have write access to the selected folder path.", "MT-32 Editor");
            return FileTools.ERROR;
        }
        SystemLevel systemConfig = memoryState.GetSystem();
        SaveMessage(sysExFile, systemConfig, 0);
        if (!excludeSystemArea)
        {
            SaveAllSystemData(sysExFile, systemConfig);
        }
        SaveAllPatches();
        SaveAllMemoryTimbres();
        SaveAllRhythmKeys();
        SaveMessage(sysExFile, systemConfig, 1);
        sysExFile.Close();
        if (fileName != FileTools.autoSaveFileLocation)
        {
            MessageBox.Show($"Saved SysEx data to {fileName}", "MT-32 Editor");
        }
        return fileName;

        void SaveAllMemoryTimbres()
        {
            for (int timbreNo = 0; timbreNo < 64; timbreNo++)
            {
                if (memoryState.GetMemoryTimbre(timbreNo).GetTimbreName() == MT32Strings.EMPTY)
                {
                    //don't save undefined timbres
                    continue;
                }
                //values of all parameters need to be totalled in order to calculate checksum
                int sumOfSysExValues = 0;
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
                if (blockNo == 1)
                {
                    sysExAddr[1] = 0x03;
                }

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
        byte[] sysExData = new byte[MT32SysEx.NO_OF_SYSTEM_PARAMS];
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
        for (int param = 0; param < MT32SysEx.NO_OF_SYSTEM_PARAMS; param++)
        {
            sumOfSysExValues += sysExData[param];
        }
        sysExFile.Write(sysExData, 0, sysExData.Length);
        return sumOfSysExValues;
    }

    private static void SaveMessage(FileStream sysExFile, SystemLevel systemConfig, int messageNo)
    {
        //values of all parameters need to be totalled in order to calculate checksum
        int sumOfSysExValues = 0;
        string message = ParseTools.MakeNCharsLong(systemConfig.GetMessage(messageNo), 20);
        byte[] messageASCIIChars = Encoding.ASCII.GetBytes(message);
        byte[] sysExAddr = { 0x20, 0x00, 0x00 };
        SaveSysExHeader(sysExFile);
        sumOfSysExValues += SaveSysExAddress(sysExFile, sysExAddr);
        sumOfSysExValues += ParseTools.CharacterSum(messageASCIIChars, 20);
        sysExFile.Write(messageASCIIChars, 0, 20);
        SaveSysExFooter(sysExFile, sumOfSysExValues);
    }

    /// <summary>
    /// Saves SysEx data from the provided systemConfig to a location chosen by the user.
    /// Multiple boolean parameters used to specify which elements of the systemConfig are saved.
    /// </summary>

    public static void SaveSystemOnly(SystemLevel systemConfig, bool level, bool tuning, bool reverb, bool channels, bool reserve, bool messages)
    {
        SaveFileDialog saveDialog = new SaveFileDialog();
        saveDialog.Title = "Save SysEx File";
        saveDialog.Filter = "MIDI System Exclusive message file|*.syx";
        if (string.IsNullOrWhiteSpace(saveDialog.FileName))
        {
            saveDialog.FileName = "New MT32 system settings file.syx";
        }

        if (saveDialog.ShowDialog() != DialogResult.OK || string.IsNullOrWhiteSpace(saveDialog.FileName))
        {
            //file error or user left filename blank
            saveDialog.Dispose();
            return;
        }

        FileStream sysExFile;
        try
        {
            sysExFile = (FileStream)saveDialog.OpenFile();
        }
        catch (Exception e)
        {
            MessageBox.Show($"Could not write SysEx file: {e.GetBaseException().Message} {Environment.NewLine}Please ensure you have write access to the selected folder path.", "MT-32 Editor");
            return;
        }
        if (messages)
        {
            SaveMessage(sysExFile, systemConfig, 0);
        }

        if (level && tuning && reverb && channels && reserve)
        {
            SaveAllSystemData(sysExFile, systemConfig);
        }
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
        if (messages)
        {
            SaveMessage(sysExFile, systemConfig, 1);
        }

        string fileName = saveDialog.FileName;
        sysExFile.Close();
        saveDialog.Dispose();
        MessageBox.Show($"Saved system settings to {fileName}", "MT-32 System Settings");

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
}
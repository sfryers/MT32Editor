using System.Text;
namespace MT32Edit;

/// <summary>
/// Load/save MT-32 timbre data files from/to local filesystem (using proprietary binary .timbre format)
/// </summary>
/// 
/// <remarks> 
/// Valid .timbre files consist of: bytes 0-39: character string header "MT-32 Editor v1 timbre definition file: ";
/// bytes 40-49: 10-character ASCII timbre name string; bytes 50-53: 2x partial structures,
/// partial mute status (encoded as 4 boolean values rather than the single byte value used in
/// the SysEx format), sustain status; bytes 54-285: 58 parameter byte values for each of the
/// four partials in order.
/// </remarks>
/// 
internal static class TimbreFile
{
    // MT32Edit: TimbreFile class (static)
    // S.Fryers Mar 2024

    private const string TIMBRE_FILE_HEADER = "MT-32 Editor v1 timbre definition file: ";

    // Total size of valid .timbre file is 286 bytes.
    private static readonly int VALID_FILE_LENGTH = TIMBRE_FILE_HEADER.Length + MT32SysEx.PARTIAL_ADDRESS_OFFSET + (TimbreStructure.NO_OF_PARAMETERS * TimbreStructure.NO_OF_PARTIALS);

    /// <summary>
    /// Loads timbre data into the provided TimbreStructure. If successful, return the name of the opened file, otherwise "Cancelled" or "Error".
    /// Overloaded method: if no filename is provided, then a file browser window will be opened
    /// </summary>

    public static string Load(TimbreStructure timbre)
    {
        OpenFileDialog loadTimbreDialog = new OpenFileDialog();

        SetUpFileDialog(loadTimbreDialog);
        string fileName = loadTimbreDialog.FileName;
        loadTimbreDialog.Dispose();
        if (string.IsNullOrWhiteSpace(fileName))
        {
            return FileTools.CANCELLED;
        }

        return Load(timbre, fileName);

        void SetUpFileDialog(OpenFileDialog loadTimbreDialog)
        {
            loadTimbreDialog.Filter = "Timbre file|*.timbre";
            loadTimbreDialog.Title = "Load Timbre File";
            loadTimbreDialog.CheckFileExists = true;
            loadTimbreDialog.CheckPathExists = true;
            loadTimbreDialog.ShowDialog();
        }
    }

    /// <summary>
    /// Loads timbre data into the provided TimbreStructure. If successful, return the name of the opened file, otherwise "Cancelled" or "Error".
    /// Overloaded method: if no filename is provided, then a file browser window will be opened
    /// </summary>

    public static string Load(TimbreStructure timbre, string fileName)
    {
        byte[] header = new byte[40];
        byte[] timbreNameBytes = new byte[10];
        byte[] timbreData = new byte[4];
        byte[] parameterValue = new byte[MT32SysEx.NO_OF_PARTIAL_PARAMETERS];
        MT32SysEx.blockMT32text = true;

        //load data from file
        FileStream timbreFile = File.OpenRead(fileName);
        timbreFile.Read(header, 0, header.Length);
        if (timbreFile.Length != VALID_FILE_LENGTH || Encoding.ASCII.GetString(header) != TIMBRE_FILE_HEADER)
        {
            //incorrect file length or invalid header: stop loading
            timbreFile.Close();
            MessageBox.Show($"{fileName} is not a valid timbre file.", "Unable to load timbre");
            return FileTools.ERROR;
        }
        MT32SysEx.blockSysExMessages = true;
        LoadTimbreParameters();
        LoadPartials();
        MT32SysEx.blockSysExMessages = false;
        MT32SysEx.blockMT32text = false;
        timbreFile.Close();
        MT32SysEx.SendText("Loaded " + timbre.GetTimbreName());

        string timbreFileName = Path.GetFileName(fileName);
        
        return timbreFileName;

        void LoadTimbreParameters()
        {
            timbreFile.Read(timbreNameBytes, 0, timbreNameBytes.Length);
            timbre.SetTimbreName(Encoding.ASCII.GetString(timbreNameBytes));
            timbreFile.Read(timbreData, 0, timbreData.Length);
            timbre.SetPart12Structure(timbreData[0]);
            timbre.SetPart34Structure(timbreData[1]);

            //use inverse value
            timbre.SetSustainStatus(!LogicTools.IntToBool(timbreData[3]));
        }

        void LoadPartials()
        {
            for (int partialNo = 0; partialNo < TimbreStructure.NO_OF_PARTIALS; partialNo++)
            {
                SetPartialMuteStatus(partialNo);
                LoadPartialParameters(partialNo);
            }
        }

        void SetPartialMuteStatus(int partialNo)
        {
            if ((timbreData[2] & (1 << partialNo)) != 0)
            {
                timbre.SetPartialMuteStatus(partialNo, false);
            }
            else
            {
                timbre.SetPartialMuteStatus(partialNo, true);
            }
        }

        void LoadPartialParameters(int partialNo)
        {
            timbreFile.Read(parameterValue, 0, parameterValue.Length);
            for (byte parameterNo = 0; parameterNo < MT32SysEx.NO_OF_PARTIAL_PARAMETERS; parameterNo++)
            {
                timbre.SetSysExParameter(partialNo, parameterNo, parameterValue[parameterNo]);
            }
        }
    }

    /// <summary>
    /// Saves timbre data to existing file
    /// </summary>

    public static void Save(TimbreStructure timbre, SaveFileDialog saveDialog)
    {
        if (string.IsNullOrWhiteSpace(saveDialog.FileName))
        {
            return;
        }
        try
        {
            FileStream file = (FileStream)saveDialog.OpenFile();
            SaveTimbreFileContents(timbre, file);
        }
        catch
        {
            MessageBox.Show("Could not write timbre file. Please ensure you have write access to the selected folder path.");
        }
    }

    /// <summary>
    /// Saves timbre data to file selected by user
    /// </summary>

    public static bool SaveAs(TimbreStructure timbre, SaveFileDialog saveTimbreDialog, string fileName)
    {
        saveTimbreDialog.Filter = "Timbre file|*.timbre";
        saveTimbreDialog.FileName = fileName;
        saveTimbreDialog.Title = "Save Timbre File";
        if (saveTimbreDialog.ShowDialog() == DialogResult.Cancel)
        {
            return false;
        }
        Save(timbre, saveTimbreDialog);
        return true;
    }

    public static bool QuickSave(TimbreStructure timbre, SaveFileDialog saveTimbreDialog, string timbreName, bool allowQuickSave)
    {
        if (!allowQuickSave)
        {
            saveTimbreDialog.FileName = string.Empty;
            return SaveAs(timbre, saveTimbreDialog, timbreName);
        }

        string action = "Save";
        if (File.Exists(saveTimbreDialog.FileName)) action = "Overwrite";
        if (UITools.AskUserToConfirm($"{action} file {saveTimbreDialog.FileName}?", "MT-32 Editor"))
        {
            Save(timbre, saveTimbreDialog);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Saves multiple timbre files, one per item from the provided timbreArray
    /// </summary>

    public static void SaveAll(TimbreStructure[] timbreArray)
    {
        string filePath = FileTools.AskUserForFilePath();
        if (!FileTools.Success(filePath))
        {
            return;
        }

        int fileCount = 0;
        for (int timbreNo = 0; timbreNo < MT32State.NO_OF_MEMORY_TIMBRES; timbreNo++)
        {
            string timbreName = ParseTools.RemoveTrailingSpaces(timbreArray[timbreNo].GetTimbreName());
            if (timbreName == MT32Strings.EMPTY)
            {
                //skip empty timbres
                continue;
            }

            string timbreFileName = CreateBatchTimbreFilename(timbreNo);
            timbreFileName = FileTools.RemoveInvalidFileNameCharacters(timbreFileName);
            if (SaveTimbreFile(timbreArray[timbreNo], Path.Combine(filePath, timbreFileName)))
            {
                fileCount++;
            }
            else
            {
                return;
            }
        }
        if (fileCount == 0)
        {
            MessageBox.Show("Couldn't save any timbre files- memory timbre slots are all empty.", "MT-32 Editor");
        }
        else
        {
            MessageBox.Show($"{fileCount} timbre file{ParseTools.Pluralise(fileCount)} saved to {filePath}", "MT-32 Editor");
        }

        string CreateBatchTimbreFilename(int timbreNo)
        {
            string timbreNumber = (timbreNo + 1).ToString();
            if (timbreNumber.Length == 1)
            {
                timbreNumber = $"0{timbreNumber}";
            }

            return $"{timbreNumber} - {timbreArray[timbreNo].GetTimbreName()}{FileTools.TIMBRE_FILE}";
        }

        bool SaveTimbreFile(TimbreStructure timbre, string timbreFileName)
        {
            try
            {
                timbreFileName = FileTools.EnsureUniqueFilename(timbreFileName);
                FileStream timbreFile = new FileStream(timbreFileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                SaveTimbreFileContents(timbre, timbreFile);
                return true;
            }
            catch
            {
                MessageBox.Show("Could not write timbre file. Please ensure you have write access to the selected folder path.");
                return false;
            }
        }
    }

    private static void SaveTimbreFileContents(TimbreStructure timbre, FileStream file)
    {
        ConsoleMessage.SendLine($"Saving {file.Name}");
        file.Write(Encoding.ASCII.GetBytes(TIMBRE_FILE_HEADER), 0, TIMBRE_FILE_HEADER.Length);
        SaveTimbreParameters(timbre, file);
        SavePartials(timbre, file);
        file.Close();
    }

    public static int SaveTimbreParameters(TimbreStructure timbre, FileStream file)
    {
        string timbreName = ParseTools.MakeNCharsLong(timbre.GetTimbreName(), 10);
        byte[] timbreNameASCIIChars = Encoding.ASCII.GetBytes(timbreName);
        byte[] timbreData = new byte[] { 0, 0, 0, 1 };
        bool[] partialStatus = timbre.GetPartialMuteStatus();
        timbreData[0] = (byte)timbre.GetPart12Structure();
        timbreData[1] = (byte)timbre.GetPart34Structure();
        timbreData[2] = MT32SysEx.PartialMuteValue(partialStatus);
        if (timbre.GetSustainStatus())
        {
            timbreData[3] = 0;
        }
        else
        {
            timbreData[3] = 1;
        }

        file.Write(timbreNameASCIIChars, 0, 10);
        file.Write(timbreData, 0, timbreData.Length);
        int sumOfSysExValues = ParseTools.CharacterSum(timbreNameASCIIChars, 10) + timbreData[0] + timbreData[1] + timbreData[2] + timbreData[3];

        //sum of individual parameter values- required to calculate checksum
        return sumOfSysExValues;
    }

    public static int SavePartials(TimbreStructure timbre, FileStream file)
    {
        byte[] parameterData = new byte[TimbreStructure.NO_OF_PARAMETERS];
        int sumOfSysExValues = 0;
        for (int partialNo = 0; partialNo < TimbreStructure.NO_OF_PARTIALS; partialNo++)
        {
            for (int parameterNo = 0; parameterNo < TimbreStructure.NO_OF_PARAMETERS; parameterNo++)
            {
                parameterData[parameterNo] = timbre.GetSysExParameter(partialNo, parameterNo);
                sumOfSysExValues += parameterData[parameterNo];
            }
            file.Write(parameterData, 0, parameterData.Length);
        }
        return sumOfSysExValues;
    }
}
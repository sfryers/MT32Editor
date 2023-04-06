using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MT32Edit
{
    internal static class TimbreFile
    {
        //
        // MT32Edit: TimbreFile class (static)
        // S.Fryers Mar 2023
        // Load/save MT-32 timbre data files from/to local filesystem (using proprietary binary .timbre format)
        // Valid .timbre files consist of:
        //      bytes 0-39: character string header "MT-32 Editor v1 timbre definition file: "
        //      bytes 40-49: 10-character ASCII timbre name string
        //      bytes 50-53: 2x partial structures, partial mute status (encoded as 4 boolean values rather than the single byte value used in the SysEx format), sustain status,
        //      bytes 54-285: 58 parameter byte values for each of the four partials in order.

        const int VALID_FILE_LENGTH = 286; // Total size of valid .timbre file is 286 bytes.
        const string TIMBRE_FILE_HEADER = "MT-32 Editor v1 timbre definition file: ";

        public static string Load(TimbreStructure timbre)
        {
            byte[] header = new byte[40];
            byte[] timbreNameBytes = new byte[10];
            byte[] timbreData = new byte[4];
            byte[] parameterValue = new byte[58];
            MT32SysEx.blockMT32text = true;

            OpenFileDialog loadTimbreDialog = new OpenFileDialog();

            SetUpFileDialog(loadTimbreDialog);
            if (loadTimbreDialog.FileName == "") return "Cancelled";

            //load data from file
            FileStream timbreFile = (FileStream)loadTimbreDialog.OpenFile();
            timbreFile.Read(header, 0, header.Length);
            if (timbreFile.Length != VALID_FILE_LENGTH || Encoding.ASCII.GetString(header) != TIMBRE_FILE_HEADER)
            {
                //incorrect file length or invalid header: stop loading
                timbreFile.Close();
                MessageBox.Show(loadTimbreDialog.FileName + " is not a valid timbre file.", "Unable to load timbre");
                return "#Error!";
            }
            MT32SysEx.blockSysExMessages = true;
            LoadTimbreParameters();
            LoadPartials();
            MT32SysEx.blockSysExMessages = false;
            MT32SysEx.blockMT32text = false;
            timbreFile.Close();
            MT32SysEx.SendText("Loaded " + timbre.GetTimbreName());


            return loadTimbreDialog.FileName;

            void SetUpFileDialog(OpenFileDialog loadTimbreDialog)
            {
                loadTimbreDialog.Filter = "Timbre file|*.timbre";
                loadTimbreDialog.Title = "Load Timbre File";
                loadTimbreDialog.CheckFileExists = true;
                loadTimbreDialog.CheckPathExists = true;
                loadTimbreDialog.ShowDialog();
            }

            void LoadTimbreParameters()
            {
                timbreFile.Read(timbreNameBytes, 0, timbreNameBytes.Length);
                timbre.SetTimbreName(Encoding.ASCII.GetString(timbreNameBytes));
                timbreFile.Read(timbreData, 0, timbreData.Length);
                timbre.SetPart12Structure(timbreData[0]);
                timbre.SetPart34Structure(timbreData[1]);
                timbre.SetSustainStatus(!LogicTools.IntToBool(timbreData[3])); //use inverse value
            }

            void LoadPartials()
            {
                for (int partialNo = 0; partialNo < 4; partialNo++)
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
                else timbre.SetPartialMuteStatus(partialNo, true);
            }

            void LoadPartialParameters(int partialNo)
            {
                timbreFile.Read(parameterValue, 0, parameterValue.Length);
                for (byte parameterNo = 0; parameterNo < 58; parameterNo++)
                {
                    timbre.SetSysExParameter(partialNo, parameterNo, parameterValue[parameterNo]);
                }
            }
        }

        public static void Save(TimbreStructure timbre, SaveFileDialog saveDialog)
        {
            if (saveDialog.FileName == "" || saveDialog.FileName == null) return;
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

        public static void SaveAll(TimbreStructure[] timbreArray)
        {
            string filePath = FileTools.AskUserForFilePath();
            if (filePath == "#Error!" || filePath == "Cancelled") return;
            int fileCount = 0;
            for (int timbreNo = 0; timbreNo < 64; timbreNo++)
            {
                string timbreName = ParseTools.RemoveTrailingSpaces(timbreArray[timbreNo].GetTimbreName());
                if (timbreName == "[empty]") continue; //skip empty timbres
                string timbreFileName = CreateBatchTimbreFilename(timbreNo);
                timbreFileName = RemoveInvalidCharacters(timbreFileName);
                if (SaveTimbreFile(timbreArray[timbreNo], filePath + Path.DirectorySeparatorChar + timbreFileName)) fileCount++;
                else return;
            }
            if (fileCount == 0) MessageBox.Show("Couldn't save any timbre files- memory timbre slots are all empty.");
            else MessageBox.Show(fileCount.ToString() + " timbre file" + ParseTools.Plural(fileCount) + " saved to " + filePath);

            string CreateBatchTimbreFilename(int timbreNo)
            {
                string timbreNumber = timbreNo.ToString();
                if (timbreNumber.Length == 1) timbreNumber = "0" + timbreNumber;
                return timbreNumber + " - " + timbreArray[timbreNo].GetTimbreName() + ".timbre";
            }

            string RemoveInvalidCharacters(string timbreFileName)
            {
                string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
                foreach (char c in invalid) timbreFileName = timbreFileName.Replace(c.ToString(), "");
                return timbreFileName;
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
            string fileHeader = "MT-32 Editor v1 timbre definition file: "; //40 character header
            file.Write(Encoding.ASCII.GetBytes(fileHeader), 0, 40);
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
            if (timbre.GetSustainStatus()) timbreData[3] = 0;
            else timbreData[3] = 1;
            file.Write(timbreNameASCIIChars, 0, 10);
            file.Write(timbreData, 0, timbreData.Length);
            int sumOfSysExValues = ParseTools.CharacterSum(timbreNameASCIIChars, 10) + timbreData[0] + timbreData[1] + timbreData[2] + timbreData[3];
            return sumOfSysExValues; //sum of individual parameter values- required to calculate checksum
        }

        public static int SavePartials(TimbreStructure timbre, FileStream file)
        {
            byte[] parameterData = new byte[58];
            int sumOfSysExValues = 0;
            for (int partialNo = 0; partialNo < 4; partialNo++)
            {
                for (int parameterNo = 0; parameterNo < 58; parameterNo++)
                {
                    parameterData[parameterNo] = timbre.GetSysExParameter(partialNo, parameterNo);
                    sumOfSysExValues += parameterData[parameterNo];
                }
                file.Write(parameterData, 0, parameterData.Length);
            }
            return sumOfSysExValues;
        }
    }
}
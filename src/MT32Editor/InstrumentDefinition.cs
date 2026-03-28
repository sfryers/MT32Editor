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
/// Tools to export Cakewalk Instrument Definition files to local filesystem
/// </summary>
/// 
internal static class InstrumentDefinition
{
    // MT32Edit: InstrumentDefinition class (static)
    // S.Fryers Mar 2026

    private const int BANK_OFFSET = 2;

    public static string Save(MT32State memorystate, string fileName = "New Instrument Definition.ins")
    {
        using (var saveDialog = new SaveFileDialog())
        {
            fileName = Path.ChangeExtension(fileName, FileTools.INSTRUMENT_DEFINITION);
            saveDialog.FileName = Path.GetFileName(fileName);
            saveDialog.Title = "Save Instrument Definition";
            saveDialog.Filter = "Instrument Defintion|*.ins";
            if (saveDialog.ShowDialog() != DialogResult.OK)
            {
                //file error or cancelled dialogue
                return FileTools.CANCELLED;
            }
            if (ParseTools.IsNullOrWhiteSpace(saveDialog.FileName))
            {
                //user didn't select a file
                return FileTools.EMPTY;
            }
            fileName = saveDialog.FileName;
            return Populate(memorystate, fileName, checkBeforeOverwriting: false);
        }
    }

    public static string Populate(MT32State memoryState, string fileName, bool checkBeforeOverwriting = true)
    {
        try
        {
            if (Path.GetExtension(fileName).ToLower() != FileTools.INSTRUMENT_DEFINITION)
            {
                fileName = Path.ChangeExtension(fileName, FileTools.INSTRUMENT_DEFINITION);
                checkBeforeOverwriting = true;
            }
            if (checkBeforeOverwriting && File.Exists(fileName) && !UITools.AskUserToConfirm($"Overwrite {fileName}?", "MT-32 Editor"))
            {
                return FileTools.CANCELLED;
            }
            //create new file if it doesn't already exist
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Dispose();
            }
            ConsoleMessage.SendVerboseLine($"Saving settings to {fileName}");
            var fs = new StreamWriter(fileName, false);
            fs.WriteLine(";Custom instrument definition for Roland MT-32/CM-32L");
            fs.WriteLine(";Created with MT-32 Editor (https://github.com/sfryers/MT32Editor)");
            fs.WriteLine(";");
            fs.WriteLine($";{memoryState.GetSystem().GetMessage(0)}");
            fs.WriteLine($";{memoryState.GetSystem().GetMessage(1)}");
            fs.WriteLine("");
            fs.WriteLine(".Patch Names");
            fs.WriteLine("");
            string mapName = Path.GetFileNameWithoutExtension(fileName);
            fs.WriteLine($"[MT-32: {mapName}]");
            WriteAllPatchNames(fs);
            fs.WriteLine("");
            fs.WriteLine($"[MT-32 Drum set: {mapName}]");
            fs.WriteLine($"0={mapName}");
            fs.WriteLine("");
            fs.WriteLine(".Note Names");
            fs.WriteLine(""); 
            fs.WriteLine($"[Custom Rhythm Keys: {mapName}]");
            WriteAllRhythmNames(fs);
            fs.WriteLine("");
            fs.WriteLine(".Instrument Definitions");
            fs.WriteLine("");
            fs.WriteLine($"[MT-32 Custom Patches: {mapName}]");
            fs.WriteLine($"Patch[0]=MT-32: {mapName}");
            fs.WriteLine($"Patch[*]=MT-32: {mapName}");
            fs.WriteLine("");
            fs.WriteLine($"[MT-32 Custom Drums: {mapName}]");
            fs.WriteLine($"Patch[*]=MT-32 Drum set: {mapName}");
            fs.WriteLine($"Key[*,*]=Custom Rhythm Keys: {mapName}");
            fs.WriteLine("Drum[*,*]=1");
            fs.WriteLine("");
            fs.Close();
            MessageBox.Show($"Saved Instrument Definition to {fileName}", "MT-32 Editor");
            return fileName;
        }
        catch (Exception)
        {
            MessageBox.Show($"Unable to create {fileName}.{Environment.NewLine}{Environment.NewLine}Check that you have read/write access to the folder that the application is running from ({FileTools.applicationPath}){Environment.NewLine}{Environment.NewLine}Instrument map has not been saved.", "MT-32 Editor");
            return FileTools.ERROR;
        }

        void WriteAllPatchNames(StreamWriter fs)
        {
            for (int patchNo = 0; patchNo < MT32State.NO_OF_PATCHES; patchNo++)
            {
                WritePatchName(fs, patchNo);
            }
        }

        void WritePatchName(StreamWriter fs, int patchNo)
        {
            Patch memoryPatch = memoryState.GetPatch(patchNo);
            int timbreNo = memoryPatch.GetTimbreNo();
            int timbreGroup = memoryPatch.GetTimbreGroup();
            string patchName = memoryState.GetTimbreNames().Get(timbreNo, timbreGroup);
            fs.WriteLine($"{patchNo}={patchName}");
        }

        void WriteAllRhythmNames(StreamWriter fs)
        {
            for (int keyNo = RhythmConstants.KEY_OFFSET; keyNo < RhythmConstants.NO_OF_RHYTHM_KEYS + RhythmConstants.KEY_OFFSET; keyNo++)
            {
                WriteRhythmKeyName(fs, keyNo);
            }
        }

        void WriteRhythmKeyName(StreamWriter fs, int keyNo)
        {
            Rhythm rhythmKey = memoryState.GetRhythmBank(keyNo - RhythmConstants.KEY_OFFSET);
            int timbreNo = rhythmKey.GetTimbreNo();
            string timbreGroup = rhythmKey.GetTimbreGroupType();
            string timbreName = memoryState.GetTimbreNames().Get(timbreNo, rhythmKey.GetTimbreGroup() + BANK_OFFSET);
            if (timbreName != MT32Strings.NONE)
            {
                fs.WriteLine($"{keyNo}={timbreName}");
            }
        }

    }
}


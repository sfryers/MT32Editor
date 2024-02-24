namespace MT32Edit;

/// <summary>
/// Basic filename/filepath tools
/// </summary>
internal static class FileTools
{
    // MT32Edit: FileTools class (static)
    // S.Fryers Feb 2024

    public const string MIDI_FILE = ".mid";
    public const string SYSEX_FILE = ".syx";
    public const string TIMBRE_FILE = ".timbre";
    public const string EMPTY = "Empty";
    public const string ERROR = "Error";
    public const string CANCELLED = "Cancelled";
    public const string AUTOSAVE = "autosave.syx";
    public static readonly string? applicationPath = Path.GetDirectoryName(Application.ExecutablePath);
    public static readonly string autoSaveFileLocation = Path.Combine($"{applicationPath}", AUTOSAVE);

    /// <summary>
    /// Returns true if status is not CANCELLED, EMPTY, or ERROR.
    /// </summary>

    public static bool Success(string status)
    {
        if (status == CANCELLED || status == EMPTY || status == ERROR)
        {
            return false;
        }
        return true;
    }

    public static string AskUserForFilePath()
    {
        FolderBrowserDialog selectFolder = new FolderBrowserDialog();
        DialogResult result = selectFolder.ShowDialog();
        string pathName = selectFolder.SelectedPath;
        selectFolder.Dispose();
        if (result != DialogResult.OK)
        {
            return ERROR;
        }
        else if (string.IsNullOrWhiteSpace(pathName))
        {
            return CANCELLED;
        }
        else
        {
            return pathName;
        }
    }

    public static string RemoveInvalidFileNameCharacters(string fileName)
    {
        return string.Concat(fileName.Split(Path.GetInvalidFileNameChars()));
    }

    /// <summary>
    /// If fileName already exists, add a bracketed unique sequential number before the filename extension.
    /// </summary>
    public static string EnsureUniqueFilename(string fileName)
    {
        if (!File.Exists(fileName))
        {
            return fileName;
        }
        ConsoleMessage.SendVerboseLine($"File already exists: {fileName}");
        int counter = 1;
        while (File.Exists(AppendNumber(fileName, counter)))
        {
            ConsoleMessage.SendVerboseLine($"File already exists: {AppendNumber(fileName, counter)}");
            counter++;
            if (counter > 9999)
            {
                //break to avoid any possibility of infinite loop
                break;
            }
        }
        return AppendNumber(fileName, counter);
    }

    /// <summary>
    /// Return filename with bracketed number before the filename extension.
    /// </summary>
    public static string AppendNumber(string fileName, int number)
    {
        string fileExtension = Path.GetExtension(fileName);
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
        string? filePath = Path.GetDirectoryName(fileName);
        fileNameWithoutExtension = $"{fileNameWithoutExtension}({number})";
        fileName = fileNameWithoutExtension + fileExtension;
        if (filePath is not null)
        {
            return Path.Combine(filePath, fileName);
        }
        return fileName;
    }
}
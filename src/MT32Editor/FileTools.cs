namespace MT32Edit;

/// <summary>
/// Basic filename/filepath tools
/// </summary>
internal static class FileTools
{
    // MT32Edit: FileTools class (static)
    // S.Fryers Mar 2023
    // Basic filename/filepath tools
    public static string AskUserForFilePath()
    {
        FolderBrowserDialog selectFolder = new FolderBrowserDialog();
        DialogResult result = selectFolder.ShowDialog();
        if (result != DialogResult.OK)
        {
            return "#Error!";
        }
        else if (string.IsNullOrWhiteSpace(selectFolder.SelectedPath))
        {
            return "Cancelled";
        }
        else
        {
            return selectFolder.SelectedPath;
        }
    }

    /// <summary>
    /// If fileName already exists, add a bracketed unique sequential number before the filename extension.
    /// </summary>
    public static string EnsureUniqueFilename(string fileName)
    {
        string fileExtension = ParseTools.RightOfChar(fileName, '.');

        //remove file extension
        fileName = ParseTools.LeftOfChar(fileName, '.');
        fileName = ParseTools.RemoveTrailingSpaces(fileName);
        string originalFileName = fileName;
        int counter = 1;
        while (File.Exists(fileName + "." + fileExtension))
        {
            //append bracketed number
            fileName = originalFileName + "(" + counter.ToString() + ")";
            counter++;
        }
        fileName += "." + fileExtension;
        return fileName;
    }
}
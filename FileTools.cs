namespace MT32Edit
{
    internal static class FileTools
    {
        //
        // MT32Edit: FileTools class (static)
        // S.Fryers Mar 2023
        // Basic filename/filepath tools
        //
        public static string AskUserForFilePath()
        {
            FolderBrowserDialog selectFolder = new FolderBrowserDialog();
            DialogResult result = selectFolder.ShowDialog();
            if (result != DialogResult.OK) return "#Error!";
            else if (string.IsNullOrWhiteSpace(selectFolder.SelectedPath)) return "Cancelled";
            else return selectFolder.SelectedPath;
        }

        public static string EnsureUniqueFilename(string fileName)
        {
            //if fileName already exists, add a bracketed unique sequential number before the filename extension.
            string fileExtension = ParseTools.RightOfChar(fileName, '.');
            fileName = ParseTools.LeftOfChar(fileName, '.');                  //remove file extension
            fileName = ParseTools.RemoveTrailingSpaces(fileName);
            string originalFileName = fileName;
            int counter = 1;
            while (File.Exists(fileName + "." + fileExtension))
            {
                fileName = originalFileName + "(" + counter.ToString() + ")"; //append bracketed number
                counter++;
            }
            fileName += "." + fileExtension;
            return fileName;
        }
    }
}

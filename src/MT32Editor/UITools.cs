namespace MT32Edit;

internal static class UITools
{
    // MT32Edit: UITools class (static)
    // S.Fryers Feb 2024

    /// <summary>
    /// Creates OK/Cancel MessageBox using specified prompt and title.
    /// </summary>
    /// <returns>If user selects OK, returns true. If user selects Cancel, returns false.</returns>
    public static bool AskUserToConfirm(string prompt, string title)
    {
        switch (MessageBox.Show(prompt, title, MessageBoxButtons.OKCancel))
        {
            case DialogResult.OK:
                return true;
            default:
                return false;
        }
    }

    /// <summary>
    /// Returns appropriate string for the main application window title bar text, consisting of description, filename and application name.
    /// </summary>
    public static string TitleBarText(string newFileName, string currentFileName, string textMessage = "", bool changesMade = false)
    {
        //if a .syx or .mid file is loaded, don't replace the title bar filename with a .timbre file
        if (Path.GetExtension(newFileName).ToLower() == FileTools.TIMBRE_FILE && ParseTools.IsSysExOrMidi(currentFileName))
        {
            //return the original title bar name
            return $"{SysExFileDescription(textMessage)}{Path.GetFileName(currentFileName)}{CloseBracket(textMessage)}{ParseTools.UnsavedEdits(changesMade)} - MT32 Editor";
        }
        //update the title bar with the name of the new file
        return $"{SysExFileDescription(textMessage)}{Path.GetFileName(newFileName)}{CloseBracket(textMessage)}{ParseTools.UnsavedEdits(changesMade)} - MT32 Editor";
    }

    private static string SysExFileDescription(string textMessage)
    {
        if (string.IsNullOrEmpty(textMessage)) 
        {
            return string.Empty;
        }
        return $"{ParseTools.RemoveTrailingSpaces(ParseTools.RemoveLeadingSpaces(textMessage))} [";
    }

    private static string CloseBracket(string textMessage)
    {
        if (!string.IsNullOrEmpty(textMessage))
        {
            return "]";
        }
        return string.Empty;
    }

    public static bool ShowMidiInErrorMessage(string midiInDeviceName)
    {
        MessageBox.Show($"Error: Cannot open MIDI In device '{midiInDeviceName}'{Environment.NewLine}Please close any conflicting MIDI applications and restart MT-32 Editor.{Environment.NewLine}This program will now exit.", "MT-32 Editor", MessageBoxButtons.OK);
        return true;
    }

    public static bool ShowMidiOutErrorMessage(string midiOutDeviceName)
    {
        MessageBox.Show($"Error: Cannot open MIDI Out device '{midiOutDeviceName}'{Environment.NewLine}Please close any conflicting MIDI applications and restart MT-32 Editor.{Environment.NewLine}This program will now exit.", "MT-32 Editor", MessageBoxButtons.OK);
        return true;
    }

}


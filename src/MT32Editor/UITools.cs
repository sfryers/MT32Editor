using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System;
namespace MT32Edit;

/// <summary>
/// Static class containing shared user interface tools for forms in the MT32 Editor application.
/// </summary>

internal static class UITools
{
    // MT32Edit: UITools class (static)
    // S.Fryers May 2024

    public const int UI_REFRESH_INTERVAL = 200; //interval between form refreshes, in milliseconds 

    /// <summary>
    /// If true, will set UI theme to dark background.
    /// If false, will set UI theme to light background.
    /// </summary>
    public static bool DarkMode { get; set; } = true;

    /// <summary>
    /// If true, will always show full timbre editor when window size is reduced.
    /// If false, will allow patch or rhythm editor to appear on top of timbre editor.
    /// </summary>
    public static bool PrioritiseTimbreEditor { get; set; } = false;

    /// <summary>
    /// If true, will save current window size and position on exit
    /// and restore upon next application start
    /// </summary>
    public static bool SaveWindowSizeAndPosition { get; set; } = false;

    /// <summary>
    /// A two element array containing the {X,Y} positions of the top left corner of the main application window
    /// </summary>
    public static int[] WindowLocation { get; set; } = { 0, 0 };

    /// <summary>
    /// A two element array containing the {X,Y} dimensions of the main application window
    /// </summary>
    public static int[] WindowSize { get; set; } = { 0, 0 };

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
        if (Path.GetExtension(newFileName).ToLower() == FileTools.TIMBRE_FILE && FileTools.IsSysExOrMidi(currentFileName))
        {
            //return the original title bar name
            return $"{SysExFileDescription()}{Path.GetFileName(currentFileName)}{ConditionalCloseBracket()}{ParseTools.UnsavedEdits(changesMade)} - MT32 Editor";
        }
        //update the title bar with the name of the new file
        return $"{SysExFileDescription()}{Path.GetFileName(newFileName)}{ConditionalCloseBracket()}{ParseTools.UnsavedEdits(changesMade)} - MT32 Editor";

        string SysExFileDescription()
        {
            if (string.IsNullOrEmpty(textMessage))
            {
                return string.Empty;
            }
            return $"{ParseTools.RemoveTrailingSpaces(ParseTools.RemoveLeadingSpaces(textMessage))} [";
        }

        string ConditionalCloseBracket()
        {
            if (string.IsNullOrEmpty(textMessage))
            {
                return string.Empty;
            }
            return "]";
        }
    }

    /// <summary>
    /// Displays message box containing Midi In error message.
    /// </summary>
    public static bool ShowMidiInErrorMessage(string midiInDeviceName)
    {
        MessageBox.Show($"Error: Cannot open MIDI In device '{midiInDeviceName}'{Environment.NewLine}Please close any conflicting MIDI applications and restart MT-32 Editor.{Environment.NewLine}This program will now exit.", "MT-32 Editor", MessageBoxButtons.OK);
        return true;
    }

    /// <summary>
    /// Displays message box containing Midi Out error message.
    /// </summary>
    public static bool ShowMidiOutErrorMessage(string midiOutDeviceName)
    {
        MessageBox.Show($"Error: Cannot open MIDI Out device '{midiOutDeviceName}'{Environment.NewLine}Please close any conflicting MIDI applications and restart MT-32 Editor.{Environment.NewLine}This program will now exit.", "MT-32 Editor", MessageBoxButtons.OK);
        return true;
    }

    /// <summary>
    /// Sets colours for specified UI elements, dependent on value of darkMode.
    /// </summary>
    public static Color SetThemeColours(Label? titleLabel, Label[]? labels, Label[]? warningLabels, CheckBox[]? checkBoxes,
                                        GroupBox[]? groupBoxes, ListView? listView, RadioButton[]? radioButtons, bool alternate = false)
    {
        Color titleColour;
        Color foreColour;
        Color backColour;
        Color alternateBackColour;
        Color warningColour;
        Color listViewBackColour;

        if (DarkMode)
        {
            titleColour = Color.FromArgb(153, 180, 209);
            foreColour = Color.FromArgb(240, 240, 240);
            backColour = Color.FromArgb(56, 56, 56);
            alternateBackColour = Color.FromArgb(32, 32, 32);
            listViewBackColour = Color.FromArgb(84, 84, 84);
            warningColour = Color.Yellow;
        }
        else
        {
            titleColour = Color.DarkSlateBlue;
            foreColour = Color.Black;
            backColour = Color.WhiteSmoke;
            alternateBackColour = Color.FromArgb(240, 240, 240);
            listViewBackColour = Color.Snow;
            warningColour = Color.OrangeRed;
        }

        if (titleLabel is not null)
        {
            titleLabel.ForeColor = titleColour;
        }

        if (labels is not null)
        {
            SetLabelColours();
        }

        if (warningLabels is not null)
        {
            SetWarningLabelColours();
        }

        if (checkBoxes is not null)
        {
            SetCheckBoxColours();
        }

        if (radioButtons is not null)
        {
            SetRadioButtons();
        }

        if (groupBoxes is not null)
        {
            SetGroupBoxes();
        }

        if (listView is not null)
        {
            listView.ForeColor = foreColour;
            listView.BackColor = listViewBackColour;
        }

        if (alternate)
        {
            return alternateBackColour;
        }
        return backColour;

        void SetLabelColours()
        {
            foreach (var element in labels)
            {
                element.ForeColor = foreColour;
            }
        }

        void SetWarningLabelColours()
        {
            foreach (var element in warningLabels)
            {
                element.ForeColor = warningColour;
            }
        }

        void SetCheckBoxColours()
        {
            foreach (var element in checkBoxes)
            {
                element.ForeColor = foreColour;
            }
        }

        void SetRadioButtons()
        {
            foreach (var element in radioButtons)
            {
                element.ForeColor = foreColour;
            }
        }

        void SetGroupBoxes()
        {
            foreach (var element in groupBoxes)
            {
                element.ForeColor = foreColour;
            }
        }
    }

    /// <summary>
    /// Sets colours for specified label elements, dependent on value of darkMode.
    /// </summary>
    public static void SetGroupHeadingColours(Label labelPitch, Label labelTVF, Label labelTVA)
    {
        if (DarkMode)
        {
            labelPitch.ForeColor = Color.Plum;
            labelTVA.ForeColor = Color.MediumTurquoise;
            labelTVF.ForeColor = Color.Khaki;
        }
        else
        {
            labelPitch.ForeColor = Color.DarkOrchid;
            labelTVA.ForeColor = Color.DarkSlateBlue;
            labelTVF.ForeColor = Color.Brown;
        }
    }
}
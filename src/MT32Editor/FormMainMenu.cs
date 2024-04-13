using System.Runtime.InteropServices;

namespace MT32Edit;

/// <summary>
/// Primary form for MT-32 Editor application, serving as menu bar and MDI
/// container for the memory bank editor, patch editor, rhythm editor and timbre editor forms.
/// </summary>
public partial class FormMainMenu : Form
{
    // MT-32 Editor
    // A patch/timbre editor and SysEx librarian for Roland MT-32/CM-32L and compatible
    // synthesizers, including the MUNT software emulator.
    // S.Fryers (sfryers@hotmail.com)
    //
    // MT32Edit: FormMainMenu 

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool AllocConsole();

    [DllImport("kernel32.dll")]
    private static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    private const string VERSION_NO = "v0.9.9b";
#if NET472
    private const string FRAMEWORK = ".NET 4.7.2";
#elif NET6_0
    private const string FRAMEWORK = ".NET 6.0";
#else
    private const string FRAMEWORK = "";
#endif
    private const string RELEASE_DATE = "April 2024";

    private const int CONSOLE_HIDE = 0;
    private const int CONSOLE_SHOW = 5;

    private bool midiInError = false;
    private bool midiOutError = false;
    private readonly MT32State memoryState = new MT32State();
    private FormMemoryBankEditor? memoryBankEditor;
    private FormTimbreEditor? timbreEditor;
    private FormPatchEditor? patchEditor;
    private FormRhythmEditor? rhythmEditor;

    private readonly SaveFileDialog saveTimbreDialog = new SaveFileDialog();
    private string titleBarFileName = "Untitled";
    private string? loadedSysExFileName;
    private bool moveFocusToMemoryBankEditor = false;

    public FormMainMenu(string[] args)
    {
        MT32SysEx.blockMT32text = true;
        InitializeComponent();
        AllocConsole();
        Console.WriteLine($"Welcome to MT32 Editor {ParseTools.GetVersion(VERSION_NO)} ({FRAMEWORK})");
        ReadConfigFile();
        if (midiInError || midiOutError)
        {
            return;
        }
        OpenTimbreEditor();
        OpenMemoryBankEditor();
        OpenRhythmEditor();
        OpenPatchEditor();
        ScaleUIElements();

        MT32SysEx.SendText($"MT32 Editor {ParseTools.TrimToLength(VERSION_NO, 8)}");
        timer.Interval = UITools.UI_REFRESH_INTERVAL;
        timer.Start();
        MT32SysEx.blockMT32text = false;
        ProcessShellArguments(args);
    }



    private void ProcessShellArguments(string[] args)
    {
        if (args.Length == 0 || !File.Exists(args[0]))
        {
            //cancel- no arguments provided or first argument is not a valid filename
            return;
        }
        string fileName = args[0];
        switch (Path.GetExtension(fileName).ToLower())
        {
            case FileTools.MIDI_FILE:
            case FileTools.SYSEX_FILE:
                LoadSysExFile.Load(memoryState, fileName);
                UpdateUIFollowingSysExLoad(fileName);
                break;
            case FileTools.TIMBRE_FILE:
                TimbreStructure timbreData = memoryState.GetMemoryTimbre(0);
                TimbreFile.Load(timbreData, fileName);
                UpdateUIFollowingTimbreLoad(timbreData, fileName, 0);
                break;
            default:
                break;
        }
    }

    private float DPIScale()
    {
        float dpi = DeviceDpi;
        float scaleValue = (dpi / 96);
        return scaleValue;
    }

    private void OpenTimbreEditor()
    {
        timbreEditor = new FormTimbreEditor(DPIScale());
        timbreEditor.MdiParent = this;
        timbreEditor.Show();
    }

    private void OpenPatchEditor()
    {
        patchEditor = new FormPatchEditor(DPIScale(), memoryState);
        patchEditor.MdiParent = this;
        patchEditor.Show();
    }

    private void OpenRhythmEditor()
    {
        rhythmEditor = new FormRhythmEditor(DPIScale(), memoryState);
        rhythmEditor.MdiParent = this;
        rhythmEditor.Show();
        rhythmEditor.Visible = false;
    }

    private void OpenMemoryBankEditor()
    {
        if (timbreEditor is null)
        {
            return;
        }
        memoryBankEditor = new FormMemoryBankEditor(DPIScale(), memoryState, timbreEditor);
        memoryBankEditor.MdiParent = this;
        memoryBankEditor.Show();
    }

    private void ScaleUIElements()
    {
        int xMargin = (int)(23 * DPIScale());
        int yMargin = (int)(44 * DPIScale());

        menuStrip.Width = Width;
        midiInToolStripMenuItem.Width = (int)(200 * DPIScale());
        midiOutToolStripMenuItem.Width = (int)(200 * DPIScale());

        ScaleMemoryBankEditor();
        ScaleTimbreEditor();
        ScalePatchEditor();
        ScaleRhythmEditor();

        void ScaleMemoryBankEditor()
        {
            if (memoryBankEditor is null)
            {
                return;
            }
            memoryBankEditor.Left = 0;
            memoryBankEditor.Top = 0;
            memoryBankEditor.Width = (Width / 8);
            if (Height > memoryBankEditor.MinimumSize.Height)
            {
                memoryBankEditor.Height = Height - yMargin;
            }
        }

        void ScaleTimbreEditor()
        {
            if (timbreEditor is null || memoryBankEditor is null)
            {
                return;
            }
            timbreEditor.Left = memoryBankEditor.Width + 1;
            timbreEditor.Top = 0;
            if (Height > timbreEditor.MinimumSize.Height)
            {
                timbreEditor.Height = Height - yMargin;
            }
        }

        void ScalePatchEditor()
        {
            if (patchEditor is null || timbreEditor is null || memoryBankEditor is null)
            {
                return;
            }
            patchEditor.Left = (Width * 68) / 100;
            patchEditor.Left = timbreEditor.Left + timbreEditor.Width + 1;
            patchEditor.Top = 0;
            patchEditor.Width = Width - (timbreEditor.Width + memoryBankEditor.Width + xMargin);
            if (Height > patchEditor.MinimumSize.Height)
            {
                patchEditor.Height = Height - yMargin;
            }
        }

        void ScaleRhythmEditor()
        {
            if (rhythmEditor is null || timbreEditor is null || memoryBankEditor is null)
            {
                return;
            }
            rhythmEditor.Left = (Width * 68) / 100;
            rhythmEditor.Left = timbreEditor.Left + timbreEditor.Width + 1;
            rhythmEditor.Top = 0;
            rhythmEditor.Width = Width - (timbreEditor.Width + memoryBankEditor.Width + xMargin);
            if (Height > rhythmEditor.MinimumSize.Height)
            {
                rhythmEditor.Height = Height - yMargin;
            }
        }
    }

    private void FormMainMenu_Resize(object sender, EventArgs e)
    {
        ScaleUIElements();
    }

    private void ReadConfigFile()
    {
        string[] configFile = ConfigFile.Load();
        InitialiseMidiInConnection();
        InitialiseMidiOutConnection();
        ConfigureConsole();
        SetOptionMenuFlags();
        if (midiInError || midiOutError)
        {
            Close();
            return;
        }

        void ConfigureConsole()
        {
            if (ConsoleMessage.Visible())
            {
                ShowWindow(GetConsoleWindow(), CONSOLE_SHOW);
            }
            else
            {
                ShowWindow(GetConsoleWindow(), CONSOLE_HIDE);
            }
        }

        void SetOptionMenuFlags()
        {
            showConsoleToolStripMenuItem.Checked = ConsoleMessage.Visible();
            verboseConsoleMessagesToolStripMenuItem.Enabled = ConsoleMessage.Visible();
            verboseConsoleMessagesToolStripMenuItem.Checked = ConsoleMessage.Verbose();
            sendMessagesToMT32DisplayToolStripMenuItem.Checked = MT32SysEx.sendTextToMT32;
            ignoreSysConfigOnLoadToolStripMenuItem.Checked = LoadSysExFile.ignoreSystemArea;
            excludeSysConfigonSaveToolStripMenuItem.Checked = SaveSysExFile.excludeSystemArea;
            autosaveEvery5MinutesToolStripMenuItem.Checked = SaveSysExFile.autoSave;
            darkModeToolStripMenuItem.Checked = UITools.DarkMode;
            allowMT32ResetToolStripMenuItem.Checked = MT32SysEx.allowReset;
        }

        void InitialiseMidiInConnection()
        {
            int inDeviceNo = 0;
            //List available MIDI In devices in combo box
            midiInToolStripMenuItem.Items.AddRange(Midi.ListInputDevices());
            if (midiInToolStripMenuItem.Items.Count == 0)
            {
                return;
            }

            for (int device = 0; device <= Midi.CountInputDevices(); device++)
            {
                if (Midi.GetInputDeviceName(device).ToString() == configFile[0])
                {
                    //Set active MIDI In device
                    inDeviceNo = device;
                }
            }
            midiInToolStripMenuItem.SelectedIndex = inDeviceNo;
            if (!Midi.OpenInputDevice(midiInToolStripMenuItem.SelectedIndex))
            {
                midiInError = UITools.ShowMidiInErrorMessage(midiInToolStripMenuItem.Text);
            }
        }

        void InitialiseMidiOutConnection()
        {
            int outDeviceNo = 0;
            //List available MIDI Out devices in combo box
            midiOutToolStripMenuItem.Items.AddRange(Midi.ListOutputDevices());
            if (midiOutToolStripMenuItem.Items.Count == 0)
            {
                return;
            }

            for (int device = 0; device <= Midi.CountOutputDevices(); device++)
            {
                if (Midi.GetOutputDeviceName(device).ToString() == configFile[1])
                {
                    //Set active MIDI Out device
                    outDeviceNo = device;
                }
            }
            midiOutToolStripMenuItem.SelectedIndex = outDeviceNo;
            if (!Midi.OpenOutputDevice(midiOutToolStripMenuItem.SelectedIndex))
            {
                midiOutError = UITools.ShowMidiOutErrorMessage(midiOutToolStripMenuItem.Text);
            }

            SetMT32HardwareStatus(MT32SysEx.hardwareMT32Connected);
            allowMT32ResetToolStripMenuItem.Checked = MT32SysEx.allowReset;
            hardwareMT32ConnectedToolStripMenuItem.Checked = MT32SysEx.hardwareMT32Connected;
        }
    }

    private void FormMainMenu_Load(object sender, EventArgs e)
    {
        if (midiInError || midiOutError)
        {
            Close();
        }
    }

    private void midiInToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
    {
        if (!midiInError && !Midi.OpenInputDevice(midiInToolStripMenuItem.SelectedIndex))
        {
            //assign new MIDI In device
            midiInError = UITools.ShowMidiInErrorMessage(midiInToolStripMenuItem.Text);
        }
        ConfigFile.Save();
    }

    private void midiOutToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
    {
        if (!midiOutError && !Midi.OpenOutputDevice(midiOutToolStripMenuItem.SelectedIndex))
        {
            //assign new MIDI Out device
            midiOutError = UITools.ShowMidiOutErrorMessage(midiOutToolStripMenuItem.Text);
        }
        CheckForEmulator();
        ConfigFile.Save();
    }

    private void loadSysExFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        string fileName = LoadSysExFile.Load(memoryState);
        if (!FileTools.Success(fileName))
        {
            return;
        }
        UpdateUIFollowingSysExLoad(fileName);
    }

    private void UpdateUIFollowingSysExLoad(string newFileName)
    {
        if (FileTools.IsSysExOrMidi(newFileName))
        {
            loadedSysExFileName = newFileName;
        }
        else
        {
            saveTimbreDialog.FileName = newFileName;
        }
        Text = UITools.TitleBarText(newFileName, titleBarFileName, memoryState.GetSystem().GetMessage(0));
        titleBarFileName = newFileName;
        saveSysExToolStripMenuItem.Enabled = true;
    }

    private void saveSysExFileAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        string fileName = loadedSysExFileName is null ? SaveSysExFile.SaveAs(memoryState) : SaveSysExFile.SaveAs(memoryState, loadedSysExFileName);
        if (!FileTools.Success(fileName))
        {
            return;
        }
        UpdateUIFollowingSysExLoad(fileName);
    }

    private void saveSysExToolStripMenuItem_Click(object sender, EventArgs e)
    {
        string fileName;
        if (loadedSysExFileName is not null && FileTools.IsSysExOrMidi(loadedSysExFileName))
        {
            fileName = SaveSysExFile.Save(memoryState, loadedSysExFileName);
        }
        else
        {
            fileName = SaveSysExFile.SaveAs(memoryState);
        }
        if (!FileTools.Success(fileName))
        {
            return;
        }
        UpdateUIFollowingSysExLoad(fileName);
    }

    private void loadTimbreFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        LoadTimbre();
    }

    private void LoadTimbre()
    {
        int selectedTimbre = memoryState.GetSelectedMemoryTimbre();
        TimbreStructure timbreData = memoryState.GetMemoryTimbre(selectedTimbre);
        string timbreName = timbreData.GetTimbreName();
        if (timbreName != MT32Strings.EMPTY && UserCancels())
        {
            return;
        }
        string fileName = TimbreFile.Load(timbreData);
        if (!FileTools.Success(fileName))
        {
            return;
        }
        UpdateUIFollowingTimbreLoad(timbreData, fileName, selectedTimbre);

        bool UserCancels()
        {
            return !UITools.AskUserToConfirm($"Memory slot {selectedTimbre + 1} already contains a timbre. Replace {timbreName}?", "MT32 Editor");
        }
    }

    private void UpdateUIFollowingTimbreLoad(TimbreStructure timbreData, string newFileName, int selectedTimbre)
    {
        string timbreName = timbreData.GetTimbreName();
        saveTimbreDialog.FileName = Path.GetFileName(newFileName);
        saveTimbreFileToolStripMenuItem.Enabled = true;
        Text = UITools.TitleBarText(newFileName, titleBarFileName);
        titleBarFileName = newFileName;
        memoryState.GetTimbreNames().SetMemoryTimbreName(timbreName, selectedTimbre);
        MT32SysEx.SendMemoryTimbre(selectedTimbre, timbreData);
        MT32SysEx.PreviewTimbre(selectedTimbre, timbreData);
        if (memoryBankEditor is not null && memoryBankEditor.Visible)
        {
            memoryBankEditor.Select();
        }
        else
        {
            // memoryBankEditor not loaded yet, flag to attempt again.
            moveFocusToMemoryBankEditor = true;
        }
    }

    private void SaveTimbre()
    {
        int selectedTimbre = memoryState.GetSelectedMemoryTimbre();
        TimbreStructure memoryTimbre = memoryState.GetMemoryTimbre(selectedTimbre);
        string timbreName = memoryState.GetTimbreNames().Get(selectedTimbre, 2);
        saveTimbreDialog.Filter = "Timbre file|*.timbre";
        saveTimbreDialog.FileName = timbreName;
        saveTimbreDialog.Title = "Save Timbre File";
        if (saveTimbreDialog.ShowDialog() == DialogResult.OK)
        {
            TimbreFile.Save(memoryTimbre, saveTimbreDialog);
        }
    }

    private void saveTimbreFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        SaveTimbre();
    }

    private void saveAllTimbresToolStripMenuItem_Click(object sender, EventArgs e)
    {
        TimbreFile.SaveAll(memoryState.GetMemoryTimbreArray());
    }

    private void closeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void FormMainMenu_FormClosed(object sender, FormClosedEventArgs e)
    {
        Midi.CloseInputDevice();
        Midi.CloseOutputDevice();
    }

    private void patchEditorToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (patchEditor is null || rhythmEditor is null)
        {
            return;
        }
        patchEditor.Visible = true;
        patchEditorToolStripMenuItem.Checked = true;
        rhythmEditor.Visible = false;
        rhythmEditorToolStripMenuItem.Checked = false;
    }

    private void rhythmEditorToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (patchEditor is null || rhythmEditor is null)
        {
            return;
        }
        patchEditor.Visible = false;
        patchEditorToolStripMenuItem.Checked = false;
        rhythmEditor.Visible = true;
        rhythmEditorToolStripMenuItem.Checked = true;
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        FormAbout about = new FormAbout(ParseTools.GetVersion(VERSION_NO), FRAMEWORK, RELEASE_DATE);
        about.Show();
    }

    private void masterSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        FormSystemSettings systemSettings = new FormSystemSettings(memoryState.GetSystem());
        systemSettings.ShowDialog();
    }

    private void timer_Tick(object sender, EventArgs e)
    {
        if (timbreEditor is not null)
        {
            timbreEditor.Enabled = (!memoryState.patchEditorActive && !memoryState.rhythmEditorActive) || memoryState.TimbreIsEditable();
        }

        saveTimbreFileToolStripMenuItem.Enabled = memoryState.GetMemoryTimbre(memoryState.GetSelectedMemoryTimbre()).GetTimbreName() != MT32Strings.EMPTY;

        if (midiInError || midiOutError)
        {
            Close();
        }

        if (moveFocusToMemoryBankEditor && memoryBankEditor is not null && memoryBankEditor.Visible)
        {
            memoryBankEditor.Select();
            moveFocusToMemoryBankEditor = false;
        }
    }

    private void timerAutoSave_Tick(object sender, EventArgs e)
    {
        if (SaveSysExFile.autoSave)
        {
            SaveSysExFile.Save(memoryState, FileTools.autoSaveFileLocation, checkBeforeOverwriting: false);
            ConsoleMessage.SendLine("Autosaving...");
        }
    }

    private void hardwareMT32ConnectedToolStripMenuItem_Click(object sender, EventArgs e)
    {
        SetMT32HardwareStatus(!MT32SysEx.hardwareMT32Connected);
        ConfigFile.Save();
    }

    private void CheckForEmulator()
    {
        if (!midiOutError && Midi.EmulatorPresent(midiOutToolStripMenuItem.SelectedIndex))
        {
            SetMT32HardwareStatus(false);
        }
    }

    private void SetMT32HardwareStatus(bool status)
    {
        hardwareMT32ConnectedToolStripMenuItem.Checked = status;
        MT32SysEx.hardwareMT32Connected = status;
    }

    private void sendMessagesToMT32DisplayToolStripMenuItem_Click(object sender, EventArgs e)
    {
        sendMessagesToMT32DisplayToolStripMenuItem.Checked = !MT32SysEx.sendTextToMT32;
        MT32SysEx.sendTextToMT32 ^= true;
        ConfigFile.Save();
    }

    private void showConsoleToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (showConsoleToolStripMenuItem.Checked)
        {
            ConsoleMessage.Hide();
            ConsoleMessage.DisableVerbose();
            verboseConsoleMessagesToolStripMenuItem.Checked = false;
            ShowWindow(GetConsoleWindow(), CONSOLE_HIDE);
        }
        else
        {
            ConsoleMessage.Show();
            ShowWindow(GetConsoleWindow(), CONSOLE_SHOW);
        }
        showConsoleToolStripMenuItem.Checked ^= true;
        verboseConsoleMessagesToolStripMenuItem.Enabled = showConsoleToolStripMenuItem.Checked;
        ConfigFile.Save();
    }

    private void verboseConsoleMessagesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        verboseConsoleMessagesToolStripMenuItem.Checked = !ConsoleMessage.Verbose();
        ConsoleMessage.SetVerbose(verboseConsoleMessagesToolStripMenuItem.Checked);
        ConfigFile.Save();
    }

    private void allowMT32ResetToolStripMenuItem_Click(object sender, EventArgs e)
    {
        allowMT32ResetToolStripMenuItem.Checked = !MT32SysEx.allowReset;
        MT32SysEx.allowReset ^= true;
        ConfigFile.Save();
    }

    private void ignoreSysConfigOnLoadToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ignoreSysConfigOnLoadToolStripMenuItem.Checked = !LoadSysExFile.ignoreSystemArea;
        LoadSysExFile.ignoreSystemArea ^= true;
        ConfigFile.Save();
    }

    private void excludeSysConfigonSaveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        excludeSysConfigonSaveToolStripMenuItem.Checked = !SaveSysExFile.excludeSystemArea;
        SaveSysExFile.excludeSystemArea ^= true;
        ConfigFile.Save();
    }

    private void autosaveEvery5MinutesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        autosaveEvery5MinutesToolStripMenuItem.Checked = !SaveSysExFile.autoSave;
        SaveSysExFile.autoSave ^= true;
        ConfigFile.Save();
    }

    private void darkModeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        darkModeToolStripMenuItem.Checked = !UITools.DarkMode;
        UITools.DarkMode ^= true;
        ConfigFile.Save();
    }
}
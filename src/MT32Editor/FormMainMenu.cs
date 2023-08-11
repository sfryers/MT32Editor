using System.Runtime.InteropServices;

namespace MT32Edit;

public partial class FormMainMenu : Form
{
    // MT-32 Editor
    // A patch/timbre editor and SysEx librarian for Roland MT-32/CM-32L and compatible synthesizers, including the MUNT software emulator.
    // S.Fryers
    // sfryers@hotmail.com
    //
    // MT32Edit: FormMainMenu
    // Primary form for MT-32 Editor application, serving as menu bar and MDI container for the memory bank editor, patch editor, rhythm editor and timbre editor forms.

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool AllocConsole();

    private const string VERSION_NO = "v0.9.5a";
    private const string RELEASE_DATE = "August 2023";

    private bool midiInError = false;
    private bool midiOutError = false;
    private readonly MT32State memoryState = new MT32State();
    private FormMemoryBankEditor memoryBankEditor;
    private FormTimbreEditor timbreEditor;
    private FormPatchEditor patchEditor;
    private FormRhythmEditor rhythmEditor;
    private readonly OpenFileDialog loadSysExDialog = new OpenFileDialog();
    private readonly SaveFileDialog saveSysExDialog = new SaveFileDialog();
    private readonly SaveFileDialog saveTimbreDialog = new SaveFileDialog();

    public FormMainMenu(string[] args)
    {
        InitializeComponent();
        AllocConsole();
        Console.WriteLine("Welcome to MT32 Editor " + VERSION_NO);
        InitialiseMidiConnections();
        if (midiInError || midiOutError)
        {
            return;
        }

        OpenTimbreEditor();
        OpenMemoryBankEditor();
        OpenRhythmEditor();
        OpenPatchEditor();
        ScaleUIElements();
        MT32SysEx.SendText("MT32 Editor " + ParseTools.TrimToLength(VERSION_NO, 8));
        timer.Start();
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
            if (memoryBankEditor == null)
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
            if (timbreEditor == null || memoryBankEditor == null)
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
            if (patchEditor == null || timbreEditor == null || memoryBankEditor == null)
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
            if (rhythmEditor == null || timbreEditor == null || memoryBankEditor == null)
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

    private void InitialiseMidiConnections()
    {
        string[] midiDeviceNames = ConfigFile.Load();
        InitialiseMidiInConnection();
        InitialiseMidiOutConnection();
        if (midiInError || midiOutError)
        {
            Close();
            return;
        }
        CheckForEmulator();

        void InitialiseMidiInConnection()
        {
            int inDeviceNo = 0;
            midiInToolStripMenuItem.Items.AddRange(Midi.ListInputDevices());                                    //List available MIDI In devices in combo box
            if (midiInToolStripMenuItem.Items.Count == 0)
            {
                return;
            }

            for (int device = 0; device <= Midi.CountInputDevices(); device++)
            {
                if (Midi.GetInputDeviceName(device).ToString() == midiDeviceNames[0])
                {
                    inDeviceNo = device;      //Set active MIDI In device
                }
            }
            midiInToolStripMenuItem.SelectedIndex = inDeviceNo;
            if (!Midi.OpenInputDevice(midiInToolStripMenuItem.SelectedIndex))
            {
                MidiInError(midiInToolStripMenuItem.Text);
            }
        }

        void InitialiseMidiOutConnection()
        {
            int outDeviceNo = 0;
            midiOutToolStripMenuItem.Items.AddRange(Midi.ListOutputDevices());                                  //List available MIDI Out devices in combo box
            if (midiOutToolStripMenuItem.Items.Count == 0)
            {
                return;
            }

            for (int device = 0; device <= Midi.CountOutputDevices(); device++)
            {
                if (Midi.GetOutputDeviceName(device).ToString() == midiDeviceNames[1])
                {
                    outDeviceNo = device;    //Set active MIDI Out device
                }
            }
            midiOutToolStripMenuItem.SelectedIndex = outDeviceNo;
            if (!Midi.OpenOutputDevice(midiOutToolStripMenuItem.SelectedIndex))
            {
                MidiOutError(midiOutToolStripMenuItem.Text);
            }
        }
    }

    private void MidiInError(string midiInDeviceName)
    {
        MessageBox.Show("Error: Cannot open MIDI In device '" + midiInDeviceName + "'\nPlease close any conflicting MIDI applications and restart MT-32 Editor.\nThis program will now exit.", "MT-32 Editor", MessageBoxButtons.OK);
        midiInError = true;
    }

    private void MidiOutError(string midiOutDeviceName)
    {
        MessageBox.Show("Error: Cannot open MIDI Out device '" + midiOutDeviceName + "'\nPlease close any conflicting MIDI applications and restart MT-32 Editor.\nThis program will now exit.", "MT-32 Editor", MessageBoxButtons.OK);
        midiOutError = true;
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
            MidiInError(midiInToolStripMenuItem.Text); //assign new MIDI In device
        }

        ConfigFile.Save();
        ConsoleMessage.SendLine("Config file saved");
    }

    private void midiOutToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
    {
        if (!midiOutError && !Midi.OpenOutputDevice(midiOutToolStripMenuItem.SelectedIndex))
        {
            MidiOutError(midiOutToolStripMenuItem.Text);
        }; //assign new MIDI Out device
        CheckForEmulator();
        ConfigFile.Save();
        ConsoleMessage.SendLine("Config file saved");
    }

    private void loadSysExFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        SysExFile.Load(loadSysExDialog, memoryState);
        if (loadSysExDialog.FileName != "")
        {
            saveSysExDialog.FileName = loadSysExDialog.FileName;
            saveSysExToolStripMenuItem.Enabled = true;
        }
    }

    private void saveSysExFileAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        saveSysExDialog.FileName = "New SysEx file.syx";
        SaveSysExFile();
    }

    private void saveSysExToolStripMenuItem_Click(object sender, EventArgs e)
    {
        SaveSysExFile();
    }

    private void SaveSysExFile()
    {
        saveSysExDialog.Title = "Save SysEx File";
        saveSysExDialog.Filter = "MIDI System Exclusive message file|*.syx";
        SysExFile.Save(memoryState, saveSysExDialog);
        saveSysExToolStripMenuItem.Enabled = true;
    }

    private void loadTimbreFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        LoadTimbre();
    }

    private void LoadTimbre()
    {
        int selectedTimbre = memoryState.GetSelectedMemoryTimbre();
        string timbreName = memoryState.GetTimbreNames().Get(selectedTimbre, 2);
        TimbreStructure timbreData = memoryState.GetMemoryTimbre(selectedTimbre);
        if (timbreName != MT32Strings.EMPTY)
        {
            switch (MessageBox.Show("Memory slot " + (selectedTimbre + 1).ToString() + " already contains a timbre. Replace " + timbreName + "?", "MT32 Editor", MessageBoxButtons.OKCancel))
            {
                case DialogResult.OK:
                    break;

                case DialogResult.Cancel:
                    return;
            }
        }
        string status = TimbreFile.Load(timbreData);
        if (status == "Cancelled" || status == "#Error!")
        {
            return;
        }

        saveTimbreDialog.FileName = status;
        saveTimbreFileToolStripMenuItem.Enabled = true;
        timbreName = timbreData.GetTimbreName();
        memoryState.GetTimbreNames().SetMemoryTimbreName(timbreName, selectedTimbre);
        MT32SysEx.SendMemoryTimbre(selectedTimbre, timbreData);
        MT32SysEx.PreviewTimbre(selectedTimbre, timbreData);
        memoryBankEditor.Select();
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

    private void FormMainMenu_FormClosing(object sender, FormClosingEventArgs e)
    {
        Midi.CloseInputDevice();
        Midi.CloseOutputDevice();
    }

    private void patchEditorToolStripMenuItem_Click(object sender, EventArgs e)
    {
        patchEditor.Visible = true;
        patchEditorToolStripMenuItem.Checked = true;
        rhythmEditor.Visible = false;
        rhythmEditorToolStripMenuItem.Checked = false;
    }

    private void rhythmEditorToolStripMenuItem_Click(object sender, EventArgs e)
    {
        patchEditor.Visible = false;
        patchEditorToolStripMenuItem.Checked = false;
        rhythmEditor.Visible = true;
        rhythmEditorToolStripMenuItem.Checked = true;
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        FormAbout about = new FormAbout(VERSION_NO, RELEASE_DATE);
        about.Show();
    }

    private void masterSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        FormSystemSettings systemSettings = new FormSystemSettings(memoryState.GetSystem());
        systemSettings.ShowDialog();
    }

    private void timer_Tick(object sender, EventArgs e)
    {
        if ((memoryState.patchEditorActive || memoryState.rhythmEditorActive) && !memoryState.TimbreIsEditable())
        {
            DisableTimbreEditor();
        }
        else
        {
            EnableTimbreEditor();
        }

        if (memoryState.GetMemoryTimbre(memoryState.GetSelectedMemoryTimbre()).GetTimbreName() == MT32Strings.EMPTY)
        {
            saveTimbreFileToolStripMenuItem.Enabled = false;
        }
        else
        {
            saveTimbreFileToolStripMenuItem.Enabled = true;
        }

        if (midiInError || midiOutError)
        {
            Close();
        }
    }

    private void DisableTimbreEditor()
    {
        if ((timbreEditor == null) || !timbreEditor.Enabled)
        {
            return;
        }

        timbreEditor.Enabled = false;
        ConsoleMessage.SendLine("Disabling timbre editor");
    }

    private void EnableTimbreEditor()
    {
        if ((timbreEditor == null) || timbreEditor.Enabled)
        {
            return;
        }

        timbreEditor.Enabled = true;
        ConsoleMessage.SendLine("Enabling timbre editor");
    }

    private void hardwareMT32ConnectedToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (Midi.hardwareMT32)
        {
            EmulatorConnected();
        }
        else
        {
            MT32Connected();
        }
    }

    private void CheckForEmulator()
    {
        if (Midi.Out != null && !midiOutError && Midi.GetOutputDeviceName(midiOutToolStripMenuItem.SelectedIndex) == "MT-32 Synth Emulator")
        {
            EmulatorConnected();
        }
    }

    private void EmulatorConnected()
    {
        Midi.hardwareMT32 = false;
        hardwareMT32ConnectedToolStripMenuItem.Checked = false;
    }

    private void MT32Connected()
    {
        Midi.hardwareMT32 = true;
        hardwareMT32ConnectedToolStripMenuItem.Checked = true;
    }

    private void sendMessagesToMT32DisplayToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (MT32SysEx.sendTextToMT32)
        {
            sendMessagesToMT32DisplayToolStripMenuItem.Checked = false;
            MT32SysEx.sendTextToMT32 = false;
        }
        else
        {
            sendMessagesToMT32DisplayToolStripMenuItem.Checked = true;
            MT32SysEx.sendTextToMT32 = true;
        }
    }

    private void verboseConsoleMessagesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (ConsoleMessage.Enabled())
        {
            ConsoleMessage.Disable();
            verboseConsoleMessagesToolStripMenuItem.Checked = false;
        }
        else
        {
            ConsoleMessage.Enable();
            verboseConsoleMessagesToolStripMenuItem.Checked = true;
        }
    }

    private void allowMT32ResetToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (MT32SysEx.allowReset)
        {
            allowMT32ResetToolStripMenuItem.Checked = false;
            MT32SysEx.allowReset = false;
        }
        else
        {
            allowMT32ResetToolStripMenuItem.Checked = true;
            MT32SysEx.allowReset = true;
        }
    }
}
using System.Windows.Forms;
using System;
namespace MT32Edit_legacy;

/// <summary>
/// Form showing visual representation of MT-32's rhythm setup- allows custom rhythm instruments to be configured
/// </summary>
public partial class FormRhythmEditor : Form
{
    // MT32Edit: FormRhythmEditor
    // S.Fryers Apr 2024

    // Preset banks A [0] and B [1] cannot be allocated to rhythm part, only memory [2] and rhythm [3] banks can be used.
    private const int BANK_OFFSET = 2;

    private MT32State memoryState;
    private DateTime lastGlobalUpdate = DateTime.Now;
    private bool thisFormIsActive = false;
    private bool changesMade = false;
    private bool darkMode = !UITools.DarkMode;
    private int pressedKey = -1;
    private float UIScale;

    public FormRhythmEditor(float DPIScale, MT32State parentMemoryState)
    {
        InitializeComponent();
        memoryState = parentMemoryState;
        UIScale = DPIScale;
        ScaleUIElements();
        SetTheme();
        InitialiseRhythmBank();
        ConfigureWarnings();
        changesMade = false;
        timer.Start();
    }

    private void ScaleUIElements()
    {
        ScaleListView();
        ScaleListViewColumns();
    }

    private void SetTheme()
    {
        if (darkMode == UITools.DarkMode)
        {
            return;
        }
        Label[] labels = {labelKeyNo, labelLevel, labelNoChannelAssigned, labelPan, labelReverb, labelTimbreGroup, labelTimbreName };
        Label[] warningLabels = { labelNoChannelAssigned, labelUnitNoWarning };
        RadioButton[] radioButtons = { radioButtonReverbOff, radioButtonReverbOn };
        BackColor = UITools.SetThemeColours(labelHeading, labels, warningLabels, checkBoxes: null, groupBoxes: null, listViewRhythmBank, radioButtons, alternate: true);
        darkMode = UITools.DarkMode;
    }

    private void InitialiseRhythmBank()
    {
        listViewRhythmBank.Items.Clear();
        for (int keyNo = RhythmConstants.KEY_OFFSET; keyNo < MT32State.NO_OF_RHYTHM_BANKS + RhythmConstants.KEY_OFFSET; keyNo++)
        {
            AddListViewColumnItems(keyNo);
        }
        SelectKeyInListView(RhythmConstants.KEY_OFFSET);
        PopulateRhythmFormParameters(RhythmConstants.KEY_OFFSET);
        comboBoxTimbreName.Items.Clear();
        comboBoxTimbreName.Items.AddRange(memoryState.GetTimbreNames().GetAll(comboBoxTimbreGroup.SelectedIndex + BANK_OFFSET));
    }

    private void ConfigureWarnings()
    {
        if (MT32SysEx.DeviceID != MT32SysEx.DEFAULT_DEVICE_ID)
        {
            labelUnitNoWarning.Visible = true;
        }
    }

    private void timer_Tick(object sender, EventArgs e)
    {
        if (!thisFormIsActive)
        {
            int selectedTimbre = memoryState.GetSelectedMemoryTimbre();
            CheckForMemoryStateUpdates();
            FindMemoryTimbreInRhythmList(selectedTimbre);

        }
        if (comboBoxTimbreGroup.Text == "Memory")
        {
            SyncMemoryTimbreNames();
        }

        if (memoryState.returnFocusToRhythmEditor)
        {
            ReturnFocusToRhythmEditor();
        }
        CheckPartStatus();
        SetTheme();
    }

    /// <summary>
    /// Scale listView to form size
    /// </summary>
    private void ScaleListView()
    {
        listViewRhythmBank.Width = Width - 20;
        listViewRhythmBank.Height = Height - (int)(272 * Math.Pow(UIScale, 1.3));
    }

    private void ScaleListViewColumns()
    {
        //Set column widths to fill the available space
        int listWidth = listViewRhythmBank.Width;
        double[] columnWidth = { 0.10, 0.13, 0.20, 0.21, 0.12, 0.08, 0.10 };
        for (int i = 0; i < 7; i++)
        {
            listViewRhythmBank.Columns[i].Width = (int)(listWidth * columnWidth[i]);
        }
    }

    private void SelectKeyInListView(int keyNo)
    {
        listViewRhythmBank.Items[keyNo - RhythmConstants.KEY_OFFSET].Selected = true;
        listViewRhythmBank.Items[keyNo - RhythmConstants.KEY_OFFSET].EnsureVisible();
        listViewRhythmBank.Select();
    }

    private void RefreshRhythmBankList()
    {
        listViewRhythmBank.Items.Clear();
        for (int keyNo = RhythmConstants.KEY_OFFSET; keyNo < MT32State.NO_OF_RHYTHM_BANKS + RhythmConstants.KEY_OFFSET; keyNo++)
        {
            AddListViewColumnItems(keyNo);
        }
        int selectedKey = memoryState.GetSelectedKey();
        SelectKeyInListView(selectedKey);
    }

    /// <summary>
    /// Updates controls with selected patch parameter values
    /// </summary>
    private void PopulateRhythmFormParameters(int keyNo)
    {
        int bankNo = keyNo - RhythmConstants.KEY_OFFSET;
        int selectedKey = keyNo;
        MT32SysEx.blockSysExMessages = true;
        numericUpDownKeyNo.Value = selectedKey;
        Rhythm rhythmKey = memoryState.GetRhythmBank(bankNo);
        comboBoxTimbreGroup.Text = rhythmKey.GetTimbreGroupType();
        comboBoxTimbreName.Text = memoryState.GetTimbreNames().Get(rhythmKey.GetTimbreNo(), rhythmKey.GetTimbreGroup() + BANK_OFFSET); //get timbre name from timbre no. and timbre group
        trackBarLevel.Value = rhythmKey.GetOutputLevel();
        trackBarPanPot.Value = rhythmKey.GetPanPot();
        SetLevelToolTip();
        SetPanPotToolTip();
        radioButtonReverbOn.Checked = rhythmKey.GetReverbEnabled();
        radioButtonReverbOff.Checked = !rhythmKey.GetReverbEnabled();
        MT32SysEx.blockSysExMessages = false;
    }

    private void AddListViewColumnItems(int keyNo)
    {
        int bankNo = keyNo - RhythmConstants.KEY_OFFSET;
        ListViewItem item = new ListViewItem(keyNo.ToString());
        Rhythm rhythmKey = memoryState.GetRhythmBank(bankNo);
        item.SubItems.Add(MT32Strings.PitchNote(keyNo));
        item.SubItems.Add(rhythmKey.GetTimbreGroupType());
        item.SubItems.Add(memoryState.GetTimbreNames().Get(rhythmKey.GetTimbreNo(), rhythmKey.GetTimbreGroup() + BANK_OFFSET)); //get timbre name from timbre no. and timbre group);
        item.SubItems.Add(MT32Strings.OnOffStatus(rhythmKey.GetReverbEnabled()));
        item.SubItems.Add(rhythmKey.GetPanPot().ToString());
        item.SubItems.Add(rhythmKey.GetOutputLevel().ToString());
        listViewRhythmBank.Items.Add(item);
    }

    private void DoFullRefresh()
    {
        UpdateMemoryTimbreNames();
        RefreshRhythmBankList();
        RefreshTimbreNamesList();
    }

    private void UpdateMemoryTimbreNames()
    {
        for (int timbreNo = 0; timbreNo < MT32State.NO_OF_MEMORY_TIMBRES; timbreNo++)
        {
            memoryState.GetTimbreNames().SetMemoryTimbreName(memoryState.GetMemoryTimbre(timbreNo).GetTimbreName(), timbreNo);
        }
    }

    private void UpdateTimbreName()
    {
        int bankNo = memoryState.GetSelectedKey() - RhythmConstants.KEY_OFFSET;
        Rhythm rhythmData = memoryState.GetRhythmBank(bankNo);
        rhythmData.SetTimbreNo(comboBoxTimbreName.SelectedIndex);
        comboBoxTimbreName.Text = memoryState.GetTimbreNames().Get(rhythmData.GetTimbreNo(), rhythmData.GetTimbreGroup());
    }

    private void SetPanPotToolTip()
    {
        toolTipParameterValue.SetToolTip(trackBarPanPot, $"Pan = {trackBarPanPot.Value}");
    }

    private void SetLevelToolTip()
    {
        toolTipParameterValue.SetToolTip(trackBarLevel, $"Level = {trackBarLevel.Value}");
    }

    private void CheckForUnsavedChanges(FormClosingEventArgs e)
    {
        if (changesMade)
        {
            e.Cancel = !UITools.AskUserToConfirm("Unsaved changes will be lost!", "MT-32 Editor");
        }
    }

    private void RefreshTimbreNamesList()
    {
        string[] memoryTimbreNameArray = memoryState.GetTimbreNames().GetAll(comboBoxTimbreGroup.SelectedIndex + BANK_OFFSET);
        comboBoxTimbreName.Items.Clear();
        comboBoxTimbreName.Items.AddRange(memoryTimbreNameArray);
        comboBoxTimbreName.Invalidate();
    }

    private void listViewRhythmBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listViewRhythmBank.SelectedIndices.Count > 0)
        {
            PopulateRhythmFormParameters(listViewRhythmBank.SelectedIndices[0] + RhythmConstants.KEY_OFFSET);
        }
    }

    private void numericUpDownKeyNo_ValueChanged(object sender, EventArgs e)
    {
        int selectedKey = (int)numericUpDownKeyNo.Value;
        memoryState.SetSelectedKey(selectedKey);
        SelectKeyInListView(selectedKey);
        PopulateRhythmFormParameters(selectedKey);
        RefreshTimbreNamesList();
    }

    private void comboBoxTimbreGroup_SelectionChangeCommitted(object sender, EventArgs e)
    {
        int selectedKey = memoryState.GetSelectedKey();
        int bankNo = selectedKey - RhythmConstants.KEY_OFFSET;
        Rhythm rhythmData = memoryState.GetRhythmBank(bankNo);
        rhythmData.SetTimbreGroup(comboBoxTimbreGroup.SelectedIndex);
        comboBoxTimbreName.Items.Clear();
        comboBoxTimbreName.Items.AddRange(memoryState.GetTimbreNames().GetAll(comboBoxTimbreGroup.SelectedIndex + BANK_OFFSET));
        if (listViewRhythmBank.SelectedIndices.Count > 0)
        {
            listViewRhythmBank.SelectedItems[0].SubItems[2].Text = rhythmData.GetTimbreGroupType();
            listViewRhythmBank.SelectedItems[0].SubItems[3].Text = memoryState.GetTimbreNames().Get(rhythmData.GetTimbreNo(), rhythmData.GetTimbreGroup() + BANK_OFFSET);
        }
        PopulateRhythmFormParameters(selectedKey);
        MT32SysEx.SendRhythmKey(rhythmData, selectedKey);
        changesMade = true;
    }

    private void comboBoxTimbreName_SelectionChangeCommitted(object sender, EventArgs e)
    {
        int selectedKey = memoryState.GetSelectedKey();
        Rhythm rhythmData = memoryState.GetRhythmKey(selectedKey);
        UpdateTimbreName();
        if (listViewRhythmBank.SelectedIndices.Count > 0)
        {
            listViewRhythmBank.SelectedItems[0].SubItems[3].Text = comboBoxTimbreName.Text;
        }
        MT32SysEx.SendRhythmKey(rhythmData, selectedKey);
        changesMade = true;
    }

    private void radioButtonReverbOn_CheckedChanged(object sender, EventArgs e)
    {
        int selectedKey = memoryState.GetSelectedKey();
        int bankNo = selectedKey - RhythmConstants.KEY_OFFSET;
        Rhythm rhythmData = memoryState.GetRhythmBank(bankNo);
        rhythmData.SetReverbEnabled(radioButtonReverbOn.Checked);
        if (listViewRhythmBank.SelectedIndices.Count > 0)
        {
            listViewRhythmBank.SelectedItems[0].SubItems[4].Text = MT32Strings.OnOffStatus(radioButtonReverbOn.Checked);
        }
        MT32SysEx.SendRhythmKey(rhythmData, selectedKey);
    }

    private void trackBarPanPot_ValueChanged(object sender, EventArgs e)
    {
        int selectedKey = memoryState.GetSelectedKey();
        int bankNo = selectedKey - RhythmConstants.KEY_OFFSET;
        Rhythm rhythmData = memoryState.GetRhythmBank(bankNo);
        rhythmData.SetPanPot(trackBarPanPot.Value);
        if (listViewRhythmBank.SelectedIndices.Count > 0)
        {
            listViewRhythmBank.SelectedItems[0].SubItems[5].Text = trackBarPanPot.Value.ToString();
        }
        MT32SysEx.SendRhythmKey(rhythmData, selectedKey);
        SetPanPotToolTip();
        changesMade = true;
    }

    private void trackBarLevel_ValueChanged(object sender, EventArgs e)
    {
        int selectedKey = memoryState.GetSelectedKey();
        int bankNo = selectedKey - RhythmConstants.KEY_OFFSET;
        Rhythm rhythmData = memoryState.GetRhythmBank(bankNo);
        rhythmData.SetOutputLevel(trackBarLevel.Value);
        if (listViewRhythmBank.SelectedIndices.Count > 0)
        {
            listViewRhythmBank.SelectedItems[0].SubItems[6].Text = trackBarLevel.Value.ToString();
        }
        SetLevelToolTip();
        MT32SysEx.SendRhythmKey(rhythmData, selectedKey);
        changesMade = true;
    }

    private void FormRhythmEditor_FormClosing(object sender, FormClosingEventArgs e)
    {
        CheckForUnsavedChanges(e);
    }

    private void FormRhythmEditor_Resize(object sender, EventArgs e)
    {
        ScaleListView();
    }

    private void buttonPlayNote_MouseDown(object sender, MouseEventArgs e)
    {
        int selectedKey = memoryState.GetSelectedKey();
        int midiChannel = memoryState.GetSystem().GetSysExMidiChannel(8);
        Midi.NoteOn(selectedKey, midiChannel);
        pressedKey = selectedKey;
    }

    private void buttonPlayNote_MouseUp(object sender, MouseEventArgs e)
    {
        int midiChannel = memoryState.GetSystem().GetSysExMidiChannel(8);
        if (pressedKey >= 0)
        {
            Midi.NoteOff(pressedKey, midiChannel);
        }
        pressedKey = -1;
    }

    private void CheckPartStatus()
    {
        if (memoryState.GetSystem().GetUIMidiChannel(8) == 0)
        {
            //Rhythm part is disabled
            buttonPlayNote.Enabled = false;
            labelNoChannelAssigned.Visible = true;
            return;
        }
        buttonPlayNote.Enabled = true;
        labelNoChannelAssigned.Visible = false;
    }

    private void FindMemoryTimbreInRhythmList(int selectedTimbreNo)
    {
        for (int bankNo = 0; bankNo < MT32State.NO_OF_RHYTHM_BANKS; bankNo++)
        {
            Rhythm rhythmData = memoryState.GetRhythmBank(bankNo);
            if (rhythmData.GetTimbreGroupType() == "Memory" && rhythmData.GetTimbreNo() == selectedTimbreNo)
            {
                int keyNo = bankNo + RhythmConstants.KEY_OFFSET;
                if (memoryState.rhythmEditorActive)
                {
                    // only proceed if focus is not on rhythm editor
                    return;
                }

                if (numericUpDownKeyNo.Value == keyNo)
                {
                    // patch is already selected
                    return;
                }

                // focus on selected rhythm key
                numericUpDownKeyNo.Value = keyNo;
                memoryState.returnFocusToMemoryBankList = true;
                return;
            }
        }
    }

    private void CheckForMemoryStateUpdates()
    {
        //only refresh if memoryState has recently been updated
        if (memoryState.requestRhythmRefresh || lastGlobalUpdate < memoryState.GetUpdateTime())
        {
            ConsoleMessage.SendVerboseLine("Updating Rhythm Bank List");
            DoFullRefresh();
            lastGlobalUpdate = DateTime.Now;
            memoryState.requestRhythmRefresh = false;
        }
    }

    private void SyncMemoryTimbreNames()
    {
        int selectedBank = memoryState.GetSelectedBank();
        string newTimbreName = memoryState.GetTimbreNames().Get(memoryState.GetRhythmBank(selectedBank).GetTimbreNo(), 2);
        if (listViewRhythmBank.SelectedIndices.Count > 0)
        {
            listViewRhythmBank.SelectedItems[0].SubItems[3].Text = newTimbreName;
        }

        if (comboBoxTimbreName.Text != newTimbreName && !comboBoxTimbreName.DroppedDown)
        {
            ConsoleMessage.SendVerboseLine("Updating Memory Timbre Names List");
            //ensure that memory timbre name changes are synchronised across comboBox and listView
            RefreshTimbreNamesList();
            comboBoxTimbreName.Text = newTimbreName;
        }
    }

    private void ReturnFocusToRhythmEditor()
    {
        listViewRhythmBank.Select();
        memoryState.returnFocusToRhythmEditor = false;
    }

    private void FormRhythmEditor_Activated(object sender, EventArgs e)
    {
        thisFormIsActive = true;
        memoryState.rhythmEditorActive = true;
        memoryState.patchEditorActive = false;
    }

    private void FormRhythmEditor_Leave(object sender, EventArgs e)
    {
        thisFormIsActive = false;
    }
}
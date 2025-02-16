using System.Windows.Forms;
using System;
using System.Drawing;
namespace MT32Edit;

/// <summary>
/// Form showing visual representation of MT-32's 128
/// patch banks- allows custom patches to be configured
/// </summary>

// MT32Edit: FormPatchEditor
// S.Fryers Feb 2025

public partial class FormPatchEditor : Form
{
    private MT32State memoryState;
    private DateTime lastGlobalUpdate = DateTime.Now;
    private bool thisFormIsActive = true;
    private bool darkMode = !UITools.DarkMode;
    private float UIScale;

    private const string TEXT_EDIT_PRESET = "Edit Preset Timbre";
    private const string TEXT_RESTORE_PRESET = "Restore Preset Timbre";

    public FormPatchEditor(float DPIScale, MT32State parentMemoryState)
    {
        InitializeComponent();
        UIScale = DPIScale;
        ScaleUIElements();
        SetTheme();
        memoryState = parentMemoryState;
        InitialisePatchArray();
        ConfigureWarnings();
        memoryState.changesMade = false;
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
        Label[] labels = {labelAssignMode, labelBendRange, labelFineTune, labelKeyShift, labelPatchNo, labelReverb, labelTimbreGroup, labelTimbreName };
        Label[] warningLabels = {labelNoChannelAssigned, labelUnitNoWarning};
        RadioButton[] radioButtons = { radioButtonReverbOff, radioButtonReverbOn };
        BackColor = UITools.SetThemeColours(labelHeading, labels, warningLabels, checkBoxes: null, groupBoxes: null, listViewPatches, radioButtons, alternate: true);
        darkMode = UITools.DarkMode;
    }

    private void InitialisePatchArray()
    {
        listViewPatches.Items.Clear();
        for (int patchNo = 0; patchNo < MT32State.NO_OF_PATCHES; patchNo++)
        {
            AddListViewColumnItems(patchNo);
        }
        int selectedPatch = memoryState.GetSelectedPatchNo();
        SelectPatchInListView(selectedPatch);
        PopulatePatchFormParameters(selectedPatch);
        PopulateTimbreNamesList();
        int midiChannel = memoryState.GetSystem().GetSysExMidiChannel(0);
        Midi.SendProgramChange(selectedPatch, midiChannel);
    }

    private void ConfigureWarnings()
    {
        if (MT32SysEx.DeviceID != MT32SysEx.DEFAULT_DEVICE_ID)
        {
            labelUnitNoWarning.Visible = true;
        }
        if (MT32SysEx.cm32LMode)
        {
            labelMT32ModeWarning.Visible = false;
            return;
        }
        labelMT32ModeWarning.Visible = true;
    }

    private void timer_Tick(object sender, EventArgs e)
    {
        if (!thisFormIsActive)
        {
            int selectedTimbre = memoryState.GetSelectedMemoryTimbre();
            CheckForMemoryStateUpdates();
            UpdateMemoryTimbreNames();
            FindMemoryTimbreInPatchList(selectedTimbre);
        }
        if (comboBoxTimbreGroup.Text == "Memory")
        {
            SyncMemoryTimbreNames();
        }

        if (memoryState.returnFocusToPatchEditor)
        {
            ReturnFocusToPatchEditor();
        }
        CheckPartStatus();
        SetTheme();
        ColourListViewItems();
    }

    /// <summary>
    /// Scales listView to form size
    /// </summary>
    private void ScaleListView()
    {
        listViewPatches.Width = Width - (int)(30 * Math.Pow(UIScale, 1.3));
        listViewPatches.Height = Height - (int)(320 * Math.Pow(UIScale, 1.3));
    }

    /// <summary>
    /// Sets column widths to fill the available space
    /// </summary>
    private void ScaleListViewColumns()
    {
        int listWidth = listViewPatches.Width;
        double[] columnWidth = {0.09, 0.19, 0.19, 0.08, 0.08, 0.09, 0.11, 0.12};
        for (int i = 0; i < 8; i++)
        {
            listViewPatches.Columns[i].Width = (int)(listWidth * columnWidth[i]);
        }
    }

    private void SelectPatchInListView(int patchNo)
    {
        listViewPatches.Items[patchNo].Selected = true;
        listViewPatches.Items[patchNo].EnsureVisible();
        listViewPatches.Select();
    }

    /// <summary>
    /// Updates controls with selected patch parameter values
    /// </summary>
    private void PopulatePatchFormParameters(int patchNo)
    {
        //prevent every updated form control from triggering a separate sysex message
        MT32SysEx.blockSysExMessages = true;
        int selectedPatch = patchNo;
        memoryState.SetSelectedPatchNo(selectedPatch);
        Patch memoryPatch = memoryState.GetPatch(patchNo);
        numericUpDownPatchNo.Value = selectedPatch + 1;
        string timbreGroupType = memoryPatch.GetTimbreGroupType();
        comboBoxTimbreName.Text = memoryState.GetTimbreNames().Get(memoryPatch.GetTimbreNo(), memoryPatch.GetTimbreGroup()); //get timbre name from timbre no. and timbre group
        comboBoxTimbreGroup.Text = timbreGroupType;
        trackBarBenderRange.Value = memoryPatch.GetBenderRange();
        trackBarFineTune.Value = memoryPatch.GetFineTune();
        trackBarKeyShift.Value = memoryPatch.GetKeyShift();
        SetBendRangeToolTip();
        SetFineTuneToolTip();
        SetKeyShiftToolTip();
        comboBoxAssignMode.SelectedIndex = memoryPatch.GetAssignMode();
        radioButtonReverbOn.Checked = memoryPatch.GetReverbEnabled();
        radioButtonReverbOff.Checked = !memoryPatch.GetReverbEnabled();
        MT32SysEx.blockSysExMessages = false;
    }

    private void RefreshPatchList()
    {
        listViewPatches.Items.Clear();
        for (int patchNo = 0; patchNo < MT32State.NO_OF_PATCHES; patchNo++)
        {
            AddListViewColumnItems(patchNo);
        }
        SelectPatchInListView(memoryState.GetSelectedPatchNo());
    }

    private void AddListViewColumnItems(int patchNo)
    {
        //number patch list starting from 1
        ListViewItem item = new ListViewItem((patchNo + 1).ToString());
        Patch memoryPatch = memoryState.GetPatch(patchNo);
        item.SubItems.Add(memoryPatch.GetTimbreGroupType());
        item.SubItems.Add(memoryState.GetTimbreNames().Get(memoryPatch.GetTimbreNo(), memoryPatch.GetTimbreGroup()));
        item.SubItems.Add(memoryPatch.GetKeyShift().ToString());
        item.SubItems.Add(memoryPatch.GetFineTune().ToString());
        item.SubItems.Add(memoryPatch.GetBenderRange().ToString());
        item.SubItems.Add(MT32Strings.OnOffStatus(memoryPatch.GetReverbEnabled()));
        //modes are internally numbered 0-3, but show 1-4 in UI.
        item.SubItems.Add((memoryPatch.GetAssignMode() + 1).ToString());
        listViewPatches.Items.Add(item);
        ColourListViewItem(patchNo);
    }

    private void SendPatch(int patchNo, bool sendSysExMessage)
    {
        if (sendSysExMessage)
        {
            MT32SysEx.SendPatchData(memoryState.GetPatchArray(), patchNo);
        }
        int midiChannel = memoryState.GetSystem().GetSysExMidiChannel(0);
        Midi.SendProgramChange(patchNo, midiChannel);
        Patch memoryPatch = memoryState.GetPatch(patchNo);
        MT32SysEx.SendText($"Patch {patchNo + 1}|{memoryState.GetTimbreNames().Get(memoryPatch.GetTimbreNo(), memoryPatch.GetTimbreGroup())}");
    }

    private void SendPatchParameterChange(int patchNo, int parameterNo)
    {
        MT32SysEx.SendPatchParameterData(memoryState.GetPatchArray(), patchNo, parameterNo);
    }

    private void UpdateTimbreName()
    {
        int selectedPatch = memoryState.GetSelectedPatchNo();
        memoryState.GetPatch(selectedPatch).SetTimbreNo(comboBoxTimbreName.SelectedIndex);
        PopulatePatchFormParameters(selectedPatch);
        MT32SysEx.SendPatchData(memoryState.GetPatchArray(), selectedPatch);
    }

    private void UpdateMemoryTimbreNames()
    {
        for (int timbreNo = 0; timbreNo < MT32State.NO_OF_MEMORY_TIMBRES; timbreNo++)
        {
            string timbreName = memoryState.GetMemoryTimbre(timbreNo).GetTimbreName();
            memoryState.GetTimbreNames().SetMemoryTimbreName(timbreName, timbreNo);
        }
    }

    private void ColourListViewItems()
    {
        for (int patchNo = 0; patchNo < listViewPatches.Items.Count; patchNo++)
        {
            ColourListViewItem(patchNo);
        }
    }

    private void ColourListViewItem(int patchNo)
    {  
        if (MT32SysEx.cm32LMode)
        {
            return;
        }
        Patch patch = memoryState.GetPatch(patchNo);
        if (patch.GetTimbreGroupType() != "Memory")
        {
            return;
        }
        int timbreNo = patch.GetTimbreNo();
        if (memoryState.GetMemoryTimbre(timbreNo).ContainsCM32LSamples())
        {
            Color mediumRed = Color.FromArgb(255, 90, 90);
            listViewPatches.Items[patchNo].ForeColor = mediumRed;
            return;
        }
        listViewPatches.Items[patchNo].ForeColor = Color.Empty;
    }

    private void CheckForUnsavedChanges(FormClosingEventArgs e)
    {
        if (memoryState.changesMade)
        {
            e.Cancel = !UITools.AskUserToConfirm("Unsaved changes will be lost!", "MT-32 Editor");
        }
    }

    private void DoFullRefresh(int patchNo)
    {
        UpdateMemoryTimbreNames();
        RefreshPatchList();
        SendPatch(patchNo, sendSysExMessage: true);
        RefreshTimbreNamesList();
        ConfigureEditButton();
    }

    private void RefreshTimbreNamesList()
    {
        PopulateTimbreNamesList();
        comboBoxTimbreName.Invalidate();
    }

    private void PopulateTimbreNamesList()
    {
        comboBoxTimbreName.Items.Clear();
        comboBoxTimbreName.Items.AddRange(memoryState.GetTimbreNames().GetAll(comboBoxTimbreGroup.SelectedIndex));
    }

    /// <summary>
    /// Patch selection changed -> populate controls with new patch parameters
    /// </summary>
    private void listViewPatches_SelectedIndexChanged(object sender, EventArgs e)
    {
        //don't attempt to read from an empty listview
        if (listViewPatches.SelectedIndices.Count > 0)
        {
            int selectedPatch = listViewPatches.SelectedIndices[0];
            PopulatePatchFormParameters(selectedPatch);
            SendPatch(selectedPatch, sendSysExMessage: false);
        }
        RefreshTimbreNamesList();
    }

    /// <summary>
    /// Updates controls with selected patch parameter values
    /// </summary>
    private void numericUpDownPatchNo_ValueChanged(object sender, EventArgs e)
    {
        int selectedPatch = (int)numericUpDownPatchNo.Value - 1;
        memoryState.SetSelectedPatchNo(selectedPatch);
        SendPatch(selectedPatch, sendSysExMessage: false);
        SelectPatchInListView(selectedPatch);
        RefreshTimbreNamesList();
        string timbreGroupType = memoryState.GetPatch(selectedPatch).GetTimbreGroupType();
        if (timbreGroupType == "Memory")
        {
            memoryState.SetTimbreIsEditable(true);
        }
        else
        {
            memoryState.SetTimbreIsEditable(false);
        }
        ConfigureEditButton();
    }

    private void ConfigureEditButton()
    {
        int selectedPatch = (int)numericUpDownPatchNo.Value - 1;
        string timbreGroupType = memoryState.GetPatch(selectedPatch).GetTimbreGroupType();
        if (timbreGroupType == "Preset A" || timbreGroupType == "Preset B")
        {
            buttonEditPreset.Text = TEXT_EDIT_PRESET;
            buttonEditPreset.Enabled = true;
        }
        else
        {
            buttonEditPreset.Text = TEXT_RESTORE_PRESET;
            buttonEditPreset.Enabled = true;
        }
    }

    private void SetKeyShiftToolTip()
    {
        toolTipParameterValue.SetToolTip(trackBarKeyShift, $"Key Shift = {trackBarKeyShift.Value}");
    }

    private void SetFineTuneToolTip()
    {
        toolTipParameterValue.SetToolTip(trackBarFineTune, $"Fine Tune = {trackBarFineTune.Value}");
    }

    private void SetBendRangeToolTip()
    {
        toolTipParameterValue.SetToolTip(trackBarBenderRange, $"Bend Range ={trackBarBenderRange.Value}");
    }

    private void FormPatchEditor_Resize(object sender, EventArgs e)
    {
        ScaleListView();
    }

    /// <summary>
    /// Timbre group changed -> populate timbre list with names from selected bank
    /// </summary>
    private void comboBoxTimbreGroup_SelectionChangeCommitted(object sender, EventArgs e)
    {
        int selectedPatch = memoryState.GetSelectedPatchNo();
        Patch memoryPatch = memoryState.GetPatch(selectedPatch);
        memoryPatch.SetTimbreGroup(comboBoxTimbreGroup.SelectedIndex);
        memoryPatch.SetTimbreNo(0);
        PopulateTimbreNamesList();
        comboBoxTimbreName.Text = memoryState.GetTimbreNames().Get(memoryPatch.GetTimbreNo(), memoryPatch.GetTimbreGroup());
        ConfigureEditButton();
        if (listViewPatches.SelectedIndices.Count > 0)
        {
            listViewPatches.SelectedItems[0].SubItems[1].Text = memoryPatch.GetTimbreGroupType();
            listViewPatches.SelectedItems[0].SubItems[2].Text = comboBoxTimbreName.Text;
        }
        SendPatch(selectedPatch, sendSysExMessage: true);
        memoryState.changesMade = true;
    }

    private void comboBoxTimbreName_SelectionChangeCommitted(object sender, EventArgs e)
    {
        UpdateTimbreName();
        int selectedPatch = memoryState.GetSelectedPatchNo();
        Patch memoryPatch = memoryState.GetPatch(selectedPatch);
        if (listViewPatches.SelectedIndices.Count > 0)
        {
            listViewPatches.SelectedItems[0].SubItems[2].Text = memoryState.GetTimbreNames().Get(memoryPatch.GetTimbreNo(), memoryPatch.GetTimbreGroup());
        }
        SendPatch(selectedPatch, sendSysExMessage: false);
        memoryState.changesMade = true;
    }

    private void trackBarKeyShift_ValueChanged(object sender, EventArgs e)
    {
        int selectedPatch = memoryState.GetSelectedPatchNo();
        memoryState.GetPatch(selectedPatch).SetKeyShift(trackBarKeyShift.Value);
        if (listViewPatches.SelectedIndices.Count > 0)
        {
            listViewPatches.SelectedItems[0].SubItems[3].Text = trackBarKeyShift.Value.ToString();
        }
        SetKeyShiftToolTip();
        SendPatchParameterChange(selectedPatch, 0x02);
        memoryState.changesMade = true;
    }

    private void trackBarFineTune_ValueChanged(object sender, EventArgs e)
    {
        int selectedPatch = memoryState.GetSelectedPatchNo();
        memoryState.GetPatch(selectedPatch).SetFineTune(trackBarFineTune.Value);
        if (listViewPatches.SelectedIndices.Count > 0)
        {
            listViewPatches.SelectedItems[0].SubItems[4].Text = trackBarFineTune.Value.ToString();
        }
        SetFineTuneToolTip();
        SendPatchParameterChange(selectedPatch, 0x03);
        memoryState.changesMade = true;
    }

    private void trackBarBenderRange_ValueChanged(object sender, EventArgs e)
    {
        int selectedPatch = memoryState.GetSelectedPatchNo();
        memoryState.GetPatch(selectedPatch).SetBenderRange(trackBarBenderRange.Value);
        if (listViewPatches.SelectedIndices.Count > 0)
        {
            listViewPatches.SelectedItems[0].SubItems[5].Text = trackBarBenderRange.Value.ToString();
        }

        SetBendRangeToolTip();
        SendPatchParameterChange(selectedPatch, 0x04);
        memoryState.changesMade = true;
    }

    private void comboBoxAssignMode_SelectedValueChanged(object sender, EventArgs e)
    {
        int selectedPatch = memoryState.GetSelectedPatchNo();
        memoryState.GetPatch(selectedPatch).SetAssignMode(comboBoxAssignMode.SelectedIndex);
        if (listViewPatches.SelectedIndices.Count > 0)
        {
            listViewPatches.SelectedItems[0].SubItems[7].Text = (comboBoxAssignMode.SelectedIndex + 1).ToString();
        }

        SendPatchParameterChange(selectedPatch, 0x05);
        memoryState.changesMade = true;
    }

    private void radioButtonReverbOn_CheckedChanged(object sender, EventArgs e)
    {
        SetReverb(memoryState.GetSelectedPatchNo());
    }

    private void SetReverb(int selectedPatch)
    {
        memoryState.GetPatch(selectedPatch).SetReverbEnabled(radioButtonReverbOn.Checked);
        if (listViewPatches.SelectedIndices.Count > 0)
        {
            listViewPatches.SelectedItems[0].SubItems[6].Text = MT32Strings.OnOffStatus(radioButtonReverbOn.Checked);
        }

        SendPatchParameterChange(selectedPatch, 0x06);
        memoryState.changesMade = true;
    }

    private void FormPatchEditor_FormClosing(object sender, FormClosingEventArgs e)
    {
        CheckForUnsavedChanges(e);
    }

    private void CheckPartStatus()
    {
        if (memoryState.GetSystem().GetUIMidiChannel(0) == 0)
        {
            labelNoChannelAssigned.Visible = true;
            return;
        }
        labelNoChannelAssigned.Visible = false;
    }

    private void FindMemoryTimbreInPatchList(int selectedTimbreNo)
    {
        for (int patchNo = 0; patchNo < MT32State.NO_OF_PATCHES; patchNo++)
        {
            Patch patchData = memoryState.GetPatch(patchNo);
            if (patchData.GetTimbreGroupType() == "Memory" && patchData.GetTimbreNo() == selectedTimbreNo)
            {
                if (memoryState.patchEditorActive)
                {
                    // only proceed if focus is not on patch editor
                    return;
                }

                if (numericUpDownPatchNo.Value == patchNo + 1)
                {
                    // patch is already selected
                    return;
                }

                // focus on selected patch
                numericUpDownPatchNo.Value = patchNo + 1;
                memoryState.returnFocusToMemoryBankList = true;
                return;
            }
        }
    }

    private void CheckForMemoryStateUpdates()
    {
        //only refresh if memoryState has recently been updated
        if (memoryState.requestPatchRefresh || lastGlobalUpdate < memoryState.GetUpdateTime())
        {
            ConsoleMessage.SendVerboseLine("Updating Patch List");
            DoFullRefresh(memoryState.GetSelectedPatchNo());
            lastGlobalUpdate = DateTime.Now;
            memoryState.requestPatchRefresh = false;
        }
    }

    private void SyncMemoryTimbreNames()
    {
        int selectedPatch = memoryState.GetSelectedPatchNo();
        string newTimbreName = memoryState.GetTimbreNames().Get(memoryState.GetPatch(selectedPatch).GetTimbreNo(), 2);
        if (listViewPatches.SelectedIndices.Count > 0)
        {
            listViewPatches.SelectedItems[0].SubItems[2].Text = newTimbreName;
        }

        if (comboBoxTimbreName.Text != newTimbreName)
        {
            //ensure that memory timbre name changes are synchronised across comboBox and listView
            RefreshTimbreNamesList();
            comboBoxTimbreName.Text = newTimbreName;
        }
    }

    private void ReturnFocusToPatchEditor()
    {
        listViewPatches.Select();
        memoryState.returnFocusToPatchEditor = false;
    }

    private void FormPatchEditor_Activated(object sender, EventArgs e)
    {
        thisFormIsActive = true;
        memoryState.patchEditorActive = true;
        memoryState.rhythmEditorActive = false;
        int midiChannel = memoryState.GetSystem().GetSysExMidiChannel(0);
        Midi.SendProgramChange(memoryState.GetSelectedPatchNo(), midiChannel);
    }

    private void FormPatchEditor_Leave(object sender, EventArgs e)
    {
        thisFormIsActive = false;
    }

    private void buttonEditPreset_Click(object sender, EventArgs e)
    {
        int selectedPatch = memoryState.GetSelectedPatchNo();
        if (buttonEditPreset.Text == TEXT_EDIT_PRESET)
        {
            EditPresetTimbre(selectedPatch);
        }
        else
        {
            RestorePresetTimbre(selectedPatch);
        }

        ConfigureEditButton();
        DoFullRefresh(selectedPatch);
    }

    private void EditPresetTimbre(int patchNo)
    {
        Patch currentPatch = memoryState.GetPatch(patchNo);
        string patchName = memoryState.GetTimbreNames().Get(currentPatch.GetTimbreNo(), currentPatch.GetTimbreGroup());
        FormSelectMemoryBank selectMemoryBank = new FormSelectMemoryBank(memoryState, patchName);
        selectMemoryBank.ShowDialog();
    }

    private void RestorePresetTimbre(int selectedPatch)
    {
        if (selectedPatch < MT32State.NO_OF_MEMORY_TIMBRES)
        {
            memoryState.GetPatch(selectedPatch).SetTimbreGroup(0);
            memoryState.GetPatch(selectedPatch).SetTimbreNo(selectedPatch);
        }
        else
        {
            memoryState.GetPatch(selectedPatch).SetTimbreGroup(1);
            memoryState.GetPatch(selectedPatch).SetTimbreNo(selectedPatch - MT32State.NO_OF_MEMORY_TIMBRES);
        }
    }
}
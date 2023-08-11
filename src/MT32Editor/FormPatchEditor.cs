namespace MT32Edit;

//
// MT32Edit: FormPatchEditor
// S.Fryers Aug 2023
// Form showing visual representation of MT-32's 128 patch banks- allows custom patches to be configured
//
public partial class FormPatchEditor : Form
{
    private readonly MT32State memoryState = new MT32State();
    private readonly SaveFileDialog saveSysExDialog = new SaveFileDialog();
    private DateTime lastGlobalUpdate = DateTime.Now;
    private bool changesMade = false;
    private bool sendSysEx = false;
    private bool thisFormIsActive = true;
    private readonly float UIScale = 1;

    public FormPatchEditor(float DPIScale, MT32State inputMemoryState)
    {
        InitializeComponent();
        UIScale = DPIScale;
        ScaleUIElements();
        memoryState = inputMemoryState;
        InitialisePatchArray();
        changesMade = false;
        timer.Start();
    }

    private void InitialisePatchArray()
    {
        listViewPatches.Items.Clear();
        for (int patchNo = 0; patchNo < 128; patchNo++)
        {
            AddListViewColumnItems(patchNo);
        }
        int selectedPatch = memoryState.GetSelectedPatchNo();
        SelectPatchInListView(selectedPatch);
        PopulatePatchFormParameters(selectedPatch);
        comboBoxTimbreName.Items.Clear();
        comboBoxTimbreName.Items.AddRange(memoryState.GetTimbreNames().GetAll(comboBoxTimbreGroup.SelectedIndex));
        int midiChannel = memoryState.GetSystem().GetSysExMidiChannel(0);
        Midi.SendProgramChange(selectedPatch, midiChannel);
    }

    private void ScaleUIElements()
    {
        ScaleListView();
        ScaleListViewColumns();
    }

    private void ScaleListView()
    {
        //Scale listView to form size
        listViewPatches.Width = Width - 30;
        listViewPatches.Height = Height - (int)(320 * Math.Pow(UIScale, 1.3));
    }

    private void ScaleListViewColumns()
    {
        //Set column widths to fill the available space
        int listWidth = listViewPatches.Width;
        listViewPatches.Columns[0].Width = (int)(listWidth * 0.10);
        listViewPatches.Columns[1].Width = (int)(listWidth * 0.19);
        listViewPatches.Columns[2].Width = (int)(listWidth * 0.19);
        listViewPatches.Columns[3].Width = (int)(listWidth * 0.08);
        listViewPatches.Columns[4].Width = (int)(listWidth * 0.08);
        listViewPatches.Columns[5].Width = (int)(listWidth * 0.09);
        listViewPatches.Columns[6].Width = (int)(listWidth * 0.11);
        listViewPatches.Columns[7].Width = (int)(listWidth * 0.12);
    }

    private void SelectPatchInListView(int patchNo)
    {
        listViewPatches.Items[patchNo].Selected = true;
        listViewPatches.Items[patchNo].EnsureVisible();
        listViewPatches.Select();
    }

    private void PopulatePatchFormParameters(int patchNo) //update controls with selected patch parameter values
    {
        sendSysEx = false; //prevent every updated form control from triggering a separate sysex message
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
        comboBoxAssignMode.SelectedIndex = memoryPatch.GetAssignMode();
        radioButtonReverbOn.Checked = memoryPatch.GetReverbEnabled();
        radioButtonReverbOff.Checked = !memoryPatch.GetReverbEnabled();
        sendSysEx = true;
    }

    private void RefreshPatchList()
    {
        listViewPatches.Items.Clear();
        for (int i = 0; i < 128; i++)
        {
            AddListViewColumnItems(i);
        }
        SelectPatchInListView(memoryState.GetSelectedPatchNo());
    }

    private void AddListViewColumnItems(int patchNo)
    {
        ListViewItem item = new ListViewItem((patchNo + 1).ToString()); //number patch list starting from 1
        Patch memoryPatch = memoryState.GetPatch(patchNo);
        item.SubItems.Add(memoryPatch.GetTimbreGroupType());
        item.SubItems.Add(memoryState.GetTimbreNames().Get(memoryPatch.GetTimbreNo(), memoryPatch.GetTimbreGroup()));
        item.SubItems.Add(memoryPatch.GetKeyShift().ToString());
        item.SubItems.Add(memoryPatch.GetFineTune().ToString());
        item.SubItems.Add(memoryPatch.GetBenderRange().ToString());
        item.SubItems.Add(MT32Strings.OnOffStatus(memoryPatch.GetReverbEnabled()));
        item.SubItems.Add((memoryPatch.GetAssignMode() + 1).ToString()); //modes are internally numbered 0-3, but show 1-4 in UI.
        listViewPatches.Items.Add(item);
    }

    private void SendPatch(int patchNo, bool sendSysExMessage)
    {
        if (sendSysExMessage) MT32SysEx.SendPatchData(memoryState.GetPatchArray(), patchNo);
        int midiChannel = memoryState.GetSystem().GetSysExMidiChannel(0);
        Midi.SendProgramChange(patchNo, midiChannel);
        Patch memoryPatch = memoryState.GetPatch(patchNo);
        MT32SysEx.SendText("Patch " + (patchNo + 1).ToString() + "|" + memoryState.GetTimbreNames().Get(memoryPatch.GetTimbreNo(), memoryPatch.GetTimbreGroup()));
    }

    private void SendPatchParameterChange(int patchNo, int parameterNo)
    {
        if (sendSysEx) MT32SysEx.SendPatchParameterData(memoryState.GetPatchArray(), patchNo, parameterNo);
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
        for (int timbreNo = 0; timbreNo < 63; timbreNo++)
        {
            string timbreName = memoryState.GetMemoryTimbre(timbreNo).GetTimbreName();
            memoryState.GetTimbreNames().SetMemoryTimbreName(timbreName, timbreNo);
        }
    }

    private void CheckForUnsavedChanges(FormClosingEventArgs e)
    {
        if (changesMade) ShowUnsavedChangesDialogue(e);
    }

    private void ShowUnsavedChangesDialogue(FormClosingEventArgs e)
    {
        switch (MessageBox.Show("Unsaved changes will be lost!", "MT-32 Patch Editor", MessageBoxButtons.OKCancel))
        {
            case DialogResult.OK:
                break;              //Allow form to close
            case DialogResult.Cancel:
                e.Cancel = true;    //Cancel form close request
                break;
        }
    }

    private void DoFullRefresh(int patchNo)
    {
        UpdateMemoryTimbreNames();
        RefreshPatchList();
        SendPatch(patchNo, sendSysExMessage: true);
        RefreshTimbreNamesList();
    }

    private void RefreshTimbreNamesList()
    {
        comboBoxTimbreName.Items.Clear();
        comboBoxTimbreName.Items.AddRange(memoryState.GetTimbreNames().GetAll(comboBoxTimbreGroup.SelectedIndex));
        comboBoxTimbreName.Invalidate();
    }

    private void listViewPatches_SelectedIndexChanged(object sender, EventArgs e)   //patch selection changed- populate controls with new patch parameters
    {
        if (listViewPatches.SelectedIndices.Count > 0)                              //don't attempt to read from an empty listview
        {
            int selectedPatch = listViewPatches.SelectedIndices[0];
            PopulatePatchFormParameters(selectedPatch);
        }
        RefreshTimbreNamesList();
    }

    private void numericUpDownPatchNo_ValueChanged(object sender, EventArgs e) //update controls with selected patch parameter values
    {
        int selectedPatch = (int)numericUpDownPatchNo.Value - 1;
        memoryState.SetSelectedPatchNo(selectedPatch);
        SendPatch(selectedPatch, sendSysExMessage: false);
        SelectPatchInListView(selectedPatch);
        RefreshTimbreNamesList();
        string timbreGroupType = memoryState.GetPatch(selectedPatch).GetTimbreGroupType();
        if (timbreGroupType == "Memory") memoryState.SetTimbreIsEditable(true);
        else memoryState.SetTimbreIsEditable(false);
        ConfigureEditButton();
    }

    private void ConfigureEditButton()
    {
        int selectedPatch = (int)numericUpDownPatchNo.Value - 1;
        string timbreGroupType = memoryState.GetPatch(selectedPatch).GetTimbreGroupType();
        if (timbreGroupType == "Preset A" || timbreGroupType == "Preset B")
        {
            buttonEditPreset.Text = "Edit Preset Timbre";
            buttonEditPreset.Enabled = true;
        }
        else
        {
            buttonEditPreset.Text = "Restore Preset Timbre";
            buttonEditPreset.Enabled = true;
        }
    }

    private void FormPatchEditor_Resize(object sender, EventArgs e)
    {
        ScaleListView();
    }

    private void comboBoxTimbreGroup_SelectionChangeCommitted(object sender, EventArgs e) //timbre group changed- populate timbre list with names from selected bank
    {
        int selectedPatch = memoryState.GetSelectedPatchNo();
        Patch memoryPatch = memoryState.GetPatch(selectedPatch);
        memoryPatch.SetTimbreGroup(comboBoxTimbreGroup.SelectedIndex);
        memoryPatch.SetTimbreNo(0);
        comboBoxTimbreName.Items.Clear();
        comboBoxTimbreName.Items.AddRange(memoryState.GetTimbreNames().GetAll(comboBoxTimbreGroup.SelectedIndex));
        comboBoxTimbreName.Text = memoryState.GetTimbreNames().Get(memoryPatch.GetTimbreNo(), memoryPatch.GetTimbreGroup());
        ConfigureEditButton();
        if (listViewPatches.SelectedIndices.Count > 0)
        {
            listViewPatches.SelectedItems[0].SubItems[1].Text = memoryPatch.GetTimbreGroupType();
            listViewPatches.SelectedItems[0].SubItems[2].Text = comboBoxTimbreName.Text;
        }
        SendPatch(selectedPatch, sendSysExMessage: true);
        changesMade = true;
    }

    private void comboBoxTimbreName_SelectionChangeCommitted(object sender, EventArgs e)
    {
        UpdateTimbreName();
        int selectedPatch = memoryState.GetSelectedPatchNo();
        Patch memoryPatch = memoryState.GetPatch(selectedPatch);
        if (listViewPatches.SelectedIndices.Count > 0) listViewPatches.SelectedItems[0].SubItems[2].Text = memoryState.GetTimbreNames().Get(memoryPatch.GetTimbreNo(), memoryPatch.GetTimbreGroup());
        SendPatch(selectedPatch, sendSysExMessage: false);
        changesMade = true;
    }

    private void trackBarKeyShift_ValueChanged(object sender, EventArgs e)
    {
        int selectedPatch = memoryState.GetSelectedPatchNo();
        memoryState.GetPatch(selectedPatch).SetKeyShift(trackBarKeyShift.Value);
        if (listViewPatches.SelectedIndices.Count > 0) listViewPatches.SelectedItems[0].SubItems[3].Text = trackBarKeyShift.Value.ToString();
        toolTipParameterValue.SetToolTip(trackBarKeyShift, "Key Shift = " + trackBarKeyShift.Value.ToString());
        SendPatchParameterChange(selectedPatch, 0x02);
        changesMade = true;
    }

    private void trackBarFineTune_ValueChanged(object sender, EventArgs e)
    {
        int selectedPatch = memoryState.GetSelectedPatchNo();
        memoryState.GetPatch(selectedPatch).SetFineTune(trackBarFineTune.Value);
        if (listViewPatches.SelectedIndices.Count > 0) listViewPatches.SelectedItems[0].SubItems[4].Text = trackBarFineTune.Value.ToString();
        toolTipParameterValue.SetToolTip(trackBarFineTune, "Fine tune = " + trackBarFineTune.Value.ToString());
        SendPatchParameterChange(selectedPatch, 0x03);
        changesMade = true;
    }

    private void trackBarBenderRange_ValueChanged(object sender, EventArgs e)
    {
        int selectedPatch = memoryState.GetSelectedPatchNo();
        memoryState.GetPatch(selectedPatch).SetBenderRange(trackBarBenderRange.Value);
        if (listViewPatches.SelectedIndices.Count > 0) listViewPatches.SelectedItems[0].SubItems[5].Text = trackBarBenderRange.Value.ToString();
        toolTipParameterValue.SetToolTip(trackBarBenderRange, "Bend range = " + trackBarBenderRange.Value.ToString());
        SendPatchParameterChange(selectedPatch, 0x04);
        changesMade = true;
    }

    private void comboBoxAssignMode_SelectedValueChanged(object sender, EventArgs e)
    {
        int selectedPatch = memoryState.GetSelectedPatchNo();
        memoryState.GetPatch(selectedPatch).SetAssignMode(comboBoxAssignMode.SelectedIndex);
        if (listViewPatches.SelectedIndices.Count > 0) listViewPatches.SelectedItems[0].SubItems[7].Text = (comboBoxAssignMode.SelectedIndex + 1).ToString();
        SendPatchParameterChange(selectedPatch, 0x05);
        changesMade = true;
    }

    private void radioButtonReverbOn_CheckedChanged(object sender, EventArgs e)
    {
        SetReverb(memoryState.GetSelectedPatchNo());
    }

    private void SetReverb(int selectedPatch)
    {
        memoryState.GetPatch(selectedPatch).SetReverbEnabled(radioButtonReverbOn.Checked);
        if (listViewPatches.SelectedIndices.Count > 0) listViewPatches.SelectedItems[0].SubItems[6].Text = MT32Strings.OnOffStatus(radioButtonReverbOn.Checked);
        SendPatchParameterChange(selectedPatch, 0x06);
        changesMade = true;
    }

    private void FormPatchEditor_FormClosing(object sender, FormClosingEventArgs e)
    {
        CheckForUnsavedChanges(e);
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
        if (comboBoxTimbreGroup.Text == "Memory") SyncMemoryTimbreNames();
        if (memoryState.returnFocusToPatchEditor) ReturnFocusToPatchEditor();
    }

    private void FindMemoryTimbreInPatchList(int selectedTimbreNo)
    {
        for (int patchNo = 0; patchNo < 128; patchNo++)
        {
            Patch patchData = memoryState.GetPatch(patchNo);
            if (patchData.GetTimbreGroupType() == "Memory" && patchData.GetTimbreNo() == selectedTimbreNo)
            {
                if (memoryState.patchEditorActive) return;             // only proceed if focus is not on patch editor
                if (numericUpDownPatchNo.Value == patchNo + 1) return; // patch is already selected
                numericUpDownPatchNo.Value = patchNo + 1;              // focus on selected patch
                memoryState.returnFocusToMemoryBankList = true;
                return;
            }
        }
    }

    private void CheckForMemoryStateUpdates()
    {
        if (lastGlobalUpdate < memoryState.GetUpdateTime()) //only refresh if memoryState has recently been updated
        {
            ConsoleMessage.SendLine("Updating Patch List");
            DoFullRefresh(memoryState.GetSelectedPatchNo());
            lastGlobalUpdate = DateTime.Now;
        }
    }

    private void SyncMemoryTimbreNames()
    {
        int selectedPatch = memoryState.GetSelectedPatchNo();
        string newTimbreName = memoryState.GetTimbreNames().Get(memoryState.GetPatch(selectedPatch).GetTimbreNo(), 2);
        if (listViewPatches.SelectedIndices.Count > 0) listViewPatches.SelectedItems[0].SubItems[2].Text = newTimbreName;
        if (comboBoxTimbreName.Text != newTimbreName)
        {
            RefreshTimbreNamesList(); //ensure that memory timbre name changes are synchronised across comboBox and listView
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
        if (buttonEditPreset.Text == "Edit Preset Timbre") EditPresetTimbre(selectedPatch);
        else RestorePresetTimbre(selectedPatch);
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
        if (selectedPatch < 63)
        {
            memoryState.GetPatch(selectedPatch).SetTimbreGroup(0);
            memoryState.GetPatch(selectedPatch).SetTimbreNo(selectedPatch);
        }
        else
        {
            memoryState.GetPatch(selectedPatch).SetTimbreGroup(1);
            memoryState.GetPatch(selectedPatch).SetTimbreNo(selectedPatch - 64);
        }
    }
}
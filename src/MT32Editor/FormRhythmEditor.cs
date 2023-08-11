namespace MT32Edit;

public partial class FormRhythmEditor : Form
{
    //
    // MT32Edit: FormRhythmEditor
    // S.Fryers Aug 2023
    // Form showing visual representation of MT-32's rhythm setup- allows custom rhythm instruments to be configured
    //
    private const int bankOffset = 2; //Preset banks A [0] and B [1] cannot be allocated to rhythm part, only memory [2] and rhythm [3] banks can be used.

    private readonly MT32State memoryState = new MT32State();
    private DateTime lastGlobalUpdate = DateTime.Now;
    private bool thisFormIsActive = false;
    private bool changesMade = false;
    private int pressedKey = -1;
    private bool sendSysEx = false;
    private readonly float UIScale = 1;

    public FormRhythmEditor(float DPIScale, MT32State inputMemoryState)
    {
        InitializeComponent();
        memoryState = inputMemoryState;
        UIScale = DPIScale;
        ScaleUIElements();
        InitialiseRhythmBank();
        changesMade = false;
        timer.Start();
    }

    private void InitialiseRhythmBank()
    {
        listViewRhythmBank.Items.Clear();
        for (int keyNo = 24; keyNo < 109; keyNo++)
        {
            AddListViewColumnItems(keyNo);
        }
        SelectKeyInListView(RhythmConstants.KEY_OFFSET);
        PopulateRhythmFormParameters(RhythmConstants.KEY_OFFSET);
        comboBoxTimbreName.Items.Clear();
        comboBoxTimbreName.Items.AddRange(memoryState.GetTimbreNames().GetAll(comboBoxTimbreGroup.SelectedIndex + bankOffset));
    }

    private void ScaleUIElements()
    {
        ScaleListView();
        ScaleListViewColumns();
    }

    private void ScaleListView()
    {
        //Scale listView to form size
        listViewRhythmBank.Width = Width - 30;
        listViewRhythmBank.Height = Height - (int)(320 * Math.Pow(UIScale, 1.3));
    }

    private void ScaleListViewColumns()
    {
        //Set column widths to fill the available space
        int listWidth = listViewRhythmBank.Width;
        listViewRhythmBank.Columns[0].Width = (int)(listWidth * 0.10);
        listViewRhythmBank.Columns[1].Width = (int)(listWidth * 0.13);
        listViewRhythmBank.Columns[2].Width = (int)(listWidth * 0.20);
        listViewRhythmBank.Columns[3].Width = (int)(listWidth * 0.21);
        listViewRhythmBank.Columns[4].Width = (int)(listWidth * 0.12);
        listViewRhythmBank.Columns[5].Width = (int)(listWidth * 0.08);
        listViewRhythmBank.Columns[6].Width = (int)(listWidth * 0.10);
    }

    private void SelectKeyInListView(int keyNo)
    {
        ConsoleMessage.SendLine("Key No." + keyNo.ToString());
        listViewRhythmBank.Items[keyNo - RhythmConstants.KEY_OFFSET].Selected = true;
        listViewRhythmBank.Items[keyNo - RhythmConstants.KEY_OFFSET].EnsureVisible();
        listViewRhythmBank.Select();
    }

    private void RefreshRhythmBankList()
    {
        listViewRhythmBank.Items.Clear();
        for (int keyNo = 24; keyNo < 108; keyNo++)
        {
            int bankNo = keyNo - RhythmConstants.KEY_OFFSET;
            AddListViewColumnItems(keyNo);
        }
        int selectedKey = memoryState.GetSelectedKey();
        SelectKeyInListView(selectedKey);
    }

    private void PopulateRhythmFormParameters(int keyNo) //update controls with selected patch parameter values
    {
        int bankNo = keyNo - RhythmConstants.KEY_OFFSET;
        int selectedKey = keyNo;
        sendSysEx = false;
        numericUpDownKeyNo.Value = selectedKey;
        Rhythm rhythmKey = memoryState.GetRhythm(bankNo);
        comboBoxTimbreGroup.Text = rhythmKey.GetTimbreGroupType();
        comboBoxTimbreName.Text = memoryState.GetTimbreNames().Get(rhythmKey.GetTimbreNo(), rhythmKey.GetTimbreGroup() + bankOffset); //get timbre name from timbre no. and timbre group
        trackBarLevel.Value = rhythmKey.GetOutputLevel();
        trackBarPanPot.Value = rhythmKey.GetPanPot();
        radioButtonReverbOn.Checked = rhythmKey.GetReverbEnabled();
        radioButtonReverbOff.Checked = !rhythmKey.GetReverbEnabled();
        sendSysEx = true;
    }

    private void AddListViewColumnItems(int keyNo)
    {
        int bankNo = keyNo - RhythmConstants.KEY_OFFSET;
        ListViewItem item = new ListViewItem(keyNo.ToString());
        Rhythm rhythmKey = memoryState.GetRhythm(bankNo);
        item.SubItems.Add(MT32Strings.PitchNote(keyNo));
        item.SubItems.Add(rhythmKey.GetTimbreGroupType());
        item.SubItems.Add(memoryState.GetTimbreNames().Get(rhythmKey.GetTimbreNo(), rhythmKey.GetTimbreGroup() + bankOffset)); //get timbre name from timbre no. and timbre group);
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
        for (int timbreNo = 0; timbreNo < 63; timbreNo++)
        {
            memoryState.GetTimbreNames().SetMemoryTimbreName(memoryState.GetMemoryTimbre(timbreNo).GetTimbreName(), timbreNo);
        }
    }

    private void SendBank(int selectedKey)
    {
        int bankNo = selectedKey - RhythmConstants.KEY_OFFSET;
        Rhythm rhythmData = memoryState.GetRhythm(bankNo);
        MT32SysEx.SendRhythmKey(rhythmData, selectedKey);
    }

    private void UpdateTimbreName()
    {
        int bankNo = memoryState.GetSelectedKey() - RhythmConstants.KEY_OFFSET;
        Rhythm rhythmData = memoryState.GetRhythm(bankNo);
        rhythmData.SetTimbreNo(comboBoxTimbreName.SelectedIndex);
        comboBoxTimbreName.Text = memoryState.GetTimbreNames().Get(rhythmData.GetTimbreNo(), rhythmData.GetTimbreGroup());
    }

    private void CheckForUnsavedChanges(FormClosingEventArgs e)
    {
        if (changesMade == true) ShowUnsavedChangesDialogue(e);
    }

    private void ShowUnsavedChangesDialogue(FormClosingEventArgs e)
    {
        switch (MessageBox.Show("Unsaved changes will be lost!", "MT-32 Rhythm Bank Editor", MessageBoxButtons.OKCancel))
        {
            case DialogResult.OK:
                break;              //Allow form to close
            case DialogResult.Cancel:
                e.Cancel = true;    //Cancel form close request
                break;
        }
    }

    private void RefreshTimbreNamesList()
    {
        string[] memoryTimbreNameArray = memoryState.GetTimbreNames().GetAll(comboBoxTimbreGroup.SelectedIndex + bankOffset);
        comboBoxTimbreName.Items.Clear();
        comboBoxTimbreName.Items.AddRange(memoryTimbreNameArray);
        comboBoxTimbreName.Invalidate();
    }

    private void listViewRhythmBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listViewRhythmBank.SelectedIndices.Count > 0) PopulateRhythmFormParameters(listViewRhythmBank.SelectedIndices[0] + RhythmConstants.KEY_OFFSET); //(selectedKey);
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
        Rhythm rhythmData = memoryState.GetRhythm(bankNo);
        rhythmData.SetTimbreGroup(comboBoxTimbreGroup.SelectedIndex);
        comboBoxTimbreName.Items.Clear();
        comboBoxTimbreName.Items.AddRange(memoryState.GetTimbreNames().GetAll(comboBoxTimbreGroup.SelectedIndex + bankOffset));
        if (listViewRhythmBank.SelectedIndices.Count > 0)
        {
            listViewRhythmBank.SelectedItems[0].SubItems[2].Text = rhythmData.GetTimbreGroupType();
            listViewRhythmBank.SelectedItems[0].SubItems[3].Text = memoryState.GetTimbreNames().Get(rhythmData.GetTimbreNo(), rhythmData.GetTimbreGroup());
        }
        PopulateRhythmFormParameters(selectedKey);
        if (sendSysEx) SendBank(selectedKey);
        changesMade = true;
    }

    private void comboBoxTimbreName_SelectionChangeCommitted(object sender, EventArgs e)
    {
        int selectedKey = memoryState.GetSelectedKey();
        int bankNo = selectedKey - RhythmConstants.KEY_OFFSET;
        Rhythm rhythmData = memoryState.GetRhythm(bankNo);
        UpdateTimbreName();
        if (listViewRhythmBank.SelectedIndices.Count > 0) listViewRhythmBank.SelectedItems[0].SubItems[3].Text = comboBoxTimbreName.Text;
        if (sendSysEx) SendBank(selectedKey);
        changesMade = true;
    }

    private void radioButtonReverbOn_CheckedChanged(object sender, EventArgs e)
    {
        int selectedKey = memoryState.GetSelectedKey();
        int bankNo = selectedKey - RhythmConstants.KEY_OFFSET;
        memoryState.GetRhythm(bankNo).SetReverbEnabled(radioButtonReverbOn.Checked);
        if (listViewRhythmBank.SelectedIndices.Count > 0) listViewRhythmBank.SelectedItems[0].SubItems[4].Text = MT32Strings.OnOffStatus(radioButtonReverbOn.Checked);
        if (sendSysEx) SendBank(selectedKey);
    }

    private void trackBarPanPot_ValueChanged(object sender, EventArgs e)
    {
        int selectedKey = memoryState.GetSelectedKey();
        int bankNo = selectedKey - RhythmConstants.KEY_OFFSET;
        memoryState.GetRhythm(bankNo).SetPanPot(trackBarPanPot.Value);
        if (listViewRhythmBank.SelectedIndices.Count > 0) listViewRhythmBank.SelectedItems[0].SubItems[5].Text = trackBarPanPot.Value.ToString();
        if (sendSysEx) SendBank(selectedKey);
        toolTipParameterValue.SetToolTip(trackBarPanPot, "Pan = " + trackBarPanPot.Value.ToString());
        changesMade = true;
    }

    private void trackBarLevel_ValueChanged(object sender, EventArgs e)
    {
        int selectedKey = memoryState.GetSelectedKey();
        int bankNo = selectedKey - RhythmConstants.KEY_OFFSET;
        memoryState.GetRhythm(bankNo).SetOutputLevel(trackBarLevel.Value);
        if (listViewRhythmBank.SelectedIndices.Count > 0) listViewRhythmBank.SelectedItems[0].SubItems[6].Text = trackBarLevel.Value.ToString();
        toolTipParameterValue.SetToolTip(trackBarLevel, "Level = " + trackBarLevel.Value.ToString());
        if (sendSysEx) SendBank(selectedKey);
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
        Midi.PlayRhythmNote(selectedKey, midiChannel);
        pressedKey = selectedKey;
    }

    private void buttonPlayNote_MouseUp(object sender, MouseEventArgs e)
    {
        int midiChannel = memoryState.GetSystem().GetSysExMidiChannel(8);
        if (pressedKey >= 0) Midi.StopRhythmNote(pressedKey, midiChannel);
        pressedKey = -1;
    }

    private void timer_Tick(object sender, EventArgs e)
    {
        if (!thisFormIsActive)
        {
            int selectedTimbre = memoryState.GetSelectedMemoryTimbre();
            CheckForMemoryStateUpdates();
            FindMemoryTimbreInRhythmList(selectedTimbre);
        }
        if (comboBoxTimbreGroup.Text == "Memory") SyncMemoryTimbreNames();
        if (memoryState.returnFocusToRhythmEditor) ReturnFocusToRhythmEditor();
    }

    private void FindMemoryTimbreInRhythmList(int selectedTimbreNo)
    {
        for (int bankNo = 0; bankNo < 85; bankNo++)
        {
            Rhythm rhythmData = memoryState.GetRhythm(bankNo);
            if (rhythmData.GetTimbreGroupType() == "Memory" && rhythmData.GetTimbreNo() == selectedTimbreNo)
            {
                int keyNo = bankNo + RhythmConstants.KEY_OFFSET;
                if (memoryState.rhythmEditorActive) return;    // only proceed if focus is not on rhythm editor
                if (numericUpDownKeyNo.Value == keyNo) return; // patch is already selected
                numericUpDownKeyNo.Value = keyNo;              // focus on selected rhythm key
                memoryState.returnFocusToMemoryBankList = true;
                return;
            }
        }
    }

    private void CheckForMemoryStateUpdates()
    {
        if (lastGlobalUpdate < memoryState.GetUpdateTime()) //only refresh if memoryState has recently been updated
        {
            ConsoleMessage.SendLine("Updating Rhythm Bank List");
            DoFullRefresh();
            lastGlobalUpdate = DateTime.Now;
        }
    }

    private void SyncMemoryTimbreNames()
    {
        int selectedBank = memoryState.GetSelectedBank();
        string newTimbreName = memoryState.GetTimbreNames().Get(memoryState.GetRhythm(selectedBank).GetTimbreNo(), 2);
        if (listViewRhythmBank.SelectedIndices.Count > 0) listViewRhythmBank.SelectedItems[0].SubItems[3].Text = newTimbreName;
        if (comboBoxTimbreName.Text != newTimbreName && !comboBoxTimbreName.DroppedDown)
        {
            ConsoleMessage.SendLine("Updating Memory Timbre Names List");
            RefreshTimbreNamesList(); //ensure that memory timbre name changes are synchronised across comboBox and listView
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
        ConsoleMessage.SendLine("Rhythm editor active");
    }

    private void FormRhythmEditor_Leave(object sender, EventArgs e)
    {
        thisFormIsActive = false;
        ConsoleMessage.SendLine("Rhythm editor inactive");
    }
}
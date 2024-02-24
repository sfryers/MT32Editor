namespace MT32Edit;

/// <summary>
/// Form showing visual representation of MT-32's 64 memory banks- allows custom timbres to be mapped
/// </summary>
public partial class FormMemoryBankEditor : Form
{
    // MT32Edit: FormMemoryBankEditor
    // S.Fryers Feb 2024

    private readonly MT32State memoryState = new MT32State();

    private readonly FormTimbreEditor timbreEditor;
    private TimbreStructure? copiedTimbre;
    private DateTime lastGlobalUpdate = DateTime.Now;
    private readonly float UIScale = 1;

    internal FormMemoryBankEditor(float DPIScale, MT32State inputMemoryState, FormTimbreEditor timbreEditorFormInput)
    {
        InitializeComponent();
        UIScale = DPIScale;
        ScaleUIElements();
        timbreEditor = timbreEditorFormInput;
        memoryState = inputMemoryState;
        SynchroniseTimbreEditor(0);
        PopulateMemoryBankListView(0);
        timer.Start();
    }

    private void ScaleUIElements()
    {
        ScaleListView();
        ScaleListViewColumns();
    }

    private void ScaleListView()
    {
        //Scale listView to form size
        listViewTimbres.Width = (Width * 88) / 100;
        listViewTimbres.Height = Height - (int)(270 * Math.Pow(UIScale, 1.3));
    }

    private void ScaleListViewColumns()
    {
        //Set column widths to fill the available space
        int listWidth = listViewTimbres.Width;
        listViewTimbres.Columns[0].Width = (int)(listWidth * 0.31);
        listViewTimbres.Columns[1].Width = (int)(listWidth * 0.55);
    }

    private void PopulateMemoryBankListView(int selectedTimbre)
    {
        listViewTimbres.Items.Clear();
        for (int timbreNo = 0; timbreNo < 64; timbreNo++)
        {
            AddListViewColumnItems(timbreNo);
        }
        SelectTimbreInListView(selectedTimbre);
    }

    private void SelectTimbreInListView(int selectedTimbre)
    {
        listViewTimbres.Items[selectedTimbre].Selected = true;
        listViewTimbres.Items[selectedTimbre].EnsureVisible();
        listViewTimbres.Select();
    }

    private void SynchroniseTimbreEditor(int selectedTimbre)
    {
        timbreEditor.TimbreData = memoryState.GetMemoryTimbre(selectedTimbre);
        string timbreName = timbreEditor.TimbreData.GetTimbreName();
        memoryState.GetTimbreNames().SetMemoryTimbreName(timbreName, selectedTimbre);
    }

    private void AddListViewColumnItems(int timbreNo)
    {
        ListViewItem item;
        //enumerate memory bank list starting from 1
        item = new ListViewItem((timbreNo + 1).ToString());
        if (memoryState.GetMemoryTimbre(timbreNo) == null)
        {
            item.SubItems.Add(memoryState.GetTimbreNames().Get(timbreNo, 2));
        }
        else
        {
            item.SubItems.Add(memoryState.GetMemoryTimbre(timbreNo).GetTimbreName());
        }

        listViewTimbres.Items.Add(item);
    }

    /// <summary>
    /// Updates controls with selected timbre parameter values
    /// </summary>
    private void PopulateTimbreFormParameters(int selectedTimbre)
    {
        //numericUpDown range is 1-64
        numericUpDownTimbreNo.Value = selectedTimbre + 1;
        labelTimbreName.Text = GetMemoryTimbreName(selectedTimbre);
        MT32SysEx.PreviewTimbre(selectedTimbre, memoryState.GetMemoryTimbre(selectedTimbre));
    }

    private void numericUpDownTimbreNo_ValueChanged(object sender, EventArgs e)
    {
        //selectedTimbre range is 0-63
        int selectedTimbre = (int)numericUpDownTimbreNo.Value - 1;
        string timbreName = GetMemoryTimbreName(selectedTimbre);
        memoryState.SetSelectedMemoryTimbre(selectedTimbre);
        labelTimbreName.Text = timbreName;
        SelectTimbreInListView(selectedTimbre);
        SynchroniseTimbreEditor(selectedTimbre);
        if (timbreName == MT32Strings.EMPTY)
        {
            timbreName = "New Timbre";
        }

        MT32SysEx.SendText("Editing " + timbreName);
    }

    private string GetMemoryTimbreName(int selectedTimbre)
    {
        return ParseTools.RemoveTrailingSpaces(memoryState.GetTimbreNames().Get(selectedTimbre, 2));
    }

    private void buttonClearTimbre_Click(object sender, EventArgs e)
    {
        if (labelTimbreName.Text == MT32Strings.EMPTY || !UITools.AskUserToConfirm("Clear selected memory timbre?", "MT-32 Editor"))
        {
            return;
        }

        int selectedTimbre = (int)numericUpDownTimbreNo.Value - 1;
        string timbreName = memoryState.GetMemoryTimbre(selectedTimbre).GetTimbreName();
        memoryState.SetMemoryTimbre(new TimbreStructure(createAudibleTimbre: false), selectedTimbre); //replace selected timbre with blank timbre
        memoryState.GetTimbreNames().SetMemoryTimbreName(timbreName, selectedTimbre);
        PopulateMemoryBankListView(selectedTimbre);
        SynchroniseTimbreEditor(selectedTimbre);
        MT32SysEx.SendMemoryTimbre(selectedTimbre, memoryState.GetMemoryTimbre(selectedTimbre));
        MT32SysEx.PreviewTimbre(selectedTimbre, memoryState.GetMemoryTimbre(selectedTimbre));
    }

    private void buttonClearAll_Click(object sender, EventArgs e)
    {
        if (!UITools.AskUserToConfirm("Clear all memory timbres?", "MT-32 Editor"))
        { 
            return; 
        }
        memoryState.SetMemoryTimbreArray(new TimbreStructure[64]);
        InitialiseMemoryTimbreArray();
        memoryState.GetTimbreNames().ResetAllMemoryTimbreNames();
        memoryState.SetSelectedMemoryTimbre(0);
        PopulateMemoryBankListView(0);
        SynchroniseTimbreEditor(0);
        Form loadSysEx = new FormLoadSysEx(memoryState, requestClearMemory: true);
        loadSysEx.ShowDialog();
        MT32SysEx.PreviewTimbre(0, memoryState.GetMemoryTimbre(0));
    }

    public void InitialiseMemoryTimbreArray()
    {
        for (int timbreNo = 0; timbreNo < 64; timbreNo++)
        {
            memoryState.SetMemoryTimbre(new TimbreStructure(createAudibleTimbre: false), timbreNo);
        }
    }

    private void listViewTimbres_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listViewTimbres.SelectedIndices.Count > 0)
        {
            //don't attempt to read from an empty listview
            PopulateTimbreFormParameters(listViewTimbres.SelectedIndices[0]);
        }
    }

    private void buttonCopyTimbre_Click(object sender, EventArgs e)
    {
        int selectedTimbre = (int)numericUpDownTimbreNo.Value - 1;
        copiedTimbre = memoryState.GetMemoryTimbre(selectedTimbre).Clone();
        buttonPasteTimbre.Enabled = true;
    }

    private void buttonPasteTimbre_Click(object sender, EventArgs e)
    {
        int selectedTimbre = (int)numericUpDownTimbreNo.Value - 1;
        if (copiedTimbre is null)
        {
            return;
        }
        if (labelTimbreName.Text != MT32Strings.EMPTY && CancelOverwrite())
        {
            return;
        }
        memoryState.SetMemoryTimbre(copiedTimbre.Clone(), selectedTimbre);
        PopulateMemoryBankListView(selectedTimbre);
        SynchroniseTimbreEditor(selectedTimbre);

        bool CancelOverwrite()
        {
            return !UITools.AskUserToConfirm($"Overwrite {memoryState.GetMemoryTimbre(selectedTimbre).GetTimbreName()} with copied timbre {copiedTimbre.GetTimbreName()}?", "MT-32 Editor");
        }
    }

    private void timer_Tick(object sender, EventArgs e)
    {
        int selectedTimbre = (int)numericUpDownTimbreNo.Value - 1;
        if (memoryState.patchEditorActive)
        {
            selectedTimbre = FindPatchTimbreInMemoryBank(selectedTimbre);
        }
        else if (memoryState.rhythmEditorActive)
        {
            selectedTimbre = FindRhythmTimbreInMemoryBank(selectedTimbre);
        }

        if (memoryState.returnFocusToMemoryBankList)
        {
            ReturnFocusToMemoryBankList();
        }
        else
        {
            SynchroniseTimbreEditor(selectedTimbre);
        }

        RefreshMemoryBankListView(selectedTimbre);
    }

    private int FindPatchTimbreInMemoryBank(int selectedTimbreNo)
    {
        int requiredTimbreNo = selectedTimbreNo;
        int selectedPatchNo = memoryState.GetSelectedPatchNo();
        Patch patchData = memoryState.GetPatch(selectedPatchNo);
        if (patchData.GetTimbreGroupType() == "Memory")
        {
            //focus memory bank editor on selected memory patch and enable timbre editor
            FindTimbre();
        }
        else
        {
            memoryState.SetTimbreIsEditable(false);
        }

        return requiredTimbreNo;

        void FindTimbre()
        {
            requiredTimbreNo = patchData.GetTimbreNo();
            if (requiredTimbreNo != selectedTimbreNo)
            {
                SetTimbreAsEditable(requiredTimbreNo);
            }
        }
    }

    private int FindRhythmTimbreInMemoryBank(int selectedTimbreNo)
    {
        int requiredTimbreNo = selectedTimbreNo;
        int bankNo = memoryState.GetSelectedBank();
        Rhythm rhythmBank = memoryState.GetRhythm(bankNo);
        if (rhythmBank.GetTimbreGroupType() == "Memory")
        {
            //focus rhythm bank editor on selected memory patch and enable timbre editor
            FindTimbre();
        }
        else
        {
            memoryState.SetTimbreIsEditable(false);
        }

        return requiredTimbreNo;

        void FindTimbre()
        {
            requiredTimbreNo = rhythmBank.GetTimbreNo();
            if (requiredTimbreNo != selectedTimbreNo)
            {
                SetTimbreAsEditable(requiredTimbreNo);
            }
        }
    }

    private void SetTimbreAsEditable(int selectedTimbre)
    {
        numericUpDownTimbreNo.Value = selectedTimbre + 1;
        memoryState.SetTimbreIsEditable(true);
        SynchroniseTimbreEditor(selectedTimbre);
        memoryState.returnFocusToPatchEditor = true;
    }

    private void ReturnFocusToMemoryBankList()
    {
        listViewTimbres.Select();
        memoryState.returnFocusToMemoryBankList = false;
    }

    private void RefreshMemoryBankListView(int selectedTimbre)
    {
        TimbreStructure timbre = memoryState.GetMemoryTimbre(selectedTimbre);
        TimbreNames timbreNames = new TimbreNames();
        string timbreName = timbre.GetTimbreName();
        //refresh listview if memoryState has recently been updated
        if (lastGlobalUpdate < timbre.GetUpdateTime())
        {
            PopulateMemoryBankListView(selectedTimbre);
            lastGlobalUpdate = DateTime.Now;
        }
        timbreNames.SetMemoryTimbreName(timbreName, selectedTimbre);
        labelTimbreName.Text = timbreNames.Get(selectedTimbre, 2);
        if (listViewTimbres.SelectedIndices.Count > 0)
        {
            listViewTimbres.SelectedItems[0].SubItems[1].Text = timbreNames.Get(selectedTimbre, 2);
        }
    }

    private void FormMemoryBankEditor_Resize(object sender, EventArgs e)
    {
        ScaleListView();
    }

    private void FormMemoryBankEditor_Activated(object sender, EventArgs e)
    {
        int selectedTimbre = (int)numericUpDownTimbreNo.Value - 1;
        memoryState.rhythmEditorActive = false;
        memoryState.patchEditorActive = false;
        memoryState.SetTimbreIsEditable(true);
        MT32SysEx.SendMemoryTimbre(selectedTimbre, memoryState.GetMemoryTimbre(selectedTimbre));
        MT32SysEx.PreviewTimbre(selectedTimbre, memoryState.GetMemoryTimbre(selectedTimbre));
    }
}
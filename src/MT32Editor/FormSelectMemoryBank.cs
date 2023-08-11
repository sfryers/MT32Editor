namespace MT32Edit;

public partial class FormSelectMemoryBank : Form
{
    //
    // MT32Edit: FormSelectMemoryBank
    // S.Fryers Apr 2023
    // Simple form allowing selection of a memory bank to copy preset timbre into
    //
    const int MEMORY_GROUP = 2;
    readonly MT32State memoryState = new MT32State();
    readonly string presetTimbreName = "none";

    public FormSelectMemoryBank(MT32State memoryStateInput, string timbreNameInput)
    {
        InitializeComponent();
        memoryState = memoryStateInput;
        presetTimbreName = timbreNameInput;
        PopulateForm();
    }

    private void PopulateForm()
    {
        labelSelectMemoryBank.Text = "Select memory bank slot for " + presetTimbreName + ":";
        string[] memoryTimbreNames = memoryState.GetTimbreNames().GetAll(MEMORY_GROUP);
        for (int timbreNo = 0; timbreNo < memoryTimbreNames.Length; timbreNo++)
        {
            memoryTimbreNames[timbreNo] = (timbreNo + 1).ToString() + ":   " + memoryTimbreNames[timbreNo]; //prefix timbre names with numbered list starting from 1
        }
        comboBoxMemoryBank.DataSource = memoryTimbreNames;
        comboBoxMemoryBank.Text = memoryState.GetTimbreNames().Get(0, MEMORY_GROUP);
    }

    private void ReplaceMemoryTimbre()
    {
        int patchNo = memoryState.GetSelectedPatchNo();
        Patch selectedPatch = memoryState.GetPatch(patchNo);
        TimbreStructure timbre = PresetTimbres.Get(selectedPatch.GetTimbreNo(), selectedPatch.GetTimbreGroup());
        memoryState.SetMemoryTimbre(timbre, comboBoxMemoryBank.SelectedIndex);
        selectedPatch.SetTimbreGroup(MEMORY_GROUP);
        selectedPatch.SetTimbreNo(comboBoxMemoryBank.SelectedIndex);
    }

    private void comboBoxMemoryBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        string timbreName = ParseTools.RightMost(memoryState.GetTimbreNames().Get(comboBoxMemoryBank.SelectedIndex, MEMORY_GROUP), MT32Strings.EMPTY.Length);
        if (timbreName == MT32Strings.EMPTY) buttonOK.Text = "OK";
        else buttonOK.Text = "Replace";
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
        if (buttonOK.Text == "Replace")
        {
            switch (MessageBox.Show("This memory slot is already occupied. Overwrite " + memoryState.GetTimbreNames().Get(comboBoxMemoryBank.SelectedIndex, MEMORY_GROUP) + " with preset timbre " + presetTimbreName + "?", "Confirm timbre replacement", MessageBoxButtons.OKCancel))
            {
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    return;
            }
        }
        ReplaceMemoryTimbre();
        Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
        Close();
    }
}

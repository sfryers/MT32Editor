namespace MT32Edit_legacy;

/// <summary>
/// Simple form allowing selection of a memory bank to copy preset timbre into
/// </summary>
public partial class FormSelectMemoryBank : Form
{
    // MT32Edit: FormSelectMemoryBank
    // S.Fryers Feb 2024

    private const int MEMORY_GROUP = 2;

    private readonly MT32State memoryState = new MT32State();
    private readonly string presetTimbreName = "none";

    public FormSelectMemoryBank(MT32State memoryStateInput, string timbreNameInput)
    {
        InitializeComponent();
        memoryState = memoryStateInput;
        presetTimbreName = timbreNameInput;
        PopulateForm();
        SetTheme();
    }

    private void PopulateForm()
    {
        labelSelectMemoryBank.Text = $"Select memory bank slot for {presetTimbreName}:";
        string[] memoryTimbreNames = memoryState.GetTimbreNames().GetAll(MEMORY_GROUP);
        string[] enumeratedTimbreNames = new string[memoryTimbreNames.Length];
        for (int timbreNo = 0; timbreNo < memoryTimbreNames.Length; timbreNo++)
        {
            //prefix timbre names with numbered list starting from 1
            enumeratedTimbreNames[timbreNo] = $"{timbreNo + 1}:   { memoryTimbreNames[timbreNo]}"; 
        }
        comboBoxMemoryBank.DataSource = enumeratedTimbreNames;
        comboBoxMemoryBank.Text = memoryState.GetTimbreNames().Get(0, MEMORY_GROUP);
    }

    private void SetTheme()
    {
        Label[] labels = { labelSelectMemoryBank };
        BackColor = UITools.SetThemeColours(titleLabel: null, labels, warningLabels: null, checkBoxes: null, groupBoxes: null, listView: null, radioButtons: null);
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
        buttonOK.Text = (timbreName == MT32Strings.EMPTY) ? "OK" : "Replace";
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
        if (buttonOK.Text == "Replace")
        {
            switch (MessageBox.Show($"This memory slot is already occupied. Overwrite {memoryState.GetTimbreNames().Get(comboBoxMemoryBank.SelectedIndex, MEMORY_GROUP)} with preset timbre {presetTimbreName}?", "Confirm timbre replacement", MessageBoxButtons.OKCancel))
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
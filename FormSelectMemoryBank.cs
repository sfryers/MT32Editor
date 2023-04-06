namespace MT32Edit
{
    public partial class FormSelectMemoryBank : Form
    {
        //
        // MT32Edit: FormSelectMemoryBank
        // S.Fryers Mar 2023
        // Simple form allowing selection of a memory bank to copy preset timbre into
        //
        MT32State memoryState = new MT32State();
        string presetTimbreName = "none";

        public FormSelectMemoryBank(MT32State memoryStateInput, string timbreNameInput)
        {
            InitializeComponent();
            memoryState = memoryStateInput;
            presetTimbreName = timbreNameInput;
            PopulateForm();
        }

        private void PopulateForm()
        {
            labelPresetTimbreName.Text = presetTimbreName + ":";
            string[] memoryTimbreNames = memoryState.GetTimbreNames().GetAll(2);
            for (int timbreNo = 0; timbreNo < memoryTimbreNames.Length; timbreNo++)
            {
                memoryTimbreNames[timbreNo] = (timbreNo + 1).ToString() + ":   " + memoryTimbreNames[timbreNo]; //prefix timbre names with numbered list starting from 1
            }
            comboBoxMemoryBank.DataSource = memoryTimbreNames;
            comboBoxMemoryBank.Text = memoryState.GetTimbreNames().Get(0, 2);
        }

        private void ReplaceMemoryTimbre()
        {
            int selectedPatch = memoryState.GetSelectedPatchNo();
            TimbreStructure timbre = PresetTimbres.Get(selectedPatch);
            memoryState.SetMemoryTimbre(timbre, comboBoxMemoryBank.SelectedIndex);
            Patch memoryPatch = memoryState.GetPatch(selectedPatch);
            memoryPatch.SetTimbreGroup(2);
            memoryPatch.SetTimbreNo(comboBoxMemoryBank.SelectedIndex);
        }

        private void comboBoxMemoryBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            string timbreNameCheck = ParseTools.RightMost(memoryState.GetTimbreNames().Get(comboBoxMemoryBank.SelectedIndex, 2), 7);
            if (timbreNameCheck == "[empty]") buttonOK.Text = "OK";
            else buttonOK.Text = "Replace";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (buttonOK.Text == "Replace")
            {
                switch (MessageBox.Show("This memory slot is already occupied. Overwrite " + memoryState.GetTimbreNames().Get(comboBoxMemoryBank.SelectedIndex, 2) + " with preset timbre " + presetTimbreName + "?", "Confirm timbre replacement", MessageBoxButtons.OKCancel))
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
}

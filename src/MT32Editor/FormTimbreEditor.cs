namespace MT32Edit;

/// <summary>
/// Form provides visual access to all MT-32 timbre parameters,
/// allowing timbres to be created, edited and previewed through 
/// a connected MT32-compatible MIDI device.
/// </summary>
public partial class FormTimbreEditor : Form
{
    // MT32Edit: FormTimbreEditor
    // S.Fryers Jan 2024

    private readonly SaveFileDialog saveTimbreDialog = new SaveFileDialog();
    private TimbreStructure timbre = new TimbreStructure(createAudibleTimbre: false);
    private readonly byte[] partialClipboard = new byte[58];
    private int activePartial = 0;
    private bool changesMade = false;
    private bool timbreToBeReturnedtoParentForm = false;
    private bool sendSysEx = false;
    private bool initialisationComplete = false;
    private bool thisFormIsActive = true;
    private int part12Image = -1;
    private int part34Image = -1;
    private readonly float UIScale = 1;
    private bool allowQuickSave = false;

    public FormTimbreEditor(float DPIScale)
    {
        InitializeComponent();
        UIScale = DPIScale;
        ScaleUIComponents();
        InitialiseTimbreParameters(false);
    }

    private void ScaleUIComponents()
    {
        comboBoxPart12Struct.DropDownWidth = (int)(525 * UIScale);
        comboBoxPart34Struct.DropDownWidth = (int)(525 * UIScale);
    }

    public static TimbreStructure returnTimbre = new TimbreStructure(createAudibleTimbre: false);

    public TimbreStructure TimbreData
    {
        get { return timbre; }
        set { timbre = value; }
    }

    private void timer_Tick(object sender, EventArgs e)
    {
        //keep controls updated whilst changes made by other active forms
        if (!thisFormIsActive)
        {
            MT32SysEx.blockSysExMessages = true;
            SetAllControlValues();
            allowQuickSave = false;
            saveTimbreDialog.FileName = "";
            changesMade = false;
            MT32SysEx.blockSysExMessages = false;
        }
        if (initialisationComplete)
        {
            //increase timer polling rate after form initialisation is completed.
            timer.Interval = 100;
        }

        initialisationComplete = true;
    }

    private void FormTimbreEditor_Deactivate(object sender, EventArgs e)
    {
        thisFormIsActive = false;
        ConsoleMessage.SendLine("Timbre Editor inactive");
    }

    private void FormTimbreEditor_Activated(object sender, EventArgs e)
    {
        thisFormIsActive = true;
        ConsoleMessage.SendLine("Timbre Editor activated");
        if (initialisationComplete && timer.Interval == 100 && timbre.GetTimbreName() == MT32Strings.EMPTY)
        {
            timbre.SetDefaultTimbreParameters(createAudibleTimbre: true);
            SetAllControlValues();
        }
        int bankNo = timbre.GetPCMBankNo(0);
        if (bankNo == 0)
        {
            radioButtonPCMBank1.Checked = true;
        }
        else
        {
            radioButtonPCMBank2.Checked = true;
        }

        UpdatePCMSampleList(bankNo);
    }

    private void InitialiseTimbreParameters(bool editExisting)
    {
        radioButtonPCMBank1.Select();
        if (!editExisting)
        {
            CreateDefaultTimbre();
        }

        timer.Interval = 2000;
        timer.Enabled = true;
        timer.Start();
        SetAllControlValues();
        SendAllSysExParameters();
        changesMade = false;

        void CreateDefaultTimbre()
        {
            //Set all timbre and partial parameters to default values;
            timbre.SetDefaultTimbreParameters(createAudibleTimbre: false);
            sendSysEx = true;
            allowQuickSave = true;
            initialisationComplete = true;
        }
    }

    private void SendAllSysExParameters()
    {
        MT32SysEx.UpdateTimbreParameters(timbre);
        MT32SysEx.SendAllPartialParameters(timbre);
    }

    private void SetAllControlValues()
    {
        activePartial = 0;
        SetMainControls();
        SetControlsforLeftPartial(timbre.GetPart12Structure());
        UpdatePartialSliders();
    }

    private void SetMainControls()
    {
        textBoxTimbreName.Text = ParseTools.RemoveTrailingSpaces(timbre.GetTimbreName());
        comboBoxPart12Struct.SelectedIndex = timbre.GetPart12Structure();
        comboBoxPart34Struct.SelectedIndex = timbre.GetPart34Structure();
        UpdatePartialStructureImages();
        SetPartialRadioButton(activePartial);
        // set checkboxes to inverse of corresponding partial mute statuses
        checkBoxPartial1.Checked = !timbre.GetPartialMuteStatus()[0];
        checkBoxPartial2.Checked = !timbre.GetPartialMuteStatus()[1];
        checkBoxPartial3.Checked = !timbre.GetPartialMuteStatus()[2];
        checkBoxPartial4.Checked = !timbre.GetPartialMuteStatus()[3];
        checkBoxSustain.Checked = timbre.GetSustainStatus();
        if (checkBoxPartial1.Checked)
        {
            labelPartialWarning.Visible = false;
        }
        else
        {
            labelPartialWarning.Visible = true;
        }

        void SetPartialRadioButton(int partialNo)
        {
            if (partialNo == 0)
            {
                radioButtonPartial1.Checked = true;
            }

            if (partialNo == 1)
            {
                radioButtonPartial2.Checked = true;
            }

            if (partialNo == 2)
            {
                radioButtonPartial3.Checked = true;
            }

            if (partialNo == 3)
            {
                radioButtonPartial4.Checked = true;
            }
        }
    }

    private void UpdatePartialStructureImages()
    {
        if (comboBoxPart12Struct.SelectedIndex > -1 && comboBoxPart12Struct.SelectedIndex != part12Image)
        {
            part12Image = comboBoxPart12Struct.SelectedIndex;
            pictureBoxPartial12.Image = imageList.Images[part12Image];
            toolTipParameterValue.SetToolTip(pictureBoxPartial12, MT32Strings.partialConfig12Desc[part12Image]);
        }
        if (comboBoxPart34Struct.SelectedIndex > -1 && comboBoxPart34Struct.SelectedIndex != part34Image)
        {
            part34Image = comboBoxPart34Struct.SelectedIndex;
            pictureBoxPartial34.Image = imageList.Images[part34Image];
            toolTipParameterValue.SetToolTip(pictureBoxPartial34, MT32Strings.partialConfig34Desc[part34Image]);
        }
    }

    /// <summary>
    /// Updates all UI controls to match current partial parameters
    /// </summary>
    private void UpdatePartialSliders()
    {
        // set flag in order to prevent control changes triggering messages on device
        MT32SysEx.blockMT32text = true;
        trackBarPitch.Value = timbre.GetUIParameter(activePartial, 0x00);
        trackBarFinePitch.Value = timbre.GetUIParameter(activePartial, 0x01);
        trackBarPitchKeyFollow.Value = timbre.GetUIParameter(activePartial, 0x02);
        checkBoxPitchBend.Checked = LogicTools.IntToBool(timbre.GetUIParameter(activePartial, 0x03));
        comboBoxPCMSample.SelectedIndex = timbre.GetUIParameter(activePartial, 0x05);
        //Parameter 0x04 sets two control values
        UpdateWaveFormAndPCMBankControls();
        trackBarPulseWidth.Value = timbre.GetUIParameter(activePartial, 0x06);
        trackBarPWVeloSens.Value = timbre.GetUIParameter(activePartial, 0x07);
        trackBarPitchEnvelopeDepth.Value = timbre.GetUIParameter(activePartial, 0x08);
        trackBarPitchEnvVeloSens.Value = timbre.GetUIParameter(activePartial, 0x09);
        trackBarPitchEnvTimeKeyfollow.Value = timbre.GetUIParameter(activePartial, 0x0A);
        trackBarPitchEnvT1.Value = timbre.GetUIParameter(activePartial, 0x0B);
        trackBarPitchEnvT2.Value = timbre.GetUIParameter(activePartial, 0x0C);
        trackBarPitchEnvT3.Value = timbre.GetUIParameter(activePartial, 0x0D);
        trackBarPitchEnvT4.Value = timbre.GetUIParameter(activePartial, 0x0E);
        trackBarPitchEnvL0.Value = timbre.GetUIParameter(activePartial, 0x0F);
        trackBarPitchEnvL1.Value = timbre.GetUIParameter(activePartial, 0x10);
        trackBarPitchEnvL2.Value = timbre.GetUIParameter(activePartial, 0x11);
        trackBarPitchEnvSust.Value = timbre.GetUIParameter(activePartial, 0x12);
        trackBarPitchEnvReleaseLevel.Value = timbre.GetUIParameter(activePartial, 0x13);
        trackBarLFORate.Value = timbre.GetUIParameter(activePartial, 0x14);
        trackBarLFODepth.Value = timbre.GetUIParameter(activePartial, 0x15);
        trackBarLFOModSens.Value = timbre.GetUIParameter(activePartial, 0x16);
        trackBarTVFCutoff.Value = timbre.GetUIParameter(activePartial, 0x17);
        trackBarTVFResonance.Value = timbre.GetUIParameter(activePartial, 0x18);
        trackBarTVFKeyfollow.Value = timbre.GetUIParameter(activePartial, 0x19);
        trackBarTVFBiasPoint.Value = timbre.GetUIParameter(activePartial, 0x1A);
        trackBarTVFBiasLevel.Value = timbre.GetUIParameter(activePartial, 0x1B);
        trackBarTVFEnvDepth.Value = timbre.GetUIParameter(activePartial, 0x1C);
        trackBarTVFVeloSensitivity.Value = timbre.GetUIParameter(activePartial, 0x1D);
        trackBarTVFDepthKeyfollow.Value = timbre.GetUIParameter(activePartial, 0x1E);
        trackBarTVFTimeKeyfollow.Value = timbre.GetUIParameter(activePartial, 0x1F);
        trackBarTVFT1.Value = timbre.GetUIParameter(activePartial, 0x20);
        trackBarTVFT2.Value = timbre.GetUIParameter(activePartial, 0x21);
        trackBarTVFT3.Value = timbre.GetUIParameter(activePartial, 0x22);
        trackBarTVFT4.Value = timbre.GetUIParameter(activePartial, 0x23);
        trackBarTVFT5.Value = timbre.GetUIParameter(activePartial, 0x24);
        trackBarTVFL1.Value = timbre.GetUIParameter(activePartial, 0x25);
        trackBarTVFL2.Value = timbre.GetUIParameter(activePartial, 0x26);
        trackBarTVFL3.Value = timbre.GetUIParameter(activePartial, 0x27);
        trackBarTVFSustain.Value = timbre.GetUIParameter(activePartial, 0x28);
        trackBarTVALevel.Value = timbre.GetUIParameter(activePartial, 0x29);
        trackBarTVAVeloSensitivity.Value = timbre.GetUIParameter(activePartial, 0x2A);
        trackBarTVABiasPoint1.Value = timbre.GetUIParameter(activePartial, 0x2B);
        trackBarTVABiasLevel1.Value = timbre.GetUIParameter(activePartial, 0x2C);
        trackBarTVABiasPoint2.Value = timbre.GetUIParameter(activePartial, 0x2D);
        trackBarTVABiasLevel2.Value = timbre.GetUIParameter(activePartial, 0x2E);
        trackBarTVATimeKeyfollow.Value = timbre.GetUIParameter(activePartial, 0x2F);
        trackBarTVAVelocityKeyfollow.Value = timbre.GetUIParameter(activePartial, 0x30);
        trackBarTVAT1.Value = timbre.GetUIParameter(activePartial, 0x31);
        trackBarTVAT2.Value = timbre.GetUIParameter(activePartial, 0x32);
        trackBarTVAT3.Value = timbre.GetUIParameter(activePartial, 0x33);
        trackBarTVAT4.Value = timbre.GetUIParameter(activePartial, 0x34);
        trackBarTVAT5.Value = timbre.GetUIParameter(activePartial, 0x35);
        trackBarTVAL1.Value = timbre.GetUIParameter(activePartial, 0x36);
        trackBarTVAL2.Value = timbre.GetUIParameter(activePartial, 0x37);
        trackBarTVAL3.Value = timbre.GetUIParameter(activePartial, 0x38);
        trackBarTVASustain.Value = timbre.GetUIParameter(activePartial, 0x39);
        MT32SysEx.blockMT32text = false;

        void UpdateWaveFormAndPCMBankControls()
        {
            int bankNo = 0;
            int waveType = 0;
            switch (timbre.GetUIParameter(activePartial, 0x04))
            {
                case 0:
                    radioButtonPCMBank1.Checked = true;
                    break;

                case 1:
                    waveType = 1;
                    radioButtonPCMBank1.Checked = true;
                    break;

                case 2:
                    bankNo = 1;
                    radioButtonPCMBank2.Checked = true;
                    break;

                case 3:
                    waveType = 1;
                    bankNo = 1;
                    radioButtonPCMBank2.Checked = true;
                    break;

                default:
                    break;
            }
            UpdatePCMSampleList(bankNo);
            comboBoxWaveform.Text = MT32Strings.waveform[waveType];
            comboBoxWaveform.Invalidate();
        }
    }

    private void ConfigurePartialWarnings(int activePartial)
    {
        CheckIfCurrentPartialIsEnabled();
        CheckIfAllPartialsAreMuted();
        UpdateAllGraphs();
        Invalidate();

        void CheckIfCurrentPartialIsEnabled()
        {
            if (timbre.GetPartialMuteStatus()[activePartial])
            {
                SetWarning();
            }
            else
            {
                ClearWarning();
            }
        }

        void SetWarning()
        {
            labelPartialWarning.Visible = true;
            checkBoxShowLabels.Checked = false;
            checkBoxShowLabels.Enabled = false;
        }

        void ClearWarning()
        {
            labelPartialWarning.Visible = false;
            checkBoxShowLabels.Enabled = true;
        }

        void CheckIfAllPartialsAreMuted()
        {
            //if all partials are muted
            if (timbre.GetPartialMuteStatus()[0] && timbre.GetPartialMuteStatus()[1] && timbre.GetPartialMuteStatus()[2] && timbre.GetPartialMuteStatus()[3])
            {
                labelNoActivePartials.Visible = true;
            }
            else
            {
                labelNoActivePartials.Visible = false;
            }
        }
    }

    ////////////////////////////////////////////////////// Load/Save timbres ////////////////////////////////////////////////////

    private void buttonLoadTimbre_Click(object sender, EventArgs e)
    {
        LoadTimbre();
    }

    private void LoadTimbre()
    {
        if (changesMade)
        {
            switch (MessageBox.Show("Unsaved changes will be lost!", "MT-32 Editor", MessageBoxButtons.OKCancel))
            {
                case DialogResult.OK:
                    break;

                case DialogResult.Cancel:
                    return;
            }
        }
        string status = TimbreFile.Load(timbre);
        if (status == "Cancelled" || status == "#Error!")
        {
            return;
        }

        saveTimbreDialog.FileName = status;
        MT32SysEx.blockMT32text = true;
        sendSysEx = false;
        SetAllControlValues();
        SendAllSysExParameters();
        buttonQuickSaveTimbre.Enabled = true;
        MT32SysEx.blockMT32text = false;
        sendSysEx = true;
        changesMade = false;
    }

    private void buttonQuickSaveTimbre_Click(object sender, EventArgs e)
    {
        QuickSaveTimbre(timbre);
    }

    private void QuickSaveTimbre(TimbreStructure timbre)
    {
        if (!allowQuickSave)
        {
            saveTimbreDialog.FileName = "";
            SaveTimbreAs(timbre);
            return;
        }

        string action = "Save";
        if (File.Exists(saveTimbreDialog.FileName)) action = "Overwrite";

        switch (MessageBox.Show(action + " file " + saveTimbreDialog.FileName + "?", "MT-32 Editor", MessageBoxButtons.OKCancel))
        {
            case DialogResult.OK:
                TimbreFile.Save(timbre, saveTimbreDialog);
                break;

            case DialogResult.Cancel:
                break;
        }
    }

    private void buttonSaveTimbreAs_Click(object sender, EventArgs e)
    {
        SaveTimbreAs(timbre);
    }

    private void SaveTimbreAs(TimbreStructure timbre)
    {
        saveTimbreDialog.Filter = "Timbre file|*.timbre";
        saveTimbreDialog.FileName = textBoxTimbreName.Text;
        saveTimbreDialog.Title = "Save Timbre File";
        if (saveTimbreDialog.ShowDialog() == DialogResult.Cancel) return;
        TimbreFile.Save(timbre, saveTimbreDialog);
        allowQuickSave = true;
    }

    private void buttonReset_Click(object sender, EventArgs e)
    {
        NewTimbre();
    }

    private void NewTimbre()
    {
        switch (MessageBox.Show("Reset all timbre parameters?", "MT-32 Editor", MessageBoxButtons.OKCancel))
        {
            case DialogResult.OK:
                InitialiseTimbreParameters(editExisting: false);
                break;

            case DialogResult.Cancel:
                break;
        }
    }

    private void FormTimbreEditor_FormClosing(object sender, FormClosingEventArgs e)
    {
        CheckForUnsavedChanges(e);
    }

    private void CheckForUnsavedChanges(FormClosingEventArgs e)
    {
        if (!changesMade)
        {
            return;
        }

        string message = "";
        if (timbreToBeReturnedtoParentForm)
        {
            message = "Close editor without saving .timbre file?";
        }
        else
        {
            message = "Close editor without saving changes?";
        }

        timbreToBeReturnedtoParentForm = true;
        switch (MessageBox.Show(message, "MT-32 Editor", MessageBoxButtons.YesNo))
        {
            case DialogResult.Yes:
                //Allow form to close
                break;
            case DialogResult.No:
                //Cancel form close request
                e.Cancel = true;
                break;
        }
    }

    ////////////////////////////////////////////////////// Update timbre parameters ////////////////////////////////////////////////////

    private void textBoxTimbreName_TextChanged(object sender, EventArgs e)
    {
        timbre.SetTimbreName(textBoxTimbreName.Text);
        if (sendSysEx)
        {
            MT32SysEx.SendTimbreName(textBoxTimbreName.Text);
        }

        changesMade = true;
    }

    private void comboBoxPart12Struct_SelectedIndexChanged(object sender, EventArgs e)
    {
        //send Partial 1 & 2 structure type value to device
        timbre.SetPart12Structure(comboBoxPart12Struct.SelectedIndex);
        if (sendSysEx)
        {
            MT32SysEx.UpdatePartialStructures(timbre.GetPart12Structure(), timbre.GetPart34Structure());
        }

        if (sendSysEx)
        {
            MT32SysEx.SendText("P1&2 Struct: " + MT32Strings.partialConfig[comboBoxPart12Struct.SelectedIndex]);
        }

        changesMade = true;
        UpdatePartialStructureImages();
        toolTipParameterValue.SetToolTip(comboBoxPart12Struct, MT32Strings.partialConfig12Desc[comboBoxPart12Struct.SelectedIndex]);
        if (activePartial == 0)
        {
            SetControlsforLeftPartial(comboBoxPart12Struct.SelectedIndex);
        }
        else if (activePartial == 1)
        {
            SetControlsforRightPartial(comboBoxPart12Struct.SelectedIndex);
        }
    }

    private void comboBoxPart34Struct_SelectedIndexChanged(object sender, EventArgs e)
    {
        //send Partial 3 & 4 structure type value to device
        timbre.SetPart34Structure(comboBoxPart34Struct.SelectedIndex);
        if (sendSysEx)
        {
            MT32SysEx.UpdatePartialStructures(timbre.GetPart12Structure(), timbre.GetPart34Structure());
        }

        if (sendSysEx)
        {
            MT32SysEx.SendText("P3&4 Struct: " + MT32Strings.partialConfig[comboBoxPart34Struct.SelectedIndex]);
        }

        changesMade = true;
        UpdatePartialStructureImages();
        toolTipParameterValue.SetToolTip(comboBoxPart34Struct, MT32Strings.partialConfig34Desc[comboBoxPart34Struct.SelectedIndex]);
        if (activePartial == 2)
        {
            SetControlsforLeftPartial(comboBoxPart34Struct.SelectedIndex);
        }
        else if (activePartial == 3)
        {
            SetControlsforRightPartial(comboBoxPart34Struct.SelectedIndex);
        }
    }

    private void SetControlsforLeftPartial(int structureType)
    {
        //Enable or disable sliders as appropriate for PCM or LA Synth on partial 1 or 3
        switch (structureType)
        {
            case 0:
            case 1:
            case 4:
            case 7:
            case 9:
            case 11: //structure nos. with S on left hand side
                ShowOnlyLASynthControls();
                break;

            default:
                ShowOnlyPCMControls();
                break;
        }
    }

    private void SetControlsforRightPartial(int structureType)
    {
        //Enable or disable sliders as appropriate for PCM or LA Synth on partial 2 or 4
        switch (structureType)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 7:
            case 9:
            case 10: //structure nos. with S on right hand side
                ShowOnlyLASynthControls();
                break;

            default:
                ShowOnlyPCMControls();
                break;
        }
    }

    private void comboBoxPart12Struct_DrawItem(object sender, DrawItemEventArgs e)
    {
        DrawStructureList(sender, e, isPartial12: true, comboBoxPart12Struct.DroppedDown);
    }

    private void comboBoxPart34Struct_DrawItem(object sender, DrawItemEventArgs e)
    {
        DrawStructureList(sender, e, isPartial12: false, comboBoxPart34Struct.DroppedDown);
    }

    private void DrawStructureList(object sender, DrawItemEventArgs e, bool isPartial12, bool droppedDown)
    {
        //custom comboBox draw method- creates vertical divider between structure type and structure description
        if (e.Index < 0)
        {
            return;
        }

        e.DrawBackground();
        string partialConfigType = (e.Index + 1).ToString() + ": " + MT32Strings.partialConfig[e.Index].ToString();
        string partialConfigDescription;
        if (isPartial12)
        {
            partialConfigDescription = MT32Strings.partialConfig12Desc[e.Index];
        }
        else
        {
            partialConfigDescription = MT32Strings.partialConfig34Desc[e.Index];
        }

        int xLeft = e.Bounds.Location.X;
        int xMid = (int)(58 * UIScale);
        int yTop = e.Bounds.Location.Y;
        int yBottom = yTop + e.Bounds.Height;

        TextRenderer.DrawText(e.Graphics, partialConfigType, e.Font, new Point(xLeft, yTop), e.ForeColor);
        if (droppedDown)
        {
            e.Graphics.DrawLine(SystemPens.ButtonFace, xMid, yTop, xMid, yBottom);
            TextRenderer.DrawText(e.Graphics, partialConfigDescription, e.Font, new Point(xMid + 5, yTop), e.ForeColor, TextFormatFlags.Left);
            e.DrawFocusRectangle();
        }
    }

    private void ShowOnlyPCMControls()
    {
        comboBoxWaveform.Enabled = false;
        comboBoxPCMSample.Enabled = true;
        trackBarTVFCutoff.Enabled = false;
        trackBarTVFResonance.Enabled = false;
        trackBarTVFKeyfollow.Enabled = false;
        trackBarTVFBiasPoint.Enabled = false;
        trackBarTVFBiasLevel.Enabled = false;
        trackBarTVFEnvDepth.Enabled = false;
        trackBarTVFVeloSensitivity.Enabled = false;
        trackBarTVFDepthKeyfollow.Enabled = false;
        trackBarTVFTimeKeyfollow.Enabled = false;
        trackBarTVFT1.Enabled = false;
        trackBarTVFT2.Enabled = false;
        trackBarTVFT3.Enabled = false;
        trackBarTVFT4.Enabled = false;
        trackBarTVFT5.Enabled = false;
        trackBarTVFL1.Enabled = false;
        trackBarTVFL2.Enabled = false;
        trackBarTVFL3.Enabled = false;
        trackBarTVFSustain.Enabled = false;
        labelTVFDisabled.Visible = true;
        radioButtonPCMBank1.Enabled = true;
        radioButtonPCMBank2.Enabled = true;
        RefreshGraphs();
    }

    private void ShowOnlyLASynthControls()
    {
        comboBoxWaveform.Enabled = true;
        comboBoxPCMSample.Enabled = false;
        trackBarTVFCutoff.Enabled = true;
        trackBarTVFResonance.Enabled = true;
        trackBarTVFKeyfollow.Enabled = true;
        trackBarTVFBiasPoint.Enabled = true;
        trackBarTVFBiasLevel.Enabled = true;
        trackBarTVFEnvDepth.Enabled = true;
        trackBarTVFVeloSensitivity.Enabled = true;
        trackBarTVFDepthKeyfollow.Enabled = true;
        trackBarTVFTimeKeyfollow.Enabled = true;
        trackBarTVFT1.Enabled = true;
        trackBarTVFT2.Enabled = true;
        trackBarTVFT3.Enabled = true;
        trackBarTVFT4.Enabled = true;
        trackBarTVFT5.Enabled = true;
        trackBarTVFL1.Enabled = true;
        trackBarTVFL2.Enabled = true;
        trackBarTVFL3.Enabled = true;
        trackBarTVFSustain.Enabled = true;
        labelTVFDisabled.Visible = false;
        radioButtonPCMBank1.Enabled = false;
        radioButtonPCMBank2.Enabled = false;
        RefreshGraphs();
    }

    private void radioButtonPartial1_CheckedChanged(object sender, EventArgs e)
    {
        SelectPartial();
    }

    private void radioButtonPartial2_CheckedChanged(object sender, EventArgs e)
    {
        SelectPartial();
    }

    private void radioButtonPartial3_CheckedChanged(object sender, EventArgs e)
    {
        SelectPartial();
    }

    private void radioButtonPartial4_CheckedChanged(object sender, EventArgs e)
    {
        SelectPartial();
    }

    private void SelectPartial()
    {   //select which partial number to edit
        int selectedPartial = 0;
        if (radioButtonPartial1.Checked)
        {
            selectedPartial = 0;
        }

        if (radioButtonPartial2.Checked)
        {
            selectedPartial = 1;
        }

        if (radioButtonPartial3.Checked)
        {
            selectedPartial = 2;
        }

        if (radioButtonPartial4.Checked)
        {
            selectedPartial = 3;
        }

        if (initialisationComplete)
        {
            sendSysEx = false;
        }

        //update UI controls with new values
        UpdatePartialSliders();
        if (selectedPartial != activePartial)
        {
            MT32SysEx.SendText("Editing partial " + (selectedPartial + 1).ToString());
        }

        activePartial = selectedPartial;
        //hide warning if currently displayed
        labelPartialWarning.Visible = false;
        //make selected partial active
        switch (activePartial)
        {
            case 0:
                checkBoxPartial1.Checked = true;
                SetControlsforLeftPartial(comboBoxPart12Struct.SelectedIndex);
                break;

            case 1:
                checkBoxPartial2.Checked = true;
                SetControlsforRightPartial(comboBoxPart12Struct.SelectedIndex);
                break;

            case 2:
                checkBoxPartial3.Checked = true;
                SetControlsforLeftPartial(comboBoxPart34Struct.SelectedIndex);
                break;

            case 3:
                checkBoxPartial4.Checked = true;
                SetControlsforRightPartial(comboBoxPart34Struct.SelectedIndex);
                break;
        }
        if (initialisationComplete)
        {
            sendSysEx = true;
        }
    }

    private void buttonCopyPartial_Click(object sender, EventArgs e)
    {
        //copy parameters from currently selected partial
        for (int partialNo = 0; partialNo < 58; partialNo++)
        {
            partialClipboard[partialNo] = timbre.GetSysExParameter(activePartial, partialNo);
        }
        //allow paste operation
        buttonPastePartial.Enabled = true;
        MT32SysEx.SendText("Partial " + (activePartial + 1).ToString() + " copied");
    }

    private void buttonPastePartial_Click(object sender, EventArgs e)
    {
        //paste parameters to currently selected partial
        for (int partialNo = 0; partialNo < 58; partialNo++)
        {
            timbre.SetSysExParameter(activePartial, partialNo, partialClipboard[partialNo]);
        }
        //send to device
        MT32SysEx.ApplyPartialParameters(timbre, activePartial);
        //update slider positions
        UpdatePartialSliders();
        RefreshGraphs();
        Invalidate();
        MT32SysEx.SendText("Pasted to partial " + (activePartial + 1).ToString());
        changesMade = true;
    }

    /// <summary>
    /// Enables or disables partial 1
    /// </summary>
    private void checkBoxPartial1_CheckedChanged(object sender, EventArgs e)
    {
        ///set mute status to inverse of checkbox status
        timbre.SetPartialMuteStatus(0, !checkBoxPartial1.Checked);
        ConfigurePartialWarnings(activePartial);
        changesMade = true;
    }

    /// <summary>
    /// Enables or disables Partial 2
    /// </summary>
    private void checkBoxPartial2_CheckedChanged(object sender, EventArgs e)
    {
        //set mute status to inverse of checkbox status
        timbre.SetPartialMuteStatus(1, !checkBoxPartial2.Checked);
        ConfigurePartialWarnings(activePartial);
        changesMade = true;
    }

    /// <summary>
    /// Enables or disables Partial 3
    /// </summary>
    private void checkBoxPartial3_CheckedChanged(object sender, EventArgs e)
    {
        //set mute status to inverse of checkbox status
        timbre.SetPartialMuteStatus(2, !checkBoxPartial3.Checked);
        ConfigurePartialWarnings(activePartial);
        changesMade = true;
    }

    /// <summary>
    /// Enables or disables Partial 4
    /// </summary>
    private void checkBoxPartial4_CheckedChanged(object sender, EventArgs e)
    {
        //set mute status to inverse of checkbox status
        timbre.SetPartialMuteStatus(3, !checkBoxPartial4.Checked);
        ConfigurePartialWarnings(activePartial);
        changesMade = true;
    }

    /// <summary>
    /// Resends all timbre parameters to device
    /// </summary>
    private void buttonRefresh_Click(object sender, EventArgs e)
    {
        SendAllSysExParameters();
    }

    private void checkBoxSustain_CheckedChanged(object sender, EventArgs e)
    {
        timbre.SetSustainStatus(checkBoxSustain.Checked);
        if (sendSysEx)
        {
            //send sustain on/off value to device
            MT32SysEx.SendSustainValue(timbre.GetSustainStatus());
        }
    }

    ////////////////////////////////////////////////////// Update partial 1-4 parameters ////////////////////////////////////////////////////
    private void UpdatePartialValueFromSliderValue(byte parameterNo, System.Windows.Forms.TrackBar slider)
    {
        int parameterValue = slider.Value;
        timbre.SetUIParameter(activePartial, parameterNo, parameterValue);
        if (sendSysEx)
        {
            //send value to device register and send text to device screen
            MT32SysEx.SendPartialParameter(activePartial, parameterNo, parameterValue);
        }

        toolTipParameterValue.SetToolTip(slider, MT32Strings.partialParameterNames[parameterNo] + " = " + MT32Strings.PartialParameterValueText(parameterNo, parameterValue));
        changesMade = true;
    }

    private void trackBarPitch_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch value to device
        UpdatePartialValueFromSliderValue(0x00, trackBarPitch);
    }

    private void trackBarFinePitch_ValueChanged(object sender, EventArgs e)
    {
        //send Fine Pitch value to device
        UpdatePartialValueFromSliderValue(0x01, trackBarFinePitch);
    }

    private void trackBarPitchKeyFollow_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch keyfollow value to device
        UpdatePartialValueFromSliderValue(0x02, trackBarPitchKeyFollow);
    }

    private void checkBoxPitchBend_CheckedChanged(object sender, EventArgs e)
    {
        int pitchBendState = LogicTools.BoolToInt(checkBoxPitchBend.Checked);
        timbre.SetUIParameter(activePartial, 0x03, pitchBendState);
        if (sendSysEx)
        {
            //send Pitch bend on/off value to device
            MT32SysEx.SendPartialParameter(activePartial, 0x03, pitchBendState);
        }

        changesMade = true;
    }

    private void comboBoxWaveform_SelectedValueChanged(object sender, EventArgs e)
    {
        int waveFormState = comboBoxWaveform.SelectedIndex;
        if (timbre.GetPCMBankNo(activePartial) == 1)
        {
            waveFormState += 2;
        }

        timbre.SetUIParameter(activePartial, 0x04, waveFormState);
        if (sendSysEx)
        {
            //send Waveform type to device
            MT32SysEx.SendPartialParameter(activePartial, 0x04, waveFormState);
        }

        changesMade = true;
    }

    private void radioButtonPCMBank1_MouseUp(object sender, MouseEventArgs e)
    {
        SetPCMBank();
    }

    private void radioButtonPCMBank2_MouseUp(object sender, MouseEventArgs e)
    {
        SetPCMBank();
    }

    private void SetPCMBank()
    {
        if (!radioButtonPCMBank1.Enabled)
        {
            return;
        }

        int bankNo = 0;
        if (radioButtonPCMBank2.Checked)
        {
            bankNo = 1;
        }

        int sysExValue = comboBoxWaveform.SelectedIndex + (bankNo * 2);
        timbre.SetUIParameter(activePartial, 0x04, sysExValue);
        if (sendSysEx)
        {
            MT32SysEx.SendPCMBankNo(activePartial, sysExValue);
        }

        UpdatePCMSampleList(bankNo);
        changesMade = true;
    }

    private void comboBoxPCMSample_EnabledChanged(object sender, EventArgs e)
    {
        int bankNo = 0;
        if (radioButtonPCMBank2.Checked)
        {
            bankNo = 1;
        }

        UpdatePCMSampleList(bankNo);
    }

    private void UpdatePCMSampleList(int bankNo)
    {
        MT32SysEx.blockMT32text = true;
        comboBoxPCMSample.Items.Clear();
        if (bankNo == 0)
        {
            comboBoxPCMSample.Items.AddRange(MT32Strings.bank1SampleNames);
        }
        else
        {
            comboBoxPCMSample.Items.AddRange(MT32Strings.bank2SampleNames);
        }

        comboBoxPCMSample.Invalidate();
        int sampleNo = timbre.GetUIParameter(activePartial, 0x05);
        string sampleName = GetSampleName();
        comboBoxPCMSample.Text = sampleName;
        comboBoxPCMSample.SelectedIndex = sampleNo;
        MT32SysEx.blockMT32text = false;

        string GetSampleName()
        {
            string sampleName;
            if (bankNo == 1)
            {
                sampleName = MT32Strings.bank2SampleNames[sampleNo];
            }
            else
            {
                sampleName = MT32Strings.bank1SampleNames[sampleNo];
            }

            return sampleName;
        }
    }

    private void comboBoxPCMSample_SelectedValueChanged(object sender, EventArgs e)
    {
        int sampleNo = comboBoxPCMSample.SelectedIndex;
        timbre.SetUIParameter(activePartial, 0x05, sampleNo);
        if (sendSysEx)
        {
            //send PCM sample type to device
            MT32SysEx.SendPartialParameter(activePartial, 0x05, sampleNo);
        }

        changesMade = true;
    }

    private void trackBarPulseWidth_ValueChanged(object sender, EventArgs e)
    {
        //send Pulse Width value to device
        UpdatePartialValueFromSliderValue(0x06, trackBarPulseWidth);
    }

    private void trackBarPWVeloSens_ValueChanged(object sender, EventArgs e)
    {
        //send Pulse Width Velocity Sensitivity value to device
        UpdatePartialValueFromSliderValue(0x07, trackBarPWVeloSens);
    }

    private void trackBarPitchEnvelopeDepth_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Depth value to device
        UpdatePartialValueFromSliderValue(0x08, trackBarPitchEnvelopeDepth);
    }

    private void trackBarPitchEnvVeloSens_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Velocity Sensitivity value to device
        UpdatePartialValueFromSliderValue(0x09, trackBarPitchEnvVeloSens);
    }

    private void trackBarPitchEnvTimeKeyfollow_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Time Keyfollow value to device
        UpdatePartialValueFromSliderValue(0x0A, trackBarPitchEnvTimeKeyfollow);
    }

    private void trackBarPitchEnvT1_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Time 1 value to device
        UpdatePartialValueFromSliderValue(0x0B, trackBarPitchEnvT1);
        UpdatePitchGraph();
    }

    private void trackBarPitchEnvT2_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Time 2 value to device
        UpdatePartialValueFromSliderValue(0x0C, trackBarPitchEnvT2);
        UpdatePitchGraph();
    }

    private void trackBarPitchEnvT3_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Time 3 value to device
        UpdatePartialValueFromSliderValue(0x0D, trackBarPitchEnvT3);
        UpdatePitchGraph();
    }

    private void trackBarPitchEnvT4_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Time 4 value to device
        UpdatePartialValueFromSliderValue(0x0E, trackBarPitchEnvT4);
        UpdatePitchGraph();
    }

    private void trackBarPitchEnvL0_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Level 0 value to device
        UpdatePartialValueFromSliderValue(0x0F, trackBarPitchEnvL0);
        UpdatePitchGraph();
    }

    private void trackBarPitchEnvL1_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Level 1 value to device
        UpdatePartialValueFromSliderValue(0x10, trackBarPitchEnvL1);
        UpdatePitchGraph();
    }

    private void trackBarPitchEnvL2_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Level 2 value to device
        UpdatePartialValueFromSliderValue(0x11, trackBarPitchEnvL2);
        UpdatePitchGraph();
    }

    private void trackBarPitchEnvSust_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Sustain Level value to device
        UpdatePartialValueFromSliderValue(0x12, trackBarPitchEnvSust);
        UpdatePitchGraph();
    }

    private void trackBarPitchEnvReleaseLevel_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Release Level value to device
        UpdatePartialValueFromSliderValue(0x13, trackBarPitchEnvReleaseLevel);
        UpdatePitchGraph();
    }

    private void trackBarLFORate_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch LFO Rate value to device
        UpdatePartialValueFromSliderValue(0x14, trackBarLFORate);
    }

    private void trackBarLFODepth_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch LFO Depth value to device
        UpdatePartialValueFromSliderValue(0x15, trackBarLFODepth);
    }

    private void trackBarLFOModSens_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch LFO Modulation Sensitivity value to device
        UpdatePartialValueFromSliderValue(0x16, trackBarLFOModSens);
    }

    private void trackBarTVFCutoff_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Cutoff (low pass filter) value to device
        UpdatePartialValueFromSliderValue(0x17, trackBarTVFCutoff);
    }

    private void trackBarTVFResonance_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Resonance value to device
        UpdatePartialValueFromSliderValue(0x18, trackBarTVFResonance);
    }

    private void trackBarTVFKeyfollow_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Keyfollow value to device
        UpdatePartialValueFromSliderValue(0x19, trackBarTVFKeyfollow);
    }

    private void trackBarTVFBiasPoint_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Bias Point value to device
        UpdatePartialValueFromSliderValue(0x1A, trackBarTVFBiasPoint);
    }

    private void trackBarTVFBiasLevel_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Bias Level value to device
        UpdatePartialValueFromSliderValue(0x1B, trackBarTVFBiasLevel);
    }

    private void trackBarTVFEnvDepth_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Depth value to device
        UpdatePartialValueFromSliderValue(0x1C, trackBarTVFEnvDepth);
    }

    private void trackBarTVFVeloSensitivity_ValueChanged(object sender, EventArgs e)
    {
        //send TVFVeloSensitivity value to device
        UpdatePartialValueFromSliderValue(0x1D, trackBarTVFVeloSensitivity);
    }

    private void trackBarTVFDepthKeyfollow_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Depth Keyfollow value to device
        UpdatePartialValueFromSliderValue(0x1E, trackBarTVFDepthKeyfollow);
    }

    private void trackBarTVFTimeKeyfollow_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Time Keyfollow to device
        UpdatePartialValueFromSliderValue(0x1F, trackBarTVFTimeKeyfollow);
    }

    private void trackBarTVFT1_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Time 1 value to device
        UpdatePartialValueFromSliderValue(0x20, trackBarTVFT1);
        UpdateTVFGraph();
    }

    private void trackBarTVFT2_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Time 2 value to device
        UpdatePartialValueFromSliderValue(0x21, trackBarTVFT2);
        UpdateTVFGraph();
    }

    private void trackBarTVFT3_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Time 3 value to device
        UpdatePartialValueFromSliderValue(0x22, trackBarTVFT3);
        UpdateTVFGraph();
    }

    private void trackBarTVFT4_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Time 4 value to device
        UpdatePartialValueFromSliderValue(0x23, trackBarTVFT4);
        UpdateTVFGraph();
    }

    private void trackBarTVFT5_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Time 5 value to device
        UpdatePartialValueFromSliderValue(0x24, trackBarTVFT5);
        UpdateTVFGraph();
    }

    private void trackBarTVFL1_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Level 1 value to device
        UpdatePartialValueFromSliderValue(0x25, trackBarTVFL1);
        UpdateTVFGraph();
    }

    private void trackBarTVFL2_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Level 2 value to device
        UpdatePartialValueFromSliderValue(0x26, trackBarTVFL2);
        UpdateTVFGraph();
    }

    private void trackBarTVFL3_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Level 3 value to device
        UpdatePartialValueFromSliderValue(0x27, trackBarTVFL3);
        UpdateTVFGraph();
    }

    private void trackBarTVFSustain_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Sustain value to device
        UpdatePartialValueFromSliderValue(0x28, trackBarTVFSustain);
        UpdateTVFGraph();
    }

    private void trackBarTVALevel_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Level to device
        UpdatePartialValueFromSliderValue(0x29, trackBarTVALevel);
    }

    private void trackBarTVAVeloSensitivity_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Velocity Sensitivity level to device
        UpdatePartialValueFromSliderValue(0x2A, trackBarTVAVeloSensitivity);
    }

    private void trackBarTVABiasPoint1_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Bias Point 1 value to device
        UpdatePartialValueFromSliderValue(0x2B, trackBarTVABiasPoint1);
    }

    private void trackBarTVABiasLevel1_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Bias Level 1 value to device
        UpdatePartialValueFromSliderValue(0x2C, trackBarTVABiasLevel1);
    }

    private void trackBarTVABiasPoint2_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Bias Point 2 value to device
        UpdatePartialValueFromSliderValue(0x2D, trackBarTVABiasPoint2);
    }

    private void trackBarTVABiasLevel2_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Bias Level 2 value to device
        UpdatePartialValueFromSliderValue(0x2E, trackBarTVABiasLevel2);
    }

    private void trackBarTVATimeKeyfollow_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Time Keyfollow value to device
        UpdatePartialValueFromSliderValue(0x2F, trackBarTVATimeKeyfollow);
    }

    private void trackBarTVAVelocityKeyfollow_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Velocity Keyfollow value to device
        UpdatePartialValueFromSliderValue(0x30, trackBarTVAVelocityKeyfollow);
    }

    private void trackBarTVAT1_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Envelope Time 1 to device
        UpdatePartialValueFromSliderValue(0x31, trackBarTVAT1);
        UpdateTVAGraph();
    }

    private void trackBarTVAT2_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Envelope Time 2 to device
        UpdatePartialValueFromSliderValue(0x32, trackBarTVAT2);
        UpdateTVAGraph();
    }

    private void trackBarTVAT3_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Envelope Time 3 to device
        UpdatePartialValueFromSliderValue(0x33, trackBarTVAT3);
        UpdateTVAGraph();
    }

    private void trackBarTVAT4_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Envelope Time 4 to device
        UpdatePartialValueFromSliderValue(0x34, trackBarTVAT4);
        UpdateTVAGraph();
    }

    private void trackBarTVAT5_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Envelope Time 5 to device
        UpdatePartialValueFromSliderValue(0x35, trackBarTVAT5);
        UpdateTVAGraph();
    }

    private void trackBarTVAL1_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Envelope Level 1 to device
        UpdatePartialValueFromSliderValue(0x36, trackBarTVAL1);
        UpdateTVAGraph();
    }

    private void trackBarTVAL2_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Envelope Level 2 to device
        UpdatePartialValueFromSliderValue(0x37, trackBarTVAL2);
        UpdateTVAGraph();
    }

    private void trackBarTVAL3_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Envelope Level 3 to device
        UpdatePartialValueFromSliderValue(0x38, trackBarTVAL3);
        UpdateTVAGraph();
    }

    private void trackBarTVASustain_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Envelope Sustain Level to device
        UpdatePartialValueFromSliderValue(0x39, trackBarTVASustain);
        UpdateTVAGraph();
    }

    /////////////////////////////////////// Envelope Graphs //////////////////////////////////////////

    private void UpdatePitchGraph()
    {
        groupBoxPitchEnvelope.Invalidate();
    }

    private void UpdateTVAGraph()
    {
        groupBoxTVA.Invalidate();
    }

    private void UpdateTVFGraph()
    {
        groupBoxTVF.Invalidate();
    }

    private void UpdateAllGraphs()
    {
        UpdatePitchGraph();
        UpdateTVAGraph();
        UpdateTVFGraph();
    }

    private void RefreshGraphs()
    {
        if (this.Enabled && thisFormIsActive)
        {
            UpdateAllGraphs();
        }
    }

    private void checkBoxShowLabels_CheckedChanged(object sender, EventArgs e)
    {
        RefreshGraphs();
    }

    private void checkBoxShowAllPartials_CheckedChanged(object sender, EventArgs e)
    {
        RefreshGraphs();
    }

    private void groupBoxPitchEnvelope_Paint(object sender, PaintEventArgs e)
    {
        //plot pitch envelope
        Graphics envelope = groupBoxPitchEnvelope.CreateGraphics();
        EnvelopeGraph graph = new EnvelopeGraph((int)(220 * UIScale), (int)(30 * UIScale));
        graph.Plot(envelope, timbre, 0, activePartial, checkBoxShowAllPartials.Checked, checkBoxShowLabels.Checked);
    }

    private void groupBoxTVF_Paint(object sender, PaintEventArgs e)
    {
        //plot TVF envelope
        if (labelTVFDisabled.Visible)
        {
            return;
        }

        Graphics envelope = groupBoxTVF.CreateGraphics();
        EnvelopeGraph graph = new EnvelopeGraph((int)(440 * UIScale), (int)(30 * UIScale));
        graph.Plot(envelope, timbre, 1, activePartial, checkBoxShowAllPartials.Checked, checkBoxShowLabels.Checked);
    }

    private void groupBoxTVA_Paint(object sender, PaintEventArgs e)
    {
        //plot TVA envelope
        Graphics envelope = groupBoxTVA.CreateGraphics();
        EnvelopeGraph graph = new EnvelopeGraph((int)(440 * UIScale), (int)(30 * UIScale));
        graph.Plot(envelope, timbre, 2, activePartial, checkBoxShowAllPartials.Checked, checkBoxShowLabels.Checked);
    }
}
namespace MT32Edit;

/// <summary>
/// Form provides visual access to all MT-32 timbre parameters,
/// allowing timbres to be created, edited and previewed through 
/// a connected MT32-compatible MIDI device.
/// </summary>
public partial class FormTimbreEditor : Form
{
    // MT32Edit: FormTimbreEditor
    // S.Fryers Apr 2024

    private SaveFileDialog saveTimbreDialog = new SaveFileDialog();
    private TimbreStructure timbre = new TimbreStructure(createAudibleTimbre: false);
    private TimbreHistory timbreHistory;
    private byte[] partialClipboard = new byte[TimbreStructure.NO_OF_PARAMETERS];
    private bool changesMade = false;
    private bool initialisationComplete = false;
    private bool thisFormIsActive = true;
    private bool allowQuickSave = false;
    private bool darkMode = !UITools.DarkMode;
    private bool allowHistoryUpdate = true;
    private int activePartial = 0;
    private int part12Image = -1;
    private int part34Image = -1;
    private readonly float UIScale;
	
	private const int GRAPH_X = 280;
    private const int GRAPH_Y = 100;

    public FormTimbreEditor(float DPIScale)
    {
        InitializeComponent();
        UIScale = DPIScale;
        ScaleUIComponents();
        SetTheme();
        InitialiseTimbreParameters(editExisting: false);
        timbreHistory = new TimbreHistory(new TimbreStructure(createAudibleTimbre: false));
    }

    public static TimbreStructure returnTimbre = new TimbreStructure(createAudibleTimbre: false);

    public TimbreStructure TimbreData
    {
        get { return timbre; }
        set { timbre = value; }
    }

    private void ScaleUIComponents()
    {
        comboBoxPart12Struct.DropDownWidth = (int)(525 * UIScale);
        comboBoxPart34Struct.DropDownWidth = (int)(525 * UIScale);
    }

    private void SetTheme()
    {
        if (darkMode == UITools.DarkMode)
        {
            return;
        }
        Label[] labels =   {
                            labelCoarsePitch, labelCopy, labelEditPartialNo, labelEnablePartials, labelEnvGraphSettings, labelFinePitch, labelLFODepth, labelLFORate,
                            labelLoad, labelNewTimbre, labelPartial12, labelPartial34, labelPartialStruct, labelPartialStruct, labelPartialType, labelPaste,
                            labelPCMSample, labelPitchEnvDepth, labelPitchEnvGraph, labelPitchEnvVeloSens, labelPitchKeyfollow, labelPitchL0, labelPitchL1,
                            labelPitchL2, labelPitchLFOModSens, labelPitchLFOSettings, labelPitchSustain, labelPitchT1, labelPitchT2, labelPitchT3, labelPitchT4,
                            labelPulseWidth, labelPWVeloSens, labelRefresh, labelResonance, labelSave, labelSaveAs, labelTimbreName, labelTVABiasPt1, labelTVABiasPt2,
                            labelTVABiasL1, labelTVABiasL2, labelTVAL1, labelTVAL2, labelTVAL3, labelTVALevel, labelTVASust, labelTVAT1, labelTVAT2, labelTVAT3,
                            labelTVAT4, labelTVAT5, labelTVATimeKF, labelTVATVFEnvGraph, labelTVAVeloSens, labelTVFBiasLevel, labelTVFBiasPt, labelTVFCutoff,
                            labelTVFDepth, labelTVFDepthKF, labelTVFDisabled, labelTVFKeyfollow, labelTVFL1, labelTVFL2, labelTVFL3, labelTVFSustain, labelTVFT1,
                            labelTVFT2, labelTVFT3, labelTVFT4, labelTVFT5, labelTVFTimeKF, labelTVFVeloKF, labelTVFVeloSens, labelUndo, labelRedo
                           };
        Label[] warningLabels = { labelNoActivePartials, labelPartialWarning };
        RadioButton[] radioButtons = { radioButtonPartial1, radioButtonPartial2, radioButtonPartial3, radioButtonPartial4 };
        CheckBox[] checkBoxes = { checkBoxPartial1, checkBoxPartial2, checkBoxPartial3, checkBoxPartial4, checkBoxPitchBend, checkBoxShowAllPartials, checkBoxShowLabels, checkBoxSustain };
        GroupBox[] groupBoxes = { groupBoxEnvGraph, groupBoxLFO, groupBoxPartialStructure, groupBoxPitch, groupBoxPitchEnvelope, groupBoxTVA, groupBoxTVABias, groupBoxTVF, groupBoxWaveform };
        BackColor = UITools.SetThemeColours(labelHeading, labels, warningLabels, checkBoxes, groupBoxes, listView: null, radioButtons);
        UITools.SetGroupHeadingColours(labelColourPitchSettings, labelColourTVFSettings, labelColourTVASettings);
        darkMode = UITools.DarkMode;
    }

    private void timer_Tick(object sender, EventArgs e)
    {
        if (!thisFormIsActive)
        {
            //keep controls updated whilst changes are being made by other active forms
            MT32SysEx.blockSysExMessages = true;
            //SetAllControlValues is called multiple times per second whenever focus is not on the timbre editor- potentially CPU-intensive on slow systems
            activePartial = timbre.GetActivePartial();
            SetAllControlValues();
            allowQuickSave = false;
            saveTimbreDialog.FileName = string.Empty;
            changesMade = false;
            timbreHistory.Clear(timbre);
            MT32SysEx.blockSysExMessages = false;
        }
        if (initialisationComplete)
        {
            //increase timer polling rate after form initialisation is completed.
            timer.Interval = UITools.UI_REFRESH_INTERVAL;
            SetTheme();
            SetUndoRedoButtons();
        }
        initialisationComplete = true;
    }

    private void SetUndoRedoButtons()
    {
        buttonUndo.Enabled = timbreHistory.GetLatestActionNo() > 0;
        buttonRedo.Enabled = timbreHistory.GetTopOfStack() > timbreHistory.GetLatestActionNo();
    }

    private void FormTimbreEditor_Deactivate(object sender, EventArgs e)
    {
        thisFormIsActive = false;
    }

    private void FormTimbreEditor_Activated(object sender, EventArgs e)
    {
        thisFormIsActive = true;
        if (initialisationComplete && timer.Interval == UITools.UI_REFRESH_INTERVAL && timbre.GetTimbreName() == MT32Strings.EMPTY)
        {
            timbre.SetDefaultTimbreParameters(createAudibleTimbre: true);
            activePartial = 0;
            SetAllControlValues();
        }
        int pcmBankNo = timbre.GetPCMBankNo(0);
        radioButtonPCMBank2.Checked = LogicTools.IntToBool(pcmBankNo);
        UpdatePCMSampleList(pcmBankNo);
        timbreHistory.Clear(timbre);
    }

    private void InitialiseTimbreParameters(bool editExisting)
    {
        MT32SysEx.blockSysExMessages = true;
        radioButtonPCMBank1.Select();
        if (!editExisting)
        {
            CreateDefaultTimbre();
        }
        timbreHistory = new TimbreHistory(timbre);
        timer.Interval = 2000;
        timer.Enabled = true;
        timer.Start();
        SetAllControlValues();
        MT32SysEx.SendAllSysExParameters(timbre);
        changesMade = false;
        MT32SysEx.blockSysExMessages = false;

        //Set all timbre and partial parameters to default values;
        void CreateDefaultTimbre()
        {
            timbre.SetDefaultTimbreParameters(createAudibleTimbre: false);
            allowQuickSave = true;
            initialisationComplete = true;
        }
    }

    private void SetAllControlValues()
    {
        //activePartial = timbre.GetActivePartial();
        SetMainControls();
        SetControlsforLeftPartial(timbre.GetPart12Structure());
        UpdatePartialControls();
    }

    private void SetMainControls()
    {
        textBoxTimbreName.Text = ParseTools.RemoveTrailingSpaces(timbre.GetTimbreName());
        comboBoxPart12Struct.SelectedIndex = timbre.GetPart12Structure();
        comboBoxPart34Struct.SelectedIndex = timbre.GetPart34Structure();
        UpdatePartialStructureImages();
        SetPartialRadioButtons(activePartial);
        // set checkboxes to inverse of corresponding partial mute statuses
        checkBoxPartial1.Checked = !timbre.GetPartialMuteStatus()[0];
        checkBoxPartial2.Checked = !timbre.GetPartialMuteStatus()[1];
        checkBoxPartial3.Checked = !timbre.GetPartialMuteStatus()[2];
        checkBoxPartial4.Checked = !timbre.GetPartialMuteStatus()[3];
        checkBoxSustain.Checked = timbre.GetSustainStatus();
        labelPartialWarning.Visible = !checkBoxPartial1.Checked;
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

    private void SetPartialRadioButtons(int partialNo)
    {
        switch (partialNo)
        {
            case 0:
                radioButtonPartial1.Checked = true;
                break;
            case 1:
                radioButtonPartial2.Checked = true;
                break;
            case 2:
                radioButtonPartial3.Checked = true;
                break;
            case 3:
                radioButtonPartial4.Checked = true;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Returns an array of all trackbars in the Timbre Editor form, using parameterNo values as the array reference.
    /// Parameters with a non-trackbar control type are allocated dummy values.
    /// </summary>
    private TrackBar[] GetTrackBars()
    {
        using (var trackBarDummy = new TrackBar())
        {
            return new TrackBar[] {
                                    trackBarPitch, trackBarFinePitch, trackBarPitchKeyFollow, trackBarDummy, trackBarDummy, trackBarDummy,
                                    trackBarPulseWidth, trackBarPWVeloSens, trackBarPitchEnvelopeDepth, trackBarPitchEnvVeloSens, trackBarPitchEnvTimeKeyfollow,
                                    trackBarPitchEnvT1, trackBarPitchEnvT2, trackBarPitchEnvT3, trackBarPitchEnvT4, trackBarPitchEnvL0, trackBarPitchEnvL1, trackBarPitchEnvL2,
                                    trackBarPitchEnvSust, trackBarPitchEnvReleaseLevel, trackBarLFORate, trackBarLFODepth, trackBarLFOModSens,
                                    trackBarTVFCutoff, trackBarTVFResonance, trackBarTVFKeyfollow, trackBarTVFBiasPoint, trackBarTVFBiasLevel, trackBarTVFEnvDepth,
                                    trackBarTVFVeloSensitivity, trackBarTVFDepthKeyfollow, trackBarTVFTimeKeyfollow,
                                    trackBarTVFT1, trackBarTVFT2, trackBarTVFT3, trackBarTVFT4, trackBarTVFT5, trackBarTVFL1, trackBarTVFL2, trackBarTVFL3, trackBarTVFSustain,
                                    trackBarTVALevel, trackBarTVAVeloSensitivity, trackBarTVABiasPoint1, trackBarTVABiasLevel1, trackBarTVABiasPoint2, trackBarTVABiasLevel2,
                                    trackBarTVATimeKeyfollow, trackBarTVAVelocityKeyfollow,
                                    trackBarTVAT1, trackBarTVAT2, trackBarTVAT3, trackBarTVAT4, trackBarTVAT5, trackBarTVAL1, trackBarTVAL2, trackBarTVAL3, trackBarTVASustain
                                };
        }
    }

    /// <summary>
    /// Updates all UI controls to match current partial parameters
    /// </summary>
    private void UpdatePartialControls()
    {
        // set flag in order to prevent control changes triggering messages on device
        MT32SysEx.blockMT32text = true;
        UpdateAllTrackBars();
        // update non-trackbar controls
        checkBoxPitchBend.Checked = LogicTools.IntToBool(timbre.GetUIParameter(activePartial, 3));
        comboBoxPCMSample.SelectedIndex = timbre.GetUIParameter(activePartial, 5);
        UpdateWaveFormAndPCMBankControls();
        MT32SysEx.blockMT32text = false;

        //update each trackbar in turn, skipping dummy values in positions 3 to 5
        void UpdateAllTrackBars()
        {
            TrackBar[] timbreTrackbar = GetTrackBars();
            for (byte i = 0; i < 3; i++)
            {
                UpdateTrackBar(i, timbreTrackbar[i]);
            }
            for (byte i = 6; i < TimbreStructure.NO_OF_PARAMETERS; i++)
            {
                UpdateTrackBar(i, timbreTrackbar[i]);
            }
        }

        void UpdateTrackBar(byte parameterNo, TrackBar trackBar)
        {
            trackBar.Value = timbre.GetUIParameter(activePartial, parameterNo);
            UpdateTrackBarToolTip(parameterNo, trackBar);
        }

        void UpdateWaveFormAndPCMBankControls()
        {
            //Parameter 4 sets two control values
            int bankNo = 0;
            int waveType = 0;
            switch (timbre.GetUIParameter(activePartial, 4))
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

    private void ConfigurePartialWarnings()
    {
        labelPartialWarning.Visible = timbre.GetPartialMuteStatus()[activePartial];
        labelNoActivePartials.Visible = timbre.GetPartialMuteStatus()[0] && timbre.GetPartialMuteStatus()[1] && timbre.GetPartialMuteStatus()[2] && timbre.GetPartialMuteStatus()[3];
        UpdateAllGraphs();
        Invalidate();
    }

    ////////////////////////////////////////////////////// Load/Save timbres ////////////////////////////////////////////////////

    private void buttonLoadTimbre_Click(object sender, EventArgs e)
    {
        LoadTimbre();
    }

    private void LoadTimbre()
    {
        if (changesMade && AbandonUnsavedChanges())
        {
            return;
        }
        string status = TimbreFile.Load(timbre);
        if (!FileTools.Success(status))
        {
            return;
        }
        saveTimbreDialog.FileName = status;
        MT32SysEx.blockMT32text = true;
        SetAllControlValues();
        timbreHistory = new TimbreHistory(timbre);
        MT32SysEx.SendAllSysExParameters(timbre);
        buttonQuickSaveTimbre.Enabled = true;
        MT32SysEx.blockMT32text = false;
        changesMade = false;

        bool AbandonUnsavedChanges()
        {
            return !UITools.AskUserToConfirm("Unsaved changes will be lost!", "MT-32 Editor");
        }
    }

    private void buttonQuickSaveTimbre_Click(object sender, EventArgs e)
    {
        QuickSaveTimbre();
    }

    private void QuickSaveTimbre()
    {
        if (!allowQuickSave)
        {
            saveTimbreDialog.FileName = string.Empty;
            SaveTimbreAs();
            return;
        }

        string action = "Save";
        if (File.Exists(saveTimbreDialog.FileName)) action = "Overwrite";
        if (UITools.AskUserToConfirm($"{action} file {saveTimbreDialog.FileName}?", "MT-32 Editor"))
        {
            TimbreFile.Save(timbre, saveTimbreDialog);
            timbreHistory.Clear(timbre);
        }
    }

    private void buttonSaveTimbreAs_Click(object sender, EventArgs e)
    {
        SaveTimbreAs();
    }

    private void SaveTimbreAs()
    {
        saveTimbreDialog.Filter = "Timbre file|*.timbre";
        saveTimbreDialog.FileName = textBoxTimbreName.Text;
        saveTimbreDialog.Title = "Save Timbre File";
        if (saveTimbreDialog.ShowDialog() == DialogResult.Cancel)
        {
            return;
        }
        TimbreFile.Save(timbre, saveTimbreDialog);
        timbreHistory.Clear(timbre);
        allowQuickSave = true;
    }

    private void buttonReset_Click(object sender, EventArgs e)
    {
        NewTimbre();
    }

    private void NewTimbre()
    {
        if (UITools.AskUserToConfirm("Reset all timbre parameters?", "MT-32 Editor"))
        {
            InitialiseTimbreParameters(editExisting: false);
        }
    }

    private void FormTimbreEditor_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = CancelFormClose();
    }

    private bool CancelFormClose()
    {
        if (!changesMade)
        {
            return false;
        }
        return !UITools.AskUserToConfirm("Close editor without saving changes?", "MT-32 Editor");
    }

    ////////////////////////////////////////////////////// Update timbre parameters ////////////////////////////////////////////////////

    private void textBoxTimbreName_TextChanged(object sender, EventArgs e)
    {
        timbre.SetTimbreName(textBoxTimbreName.Text);
        MT32SysEx.SendTimbreName(textBoxTimbreName.Text);
        UpdateUndoHistory();
        changesMade = true;
    }

    private void comboBoxPart12Struct_SelectedIndexChanged(object sender, EventArgs e)
    {
        timbre.SetPart12Structure(comboBoxPart12Struct.SelectedIndex);
        SetPartialStructures(activePartial);
        MT32SysEx.SendText("P1&2 Struct: " + MT32Strings.partialConfig[comboBoxPart12Struct.SelectedIndex]);
        toolTipParameterValue.SetToolTip(comboBoxPart12Struct, MT32Strings.partialConfig12Desc[comboBoxPart12Struct.SelectedIndex]);
    }

    private void comboBoxPart34Struct_SelectedIndexChanged(object sender, EventArgs e)
    {
        timbre.SetPart34Structure(comboBoxPart34Struct.SelectedIndex);
        SetPartialStructures(activePartial);
        MT32SysEx.SendText("P3&4 Struct: " + MT32Strings.partialConfig[comboBoxPart34Struct.SelectedIndex]);
        toolTipParameterValue.SetToolTip(comboBoxPart34Struct, MT32Strings.partialConfig34Desc[comboBoxPart34Struct.SelectedIndex]);
    }

    private void SetPartialStructures(int partialNo)
    {
        switch (partialNo)
        {
            case 0:
                SetControlsforLeftPartial(comboBoxPart12Struct.SelectedIndex);
                break;
            case 1:
                SetControlsforRightPartial(comboBoxPart12Struct.SelectedIndex);
                break;
            case 2:
                SetControlsforLeftPartial(comboBoxPart34Struct.SelectedIndex);
                break;
            case 3:
                SetControlsforRightPartial(comboBoxPart34Struct.SelectedIndex);
                break;
            default:
                return;
        }
        MT32SysEx.UpdatePartialStructures(timbre.GetPart12Structure(), timbre.GetPart34Structure());
        UpdateUndoHistory();
        UpdatePartialStructureImages();
        changesMade = true;
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
        var dividedComboBox = new DrawingTools();
        dividedComboBox.DrawStructureList(e, isPartial12: true, comboBoxPart12Struct.DroppedDown, UIScale);
    }

    private void comboBoxPart34Struct_DrawItem(object sender, DrawItemEventArgs e)
    {
        var dividedComboBox = new DrawingTools();
        dividedComboBox.DrawStructureList(e, isPartial12: false, comboBoxPart34Struct.DroppedDown, UIScale);
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
        SelectPartial(LogicTools.GetRadioButtonValue(radioButtonPartial1.Checked, radioButtonPartial2.Checked, radioButtonPartial3.Checked, radioButtonPartial4.Checked));
    }

    private void radioButtonPartial2_CheckedChanged(object sender, EventArgs e)
    {
        SelectPartial(LogicTools.GetRadioButtonValue(radioButtonPartial1.Checked, radioButtonPartial2.Checked, radioButtonPartial3.Checked, radioButtonPartial4.Checked));
    }

    private void radioButtonPartial3_CheckedChanged(object sender, EventArgs e)
    {
        SelectPartial(LogicTools.GetRadioButtonValue(radioButtonPartial1.Checked, radioButtonPartial2.Checked, radioButtonPartial3.Checked, radioButtonPartial4.Checked));
    }

    private void radioButtonPartial4_CheckedChanged(object sender, EventArgs e)
    {
        SelectPartial(LogicTools.GetRadioButtonValue(radioButtonPartial1.Checked, radioButtonPartial2.Checked, radioButtonPartial3.Checked, radioButtonPartial4.Checked));
    }

    private void SelectPartial(int partialNo)
    {   
        if (initialisationComplete)
        {
            MT32SysEx.blockSysExMessages = true;
        }
        //update UI controls with new values
        UpdatePartialControls();
        if (partialNo != activePartial)
        {
            MT32SysEx.SendText($"Editing partial {partialNo + 1}");
        }
        if (initialisationComplete)
        {
            MT32SysEx.blockSysExMessages = false;
        }

        activePartial = partialNo;
        timbre.SetActivePartial(activePartial);
        timbre.SetPartialMuteStatus(activePartial, false);
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
    }

    private void buttonRefresh_Click(object sender, EventArgs e)
    {
        // resend all timbre parameters to device
        MT32SysEx.SendAllSysExParameters(timbre);
    }

    private void checkBoxSustain_CheckedChanged(object sender, EventArgs e)
    {
        // send sustain on/off value to device
        timbre.SetSustainStatus(checkBoxSustain.Checked);
        MT32SysEx.SendSustainValue(timbre.GetSustainStatus());
        UpdateUndoHistory();
    }

    private void buttonCopyPartial_Click(object sender, EventArgs e)
    {
        partialClipboard = timbre.CopyPartial(activePartial);
        //allow paste operation
        buttonPastePartial.Enabled = true;
        ConsoleMessage.SendVerboseLine($"Partial {activePartial + 1} copied");
        MT32SysEx.SendText($"Partial {activePartial + 1} copied");
    }

    private void buttonPastePartial_Click(object sender, EventArgs e)
    {
        //paste parameters to currently selected partial
        timbre.PastePartial(activePartial, partialClipboard);
        //send to device
        MT32SysEx.ApplyPartialParameters(timbre, activePartial);
        UpdatePartialControls();
        UpdateUndoHistory();
        RefreshGraphs();
        Invalidate();
        ConsoleMessage.SendVerboseLine($"Pasted to partial {activePartial + 1}");
        MT32SysEx.SendText($"Pasted to partial {activePartial + 1}");
        changesMade = true;
    }

    //////////////////////////////////// Undo and Redo /////////////////////////////////////

    private void buttonUndo_Click(object sender, EventArgs e)
    {
        MT32SysEx.blockMT32text = true;
        allowHistoryUpdate = false;
        timbre = timbreHistory.Undo();
        SetHistoryState();
        SetPartialRadioButtons(activePartial);
        MT32SysEx.blockMT32text = false;
        MT32SysEx.SendText("Action undone");
        allowHistoryUpdate = true;
    }

    private void buttonRedo_Click(object sender, EventArgs e)
    {
        MT32SysEx.blockMT32text = true;
        timbre = timbreHistory.Redo();
        SetHistoryState();
        SetPartialRadioButtons(activePartial);
        MT32SysEx.blockMT32text = false;
        MT32SysEx.SendText("Action redone");
    }

    private void SetHistoryState()
    {
        MT32SysEx.blockMT32text = true;
        MT32SysEx.SendAllSysExParameters(timbre);
        SetAllControlValues();
        activePartial = timbre.GetActivePartial();
    }

    private void UpdateUndoHistory()
    {
        if (!thisFormIsActive || timbreHistory is null || timbre is null || !allowHistoryUpdate)
        {
            return;
        }
        if (initialisationComplete && timbreHistory.IsDifferentTo(timbre))
        {
            MT32SysEx.blockMT32text = true;
            timbreHistory.AddTo(timbre);
            SetUndoRedoButtons();
            MT32SysEx.blockMT32text = false;
        }
    }

    //////////////////////////////////// Partial mute and unmute /////////////////////////////////////

    private void checkBoxPartial1_CheckedChanged(object sender, EventArgs e)
    {
        UpdatePartialMuteStatus(0, checkBoxPartial1.Checked);
    }

    private void checkBoxPartial2_CheckedChanged(object sender, EventArgs e)
    {
        UpdatePartialMuteStatus(1, checkBoxPartial2.Checked);
    }

    private void checkBoxPartial3_CheckedChanged(object sender, EventArgs e)
    {
        UpdatePartialMuteStatus(2, checkBoxPartial3.Checked);
    }

    private void checkBoxPartial4_CheckedChanged(object sender, EventArgs e)
    {
        UpdatePartialMuteStatus(3, checkBoxPartial4.Checked);
    }

    void UpdatePartialMuteStatus(int partialNo, bool checkBoxStatus)
    {
        // set mute status to inverse of checkbox status
        timbre.SetPartialMuteStatus(partialNo, !checkBoxStatus);
        ConfigurePartialWarnings();
        UpdateUndoHistory();
        changesMade = true;
    }

    ////////////////////////////////////////////////////// Update partial 1-4 parameters ////////////////////////////////////////////////////
    private void UpdateTimbreParameterFromTrackBarValue(byte parameterNo, TrackBar trackBar)
    {
        int parameterValue = trackBar.Value;
        timbre.SetUIParameter(activePartial, parameterNo, parameterValue);
        //send value to device register and send text to device screen
        MT32SysEx.SendPartialParameter(activePartial, parameterNo, parameterValue);
        UpdateTrackBarToolTip(parameterNo, trackBar);
        changesMade = true;
    }

    private void UpdateTrackBarToolTip(byte parameterNo, TrackBar trackBar)
    {
        toolTipParameterValue.SetToolTip(trackBar, $"{MT32Strings.partialParameterNames[parameterNo]} = {MT32Strings.PartialParameterValueText(parameterNo, trackBar.Value)}");
    }

    private void trackBarPitch_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch value to device
        UpdateTimbreParameterFromTrackBarValue(0x00, trackBarPitch);
    }

    private void trackBarFinePitch_ValueChanged(object sender, EventArgs e)
    {
        //send Fine Pitch value to device
        UpdateTimbreParameterFromTrackBarValue(0x01, trackBarFinePitch);
    }

    private void trackBarPitchKeyFollow_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch keyfollow value to device
        UpdateTimbreParameterFromTrackBarValue(0x02, trackBarPitchKeyFollow);
    }

    private void checkBoxPitchBend_CheckedChanged(object sender, EventArgs e)
    {
        int pitchBendState = LogicTools.BoolToInt(checkBoxPitchBend.Checked);
        timbre.SetUIParameter(activePartial, 0x03, pitchBendState);
        //send Pitch bend on/off value to device
        MT32SysEx.SendPartialParameter(activePartial, 0x03, pitchBendState);
        UpdateUndoHistory();
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
        //send Waveform type to device
        MT32SysEx.SendPartialParameter(activePartial, 0x04, waveFormState);
        UpdateUndoHistory();
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
        int bankNo = LogicTools.BoolToInt(radioButtonPCMBank2.Checked);
        int sysExValue = comboBoxWaveform.SelectedIndex + (bankNo * 2);
        timbre.SetUIParameter(activePartial, 0x04, sysExValue);
        MT32SysEx.SendPCMBankNo(activePartial, sysExValue);
        UpdatePCMSampleList(bankNo);
        UpdateUndoHistory();
        changesMade = true;
    }

    private void comboBoxPCMSample_EnabledChanged(object sender, EventArgs e)
    {
        int bankNo = LogicTools.BoolToInt(radioButtonPCMBank2.Checked);
        UpdatePCMSampleList(bankNo);
    }

    private void UpdatePCMSampleList(int bankNo)
    {
        int sampleNo = timbre.GetUIParameter(activePartial, 0x05);
        MT32SysEx.blockMT32text = true;
        comboBoxPCMSample.Items.Clear();
        comboBoxPCMSample.Items.AddRange(MT32Strings.GetAllSampleNames(bankNo));
        comboBoxPCMSample.Invalidate();
        comboBoxPCMSample.Text = MT32Strings.GetSampleName(bankNo, sampleNo);
        comboBoxPCMSample.SelectedIndex = sampleNo;
        MT32SysEx.blockMT32text = false;
    }

    private void comboBoxPCMSample_SelectedValueChanged(object sender, EventArgs e)
    {
        int sampleNo = comboBoxPCMSample.SelectedIndex;
        timbre.SetUIParameter(activePartial, 0x05, sampleNo);
        //send PCM sample type to device
        MT32SysEx.SendPartialParameter(activePartial, 0x05, sampleNo);
        UpdateUndoHistory();
        changesMade = true;
    }

    private void trackBar_MouseUp(object sender, MouseEventArgs e)
    {
        UpdateUndoHistory();
    }

    private void trackBarKeyUp(object sender, KeyEventArgs e)
    {
        UpdateUndoHistory();
    }

    private void trackBarPulseWidth_ValueChanged(object sender, EventArgs e)
    {
        //send Pulse Width value to device
        UpdateTimbreParameterFromTrackBarValue(0x06, trackBarPulseWidth);
    }

    private void trackBarPWVeloSens_ValueChanged(object sender, EventArgs e)
    {
        //send Pulse Width Velocity Sensitivity value to device
        UpdateTimbreParameterFromTrackBarValue(0x07, trackBarPWVeloSens);
    }

    private void trackBarPitchEnvelopeDepth_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Depth value to device
        UpdateTimbreParameterFromTrackBarValue(0x08, trackBarPitchEnvelopeDepth);
    }

    private void trackBarPitchEnvVeloSens_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Velocity Sensitivity value to device
        UpdateTimbreParameterFromTrackBarValue(0x09, trackBarPitchEnvVeloSens);
    }

    private void trackBarPitchEnvTimeKeyfollow_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Time Keyfollow value to device
        UpdateTimbreParameterFromTrackBarValue(0x0A, trackBarPitchEnvTimeKeyfollow);
    }

    private void trackBarPitchEnvT1_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Time 1 value to device
        UpdateTimbreParameterFromTrackBarValue(0x0B, trackBarPitchEnvT1);
        UpdatePitchGraph();
    }

    private void trackBarPitchEnvT2_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Time 2 value to device
        UpdateTimbreParameterFromTrackBarValue(0x0C, trackBarPitchEnvT2);
        UpdatePitchGraph();
    }

    private void trackBarPitchEnvT3_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Time 3 value to device
        UpdateTimbreParameterFromTrackBarValue(0x0D, trackBarPitchEnvT3);
        UpdatePitchGraph();
    }

    private void trackBarPitchEnvT4_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Time 4 value to device
        UpdateTimbreParameterFromTrackBarValue(0x0E, trackBarPitchEnvT4);
        UpdatePitchGraph();
    }

    private void trackBarPitchEnvL0_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Level 0 value to device
        UpdateTimbreParameterFromTrackBarValue(0x0F, trackBarPitchEnvL0);
        UpdatePitchGraph();
    }

    private void trackBarPitchEnvL1_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Level 1 value to device
        UpdateTimbreParameterFromTrackBarValue(0x10, trackBarPitchEnvL1);
        UpdatePitchGraph();
    }

    private void trackBarPitchEnvL2_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Level 2 value to device
        UpdateTimbreParameterFromTrackBarValue(0x11, trackBarPitchEnvL2);
        UpdatePitchGraph();
    }

    private void trackBarPitchEnvSust_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Sustain Level value to device
        UpdateTimbreParameterFromTrackBarValue(0x12, trackBarPitchEnvSust);
        UpdatePitchGraph();
    }

    private void trackBarPitchEnvReleaseLevel_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch Envelope Release Level value to device
        UpdateTimbreParameterFromTrackBarValue(0x13, trackBarPitchEnvReleaseLevel);
        UpdatePitchGraph();
    }

    private void trackBarLFORate_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch LFO Rate value to device
        UpdateTimbreParameterFromTrackBarValue(0x14, trackBarLFORate);
    }

    private void trackBarLFODepth_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch LFO Depth value to device
        UpdateTimbreParameterFromTrackBarValue(0x15, trackBarLFODepth);
    }

    private void trackBarLFOModSens_ValueChanged(object sender, EventArgs e)
    {
        //send Pitch LFO Modulation Sensitivity value to device
        UpdateTimbreParameterFromTrackBarValue(0x16, trackBarLFOModSens);
    }

    private void trackBarTVFCutoff_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Cutoff (low pass filter) value to device
        UpdateTimbreParameterFromTrackBarValue(0x17, trackBarTVFCutoff);
    }

    private void trackBarTVFResonance_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Resonance value to device
        UpdateTimbreParameterFromTrackBarValue(0x18, trackBarTVFResonance);
    }

    private void trackBarTVFKeyfollow_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Keyfollow value to device
        UpdateTimbreParameterFromTrackBarValue(0x19, trackBarTVFKeyfollow);
    }

    private void trackBarTVFBiasPoint_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Bias Point value to device
        UpdateTimbreParameterFromTrackBarValue(0x1A, trackBarTVFBiasPoint);
    }

    private void trackBarTVFBiasLevel_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Bias Level value to device
        UpdateTimbreParameterFromTrackBarValue(0x1B, trackBarTVFBiasLevel);
    }

    private void trackBarTVFEnvDepth_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Depth value to device
        UpdateTimbreParameterFromTrackBarValue(0x1C, trackBarTVFEnvDepth);
    }

    private void trackBarTVFVeloSensitivity_ValueChanged(object sender, EventArgs e)
    {
        //send TVFVeloSensitivity value to device
        UpdateTimbreParameterFromTrackBarValue(0x1D, trackBarTVFVeloSensitivity);
    }

    private void trackBarTVFDepthKeyfollow_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Depth Keyfollow value to device
        UpdateTimbreParameterFromTrackBarValue(0x1E, trackBarTVFDepthKeyfollow);
    }

    private void trackBarTVFTimeKeyfollow_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Time Keyfollow to device
        UpdateTimbreParameterFromTrackBarValue(0x1F, trackBarTVFTimeKeyfollow);
    }

    private void trackBarTVFT1_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Time 1 value to device
        UpdateTimbreParameterFromTrackBarValue(0x20, trackBarTVFT1);
        UpdateTVFGraph();
    }

    private void trackBarTVFT2_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Time 2 value to device
        UpdateTimbreParameterFromTrackBarValue(0x21, trackBarTVFT2);
        UpdateTVFGraph();
    }

    private void trackBarTVFT3_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Time 3 value to device
        UpdateTimbreParameterFromTrackBarValue(0x22, trackBarTVFT3);
        UpdateTVFGraph();
    }

    private void trackBarTVFT4_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Time 4 value to device
        UpdateTimbreParameterFromTrackBarValue(0x23, trackBarTVFT4);
        UpdateTVFGraph();
    }

    private void trackBarTVFT5_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Time 5 value to device
        UpdateTimbreParameterFromTrackBarValue(0x24, trackBarTVFT5);
        UpdateTVFGraph();
    }

    private void trackBarTVFL1_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Level 1 value to device
        UpdateTimbreParameterFromTrackBarValue(0x25, trackBarTVFL1);
        UpdateTVFGraph();
    }

    private void trackBarTVFL2_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Level 2 value to device
        UpdateTimbreParameterFromTrackBarValue(0x26, trackBarTVFL2);
        UpdateTVFGraph();
    }

    private void trackBarTVFL3_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Level 3 value to device
        UpdateTimbreParameterFromTrackBarValue(0x27, trackBarTVFL3);
        UpdateTVFGraph();
    }

    private void trackBarTVFSustain_ValueChanged(object sender, EventArgs e)
    {
        //send TVF Envelope Sustain value to device
        UpdateTimbreParameterFromTrackBarValue(0x28, trackBarTVFSustain);
        UpdateTVFGraph();
    }

    private void trackBarTVALevel_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Level to device
        UpdateTimbreParameterFromTrackBarValue(0x29, trackBarTVALevel);
    }

    private void trackBarTVAVeloSensitivity_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Velocity Sensitivity level to device
        UpdateTimbreParameterFromTrackBarValue(0x2A, trackBarTVAVeloSensitivity);
    }

    private void trackBarTVABiasPoint1_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Bias Point 1 value to device
        UpdateTimbreParameterFromTrackBarValue(0x2B, trackBarTVABiasPoint1);
    }

    private void trackBarTVABiasLevel1_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Bias Level 1 value to device
        UpdateTimbreParameterFromTrackBarValue(0x2C, trackBarTVABiasLevel1);
    }

    private void trackBarTVABiasPoint2_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Bias Point 2 value to device
        UpdateTimbreParameterFromTrackBarValue(0x2D, trackBarTVABiasPoint2);
    }

    private void trackBarTVABiasLevel2_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Bias Level 2 value to device
        UpdateTimbreParameterFromTrackBarValue(0x2E, trackBarTVABiasLevel2);
    }

    private void trackBarTVATimeKeyfollow_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Time Keyfollow value to device
        UpdateTimbreParameterFromTrackBarValue(0x2F, trackBarTVATimeKeyfollow);
    }

    private void trackBarTVAVelocityKeyfollow_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Velocity Keyfollow value to device
        UpdateTimbreParameterFromTrackBarValue(0x30, trackBarTVAVelocityKeyfollow);
    }

    private void trackBarTVAT1_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Envelope Time 1 to device
        UpdateTimbreParameterFromTrackBarValue(0x31, trackBarTVAT1);
        UpdateTVAGraph();
    }

    private void trackBarTVAT2_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Envelope Time 2 to device
        UpdateTimbreParameterFromTrackBarValue(0x32, trackBarTVAT2);
        UpdateTVAGraph();
    }

    private void trackBarTVAT3_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Envelope Time 3 to device
        UpdateTimbreParameterFromTrackBarValue(0x33, trackBarTVAT3);
        UpdateTVAGraph();
    }

    private void trackBarTVAT4_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Envelope Time 4 to device
        UpdateTimbreParameterFromTrackBarValue(0x34, trackBarTVAT4);
        UpdateTVAGraph();
    }

    private void trackBarTVAT5_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Envelope Time 5 to device
        UpdateTimbreParameterFromTrackBarValue(0x35, trackBarTVAT5);
        UpdateTVAGraph();
    }

    private void trackBarTVAL1_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Envelope Level 1 to device
        UpdateTimbreParameterFromTrackBarValue(0x36, trackBarTVAL1);
        UpdateTVAGraph();
    }

    private void trackBarTVAL2_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Envelope Level 2 to device
        UpdateTimbreParameterFromTrackBarValue(0x37, trackBarTVAL2);
        UpdateTVAGraph();
    }

    private void trackBarTVAL3_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Envelope Level 3 to device
        UpdateTimbreParameterFromTrackBarValue(0x38, trackBarTVAL3);
        UpdateTVAGraph();
    }

    private void trackBarTVASustain_ValueChanged(object sender, EventArgs e)
    {
        //send TVA Envelope Sustain Level to device
        UpdateTimbreParameterFromTrackBarValue(0x39, trackBarTVASustain);
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
        EnvelopeGraph graph = new EnvelopeGraph((int)(220 * UIScale) - 35, (int)(30 * UIScale), GRAPH_X, GRAPH_Y);
        graph.Plot(envelope, timbre, EnvelopeGraph.PITCH_GRAPH, activePartial, checkBoxShowAllPartials.Checked, checkBoxShowLabels.Checked);
    }

    private void groupBoxTVF_Paint(object sender, PaintEventArgs e)
    {
        if (labelTVFDisabled.Visible)
        {
            return;
        }
        //plot TVF envelope
        Graphics envelope = groupBoxTVF.CreateGraphics();
        EnvelopeGraph graph = new EnvelopeGraph((int)(440 * UIScale) - 35, (int)(30 * UIScale), GRAPH_X, GRAPH_Y);
        graph.Plot(envelope, timbre, EnvelopeGraph.TVF_GRAPH, activePartial, checkBoxShowAllPartials.Checked, checkBoxShowLabels.Checked);
    }

    private void groupBoxTVA_Paint(object sender, PaintEventArgs e)
    {
        //plot TVA envelope
        Graphics envelope = groupBoxTVA.CreateGraphics();
        EnvelopeGraph graph = new EnvelopeGraph((int)(440 * UIScale) - 35, (int)(30 * UIScale), GRAPH_X, GRAPH_Y);
        graph.Plot(envelope, timbre, EnvelopeGraph.TVA_GRAPH, activePartial, checkBoxShowAllPartials.Checked, checkBoxShowLabels.Checked);
    }
}
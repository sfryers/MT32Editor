namespace MT32Edit;

/// <summary>
/// Form gives access to MT-32 system area parameters. <br/>
/// Allows configuration of master volume, master tuning, reverb, MIDI channels and partial reserve settings.
/// </summary>
public partial class FormSystemSettings : Form
{
    // MT32Edit: FormSystemSettings
    // S.Fryers Jan 2024

    private readonly SystemLevel system = new SystemLevel();
    private readonly SaveFileDialog saveSystemDialog = new SaveFileDialog();
    private bool sendSysEx = false;

    public FormSystemSettings(SystemLevel systemInput)
    {
        InitializeComponent();
        system = systemInput;
        SetSystemControls();
    }

    private void SetSystemControls()
    {
        sendSysEx = false;
        trackBarMasterLevel.Value = system.GetMasterLevel();
        labelMasterLevelValue.Text = system.GetMasterLevel().ToString();
        trackBarMasterTune.Value = system.GetMasterTune();
        labelMasterTuneValue.Text = system.GetMasterTuneFrequency();
        comboBoxReverbType.SelectedIndex = system.GetReverbMode();
        trackBarReverbLevel.Value = system.GetReverbLevel();
        trackBarReverbRate.Value = system.GetReverbTime();
        numericUpDownMIDIPart1.Value = system.GetUIMidiChannel(0);
        numericUpDownMIDIPart2.Value = system.GetUIMidiChannel(1);
        numericUpDownMIDIPart3.Value = system.GetUIMidiChannel(2);
        numericUpDownMIDIPart4.Value = system.GetUIMidiChannel(3);
        numericUpDownMIDIPart5.Value = system.GetUIMidiChannel(4);
        numericUpDownMIDIPart6.Value = system.GetUIMidiChannel(5);
        numericUpDownMIDIPart7.Value = system.GetUIMidiChannel(6);
        numericUpDownMIDIPart8.Value = system.GetUIMidiChannel(7);
        numericUpDownMIDIPartR.Value = system.GetUIMidiChannel(8);
        numericUpDownPartReserve1.Value = system.GetPartialReserve(0);
        numericUpDownPartReserve2.Value = system.GetPartialReserve(1);
        numericUpDownPartReserve3.Value = system.GetPartialReserve(2);
        numericUpDownPartReserve4.Value = system.GetPartialReserve(3);
        numericUpDownPartReserve5.Value = system.GetPartialReserve(4);
        numericUpDownPartReserve6.Value = system.GetPartialReserve(5);
        numericUpDownPartReserve7.Value = system.GetPartialReserve(6);
        numericUpDownPartReserve8.Value = system.GetPartialReserve(7);
        numericUpDownPartReserveR.Value = system.GetPartialReserve(8);
        textBoxMessage1.Text = system.GetMessage(0);
        textBoxMessage2.Text = system.GetMessage(1);
        sendSysEx = true;
        MT32SysEx.SendSystemParameters(system);
    }

    private void numericUpDownMIDIPart1_ValueChanged(object sender, EventArgs e)
    {
        system.SetUIMidiChannel(0, (int)numericUpDownMIDIPart1.Value);
        if (sendSysEx)
        {
            MT32SysEx.SendSystemParameters(system);
        }

        if (sendSysEx)
        {
            MT32SysEx.SendText($"Part 1 channel: {numericUpDownMIDIPart1.Value}");
        }

        SetRadioButtons();
    }

    private void numericUpDownMIDIPart2_ValueChanged(object sender, EventArgs e)
    {
        system.SetUIMidiChannel(1, (int)numericUpDownMIDIPart2.Value);
        if (sendSysEx)
        {
            MT32SysEx.SendSystemParameters(system);
        }

        if (sendSysEx)
        {
            MT32SysEx.SendText($"Part 2 channel: { numericUpDownMIDIPart2.Value}");
        }

        SetRadioButtons();
    }

    private void numericUpDownMIDIPart3_ValueChanged(object sender, EventArgs e)
    {
        system.SetUIMidiChannel(2, (int)numericUpDownMIDIPart3.Value);
        if (sendSysEx)
        {
            MT32SysEx.SendSystemParameters(system);
        }

        if (sendSysEx)
        {
            MT32SysEx.SendText($"Part 3 channel: { numericUpDownMIDIPart3.Value}");
        }

        SetRadioButtons();
    }

    private void numericUpDownMIDIPart4_ValueChanged(object sender, EventArgs e)
    {
        system.SetUIMidiChannel(3, (int)numericUpDownMIDIPart4.Value);
        if (sendSysEx)
        {
            MT32SysEx.SendSystemParameters(system);
        }

        if (sendSysEx)
        {
            MT32SysEx.SendText($"Part 4 channel: {numericUpDownMIDIPart4.Value}");
        }

        SetRadioButtons();
    }

    private void numericUpDownMIDIPart5_ValueChanged(object sender, EventArgs e)
    {
        system.SetUIMidiChannel(4, (int)numericUpDownMIDIPart5.Value);
        if (sendSysEx)
        {
            MT32SysEx.SendSystemParameters(system);
        }

        if (sendSysEx)
        {
            MT32SysEx.SendText($"Part 5 channel: {numericUpDownMIDIPart5.Value}");
        }

        SetRadioButtons();
    }

    private void numericUpDownMIDIPart6_ValueChanged(object sender, EventArgs e)
    {
        system.SetUIMidiChannel(5, (int)numericUpDownMIDIPart6.Value);
        if (sendSysEx)
        {
            MT32SysEx.SendSystemParameters(system);
        }

        if (sendSysEx)
        {
            MT32SysEx.SendText($"Part 6 channel: {numericUpDownMIDIPart6.Value}");
        }

        SetRadioButtons();
    }

    private void numericUpDownMIDIPart7_ValueChanged(object sender, EventArgs e)
    {
        system.SetUIMidiChannel(6, (int)numericUpDownMIDIPart7.Value);
        if (sendSysEx)
        {
            MT32SysEx.SendSystemParameters(system);
        }

        if (sendSysEx)
        {
            MT32SysEx.SendText($"Part 7 channel: {numericUpDownMIDIPart7.Value}");
        }

        SetRadioButtons();
    }

    private void numericUpDownMIDIPart8_ValueChanged(object sender, EventArgs e)
    {
        system.SetUIMidiChannel(7, (int)numericUpDownMIDIPart8.Value);
        if (sendSysEx)
        {
            MT32SysEx.SendSystemParameters(system);
        }

        if (sendSysEx)
        {
            MT32SysEx.SendText($"Part 8 channel: {numericUpDownMIDIPart8.Value}");
        }

        SetRadioButtons();
    }

    private void numericUpDownMIDIPartR_ValueChanged(object sender, EventArgs e)
    {
        system.SetUIMidiChannel(8, (int)numericUpDownMIDIPartR.Value);
        if (sendSysEx)
        {
            MT32SysEx.SendSystemParameters(system);
        }

        if (sendSysEx)
        {
            MT32SysEx.SendText($"Rhythm channel: {numericUpDownMIDIPartR.Value}");
        }

        SetRadioButtons();
    }

    private void numericUpDownPartReserve1_ValueChanged(object sender, EventArgs e)
    {
        system.SetPartialReserve(0, (int)numericUpDownPartReserve1.Value);
        if (sendSysEx)
        {
            MT32SysEx.SendSystemParameters(system);
        }

        if (sendSysEx)
        {
            MT32SysEx.SendText($"Pt.1 Reserve: {numericUpDownPartReserve1.Value}");
        }
    }

    private void numericUpDownPartReserve2_ValueChanged(object sender, EventArgs e)
    {
        system.SetPartialReserve(1, (int)numericUpDownPartReserve2.Value);
        if (sendSysEx)
        {
            MT32SysEx.SendSystemParameters(system);
        }

        if (sendSysEx)
        {
            MT32SysEx.SendText($"Pt.2 Reserve: {numericUpDownPartReserve2.Value}");
        }
    }

    private void numericUpDownPartReserve3_ValueChanged(object sender, EventArgs e)
    {
        system.SetPartialReserve(2, (int)numericUpDownPartReserve3.Value);
        if (sendSysEx)
        {
            MT32SysEx.SendSystemParameters(system);
        }

        if (sendSysEx)
        {
            MT32SysEx.SendText($"Pt.3 Reserve: {numericUpDownPartReserve3.Value}");
        }
    }

    private void numericUpDownPartReserve4_ValueChanged(object sender, EventArgs e)
    {
        system.SetPartialReserve(3, (int)numericUpDownPartReserve4.Value);
        if (sendSysEx)
        {
            MT32SysEx.SendSystemParameters(system);
        }

        if (sendSysEx)
        {
            MT32SysEx.SendText($"Pt.4 Reserve: {numericUpDownPartReserve4.Value}");
        }
    }

    private void numericUpDownPartReserve5_ValueChanged(object sender, EventArgs e)
    {
        system.SetPartialReserve(4, (int)numericUpDownPartReserve5.Value);
        if (sendSysEx)
        {
            MT32SysEx.SendSystemParameters(system);
        }

        if (sendSysEx)
        {
            MT32SysEx.SendText($"Pt.5 Reserve: {numericUpDownPartReserve5.Value}");
        }
    }

    private void numericUpDownPartReserve6_ValueChanged(object sender, EventArgs e)
    {
        system.SetPartialReserve(5, (int)numericUpDownPartReserve6.Value);
        if (sendSysEx)
        {
            MT32SysEx.SendSystemParameters(system);
        }

        if (sendSysEx)
        {
            MT32SysEx.SendText($"Pt.6 Reserve: {numericUpDownPartReserve6.Value}");
        }
    }

    private void numericUpDownPartReserve7_ValueChanged(object sender, EventArgs e)
    {
        system.SetPartialReserve(6, (int)numericUpDownPartReserve7.Value);
        if (sendSysEx)
        {
            MT32SysEx.SendSystemParameters(system);
        }

        if (sendSysEx)
        {
            MT32SysEx.SendText($"Pt.7 Reserve: {numericUpDownPartReserve7.Value}");
        }
    }

    private void numericUpDownPartReserve8_ValueChanged(object sender, EventArgs e)
    {
        system.SetPartialReserve(7, (int)numericUpDownPartReserve8.Value);
        if (sendSysEx)
        {
            MT32SysEx.SendSystemParameters(system);
        }

        if (sendSysEx)
        {
            MT32SysEx.SendText($"Pt.8 Reserve: {numericUpDownPartReserve8.Value}");
        }
    }

    private void numericUpDownPartReserveR_ValueChanged(object sender, EventArgs e)
    {
        system.SetPartialReserve(8, (int)numericUpDownPartReserveR.Value);
        if (sendSysEx)
        {
            MT32SysEx.SendSystemParameters(system);
        }

        if (sendSysEx)
        {
            MT32SysEx.SendText($"Pt.R Reserve: {numericUpDownPartReserveR.Value}");
        }
    }

    private void trackBarMasterLevel_ValueChanged(object sender, EventArgs e)
    {
        system.SetMasterLevel(trackBarMasterLevel.Value);
        if (sendSysEx)
        {
            MT32SysEx.SendSystemParameters(system);
        }

        labelMasterLevelValue.Text = trackBarMasterLevel.Value.ToString();
        if (sendSysEx)
        {
            MT32SysEx.SendText($"Master Level: {labelMasterLevelValue.Text}");
        }
    }

    private void trackBarMasterTune_ValueChanged(object sender, EventArgs e)
    {
        system.SetMasterTune(trackBarMasterTune.Value);
        if (sendSysEx)
        {
            MT32SysEx.SendSystemParameters(system);
        }

        labelMasterTuneValue.Text = system.GetMasterTuneFrequency();
        if (sendSysEx)
        {
            MT32SysEx.SendText($"Master Tune: {labelMasterTuneValue.Text}");
        }
    }

    private void comboBoxReverbType_SelectedValueChanged(object sender, EventArgs e)
    {
        system.SetReverbMode(comboBoxReverbType.SelectedIndex);
        if (sendSysEx)
        {
            MT32SysEx.SendSystemParameters(system);
        }

        if (sendSysEx)
        {
            MT32SysEx.SendText($"Reverb Type: {comboBoxReverbType.Text}");
        }
    }

    private void trackBarReverbLevel_ValueChanged(object sender, EventArgs e)
    {
        system.SetReverbLevel(trackBarReverbLevel.Value);
        if (sendSysEx)
        {
            MT32SysEx.SendSystemParameters(system);
        }

        labelReverbLevelValue.Text = trackBarReverbLevel.Value.ToString();
        if (sendSysEx)
        {
            MT32SysEx.SendText($"Reverb Level: {trackBarReverbLevel.Value}");
        }
    }

    private void trackBarReverbRate_ValueChanged(object sender, EventArgs e)
    {
        system.SetReverbTime(trackBarReverbRate.Value);
        if (sendSysEx)
        {
            MT32SysEx.SendSystemParameters(system);
        }

        labelReverbRateValue.Text = trackBarReverbRate.Value.ToString();
        if (sendSysEx)
        {
            MT32SysEx.SendText($"Reverb Rate: {trackBarReverbRate.Value}");
        }
    }

    private void radioButtonChannels2to9_CheckedChanged(object sender, EventArgs e)
    {
        SetMidiChannels();
        if (sendSysEx)
        {
            MT32SysEx.SendText("Channels 2-10");
        }
    }

    private void radioButtonChannels1to8_CheckedChanged(object sender, EventArgs e)
    {
        SetMidiChannels();
        if (sendSysEx)
        {
            MT32SysEx.SendText("Channels 1-8 & 10");
        }
    }

    private void SetMidiChannels()
    {
        if (radioButtonChannels2to9.Checked)
        {
            system.SetMidiChannels2to9();
        }
        else if (radioButtonChannels1to8.Checked)
        {
            system.SetMidiChannels1to8();
        }

        SetSystemControls();
    }

    private void SetRadioButtons()
    {
        if (system.MidiChannelsAreSet1to8())
        {
            radioButtonChannels1to8.Checked = true;
        }
        else if (system.MidiChannelsAreSet2to9())
        {
            radioButtonChannels2to9.Checked = true;
        }
        else
        {
            radioButtonChannelCustom.Checked = true;
        }
    }

    private void textBoxMessage1_TextChanged(object sender, EventArgs e)
    {
        system.SetMessage(0, textBoxMessage1.Text);
    }

    private void textBoxMessage2_TextChanged(object sender, EventArgs e)
    {
        system.SetMessage(1, textBoxMessage2.Text);
    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
        SysExFile.SaveSystemOnly(system, saveSystemDialog, checkBoxMasterLevel.Checked, checkBoxMasterTune.Checked, checkBoxReverb.Checked, checkBoxMIDIChannel.Checked, checkBoxPartialReserve.Checked, checkBoxTextMessages.Checked);
    }
}
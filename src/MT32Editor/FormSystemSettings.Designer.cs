namespace MT32Edit
{
    partial class FormSystemSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSystemSettings));
            trackBarMasterLevel = new TrackBar();
            trackBarMasterTune = new TrackBar();
            labelMasterLevel = new Label();
            labelMasterTune = new Label();
            labelMasterTuneValue = new Label();
            labelReverbRate = new Label();
            labelReverbLevel = new Label();
            trackBarReverbRate = new TrackBar();
            trackBarReverbLevel = new TrackBar();
            comboBoxReverbType = new ComboBox();
            labelReverbType = new Label();
            labelPart4Channel = new Label();
            labelPart5Channel = new Label();
            labelPart6Channel = new Label();
            labelPart3Channel = new Label();
            labelPart2Channel = new Label();
            labelPart1Channel = new Label();
            labelPart8Channel = new Label();
            labelPart7Channel = new Label();
            labelRhythmChannel = new Label();
            labelMidiRxChannel = new Label();
            labelPartialReserve = new Label();
            panel1 = new Panel();
            radioButtonChannelCustom = new RadioButton();
            radioButtonChannels1to8 = new RadioButton();
            radioButtonChannels2to9 = new RadioButton();
            groupBoxReverb = new GroupBox();
            labelReverbRateValue = new Label();
            labelReverbLevelValue = new Label();
            numericUpDownMIDIPart1 = new NumericUpDown();
            numericUpDownMIDIPart2 = new NumericUpDown();
            numericUpDownMIDIPart3 = new NumericUpDown();
            numericUpDownMIDIPart6 = new NumericUpDown();
            numericUpDownMIDIPart5 = new NumericUpDown();
            numericUpDownMIDIPart4 = new NumericUpDown();
            numericUpDownMIDIPartR = new NumericUpDown();
            numericUpDownMIDIPart8 = new NumericUpDown();
            numericUpDownMIDIPart7 = new NumericUpDown();
            numericUpDownPartReserveR = new NumericUpDown();
            numericUpDownPartReserve8 = new NumericUpDown();
            numericUpDownPartReserve7 = new NumericUpDown();
            numericUpDownPartReserve6 = new NumericUpDown();
            numericUpDownPartReserve5 = new NumericUpDown();
            numericUpDownPartReserve4 = new NumericUpDown();
            numericUpDownPartReserve3 = new NumericUpDown();
            numericUpDownPartReserve2 = new NumericUpDown();
            numericUpDownPartReserve1 = new NumericUpDown();
            labelMasterLevelValue = new Label();
            groupBoxMessageSettings = new GroupBox();
            textBoxMessage2 = new TextBox();
            labelMessage2 = new Label();
            labelMessage1 = new Label();
            textBoxMessage1 = new TextBox();
            toolTip = new ToolTip(components);
            buttonSave = new Button();
            groupBoxExportSystemSettings = new GroupBox();
            labelIncludeParameters = new Label();
            checkBoxTextMessages = new CheckBox();
            checkBoxPartialReserve = new CheckBox();
            checkBoxMIDIChannel = new CheckBox();
            checkBoxReverb = new CheckBox();
            checkBoxMasterTune = new CheckBox();
            checkBoxMasterLevel = new CheckBox();
            labelMidiOff = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBarMasterLevel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarMasterTune).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarReverbRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarReverbLevel).BeginInit();
            panel1.SuspendLayout();
            groupBoxReverb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMIDIPart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMIDIPart2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMIDIPart3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMIDIPart6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMIDIPart5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMIDIPart4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMIDIPartR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMIDIPart8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMIDIPart7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPartReserveR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPartReserve8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPartReserve7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPartReserve6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPartReserve5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPartReserve4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPartReserve3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPartReserve2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPartReserve1).BeginInit();
            groupBoxMessageSettings.SuspendLayout();
            groupBoxExportSystemSettings.SuspendLayout();
            SuspendLayout();
            // 
            // trackBarMasterLevel
            // 
            trackBarMasterLevel.LargeChange = 10;
            trackBarMasterLevel.Location = new Point(49, 48);
            trackBarMasterLevel.Maximum = 100;
            trackBarMasterLevel.Name = "trackBarMasterLevel";
            trackBarMasterLevel.Orientation = Orientation.Vertical;
            trackBarMasterLevel.Size = new Size(45, 104);
            trackBarMasterLevel.TabIndex = 0;
            trackBarMasterLevel.TickFrequency = 10;
            trackBarMasterLevel.TickStyle = TickStyle.Both;
            trackBarMasterLevel.Value = 80;
            trackBarMasterLevel.ValueChanged += trackBarMasterLevel_ValueChanged;
            // 
            // trackBarMasterTune
            // 
            trackBarMasterTune.Location = new Point(129, 48);
            trackBarMasterTune.Maximum = 127;
            trackBarMasterTune.Name = "trackBarMasterTune";
            trackBarMasterTune.Orientation = Orientation.Vertical;
            trackBarMasterTune.Size = new Size(45, 104);
            trackBarMasterTune.TabIndex = 1;
            trackBarMasterTune.TickFrequency = 10;
            trackBarMasterTune.TickStyle = TickStyle.Both;
            trackBarMasterTune.Value = 63;
            trackBarMasterTune.ValueChanged += trackBarMasterTune_ValueChanged;
            // 
            // labelMasterLevel
            // 
            labelMasterLevel.AutoSize = true;
            labelMasterLevel.ForeColor = SystemColors.Control;
            labelMasterLevel.Location = new Point(37, 30);
            labelMasterLevel.Name = "labelMasterLevel";
            labelMasterLevel.Size = new Size(73, 15);
            labelMasterLevel.TabIndex = 2;
            labelMasterLevel.Text = "Master Level";
            // 
            // labelMasterTune
            // 
            labelMasterTune.AutoSize = true;
            labelMasterTune.ForeColor = SystemColors.Control;
            labelMasterTune.Location = new Point(116, 30);
            labelMasterTune.Name = "labelMasterTune";
            labelMasterTune.Size = new Size(72, 15);
            labelMasterTune.TabIndex = 3;
            labelMasterTune.Text = "Master Tune";
            // 
            // labelMasterTuneValue
            // 
            labelMasterTuneValue.AutoSize = true;
            labelMasterTuneValue.ForeColor = SystemColors.Control;
            labelMasterTuneValue.Location = new Point(126, 155);
            labelMasterTuneValue.Name = "labelMasterTuneValue";
            labelMasterTuneValue.Size = new Size(48, 15);
            labelMasterTuneValue.TabIndex = 4;
            labelMasterTuneValue.Text = "440.0Hz";
            // 
            // labelReverbRate
            // 
            labelReverbRate.AutoSize = true;
            labelReverbRate.ForeColor = SystemColors.Control;
            labelReverbRate.Location = new Point(119, 64);
            labelReverbRate.Name = "labelReverbRate";
            labelReverbRate.Size = new Size(30, 15);
            labelReverbRate.TabIndex = 8;
            labelReverbRate.Text = "Rate";
            labelReverbRate.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelReverbLevel
            // 
            labelReverbLevel.AutoSize = true;
            labelReverbLevel.ForeColor = SystemColors.Control;
            labelReverbLevel.Location = new Point(37, 64);
            labelReverbLevel.Name = "labelReverbLevel";
            labelReverbLevel.Size = new Size(34, 15);
            labelReverbLevel.TabIndex = 7;
            labelReverbLevel.Text = "Level";
            labelReverbLevel.TextAlign = ContentAlignment.TopCenter;
            // 
            // trackBarReverbRate
            // 
            trackBarReverbRate.Location = new Point(115, 82);
            trackBarReverbRate.Maximum = 7;
            trackBarReverbRate.Name = "trackBarReverbRate";
            trackBarReverbRate.Orientation = Orientation.Vertical;
            trackBarReverbRate.Size = new Size(45, 104);
            trackBarReverbRate.TabIndex = 6;
            trackBarReverbRate.TickStyle = TickStyle.Both;
            trackBarReverbRate.Value = 4;
            trackBarReverbRate.ValueChanged += trackBarReverbRate_ValueChanged;
            // 
            // trackBarReverbLevel
            // 
            trackBarReverbLevel.Location = new Point(35, 82);
            trackBarReverbLevel.Maximum = 7;
            trackBarReverbLevel.Name = "trackBarReverbLevel";
            trackBarReverbLevel.Orientation = Orientation.Vertical;
            trackBarReverbLevel.Size = new Size(45, 104);
            trackBarReverbLevel.TabIndex = 5;
            trackBarReverbLevel.TickStyle = TickStyle.Both;
            trackBarReverbLevel.Value = 4;
            trackBarReverbLevel.ValueChanged += trackBarReverbLevel_ValueChanged;
            // 
            // comboBoxReverbType
            // 
            comboBoxReverbType.FormattingEnabled = true;
            comboBoxReverbType.Items.AddRange(new object[] { "Room", "Hall", "Plate", "Delay" });
            comboBoxReverbType.Location = new Point(90, 34);
            comboBoxReverbType.Name = "comboBoxReverbType";
            comboBoxReverbType.Size = new Size(84, 23);
            comboBoxReverbType.TabIndex = 12;
            comboBoxReverbType.SelectedValueChanged += comboBoxReverbType_SelectedValueChanged;
            // 
            // labelReverbType
            // 
            labelReverbType.AutoSize = true;
            labelReverbType.ForeColor = SystemColors.Control;
            labelReverbType.Location = new Point(10, 37);
            labelReverbType.Name = "labelReverbType";
            labelReverbType.Size = new Size(70, 15);
            labelReverbType.TabIndex = 13;
            labelReverbType.Text = "Reverb Type";
            // 
            // labelPart4Channel
            // 
            labelPart4Channel.AutoSize = true;
            labelPart4Channel.ForeColor = SystemColors.Control;
            labelPart4Channel.Location = new Point(259, 149);
            labelPart4Channel.Name = "labelPart4Channel";
            labelPart4Channel.Size = new Size(37, 15);
            labelPart4Channel.TabIndex = 14;
            labelPart4Channel.Text = "Part 4";
            // 
            // labelPart5Channel
            // 
            labelPart5Channel.AutoSize = true;
            labelPart5Channel.ForeColor = SystemColors.Control;
            labelPart5Channel.Location = new Point(259, 178);
            labelPart5Channel.Name = "labelPart5Channel";
            labelPart5Channel.Size = new Size(37, 15);
            labelPart5Channel.TabIndex = 15;
            labelPart5Channel.Text = "Part 5";
            // 
            // labelPart6Channel
            // 
            labelPart6Channel.AutoSize = true;
            labelPart6Channel.ForeColor = SystemColors.Control;
            labelPart6Channel.Location = new Point(259, 207);
            labelPart6Channel.Name = "labelPart6Channel";
            labelPart6Channel.Size = new Size(37, 15);
            labelPart6Channel.TabIndex = 16;
            labelPart6Channel.Text = "Part 6";
            // 
            // labelPart3Channel
            // 
            labelPart3Channel.AutoSize = true;
            labelPart3Channel.ForeColor = SystemColors.Control;
            labelPart3Channel.Location = new Point(260, 120);
            labelPart3Channel.Name = "labelPart3Channel";
            labelPart3Channel.Size = new Size(37, 15);
            labelPart3Channel.TabIndex = 19;
            labelPart3Channel.Text = "Part 3";
            // 
            // labelPart2Channel
            // 
            labelPart2Channel.AutoSize = true;
            labelPart2Channel.ForeColor = SystemColors.Control;
            labelPart2Channel.Location = new Point(260, 91);
            labelPart2Channel.Name = "labelPart2Channel";
            labelPart2Channel.Size = new Size(37, 15);
            labelPart2Channel.TabIndex = 18;
            labelPart2Channel.Text = "Part 2";
            // 
            // labelPart1Channel
            // 
            labelPart1Channel.AutoSize = true;
            labelPart1Channel.ForeColor = SystemColors.Control;
            labelPart1Channel.Location = new Point(260, 62);
            labelPart1Channel.Name = "labelPart1Channel";
            labelPart1Channel.Size = new Size(37, 15);
            labelPart1Channel.TabIndex = 17;
            labelPart1Channel.Text = "Part 1";
            // 
            // labelPart8Channel
            // 
            labelPart8Channel.AutoSize = true;
            labelPart8Channel.ForeColor = SystemColors.Control;
            labelPart8Channel.Location = new Point(259, 264);
            labelPart8Channel.Name = "labelPart8Channel";
            labelPart8Channel.Size = new Size(37, 15);
            labelPart8Channel.TabIndex = 21;
            labelPart8Channel.Text = "Part 8";
            // 
            // labelPart7Channel
            // 
            labelPart7Channel.AutoSize = true;
            labelPart7Channel.ForeColor = SystemColors.Control;
            labelPart7Channel.Location = new Point(259, 235);
            labelPart7Channel.Name = "labelPart7Channel";
            labelPart7Channel.Size = new Size(37, 15);
            labelPart7Channel.TabIndex = 20;
            labelPart7Channel.Text = "Part 7";
            // 
            // labelRhythmChannel
            // 
            labelRhythmChannel.AutoSize = true;
            labelRhythmChannel.ForeColor = SystemColors.Control;
            labelRhythmChannel.Location = new Point(259, 293);
            labelRhythmChannel.Name = "labelRhythmChannel";
            labelRhythmChannel.Size = new Size(49, 15);
            labelRhythmChannel.TabIndex = 22;
            labelRhythmChannel.Text = "Rhythm";
            // 
            // labelMidiRxChannel
            // 
            labelMidiRxChannel.AutoSize = true;
            labelMidiRxChannel.ForeColor = SystemColors.Control;
            labelMidiRxChannel.Location = new Point(311, 20);
            labelMidiRxChannel.Name = "labelMidiRxChannel";
            labelMidiRxChannel.Size = new Size(77, 15);
            labelMidiRxChannel.TabIndex = 23;
            labelMidiRxChannel.Text = "MIDI channel";
            // 
            // labelPartialReserve
            // 
            labelPartialReserve.AutoSize = true;
            labelPartialReserve.ForeColor = SystemColors.Control;
            labelPartialReserve.Location = new Point(400, 20);
            labelPartialReserve.Name = "labelPartialReserve";
            labelPartialReserve.Size = new Size(80, 15);
            labelPartialReserve.TabIndex = 24;
            labelPartialReserve.Text = "Partial reserve";
            // 
            // panel1
            // 
            panel1.Controls.Add(radioButtonChannelCustom);
            panel1.Controls.Add(radioButtonChannels1to8);
            panel1.Controls.Add(radioButtonChannels2to9);
            panel1.Location = new Point(244, 326);
            panel1.Name = "panel1";
            panel1.Size = new Size(307, 93);
            panel1.TabIndex = 25;
            // 
            // radioButtonChannelCustom
            // 
            radioButtonChannelCustom.AutoSize = true;
            radioButtonChannelCustom.ForeColor = SystemColors.Control;
            radioButtonChannelCustom.Location = new Point(16, 62);
            radioButtonChannelCustom.Name = "radioButtonChannelCustom";
            radioButtonChannelCustom.Size = new Size(118, 19);
            radioButtonChannelCustom.TabIndex = 14;
            radioButtonChannelCustom.TabStop = true;
            radioButtonChannelCustom.Text = "Custom mapping";
            radioButtonChannelCustom.UseVisualStyleBackColor = true;
            // 
            // radioButtonChannels1to8
            // 
            radioButtonChannels1to8.AutoSize = true;
            radioButtonChannels1to8.ForeColor = SystemColors.Control;
            radioButtonChannels1to8.Location = new Point(16, 37);
            radioButtonChannels1to8.Name = "radioButtonChannels1to8";
            radioButtonChannels1to8.Size = new Size(266, 19);
            radioButtonChannels1to8.TabIndex = 13;
            radioButtonChannels1to8.TabStop = true;
            radioButtonChannels1to8.Text = "1-8, 10 (improved General MIDI compatibility)";
            radioButtonChannels1to8.UseVisualStyleBackColor = true;
            radioButtonChannels1to8.CheckedChanged += radioButtonChannels1to8_CheckedChanged;
            // 
            // radioButtonChannels2to9
            // 
            radioButtonChannels2to9.AutoSize = true;
            radioButtonChannels2to9.Checked = true;
            radioButtonChannels2to9.ForeColor = SystemColors.Control;
            radioButtonChannels2to9.Location = new Point(16, 12);
            radioButtonChannels2to9.Name = "radioButtonChannels2to9";
            radioButtonChannels2to9.Size = new Size(108, 19);
            radioButtonChannels2to9.TabIndex = 12;
            radioButtonChannels2to9.TabStop = true;
            radioButtonChannels2to9.Text = "2-9, 10 (default)";
            radioButtonChannels2to9.UseVisualStyleBackColor = true;
            radioButtonChannels2to9.CheckedChanged += radioButtonChannels2to9_CheckedChanged;
            // 
            // groupBoxReverb
            // 
            groupBoxReverb.Controls.Add(labelReverbRateValue);
            groupBoxReverb.Controls.Add(labelReverbLevelValue);
            groupBoxReverb.Controls.Add(labelReverbType);
            groupBoxReverb.Controls.Add(comboBoxReverbType);
            groupBoxReverb.Controls.Add(trackBarReverbLevel);
            groupBoxReverb.Controls.Add(trackBarReverbRate);
            groupBoxReverb.Controls.Add(labelReverbLevel);
            groupBoxReverb.Controls.Add(labelReverbRate);
            groupBoxReverb.Location = new Point(14, 196);
            groupBoxReverb.Name = "groupBoxReverb";
            groupBoxReverb.Size = new Size(192, 223);
            groupBoxReverb.TabIndex = 26;
            groupBoxReverb.TabStop = false;
            groupBoxReverb.Text = "Reverb settings";
            // 
            // labelReverbRateValue
            // 
            labelReverbRateValue.AutoSize = true;
            labelReverbRateValue.ForeColor = SystemColors.Control;
            labelReverbRateValue.Location = new Point(129, 188);
            labelReverbRateValue.Name = "labelReverbRateValue";
            labelReverbRateValue.Size = new Size(13, 15);
            labelReverbRateValue.TabIndex = 47;
            labelReverbRateValue.Text = "0";
            labelReverbRateValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelReverbLevelValue
            // 
            labelReverbLevelValue.AutoSize = true;
            labelReverbLevelValue.ForeColor = SystemColors.Control;
            labelReverbLevelValue.Location = new Point(49, 188);
            labelReverbLevelValue.Name = "labelReverbLevelValue";
            labelReverbLevelValue.Size = new Size(13, 15);
            labelReverbLevelValue.TabIndex = 46;
            labelReverbLevelValue.Text = "0";
            labelReverbLevelValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numericUpDownMIDIPart1
            // 
            numericUpDownMIDIPart1.Location = new Point(325, 60);
            numericUpDownMIDIPart1.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            numericUpDownMIDIPart1.Name = "numericUpDownMIDIPart1";
            numericUpDownMIDIPart1.Size = new Size(43, 23);
            numericUpDownMIDIPart1.TabIndex = 27;
            numericUpDownMIDIPart1.Value = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDownMIDIPart1.ValueChanged += numericUpDownMIDIPart1_ValueChanged;
            // 
            // numericUpDownMIDIPart2
            // 
            numericUpDownMIDIPart2.Location = new Point(325, 89);
            numericUpDownMIDIPart2.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            numericUpDownMIDIPart2.Name = "numericUpDownMIDIPart2";
            numericUpDownMIDIPart2.Size = new Size(43, 23);
            numericUpDownMIDIPart2.TabIndex = 28;
            numericUpDownMIDIPart2.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDownMIDIPart2.ValueChanged += numericUpDownMIDIPart2_ValueChanged;
            // 
            // numericUpDownMIDIPart3
            // 
            numericUpDownMIDIPart3.Location = new Point(325, 118);
            numericUpDownMIDIPart3.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            numericUpDownMIDIPart3.Name = "numericUpDownMIDIPart3";
            numericUpDownMIDIPart3.Size = new Size(43, 23);
            numericUpDownMIDIPart3.TabIndex = 29;
            numericUpDownMIDIPart3.Value = new decimal(new int[] { 4, 0, 0, 0 });
            numericUpDownMIDIPart3.ValueChanged += numericUpDownMIDIPart3_ValueChanged;
            // 
            // numericUpDownMIDIPart6
            // 
            numericUpDownMIDIPart6.Location = new Point(325, 205);
            numericUpDownMIDIPart6.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            numericUpDownMIDIPart6.Name = "numericUpDownMIDIPart6";
            numericUpDownMIDIPart6.Size = new Size(43, 23);
            numericUpDownMIDIPart6.TabIndex = 32;
            numericUpDownMIDIPart6.Value = new decimal(new int[] { 7, 0, 0, 0 });
            numericUpDownMIDIPart6.ValueChanged += numericUpDownMIDIPart6_ValueChanged;
            // 
            // numericUpDownMIDIPart5
            // 
            numericUpDownMIDIPart5.Location = new Point(325, 176);
            numericUpDownMIDIPart5.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            numericUpDownMIDIPart5.Name = "numericUpDownMIDIPart5";
            numericUpDownMIDIPart5.Size = new Size(43, 23);
            numericUpDownMIDIPart5.TabIndex = 31;
            numericUpDownMIDIPart5.Value = new decimal(new int[] { 6, 0, 0, 0 });
            numericUpDownMIDIPart5.ValueChanged += numericUpDownMIDIPart5_ValueChanged;
            // 
            // numericUpDownMIDIPart4
            // 
            numericUpDownMIDIPart4.Location = new Point(325, 147);
            numericUpDownMIDIPart4.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            numericUpDownMIDIPart4.Name = "numericUpDownMIDIPart4";
            numericUpDownMIDIPart4.Size = new Size(43, 23);
            numericUpDownMIDIPart4.TabIndex = 30;
            numericUpDownMIDIPart4.Value = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownMIDIPart4.ValueChanged += numericUpDownMIDIPart4_ValueChanged;
            // 
            // numericUpDownMIDIPartR
            // 
            numericUpDownMIDIPartR.Location = new Point(325, 291);
            numericUpDownMIDIPartR.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            numericUpDownMIDIPartR.Name = "numericUpDownMIDIPartR";
            numericUpDownMIDIPartR.Size = new Size(43, 23);
            numericUpDownMIDIPartR.TabIndex = 35;
            numericUpDownMIDIPartR.Value = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownMIDIPartR.ValueChanged += numericUpDownMIDIPartR_ValueChanged;
            // 
            // numericUpDownMIDIPart8
            // 
            numericUpDownMIDIPart8.Location = new Point(325, 262);
            numericUpDownMIDIPart8.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            numericUpDownMIDIPart8.Name = "numericUpDownMIDIPart8";
            numericUpDownMIDIPart8.Size = new Size(43, 23);
            numericUpDownMIDIPart8.TabIndex = 34;
            numericUpDownMIDIPart8.Value = new decimal(new int[] { 9, 0, 0, 0 });
            numericUpDownMIDIPart8.ValueChanged += numericUpDownMIDIPart8_ValueChanged;
            // 
            // numericUpDownMIDIPart7
            // 
            numericUpDownMIDIPart7.Location = new Point(325, 233);
            numericUpDownMIDIPart7.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            numericUpDownMIDIPart7.Name = "numericUpDownMIDIPart7";
            numericUpDownMIDIPart7.Size = new Size(43, 23);
            numericUpDownMIDIPart7.TabIndex = 33;
            numericUpDownMIDIPart7.Value = new decimal(new int[] { 8, 0, 0, 0 });
            numericUpDownMIDIPart7.ValueChanged += numericUpDownMIDIPart7_ValueChanged;
            // 
            // numericUpDownPartReserveR
            // 
            numericUpDownPartReserveR.Location = new Point(416, 291);
            numericUpDownPartReserveR.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            numericUpDownPartReserveR.Name = "numericUpDownPartReserveR";
            numericUpDownPartReserveR.Size = new Size(43, 23);
            numericUpDownPartReserveR.TabIndex = 44;
            numericUpDownPartReserveR.ValueChanged += numericUpDownPartReserveR_ValueChanged;
            // 
            // numericUpDownPartReserve8
            // 
            numericUpDownPartReserve8.Location = new Point(416, 262);
            numericUpDownPartReserve8.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            numericUpDownPartReserve8.Name = "numericUpDownPartReserve8";
            numericUpDownPartReserve8.Size = new Size(43, 23);
            numericUpDownPartReserve8.TabIndex = 43;
            numericUpDownPartReserve8.ValueChanged += numericUpDownPartReserve8_ValueChanged;
            // 
            // numericUpDownPartReserve7
            // 
            numericUpDownPartReserve7.Location = new Point(416, 233);
            numericUpDownPartReserve7.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            numericUpDownPartReserve7.Name = "numericUpDownPartReserve7";
            numericUpDownPartReserve7.Size = new Size(43, 23);
            numericUpDownPartReserve7.TabIndex = 42;
            numericUpDownPartReserve7.ValueChanged += numericUpDownPartReserve7_ValueChanged;
            // 
            // numericUpDownPartReserve6
            // 
            numericUpDownPartReserve6.Location = new Point(416, 205);
            numericUpDownPartReserve6.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            numericUpDownPartReserve6.Name = "numericUpDownPartReserve6";
            numericUpDownPartReserve6.Size = new Size(43, 23);
            numericUpDownPartReserve6.TabIndex = 41;
            numericUpDownPartReserve6.ValueChanged += numericUpDownPartReserve6_ValueChanged;
            // 
            // numericUpDownPartReserve5
            // 
            numericUpDownPartReserve5.Location = new Point(416, 176);
            numericUpDownPartReserve5.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            numericUpDownPartReserve5.Name = "numericUpDownPartReserve5";
            numericUpDownPartReserve5.Size = new Size(43, 23);
            numericUpDownPartReserve5.TabIndex = 40;
            numericUpDownPartReserve5.ValueChanged += numericUpDownPartReserve5_ValueChanged;
            // 
            // numericUpDownPartReserve4
            // 
            numericUpDownPartReserve4.Location = new Point(416, 147);
            numericUpDownPartReserve4.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            numericUpDownPartReserve4.Name = "numericUpDownPartReserve4";
            numericUpDownPartReserve4.Size = new Size(43, 23);
            numericUpDownPartReserve4.TabIndex = 39;
            numericUpDownPartReserve4.ValueChanged += numericUpDownPartReserve4_ValueChanged;
            // 
            // numericUpDownPartReserve3
            // 
            numericUpDownPartReserve3.Location = new Point(416, 118);
            numericUpDownPartReserve3.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            numericUpDownPartReserve3.Name = "numericUpDownPartReserve3";
            numericUpDownPartReserve3.Size = new Size(43, 23);
            numericUpDownPartReserve3.TabIndex = 38;
            numericUpDownPartReserve3.ValueChanged += numericUpDownPartReserve3_ValueChanged;
            // 
            // numericUpDownPartReserve2
            // 
            numericUpDownPartReserve2.Location = new Point(416, 89);
            numericUpDownPartReserve2.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            numericUpDownPartReserve2.Name = "numericUpDownPartReserve2";
            numericUpDownPartReserve2.Size = new Size(43, 23);
            numericUpDownPartReserve2.TabIndex = 37;
            numericUpDownPartReserve2.ValueChanged += numericUpDownPartReserve2_ValueChanged;
            // 
            // numericUpDownPartReserve1
            // 
            numericUpDownPartReserve1.Location = new Point(416, 60);
            numericUpDownPartReserve1.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            numericUpDownPartReserve1.Name = "numericUpDownPartReserve1";
            numericUpDownPartReserve1.Size = new Size(43, 23);
            numericUpDownPartReserve1.TabIndex = 36;
            numericUpDownPartReserve1.ValueChanged += numericUpDownPartReserve1_ValueChanged;
            // 
            // labelMasterLevelValue
            // 
            labelMasterLevelValue.AutoSize = true;
            labelMasterLevelValue.ForeColor = SystemColors.Control;
            labelMasterLevelValue.Location = new Point(60, 155);
            labelMasterLevelValue.Name = "labelMasterLevelValue";
            labelMasterLevelValue.Size = new Size(19, 15);
            labelMasterLevelValue.TabIndex = 45;
            labelMasterLevelValue.Text = "80";
            labelMasterLevelValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBoxMessageSettings
            // 
            groupBoxMessageSettings.Controls.Add(textBoxMessage2);
            groupBoxMessageSettings.Controls.Add(labelMessage2);
            groupBoxMessageSettings.Controls.Add(labelMessage1);
            groupBoxMessageSettings.Controls.Add(textBoxMessage1);
            groupBoxMessageSettings.Location = new Point(14, 425);
            groupBoxMessageSettings.Name = "groupBoxMessageSettings";
            groupBoxMessageSettings.Size = new Size(537, 60);
            groupBoxMessageSettings.TabIndex = 46;
            groupBoxMessageSettings.TabStop = false;
            groupBoxMessageSettings.Text = "Text messages";
            // 
            // textBoxMessage2
            // 
            textBoxMessage2.Location = new Point(344, 22);
            textBoxMessage2.MaxLength = 20;
            textBoxMessage2.Name = "textBoxMessage2";
            textBoxMessage2.Size = new Size(180, 23);
            textBoxMessage2.TabIndex = 18;
            toolTip.SetToolTip(textBoxMessage2, "Enter a custom message to be shown on MT-32 display after loading SysEx file");
            textBoxMessage2.Click += textBoxMessage2_Click;
            textBoxMessage2.TextChanged += textBoxMessage2_TextChanged;
            // 
            // labelMessage2
            // 
            labelMessage2.AutoSize = true;
            labelMessage2.ForeColor = SystemColors.Control;
            labelMessage2.Location = new Point(272, 25);
            labelMessage2.Name = "labelMessage2";
            labelMessage2.Size = new Size(62, 15);
            labelMessage2.TabIndex = 17;
            labelMessage2.Text = "Message 2";
            // 
            // labelMessage1
            // 
            labelMessage1.AutoSize = true;
            labelMessage1.ForeColor = SystemColors.Control;
            labelMessage1.Location = new Point(10, 25);
            labelMessage1.Name = "labelMessage1";
            labelMessage1.Size = new Size(62, 15);
            labelMessage1.TabIndex = 16;
            labelMessage1.Text = "Message 1";
            // 
            // textBoxMessage1
            // 
            textBoxMessage1.Location = new Point(81, 22);
            textBoxMessage1.MaxLength = 20;
            textBoxMessage1.Name = "textBoxMessage1";
            textBoxMessage1.Size = new Size(175, 23);
            textBoxMessage1.TabIndex = 0;
            toolTip.SetToolTip(textBoxMessage1, "Enter a custom message to be shown on MT-32 display when loading SysEx file");
            textBoxMessage1.Click += textBoxMessage1_Click;
            textBoxMessage1.TextChanged += textBoxMessage1_TextChanged;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.FromArgb(224, 224, 224);
            buttonSave.ForeColor = Color.Black;
            buttonSave.Location = new Point(81, 57);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(44, 23);
            buttonSave.TabIndex = 60;
            buttonSave.Text = "Save";
            toolTip.SetToolTip(buttonSave, "Create a SysEx file containing only these System settings");
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // groupBoxExportSystemSettings
            // 
            groupBoxExportSystemSettings.Controls.Add(buttonSave);
            groupBoxExportSystemSettings.Controls.Add(labelIncludeParameters);
            groupBoxExportSystemSettings.Controls.Add(checkBoxTextMessages);
            groupBoxExportSystemSettings.Controls.Add(checkBoxPartialReserve);
            groupBoxExportSystemSettings.Controls.Add(checkBoxMIDIChannel);
            groupBoxExportSystemSettings.Controls.Add(checkBoxReverb);
            groupBoxExportSystemSettings.Controls.Add(checkBoxMasterTune);
            groupBoxExportSystemSettings.Controls.Add(checkBoxMasterLevel);
            groupBoxExportSystemSettings.Location = new Point(14, 491);
            groupBoxExportSystemSettings.Name = "groupBoxExportSystemSettings";
            groupBoxExportSystemSettings.Size = new Size(537, 100);
            groupBoxExportSystemSettings.TabIndex = 53;
            groupBoxExportSystemSettings.TabStop = false;
            groupBoxExportSystemSettings.Text = "Save system settings";
            // 
            // labelIncludeParameters
            // 
            labelIncludeParameters.AutoSize = true;
            labelIncludeParameters.ForeColor = SystemColors.Control;
            labelIncludeParameters.Location = new Point(19, 27);
            labelIncludeParameters.Name = "labelIncludeParameters";
            labelIncludeParameters.Size = new Size(111, 15);
            labelIncludeParameters.TabIndex = 59;
            labelIncludeParameters.Text = "Include parameters:";
            // 
            // checkBoxTextMessages
            // 
            checkBoxTextMessages.AutoSize = true;
            checkBoxTextMessages.Checked = true;
            checkBoxTextMessages.CheckState = CheckState.Checked;
            checkBoxTextMessages.ForeColor = SystemColors.Control;
            checkBoxTextMessages.Location = new Point(311, 72);
            checkBoxTextMessages.Name = "checkBoxTextMessages";
            checkBoxTextMessages.Size = new Size(145, 19);
            checkBoxTextMessages.TabIndex = 58;
            checkBoxTextMessages.Text = "Custom text messages";
            checkBoxTextMessages.UseVisualStyleBackColor = true;
            // 
            // checkBoxPartialReserve
            // 
            checkBoxPartialReserve.AutoSize = true;
            checkBoxPartialReserve.Checked = true;
            checkBoxPartialReserve.CheckState = CheckState.Checked;
            checkBoxPartialReserve.ForeColor = SystemColors.Control;
            checkBoxPartialReserve.Location = new Point(311, 47);
            checkBoxPartialReserve.Name = "checkBoxPartialReserve";
            checkBoxPartialReserve.Size = new Size(143, 19);
            checkBoxPartialReserve.TabIndex = 57;
            checkBoxPartialReserve.Text = "Partial reserve settings";
            checkBoxPartialReserve.UseVisualStyleBackColor = true;
            // 
            // checkBoxMIDIChannel
            // 
            checkBoxMIDIChannel.AutoSize = true;
            checkBoxMIDIChannel.Checked = true;
            checkBoxMIDIChannel.CheckState = CheckState.Checked;
            checkBoxMIDIChannel.ForeColor = SystemColors.Control;
            checkBoxMIDIChannel.Location = new Point(311, 22);
            checkBoxMIDIChannel.Name = "checkBoxMIDIChannel";
            checkBoxMIDIChannel.Size = new Size(165, 19);
            checkBoxMIDIChannel.TabIndex = 56;
            checkBoxMIDIChannel.Text = "MIDI channel assignments";
            checkBoxMIDIChannel.UseVisualStyleBackColor = true;
            // 
            // checkBoxReverb
            // 
            checkBoxReverb.AutoSize = true;
            checkBoxReverb.Checked = true;
            checkBoxReverb.CheckState = CheckState.Checked;
            checkBoxReverb.ForeColor = SystemColors.Control;
            checkBoxReverb.Location = new Point(156, 72);
            checkBoxReverb.Name = "checkBoxReverb";
            checkBoxReverb.Size = new Size(106, 19);
            checkBoxReverb.TabIndex = 55;
            checkBoxReverb.Text = "Reverb settings";
            checkBoxReverb.UseVisualStyleBackColor = true;
            // 
            // checkBoxMasterTune
            // 
            checkBoxMasterTune.AutoSize = true;
            checkBoxMasterTune.Checked = true;
            checkBoxMasterTune.CheckState = CheckState.Checked;
            checkBoxMasterTune.ForeColor = SystemColors.Control;
            checkBoxMasterTune.Location = new Point(156, 47);
            checkBoxMasterTune.Name = "checkBoxMasterTune";
            checkBoxMasterTune.Size = new Size(89, 19);
            checkBoxMasterTune.TabIndex = 54;
            checkBoxMasterTune.Text = "Master tune";
            checkBoxMasterTune.UseVisualStyleBackColor = true;
            // 
            // checkBoxMasterLevel
            // 
            checkBoxMasterLevel.AutoSize = true;
            checkBoxMasterLevel.Checked = true;
            checkBoxMasterLevel.CheckState = CheckState.Checked;
            checkBoxMasterLevel.ForeColor = SystemColors.Control;
            checkBoxMasterLevel.Location = new Point(156, 22);
            checkBoxMasterLevel.Name = "checkBoxMasterLevel";
            checkBoxMasterLevel.Size = new Size(89, 19);
            checkBoxMasterLevel.TabIndex = 53;
            checkBoxMasterLevel.Text = "Master level";
            checkBoxMasterLevel.UseVisualStyleBackColor = true;
            // 
            // labelMidiOff
            // 
            labelMidiOff.AutoSize = true;
            labelMidiOff.ForeColor = SystemColors.Control;
            labelMidiOff.Location = new Point(322, 36);
            labelMidiOff.Name = "labelMidiOff";
            labelMidiOff.Size = new Size(50, 15);
            labelMidiOff.TabIndex = 54;
            labelMidiOff.Text = "(0 = off)";
            // 
            // FormSystemSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(563, 597);
            Controls.Add(labelMidiOff);
            Controls.Add(groupBoxExportSystemSettings);
            Controls.Add(groupBoxMessageSettings);
            Controls.Add(labelMasterLevelValue);
            Controls.Add(numericUpDownPartReserveR);
            Controls.Add(numericUpDownPartReserve8);
            Controls.Add(numericUpDownPartReserve7);
            Controls.Add(numericUpDownPartReserve6);
            Controls.Add(numericUpDownPartReserve5);
            Controls.Add(numericUpDownPartReserve4);
            Controls.Add(numericUpDownPartReserve3);
            Controls.Add(numericUpDownPartReserve2);
            Controls.Add(numericUpDownPartReserve1);
            Controls.Add(numericUpDownMIDIPartR);
            Controls.Add(numericUpDownMIDIPart8);
            Controls.Add(numericUpDownMIDIPart7);
            Controls.Add(numericUpDownMIDIPart6);
            Controls.Add(numericUpDownMIDIPart5);
            Controls.Add(numericUpDownMIDIPart4);
            Controls.Add(numericUpDownMIDIPart3);
            Controls.Add(numericUpDownMIDIPart2);
            Controls.Add(numericUpDownMIDIPart1);
            Controls.Add(groupBoxReverb);
            Controls.Add(panel1);
            Controls.Add(labelPartialReserve);
            Controls.Add(labelMidiRxChannel);
            Controls.Add(labelRhythmChannel);
            Controls.Add(labelPart8Channel);
            Controls.Add(labelPart7Channel);
            Controls.Add(labelPart3Channel);
            Controls.Add(labelPart2Channel);
            Controls.Add(labelPart1Channel);
            Controls.Add(labelPart6Channel);
            Controls.Add(labelPart5Channel);
            Controls.Add(labelPart4Channel);
            Controls.Add(labelMasterTuneValue);
            Controls.Add(labelMasterTune);
            Controls.Add(labelMasterLevel);
            Controls.Add(trackBarMasterTune);
            Controls.Add(trackBarMasterLevel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormSystemSettings";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MT-32 System Settings";
            ((System.ComponentModel.ISupportInitialize)trackBarMasterLevel).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarMasterTune).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarReverbRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarReverbLevel).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBoxReverb.ResumeLayout(false);
            groupBoxReverb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMIDIPart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMIDIPart2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMIDIPart3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMIDIPart6).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMIDIPart5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMIDIPart4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMIDIPartR).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMIDIPart8).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMIDIPart7).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPartReserveR).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPartReserve8).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPartReserve7).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPartReserve6).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPartReserve5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPartReserve4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPartReserve3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPartReserve2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPartReserve1).EndInit();
            groupBoxMessageSettings.ResumeLayout(false);
            groupBoxMessageSettings.PerformLayout();
            groupBoxExportSystemSettings.ResumeLayout(false);
            groupBoxExportSystemSettings.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar trackBarMasterLevel;
        private TrackBar trackBarMasterTune;
        private Label labelMasterLevel;
        private Label labelMasterTune;
        private Label labelMasterTuneValue;
        private Label labelReverbRate;
        private Label labelReverbLevel;
        private TrackBar trackBarReverbRate;
        private TrackBar trackBarReverbLevel;
        private ComboBox comboBoxReverbType;
        private Label labelReverbType;
        private Label labelPart4Channel;
        private Label labelPart5Channel;
        private Label labelPart6Channel;
        private Label labelPart3Channel;
        private Label labelPart2Channel;
        private Label labelPart1Channel;
        private Label labelPart8Channel;
        private Label labelPart7Channel;
        private Label labelRhythmChannel;
        private Label labelMidiRxChannel;
        private Label labelPartialReserve;
        private Panel panel1;
        private RadioButton radioButtonChannelCustom;
        private RadioButton radioButtonChannels1to8;
        private RadioButton radioButtonChannels2to9;
        private GroupBox groupBoxReverb;
        private NumericUpDown numericUpDownMIDIPart1;
        private NumericUpDown numericUpDownMIDIPart2;
        private NumericUpDown numericUpDownMIDIPart3;
        private NumericUpDown numericUpDownMIDIPart6;
        private NumericUpDown numericUpDownMIDIPart5;
        private NumericUpDown numericUpDownMIDIPart4;
        private NumericUpDown numericUpDownMIDIPartR;
        private NumericUpDown numericUpDownMIDIPart8;
        private NumericUpDown numericUpDownMIDIPart7;
        private NumericUpDown numericUpDownPartReserveR;
        private NumericUpDown numericUpDownPartReserve8;
        private NumericUpDown numericUpDownPartReserve7;
        private NumericUpDown numericUpDownPartReserve6;
        private NumericUpDown numericUpDownPartReserve5;
        private NumericUpDown numericUpDownPartReserve4;
        private NumericUpDown numericUpDownPartReserve3;
        private NumericUpDown numericUpDownPartReserve2;
        private NumericUpDown numericUpDownPartReserve1;
        private Label labelMasterLevelValue;
        private GroupBox groupBoxMessageSettings;
        private TextBox textBoxMessage2;
        private ToolTip toolTip;
        private Label labelMessage2;
        private Label labelMessage1;
        private TextBox textBoxMessage1;
        private GroupBox groupBoxExportSystemSettings;
        private Button buttonSave;
        private Label labelIncludeParameters;
        private CheckBox checkBoxTextMessages;
        private CheckBox checkBoxPartialReserve;
        private CheckBox checkBoxMIDIChannel;
        private CheckBox checkBoxReverb;
        private CheckBox checkBoxMasterTune;
        private CheckBox checkBoxMasterLevel;
        private Label labelReverbRateValue;
        private Label labelReverbLevelValue;
        private Label labelMidiOff;
    }
}
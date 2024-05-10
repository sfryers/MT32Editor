using System.Windows.Forms;
using System.Drawing;
namespace MT32Edit_legacy
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSystemSettings));
            this.trackBarMasterLevel = new System.Windows.Forms.TrackBar();
            this.trackBarMasterTune = new System.Windows.Forms.TrackBar();
            this.labelMasterLevel = new System.Windows.Forms.Label();
            this.labelMasterTune = new System.Windows.Forms.Label();
            this.labelMasterTuneValue = new System.Windows.Forms.Label();
            this.labelReverbRate = new System.Windows.Forms.Label();
            this.labelReverbLevel = new System.Windows.Forms.Label();
            this.trackBarReverbRate = new System.Windows.Forms.TrackBar();
            this.trackBarReverbLevel = new System.Windows.Forms.TrackBar();
            this.comboBoxReverbType = new System.Windows.Forms.ComboBox();
            this.labelReverbType = new System.Windows.Forms.Label();
            this.labelPart4Channel = new System.Windows.Forms.Label();
            this.labelPart5Channel = new System.Windows.Forms.Label();
            this.labelPart6Channel = new System.Windows.Forms.Label();
            this.labelPart3Channel = new System.Windows.Forms.Label();
            this.labelPart2Channel = new System.Windows.Forms.Label();
            this.labelPart1Channel = new System.Windows.Forms.Label();
            this.labelPart8Channel = new System.Windows.Forms.Label();
            this.labelPart7Channel = new System.Windows.Forms.Label();
            this.labelRhythmChannel = new System.Windows.Forms.Label();
            this.labelMidiRxChannel = new System.Windows.Forms.Label();
            this.labelPartialReserve = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonChannelCustom = new System.Windows.Forms.RadioButton();
            this.radioButtonChannels1to8 = new System.Windows.Forms.RadioButton();
            this.radioButtonChannels2to9 = new System.Windows.Forms.RadioButton();
            this.groupBoxReverb = new System.Windows.Forms.GroupBox();
            this.labelReverbRateValue = new System.Windows.Forms.Label();
            this.labelReverbLevelValue = new System.Windows.Forms.Label();
            this.numericUpDownMIDIPart1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMIDIPart2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMIDIPart3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMIDIPart6 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMIDIPart5 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMIDIPart4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMIDIPartR = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMIDIPart8 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMIDIPart7 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPartReserveR = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPartReserve8 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPartReserve7 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPartReserve6 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPartReserve5 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPartReserve4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPartReserve3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPartReserve2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPartReserve1 = new System.Windows.Forms.NumericUpDown();
            this.labelMasterLevelValue = new System.Windows.Forms.Label();
            this.groupBoxMessageSettings = new System.Windows.Forms.GroupBox();
            this.textBoxMessage2 = new System.Windows.Forms.TextBox();
            this.labelMessage2 = new System.Windows.Forms.Label();
            this.labelMessage1 = new System.Windows.Forms.Label();
            this.textBoxMessage1 = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBoxExportSystemSettings = new System.Windows.Forms.GroupBox();
            this.labelIncludeParameters = new System.Windows.Forms.Label();
            this.checkBoxTextMessages = new System.Windows.Forms.CheckBox();
            this.checkBoxPartialReserve = new System.Windows.Forms.CheckBox();
            this.checkBoxMIDIChannel = new System.Windows.Forms.CheckBox();
            this.checkBoxReverb = new System.Windows.Forms.CheckBox();
            this.checkBoxMasterTune = new System.Windows.Forms.CheckBox();
            this.checkBoxMasterLevel = new System.Windows.Forms.CheckBox();
            this.labelMidiOff = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMasterLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMasterTune)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarReverbRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarReverbLevel)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBoxReverb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMIDIPart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMIDIPart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMIDIPart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMIDIPart6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMIDIPart5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMIDIPart4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMIDIPartR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMIDIPart8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMIDIPart7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPartReserveR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPartReserve8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPartReserve7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPartReserve6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPartReserve5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPartReserve4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPartReserve3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPartReserve2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPartReserve1)).BeginInit();
            this.groupBoxMessageSettings.SuspendLayout();
            this.groupBoxExportSystemSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBarMasterLevel
            // 
            this.trackBarMasterLevel.LargeChange = 10;
            this.trackBarMasterLevel.Location = new System.Drawing.Point(42, 42);
            this.trackBarMasterLevel.Maximum = 100;
            this.trackBarMasterLevel.Name = "trackBarMasterLevel";
            this.trackBarMasterLevel.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarMasterLevel.Size = new System.Drawing.Size(45, 90);
            this.trackBarMasterLevel.TabIndex = 0;
            this.trackBarMasterLevel.TickFrequency = 10;
            this.trackBarMasterLevel.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarMasterLevel.Value = 80;
            this.trackBarMasterLevel.ValueChanged += new System.EventHandler(this.trackBarMasterLevel_ValueChanged);
            // 
            // trackBarMasterTune
            // 
            this.trackBarMasterTune.Location = new System.Drawing.Point(111, 42);
            this.trackBarMasterTune.Maximum = 127;
            this.trackBarMasterTune.Name = "trackBarMasterTune";
            this.trackBarMasterTune.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarMasterTune.Size = new System.Drawing.Size(45, 90);
            this.trackBarMasterTune.TabIndex = 1;
            this.trackBarMasterTune.TickFrequency = 10;
            this.trackBarMasterTune.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarMasterTune.Value = 63;
            this.trackBarMasterTune.ValueChanged += new System.EventHandler(this.trackBarMasterTune_ValueChanged);
            // 
            // labelMasterLevel
            // 
            this.labelMasterLevel.AutoSize = true;
            this.labelMasterLevel.ForeColor = System.Drawing.SystemColors.Control;
            this.labelMasterLevel.Location = new System.Drawing.Point(32, 26);
            this.labelMasterLevel.Name = "labelMasterLevel";
            this.labelMasterLevel.Size = new System.Drawing.Size(68, 13);
            this.labelMasterLevel.TabIndex = 2;
            this.labelMasterLevel.Text = "Master Level";
            // 
            // labelMasterTune
            // 
            this.labelMasterTune.AutoSize = true;
            this.labelMasterTune.ForeColor = System.Drawing.SystemColors.Control;
            this.labelMasterTune.Location = new System.Drawing.Point(99, 26);
            this.labelMasterTune.Name = "labelMasterTune";
            this.labelMasterTune.Size = new System.Drawing.Size(67, 13);
            this.labelMasterTune.TabIndex = 3;
            this.labelMasterTune.Text = "Master Tune";
            // 
            // labelMasterTuneValue
            // 
            this.labelMasterTuneValue.AutoSize = true;
            this.labelMasterTuneValue.ForeColor = System.Drawing.SystemColors.Control;
            this.labelMasterTuneValue.Location = new System.Drawing.Point(108, 134);
            this.labelMasterTuneValue.Name = "labelMasterTuneValue";
            this.labelMasterTuneValue.Size = new System.Drawing.Size(47, 13);
            this.labelMasterTuneValue.TabIndex = 4;
            this.labelMasterTuneValue.Text = "440.0Hz";
            // 
            // labelReverbRate
            // 
            this.labelReverbRate.AutoSize = true;
            this.labelReverbRate.ForeColor = System.Drawing.SystemColors.Control;
            this.labelReverbRate.Location = new System.Drawing.Point(102, 55);
            this.labelReverbRate.Name = "labelReverbRate";
            this.labelReverbRate.Size = new System.Drawing.Size(30, 13);
            this.labelReverbRate.TabIndex = 8;
            this.labelReverbRate.Text = "Rate";
            this.labelReverbRate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelReverbLevel
            // 
            this.labelReverbLevel.AutoSize = true;
            this.labelReverbLevel.ForeColor = System.Drawing.SystemColors.Control;
            this.labelReverbLevel.Location = new System.Drawing.Point(32, 55);
            this.labelReverbLevel.Name = "labelReverbLevel";
            this.labelReverbLevel.Size = new System.Drawing.Size(33, 13);
            this.labelReverbLevel.TabIndex = 7;
            this.labelReverbLevel.Text = "Level";
            this.labelReverbLevel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // trackBarReverbRate
            // 
            this.trackBarReverbRate.Location = new System.Drawing.Point(99, 71);
            this.trackBarReverbRate.Maximum = 7;
            this.trackBarReverbRate.Name = "trackBarReverbRate";
            this.trackBarReverbRate.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarReverbRate.Size = new System.Drawing.Size(45, 90);
            this.trackBarReverbRate.TabIndex = 6;
            this.trackBarReverbRate.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarReverbRate.Value = 4;
            this.trackBarReverbRate.ValueChanged += new System.EventHandler(this.trackBarReverbRate_ValueChanged);
            // 
            // trackBarReverbLevel
            // 
            this.trackBarReverbLevel.Location = new System.Drawing.Point(30, 71);
            this.trackBarReverbLevel.Maximum = 7;
            this.trackBarReverbLevel.Name = "trackBarReverbLevel";
            this.trackBarReverbLevel.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarReverbLevel.Size = new System.Drawing.Size(45, 90);
            this.trackBarReverbLevel.TabIndex = 5;
            this.trackBarReverbLevel.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarReverbLevel.Value = 4;
            this.trackBarReverbLevel.ValueChanged += new System.EventHandler(this.trackBarReverbLevel_ValueChanged);
            // 
            // comboBoxReverbType
            // 
            this.comboBoxReverbType.FormattingEnabled = true;
            this.comboBoxReverbType.Items.AddRange(new object[] {
            "Room",
            "Hall",
            "Plate",
            "Delay"});
            this.comboBoxReverbType.Location = new System.Drawing.Point(77, 29);
            this.comboBoxReverbType.Name = "comboBoxReverbType";
            this.comboBoxReverbType.Size = new System.Drawing.Size(73, 21);
            this.comboBoxReverbType.TabIndex = 12;
            this.comboBoxReverbType.SelectedValueChanged += new System.EventHandler(this.comboBoxReverbType_SelectedValueChanged);
            // 
            // labelReverbType
            // 
            this.labelReverbType.AutoSize = true;
            this.labelReverbType.ForeColor = System.Drawing.SystemColors.Control;
            this.labelReverbType.Location = new System.Drawing.Point(9, 32);
            this.labelReverbType.Name = "labelReverbType";
            this.labelReverbType.Size = new System.Drawing.Size(69, 13);
            this.labelReverbType.TabIndex = 13;
            this.labelReverbType.Text = "Reverb Type";
            // 
            // labelPart4Channel
            // 
            this.labelPart4Channel.AutoSize = true;
            this.labelPart4Channel.ForeColor = System.Drawing.SystemColors.Control;
            this.labelPart4Channel.Location = new System.Drawing.Point(222, 129);
            this.labelPart4Channel.Name = "labelPart4Channel";
            this.labelPart4Channel.Size = new System.Drawing.Size(35, 13);
            this.labelPart4Channel.TabIndex = 14;
            this.labelPart4Channel.Text = "Part 4";
            // 
            // labelPart5Channel
            // 
            this.labelPart5Channel.AutoSize = true;
            this.labelPart5Channel.ForeColor = System.Drawing.SystemColors.Control;
            this.labelPart5Channel.Location = new System.Drawing.Point(222, 154);
            this.labelPart5Channel.Name = "labelPart5Channel";
            this.labelPart5Channel.Size = new System.Drawing.Size(35, 13);
            this.labelPart5Channel.TabIndex = 15;
            this.labelPart5Channel.Text = "Part 5";
            // 
            // labelPart6Channel
            // 
            this.labelPart6Channel.AutoSize = true;
            this.labelPart6Channel.ForeColor = System.Drawing.SystemColors.Control;
            this.labelPart6Channel.Location = new System.Drawing.Point(222, 179);
            this.labelPart6Channel.Name = "labelPart6Channel";
            this.labelPart6Channel.Size = new System.Drawing.Size(35, 13);
            this.labelPart6Channel.TabIndex = 16;
            this.labelPart6Channel.Text = "Part 6";
            // 
            // labelPart3Channel
            // 
            this.labelPart3Channel.AutoSize = true;
            this.labelPart3Channel.ForeColor = System.Drawing.SystemColors.Control;
            this.labelPart3Channel.Location = new System.Drawing.Point(223, 104);
            this.labelPart3Channel.Name = "labelPart3Channel";
            this.labelPart3Channel.Size = new System.Drawing.Size(35, 13);
            this.labelPart3Channel.TabIndex = 19;
            this.labelPart3Channel.Text = "Part 3";
            // 
            // labelPart2Channel
            // 
            this.labelPart2Channel.AutoSize = true;
            this.labelPart2Channel.ForeColor = System.Drawing.SystemColors.Control;
            this.labelPart2Channel.Location = new System.Drawing.Point(223, 79);
            this.labelPart2Channel.Name = "labelPart2Channel";
            this.labelPart2Channel.Size = new System.Drawing.Size(35, 13);
            this.labelPart2Channel.TabIndex = 18;
            this.labelPart2Channel.Text = "Part 2";
            // 
            // labelPart1Channel
            // 
            this.labelPart1Channel.AutoSize = true;
            this.labelPart1Channel.ForeColor = System.Drawing.SystemColors.Control;
            this.labelPart1Channel.Location = new System.Drawing.Point(223, 54);
            this.labelPart1Channel.Name = "labelPart1Channel";
            this.labelPart1Channel.Size = new System.Drawing.Size(35, 13);
            this.labelPart1Channel.TabIndex = 17;
            this.labelPart1Channel.Text = "Part 1";
            // 
            // labelPart8Channel
            // 
            this.labelPart8Channel.AutoSize = true;
            this.labelPart8Channel.ForeColor = System.Drawing.SystemColors.Control;
            this.labelPart8Channel.Location = new System.Drawing.Point(222, 229);
            this.labelPart8Channel.Name = "labelPart8Channel";
            this.labelPart8Channel.Size = new System.Drawing.Size(35, 13);
            this.labelPart8Channel.TabIndex = 21;
            this.labelPart8Channel.Text = "Part 8";
            // 
            // labelPart7Channel
            // 
            this.labelPart7Channel.AutoSize = true;
            this.labelPart7Channel.ForeColor = System.Drawing.SystemColors.Control;
            this.labelPart7Channel.Location = new System.Drawing.Point(222, 204);
            this.labelPart7Channel.Name = "labelPart7Channel";
            this.labelPart7Channel.Size = new System.Drawing.Size(35, 13);
            this.labelPart7Channel.TabIndex = 20;
            this.labelPart7Channel.Text = "Part 7";
            // 
            // labelRhythmChannel
            // 
            this.labelRhythmChannel.AutoSize = true;
            this.labelRhythmChannel.ForeColor = System.Drawing.SystemColors.Control;
            this.labelRhythmChannel.Location = new System.Drawing.Point(222, 254);
            this.labelRhythmChannel.Name = "labelRhythmChannel";
            this.labelRhythmChannel.Size = new System.Drawing.Size(43, 13);
            this.labelRhythmChannel.TabIndex = 22;
            this.labelRhythmChannel.Text = "Rhythm";
            // 
            // labelMidiRxChannel
            // 
            this.labelMidiRxChannel.AutoSize = true;
            this.labelMidiRxChannel.ForeColor = System.Drawing.SystemColors.Control;
            this.labelMidiRxChannel.Location = new System.Drawing.Point(267, 17);
            this.labelMidiRxChannel.Name = "labelMidiRxChannel";
            this.labelMidiRxChannel.Size = new System.Drawing.Size(71, 13);
            this.labelMidiRxChannel.TabIndex = 23;
            this.labelMidiRxChannel.Text = "MIDI channel";
            // 
            // labelPartialReserve
            // 
            this.labelPartialReserve.AutoSize = true;
            this.labelPartialReserve.ForeColor = System.Drawing.SystemColors.Control;
            this.labelPartialReserve.Location = new System.Drawing.Point(343, 17);
            this.labelPartialReserve.Name = "labelPartialReserve";
            this.labelPartialReserve.Size = new System.Drawing.Size(74, 13);
            this.labelPartialReserve.TabIndex = 24;
            this.labelPartialReserve.Text = "Partial reserve";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonChannelCustom);
            this.panel1.Controls.Add(this.radioButtonChannels1to8);
            this.panel1.Controls.Add(this.radioButtonChannels2to9);
            this.panel1.Location = new System.Drawing.Point(209, 283);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 81);
            this.panel1.TabIndex = 25;
            // 
            // radioButtonChannelCustom
            // 
            this.radioButtonChannelCustom.AutoSize = true;
            this.radioButtonChannelCustom.ForeColor = System.Drawing.SystemColors.Control;
            this.radioButtonChannelCustom.Location = new System.Drawing.Point(14, 54);
            this.radioButtonChannelCustom.Name = "radioButtonChannelCustom";
            this.radioButtonChannelCustom.Size = new System.Drawing.Size(103, 17);
            this.radioButtonChannelCustom.TabIndex = 14;
            this.radioButtonChannelCustom.TabStop = true;
            this.radioButtonChannelCustom.Text = "Custom mapping";
            this.radioButtonChannelCustom.UseVisualStyleBackColor = true;
            // 
            // radioButtonChannels1to8
            // 
            this.radioButtonChannels1to8.AutoSize = true;
            this.radioButtonChannels1to8.ForeColor = System.Drawing.SystemColors.Control;
            this.radioButtonChannels1to8.Location = new System.Drawing.Point(14, 32);
            this.radioButtonChannels1to8.Name = "radioButtonChannels1to8";
            this.radioButtonChannels1to8.Size = new System.Drawing.Size(236, 17);
            this.radioButtonChannels1to8.TabIndex = 13;
            this.radioButtonChannels1to8.TabStop = true;
            this.radioButtonChannels1to8.Text = "1-8, 10 (improved General MIDI compatibility)";
            this.radioButtonChannels1to8.UseVisualStyleBackColor = true;
            this.radioButtonChannels1to8.CheckedChanged += new System.EventHandler(this.radioButtonChannels1to8_CheckedChanged);
            // 
            // radioButtonChannels2to9
            // 
            this.radioButtonChannels2to9.AutoSize = true;
            this.radioButtonChannels2to9.Checked = true;
            this.radioButtonChannels2to9.ForeColor = System.Drawing.SystemColors.Control;
            this.radioButtonChannels2to9.Location = new System.Drawing.Point(14, 10);
            this.radioButtonChannels2to9.Name = "radioButtonChannels2to9";
            this.radioButtonChannels2to9.Size = new System.Drawing.Size(99, 17);
            this.radioButtonChannels2to9.TabIndex = 12;
            this.radioButtonChannels2to9.TabStop = true;
            this.radioButtonChannels2to9.Text = "2-9, 10 (default)";
            this.radioButtonChannels2to9.UseVisualStyleBackColor = true;
            this.radioButtonChannels2to9.CheckedChanged += new System.EventHandler(this.radioButtonChannels2to9_CheckedChanged);
            // 
            // groupBoxReverb
            // 
            this.groupBoxReverb.Controls.Add(this.labelReverbRateValue);
            this.groupBoxReverb.Controls.Add(this.labelReverbLevelValue);
            this.groupBoxReverb.Controls.Add(this.labelReverbType);
            this.groupBoxReverb.Controls.Add(this.comboBoxReverbType);
            this.groupBoxReverb.Controls.Add(this.trackBarReverbLevel);
            this.groupBoxReverb.Controls.Add(this.trackBarReverbRate);
            this.groupBoxReverb.Controls.Add(this.labelReverbLevel);
            this.groupBoxReverb.Controls.Add(this.labelReverbRate);
            this.groupBoxReverb.Location = new System.Drawing.Point(12, 170);
            this.groupBoxReverb.Name = "groupBoxReverb";
            this.groupBoxReverb.Size = new System.Drawing.Size(165, 193);
            this.groupBoxReverb.TabIndex = 26;
            this.groupBoxReverb.TabStop = false;
            this.groupBoxReverb.Text = "Reverb settings";
            // 
            // labelReverbRateValue
            // 
            this.labelReverbRateValue.AutoSize = true;
            this.labelReverbRateValue.ForeColor = System.Drawing.SystemColors.Control;
            this.labelReverbRateValue.Location = new System.Drawing.Point(111, 163);
            this.labelReverbRateValue.Name = "labelReverbRateValue";
            this.labelReverbRateValue.Size = new System.Drawing.Size(13, 13);
            this.labelReverbRateValue.TabIndex = 47;
            this.labelReverbRateValue.Text = "0";
            this.labelReverbRateValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelReverbLevelValue
            // 
            this.labelReverbLevelValue.AutoSize = true;
            this.labelReverbLevelValue.ForeColor = System.Drawing.SystemColors.Control;
            this.labelReverbLevelValue.Location = new System.Drawing.Point(42, 163);
            this.labelReverbLevelValue.Name = "labelReverbLevelValue";
            this.labelReverbLevelValue.Size = new System.Drawing.Size(13, 13);
            this.labelReverbLevelValue.TabIndex = 46;
            this.labelReverbLevelValue.Text = "0";
            this.labelReverbLevelValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDownMIDIPart1
            // 
            this.numericUpDownMIDIPart1.Location = new System.Drawing.Point(279, 52);
            this.numericUpDownMIDIPart1.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDownMIDIPart1.Name = "numericUpDownMIDIPart1";
            this.numericUpDownMIDIPart1.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownMIDIPart1.TabIndex = 27;
            this.numericUpDownMIDIPart1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownMIDIPart1.ValueChanged += new System.EventHandler(this.numericUpDownMIDIPart1_ValueChanged);
            // 
            // numericUpDownMIDIPart2
            // 
            this.numericUpDownMIDIPart2.Location = new System.Drawing.Point(279, 77);
            this.numericUpDownMIDIPart2.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDownMIDIPart2.Name = "numericUpDownMIDIPart2";
            this.numericUpDownMIDIPart2.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownMIDIPart2.TabIndex = 28;
            this.numericUpDownMIDIPart2.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownMIDIPart2.ValueChanged += new System.EventHandler(this.numericUpDownMIDIPart2_ValueChanged);
            // 
            // numericUpDownMIDIPart3
            // 
            this.numericUpDownMIDIPart3.Location = new System.Drawing.Point(279, 102);
            this.numericUpDownMIDIPart3.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDownMIDIPart3.Name = "numericUpDownMIDIPart3";
            this.numericUpDownMIDIPart3.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownMIDIPart3.TabIndex = 29;
            this.numericUpDownMIDIPart3.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownMIDIPart3.ValueChanged += new System.EventHandler(this.numericUpDownMIDIPart3_ValueChanged);
            // 
            // numericUpDownMIDIPart6
            // 
            this.numericUpDownMIDIPart6.Location = new System.Drawing.Point(279, 178);
            this.numericUpDownMIDIPart6.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDownMIDIPart6.Name = "numericUpDownMIDIPart6";
            this.numericUpDownMIDIPart6.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownMIDIPart6.TabIndex = 32;
            this.numericUpDownMIDIPart6.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDownMIDIPart6.ValueChanged += new System.EventHandler(this.numericUpDownMIDIPart6_ValueChanged);
            // 
            // numericUpDownMIDIPart5
            // 
            this.numericUpDownMIDIPart5.Location = new System.Drawing.Point(279, 153);
            this.numericUpDownMIDIPart5.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDownMIDIPart5.Name = "numericUpDownMIDIPart5";
            this.numericUpDownMIDIPart5.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownMIDIPart5.TabIndex = 31;
            this.numericUpDownMIDIPart5.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownMIDIPart5.ValueChanged += new System.EventHandler(this.numericUpDownMIDIPart5_ValueChanged);
            // 
            // numericUpDownMIDIPart4
            // 
            this.numericUpDownMIDIPart4.Location = new System.Drawing.Point(279, 127);
            this.numericUpDownMIDIPart4.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDownMIDIPart4.Name = "numericUpDownMIDIPart4";
            this.numericUpDownMIDIPart4.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownMIDIPart4.TabIndex = 30;
            this.numericUpDownMIDIPart4.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownMIDIPart4.ValueChanged += new System.EventHandler(this.numericUpDownMIDIPart4_ValueChanged);
            // 
            // numericUpDownMIDIPartR
            // 
            this.numericUpDownMIDIPartR.Location = new System.Drawing.Point(279, 252);
            this.numericUpDownMIDIPartR.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDownMIDIPartR.Name = "numericUpDownMIDIPartR";
            this.numericUpDownMIDIPartR.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownMIDIPartR.TabIndex = 35;
            this.numericUpDownMIDIPartR.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownMIDIPartR.ValueChanged += new System.EventHandler(this.numericUpDownMIDIPartR_ValueChanged);
            // 
            // numericUpDownMIDIPart8
            // 
            this.numericUpDownMIDIPart8.Location = new System.Drawing.Point(279, 227);
            this.numericUpDownMIDIPart8.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDownMIDIPart8.Name = "numericUpDownMIDIPart8";
            this.numericUpDownMIDIPart8.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownMIDIPart8.TabIndex = 34;
            this.numericUpDownMIDIPart8.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDownMIDIPart8.ValueChanged += new System.EventHandler(this.numericUpDownMIDIPart8_ValueChanged);
            // 
            // numericUpDownMIDIPart7
            // 
            this.numericUpDownMIDIPart7.Location = new System.Drawing.Point(279, 202);
            this.numericUpDownMIDIPart7.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDownMIDIPart7.Name = "numericUpDownMIDIPart7";
            this.numericUpDownMIDIPart7.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownMIDIPart7.TabIndex = 33;
            this.numericUpDownMIDIPart7.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownMIDIPart7.ValueChanged += new System.EventHandler(this.numericUpDownMIDIPart7_ValueChanged);
            // 
            // numericUpDownPartReserveR
            // 
            this.numericUpDownPartReserveR.Location = new System.Drawing.Point(357, 252);
            this.numericUpDownPartReserveR.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownPartReserveR.Name = "numericUpDownPartReserveR";
            this.numericUpDownPartReserveR.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownPartReserveR.TabIndex = 44;
            this.numericUpDownPartReserveR.ValueChanged += new System.EventHandler(this.numericUpDownMIDIPartR_ValueChanged);
            // 
            // numericUpDownPartReserve8
            // 
            this.numericUpDownPartReserve8.Location = new System.Drawing.Point(357, 227);
            this.numericUpDownPartReserve8.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownPartReserve8.Name = "numericUpDownPartReserve8";
            this.numericUpDownPartReserve8.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownPartReserve8.TabIndex = 43;
            this.numericUpDownPartReserve8.ValueChanged += new System.EventHandler(this.numericUpDownMIDIPart8_ValueChanged);
            // 
            // numericUpDownPartReserve7
            // 
            this.numericUpDownPartReserve7.Location = new System.Drawing.Point(357, 202);
            this.numericUpDownPartReserve7.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownPartReserve7.Name = "numericUpDownPartReserve7";
            this.numericUpDownPartReserve7.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownPartReserve7.TabIndex = 42;
            this.numericUpDownPartReserve7.ValueChanged += new System.EventHandler(this.numericUpDownMIDIPart7_ValueChanged);
            // 
            // numericUpDownPartReserve6
            // 
            this.numericUpDownPartReserve6.Location = new System.Drawing.Point(357, 178);
            this.numericUpDownPartReserve6.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownPartReserve6.Name = "numericUpDownPartReserve6";
            this.numericUpDownPartReserve6.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownPartReserve6.TabIndex = 41;
            this.numericUpDownPartReserve6.ValueChanged += new System.EventHandler(this.numericUpDownMIDIPart6_ValueChanged);
            // 
            // numericUpDownPartReserve5
            // 
            this.numericUpDownPartReserve5.Location = new System.Drawing.Point(357, 153);
            this.numericUpDownPartReserve5.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownPartReserve5.Name = "numericUpDownPartReserve5";
            this.numericUpDownPartReserve5.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownPartReserve5.TabIndex = 40;
            this.numericUpDownPartReserve5.ValueChanged += new System.EventHandler(this.numericUpDownMIDIPart5_ValueChanged);
            // 
            // numericUpDownPartReserve4
            // 
            this.numericUpDownPartReserve4.Location = new System.Drawing.Point(357, 127);
            this.numericUpDownPartReserve4.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownPartReserve4.Name = "numericUpDownPartReserve4";
            this.numericUpDownPartReserve4.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownPartReserve4.TabIndex = 39;
            this.numericUpDownPartReserve4.ValueChanged += new System.EventHandler(this.numericUpDownMIDIPart4_ValueChanged);
            // 
            // numericUpDownPartReserve3
            // 
            this.numericUpDownPartReserve3.Location = new System.Drawing.Point(357, 102);
            this.numericUpDownPartReserve3.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownPartReserve3.Name = "numericUpDownPartReserve3";
            this.numericUpDownPartReserve3.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownPartReserve3.TabIndex = 38;
            this.numericUpDownPartReserve3.ValueChanged += new System.EventHandler(this.numericUpDownMIDIPart3_ValueChanged);
            // 
            // numericUpDownPartReserve2
            // 
            this.numericUpDownPartReserve2.Location = new System.Drawing.Point(357, 77);
            this.numericUpDownPartReserve2.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownPartReserve2.Name = "numericUpDownPartReserve2";
            this.numericUpDownPartReserve2.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownPartReserve2.TabIndex = 37;
            this.numericUpDownPartReserve2.ValueChanged += new System.EventHandler(this.numericUpDownPartReserve2_ValueChanged);
            // 
            // numericUpDownPartReserve1
            // 
            this.numericUpDownPartReserve1.Location = new System.Drawing.Point(357, 52);
            this.numericUpDownPartReserve1.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownPartReserve1.Name = "numericUpDownPartReserve1";
            this.numericUpDownPartReserve1.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownPartReserve1.TabIndex = 36;
            this.numericUpDownPartReserve1.ValueChanged += new System.EventHandler(this.numericUpDownPartReserve1_ValueChanged);
            // 
            // labelMasterLevelValue
            // 
            this.labelMasterLevelValue.AutoSize = true;
            this.labelMasterLevelValue.ForeColor = System.Drawing.SystemColors.Control;
            this.labelMasterLevelValue.Location = new System.Drawing.Point(51, 134);
            this.labelMasterLevelValue.Name = "labelMasterLevelValue";
            this.labelMasterLevelValue.Size = new System.Drawing.Size(19, 13);
            this.labelMasterLevelValue.TabIndex = 45;
            this.labelMasterLevelValue.Text = "80";
            this.labelMasterLevelValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxMessageSettings
            // 
            this.groupBoxMessageSettings.Controls.Add(this.textBoxMessage2);
            this.groupBoxMessageSettings.Controls.Add(this.labelMessage2);
            this.groupBoxMessageSettings.Controls.Add(this.labelMessage1);
            this.groupBoxMessageSettings.Controls.Add(this.textBoxMessage1);
            this.groupBoxMessageSettings.Location = new System.Drawing.Point(12, 368);
            this.groupBoxMessageSettings.Name = "groupBoxMessageSettings";
            this.groupBoxMessageSettings.Size = new System.Drawing.Size(460, 52);
            this.groupBoxMessageSettings.TabIndex = 46;
            this.groupBoxMessageSettings.TabStop = false;
            this.groupBoxMessageSettings.Text = "Text messages";
            // 
            // textBoxMessage2
            // 
            this.textBoxMessage2.Location = new System.Drawing.Point(295, 19);
            this.textBoxMessage2.MaxLength = 20;
            this.textBoxMessage2.Name = "textBoxMessage2";
            this.textBoxMessage2.Size = new System.Drawing.Size(155, 20);
            this.textBoxMessage2.TabIndex = 18;
            this.toolTip.SetToolTip(this.textBoxMessage2, "Enter a custom message to be shown on MT-32 display after loading SysEx file");
            this.textBoxMessage2.Click += new System.EventHandler(this.textBoxMessage2_Click);
            this.textBoxMessage2.TextChanged += new System.EventHandler(this.textBoxMessage2_TextChanged);
            // 
            // labelMessage2
            // 
            this.labelMessage2.AutoSize = true;
            this.labelMessage2.ForeColor = System.Drawing.SystemColors.Control;
            this.labelMessage2.Location = new System.Drawing.Point(233, 22);
            this.labelMessage2.Name = "labelMessage2";
            this.labelMessage2.Size = new System.Drawing.Size(59, 13);
            this.labelMessage2.TabIndex = 17;
            this.labelMessage2.Text = "Message 2";
            // 
            // labelMessage1
            // 
            this.labelMessage1.AutoSize = true;
            this.labelMessage1.ForeColor = System.Drawing.SystemColors.Control;
            this.labelMessage1.Location = new System.Drawing.Point(9, 22);
            this.labelMessage1.Name = "labelMessage1";
            this.labelMessage1.Size = new System.Drawing.Size(59, 13);
            this.labelMessage1.TabIndex = 16;
            this.labelMessage1.Text = "Message 1";
            // 
            // textBoxMessage1
            // 
            this.textBoxMessage1.Location = new System.Drawing.Point(69, 19);
            this.textBoxMessage1.MaxLength = 20;
            this.textBoxMessage1.Name = "textBoxMessage1";
            this.textBoxMessage1.Size = new System.Drawing.Size(151, 20);
            this.textBoxMessage1.TabIndex = 0;
            this.toolTip.SetToolTip(this.textBoxMessage1, "Enter a custom message to be shown on MT-32 display when loading SysEx file");
            this.textBoxMessage1.Click += new System.EventHandler(this.textBoxMessage1_Click);
            this.textBoxMessage1.TextChanged += new System.EventHandler(this.textBoxMessage1_TextChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonSave.ForeColor = System.Drawing.Color.Black;
            this.buttonSave.Location = new System.Drawing.Point(61, 49);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(46, 20);
            this.buttonSave.TabIndex = 60;
            this.buttonSave.Text = "Save";
            this.toolTip.SetToolTip(this.buttonSave, "Create a SysEx file containing only these System settings");
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBoxExportSystemSettings
            // 
            this.groupBoxExportSystemSettings.Controls.Add(this.buttonSave);
            this.groupBoxExportSystemSettings.Controls.Add(this.labelIncludeParameters);
            this.groupBoxExportSystemSettings.Controls.Add(this.checkBoxTextMessages);
            this.groupBoxExportSystemSettings.Controls.Add(this.checkBoxPartialReserve);
            this.groupBoxExportSystemSettings.Controls.Add(this.checkBoxMIDIChannel);
            this.groupBoxExportSystemSettings.Controls.Add(this.checkBoxReverb);
            this.groupBoxExportSystemSettings.Controls.Add(this.checkBoxMasterTune);
            this.groupBoxExportSystemSettings.Controls.Add(this.checkBoxMasterLevel);
            this.groupBoxExportSystemSettings.Location = new System.Drawing.Point(12, 426);
            this.groupBoxExportSystemSettings.Name = "groupBoxExportSystemSettings";
            this.groupBoxExportSystemSettings.Size = new System.Drawing.Size(460, 87);
            this.groupBoxExportSystemSettings.TabIndex = 53;
            this.groupBoxExportSystemSettings.TabStop = false;
            this.groupBoxExportSystemSettings.Text = "Save system settings";
            // 
            // labelIncludeParameters
            // 
            this.labelIncludeParameters.AutoSize = true;
            this.labelIncludeParameters.ForeColor = System.Drawing.SystemColors.Control;
            this.labelIncludeParameters.Location = new System.Drawing.Point(16, 23);
            this.labelIncludeParameters.Name = "labelIncludeParameters";
            this.labelIncludeParameters.Size = new System.Drawing.Size(100, 13);
            this.labelIncludeParameters.TabIndex = 59;
            this.labelIncludeParameters.Text = "Include parameters:";
            // 
            // checkBoxTextMessages
            // 
            this.checkBoxTextMessages.AutoSize = true;
            this.checkBoxTextMessages.Checked = true;
            this.checkBoxTextMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTextMessages.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBoxTextMessages.Location = new System.Drawing.Point(267, 62);
            this.checkBoxTextMessages.Name = "checkBoxTextMessages";
            this.checkBoxTextMessages.Size = new System.Drawing.Size(131, 17);
            this.checkBoxTextMessages.TabIndex = 58;
            this.checkBoxTextMessages.Text = "Custom text messages";
            this.checkBoxTextMessages.UseVisualStyleBackColor = true;
            // 
            // checkBoxPartialReserve
            // 
            this.checkBoxPartialReserve.AutoSize = true;
            this.checkBoxPartialReserve.Checked = true;
            this.checkBoxPartialReserve.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPartialReserve.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBoxPartialReserve.Location = new System.Drawing.Point(267, 41);
            this.checkBoxPartialReserve.Name = "checkBoxPartialReserve";
            this.checkBoxPartialReserve.Size = new System.Drawing.Size(132, 17);
            this.checkBoxPartialReserve.TabIndex = 57;
            this.checkBoxPartialReserve.Text = "Partial reserve settings";
            this.checkBoxPartialReserve.UseVisualStyleBackColor = true;
            // 
            // checkBoxMIDIChannel
            // 
            this.checkBoxMIDIChannel.AutoSize = true;
            this.checkBoxMIDIChannel.Checked = true;
            this.checkBoxMIDIChannel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMIDIChannel.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBoxMIDIChannel.Location = new System.Drawing.Point(267, 19);
            this.checkBoxMIDIChannel.Name = "checkBoxMIDIChannel";
            this.checkBoxMIDIChannel.Size = new System.Drawing.Size(151, 17);
            this.checkBoxMIDIChannel.TabIndex = 56;
            this.checkBoxMIDIChannel.Text = "MIDI channel assignments";
            this.checkBoxMIDIChannel.UseVisualStyleBackColor = true;
            // 
            // checkBoxReverb
            // 
            this.checkBoxReverb.AutoSize = true;
            this.checkBoxReverb.Checked = true;
            this.checkBoxReverb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxReverb.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBoxReverb.Location = new System.Drawing.Point(134, 62);
            this.checkBoxReverb.Name = "checkBoxReverb";
            this.checkBoxReverb.Size = new System.Drawing.Size(100, 17);
            this.checkBoxReverb.TabIndex = 55;
            this.checkBoxReverb.Text = "Reverb settings";
            this.checkBoxReverb.UseVisualStyleBackColor = true;
            // 
            // checkBoxMasterTune
            // 
            this.checkBoxMasterTune.AutoSize = true;
            this.checkBoxMasterTune.Checked = true;
            this.checkBoxMasterTune.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMasterTune.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBoxMasterTune.Location = new System.Drawing.Point(134, 41);
            this.checkBoxMasterTune.Name = "checkBoxMasterTune";
            this.checkBoxMasterTune.Size = new System.Drawing.Size(82, 17);
            this.checkBoxMasterTune.TabIndex = 54;
            this.checkBoxMasterTune.Text = "Master tune";
            this.checkBoxMasterTune.UseVisualStyleBackColor = true;
            // 
            // checkBoxMasterLevel
            // 
            this.checkBoxMasterLevel.AutoSize = true;
            this.checkBoxMasterLevel.Checked = true;
            this.checkBoxMasterLevel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMasterLevel.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBoxMasterLevel.Location = new System.Drawing.Point(134, 19);
            this.checkBoxMasterLevel.Name = "checkBoxMasterLevel";
            this.checkBoxMasterLevel.Size = new System.Drawing.Size(83, 17);
            this.checkBoxMasterLevel.TabIndex = 53;
            this.checkBoxMasterLevel.Text = "Master level";
            this.checkBoxMasterLevel.UseVisualStyleBackColor = true;
            // 
            // labelMidiOff
            // 
            this.labelMidiOff.AutoSize = true;
            this.labelMidiOff.ForeColor = System.Drawing.SystemColors.Control;
            this.labelMidiOff.Location = new System.Drawing.Point(276, 31);
            this.labelMidiOff.Name = "labelMidiOff";
            this.labelMidiOff.Size = new System.Drawing.Size(43, 13);
            this.labelMidiOff.TabIndex = 54;
            this.labelMidiOff.Text = "(0 = off)";
            // 
            // FormSystemSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(483, 517);
            this.Controls.Add(this.labelMidiOff);
            this.Controls.Add(this.groupBoxExportSystemSettings);
            this.Controls.Add(this.groupBoxMessageSettings);
            this.Controls.Add(this.labelMasterLevelValue);
            this.Controls.Add(this.numericUpDownPartReserveR);
            this.Controls.Add(this.numericUpDownPartReserve8);
            this.Controls.Add(this.numericUpDownPartReserve7);
            this.Controls.Add(this.numericUpDownPartReserve6);
            this.Controls.Add(this.numericUpDownPartReserve5);
            this.Controls.Add(this.numericUpDownPartReserve4);
            this.Controls.Add(this.numericUpDownPartReserve3);
            this.Controls.Add(this.numericUpDownPartReserve2);
            this.Controls.Add(this.numericUpDownPartReserve1);
            this.Controls.Add(this.numericUpDownMIDIPartR);
            this.Controls.Add(this.numericUpDownMIDIPart8);
            this.Controls.Add(this.numericUpDownMIDIPart7);
            this.Controls.Add(this.numericUpDownMIDIPart6);
            this.Controls.Add(this.numericUpDownMIDIPart5);
            this.Controls.Add(this.numericUpDownMIDIPart4);
            this.Controls.Add(this.numericUpDownMIDIPart3);
            this.Controls.Add(this.numericUpDownMIDIPart2);
            this.Controls.Add(this.numericUpDownMIDIPart1);
            this.Controls.Add(this.groupBoxReverb);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelPartialReserve);
            this.Controls.Add(this.labelMidiRxChannel);
            this.Controls.Add(this.labelRhythmChannel);
            this.Controls.Add(this.labelPart8Channel);
            this.Controls.Add(this.labelPart7Channel);
            this.Controls.Add(this.labelPart3Channel);
            this.Controls.Add(this.labelPart2Channel);
            this.Controls.Add(this.labelPart1Channel);
            this.Controls.Add(this.labelPart6Channel);
            this.Controls.Add(this.labelPart5Channel);
            this.Controls.Add(this.labelPart4Channel);
            this.Controls.Add(this.labelMasterTuneValue);
            this.Controls.Add(this.labelMasterTune);
            this.Controls.Add(this.labelMasterLevel);
            this.Controls.Add(this.trackBarMasterTune);
            this.Controls.Add(this.trackBarMasterLevel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormSystemSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MT-32 System Settings";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMasterLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMasterTune)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarReverbRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarReverbLevel)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxReverb.ResumeLayout(false);
            this.groupBoxReverb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMIDIPart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMIDIPart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMIDIPart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMIDIPart6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMIDIPart5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMIDIPart4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMIDIPartR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMIDIPart8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMIDIPart7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPartReserveR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPartReserve8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPartReserve7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPartReserve6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPartReserve5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPartReserve4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPartReserve3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPartReserve2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPartReserve1)).EndInit();
            this.groupBoxMessageSettings.ResumeLayout(false);
            this.groupBoxMessageSettings.PerformLayout();
            this.groupBoxExportSystemSettings.ResumeLayout(false);
            this.groupBoxExportSystemSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
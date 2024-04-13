namespace MT32Edit
{
    partial class FormPatchEditor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ListViewItem listViewItem2 = new ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPatchEditor));
            listViewPatches = new ListView();
            columnHeaderPatchNo = new ColumnHeader();
            columnHeaderTimbreGroup = new ColumnHeader();
            columnHeaderTimbreName = new ColumnHeader();
            columnHeaderKeyShift = new ColumnHeader();
            columnHeaderFineTune = new ColumnHeader();
            columnHeaderBendRange = new ColumnHeader();
            columnHeaderReverb = new ColumnHeader();
            columnHeaderAssignMode = new ColumnHeader();
            comboBoxTimbreGroup = new ComboBox();
            numericUpDownPatchNo = new NumericUpDown();
            comboBoxTimbreName = new ComboBox();
            labelPatchNo = new Label();
            labelTimbreGroup = new Label();
            labelTimbreName = new Label();
            trackBarKeyShift = new TrackBar();
            trackBarFineTune = new TrackBar();
            trackBarBenderRange = new TrackBar();
            radioButtonReverbOn = new RadioButton();
            radioButtonReverbOff = new RadioButton();
            labelKeyShift = new Label();
            labelFineTune = new Label();
            labelBendRange = new Label();
            labelReverb = new Label();
            comboBoxAssignMode = new ComboBox();
            labelAssignMode = new Label();
            toolTipParameterValue = new ToolTip(components);
            labelUnitNoWarning = new Label();
            labelHeading = new Label();
            timer = new System.Windows.Forms.Timer(components);
            buttonEditPreset = new Button();
            labelNoChannelAssigned = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPatchNo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarKeyShift).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarFineTune).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarBenderRange).BeginInit();
            SuspendLayout();
            // 
            // listViewPatches
            // 
            listViewPatches.BackColor = Color.FromArgb(84, 84, 84);
            listViewPatches.Columns.AddRange(new ColumnHeader[] { columnHeaderPatchNo, columnHeaderTimbreGroup, columnHeaderTimbreName, columnHeaderKeyShift, columnHeaderFineTune, columnHeaderBendRange, columnHeaderReverb, columnHeaderAssignMode });
            listViewPatches.ForeColor = SystemColors.Control;
            listViewPatches.FullRowSelect = true;
            listViewPatches.GridLines = true;
            listViewPatches.Items.AddRange(new ListViewItem[] { listViewItem2 });
            listViewPatches.Location = new Point(14, 305);
            listViewPatches.MinimumSize = new Size(0, 28);
            listViewPatches.MultiSelect = false;
            listViewPatches.Name = "listViewPatches";
            listViewPatches.Size = new Size(499, 591);
            listViewPatches.TabIndex = 1;
            listViewPatches.TileSize = new Size(50, 20);
            listViewPatches.UseCompatibleStateImageBehavior = false;
            listViewPatches.View = View.Details;
            listViewPatches.SelectedIndexChanged += listViewPatches_SelectedIndexChanged;
            // 
            // columnHeaderPatchNo
            // 
            columnHeaderPatchNo.Text = "Patch";
            columnHeaderPatchNo.Width = 42;
            // 
            // columnHeaderTimbreGroup
            // 
            columnHeaderTimbreGroup.Text = "Timbre Group";
            columnHeaderTimbreGroup.Width = 86;
            // 
            // columnHeaderTimbreName
            // 
            columnHeaderTimbreName.Text = "Timbre Name";
            columnHeaderTimbreName.Width = 90;
            // 
            // columnHeaderKeyShift
            // 
            columnHeaderKeyShift.Text = "Key";
            columnHeaderKeyShift.Width = 40;
            // 
            // columnHeaderFineTune
            // 
            columnHeaderFineTune.Text = "Fine";
            columnHeaderFineTune.Width = 40;
            // 
            // columnHeaderBendRange
            // 
            columnHeaderBendRange.Text = "Bend";
            columnHeaderBendRange.Width = 40;
            // 
            // columnHeaderReverb
            // 
            columnHeaderReverb.Text = "Reverb";
            columnHeaderReverb.Width = 48;
            // 
            // columnHeaderAssignMode
            // 
            columnHeaderAssignMode.Text = "A.Mode";
            columnHeaderAssignMode.Width = 54;
            // 
            // comboBoxTimbreGroup
            // 
            comboBoxTimbreGroup.BackColor = SystemColors.Window;
            comboBoxTimbreGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTimbreGroup.FormattingEnabled = true;
            comboBoxTimbreGroup.Items.AddRange(new object[] { "Preset A", "Preset B", "Memory", "Rhythm" });
            comboBoxTimbreGroup.Location = new Point(92, 113);
            comboBoxTimbreGroup.Name = "comboBoxTimbreGroup";
            comboBoxTimbreGroup.Size = new Size(121, 23);
            comboBoxTimbreGroup.TabIndex = 3;
            comboBoxTimbreGroup.SelectionChangeCommitted += comboBoxTimbreGroup_SelectionChangeCommitted;
            // 
            // numericUpDownPatchNo
            // 
            numericUpDownPatchNo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            numericUpDownPatchNo.Location = new Point(385, 39);
            numericUpDownPatchNo.Maximum = new decimal(new int[] { 128, 0, 0, 0 });
            numericUpDownPatchNo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownPatchNo.Name = "numericUpDownPatchNo";
            numericUpDownPatchNo.Size = new Size(56, 29);
            numericUpDownPatchNo.TabIndex = 4;
            numericUpDownPatchNo.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownPatchNo.ValueChanged += numericUpDownPatchNo_ValueChanged;
            // 
            // comboBoxTimbreName
            // 
            comboBoxTimbreName.FormattingEnabled = true;
            comboBoxTimbreName.Location = new Point(219, 113);
            comboBoxTimbreName.Name = "comboBoxTimbreName";
            comboBoxTimbreName.Size = new Size(125, 23);
            comboBoxTimbreName.TabIndex = 5;
            comboBoxTimbreName.SelectionChangeCommitted += comboBoxTimbreName_SelectionChangeCommitted;
            // 
            // labelPatchNo
            // 
            labelPatchNo.AutoSize = true;
            labelPatchNo.ForeColor = SystemColors.Control;
            labelPatchNo.Location = new Point(320, 46);
            labelPatchNo.Name = "labelPatchNo";
            labelPatchNo.Size = new Size(59, 15);
            labelPatchNo.TabIndex = 6;
            labelPatchNo.Text = "Patch No.";
            // 
            // labelTimbreGroup
            // 
            labelTimbreGroup.AutoSize = true;
            labelTimbreGroup.ForeColor = SystemColors.Control;
            labelTimbreGroup.Location = new Point(92, 95);
            labelTimbreGroup.Name = "labelTimbreGroup";
            labelTimbreGroup.Size = new Size(80, 15);
            labelTimbreGroup.TabIndex = 7;
            labelTimbreGroup.Text = "Timbre Group";
            // 
            // labelTimbreName
            // 
            labelTimbreName.AutoSize = true;
            labelTimbreName.ForeColor = SystemColors.Control;
            labelTimbreName.Location = new Point(219, 95);
            labelTimbreName.Name = "labelTimbreName";
            labelTimbreName.Size = new Size(79, 15);
            labelTimbreName.TabIndex = 8;
            labelTimbreName.Text = "Timbre Name";
            // 
            // trackBarKeyShift
            // 
            trackBarKeyShift.LargeChange = 12;
            trackBarKeyShift.Location = new Point(102, 177);
            trackBarKeyShift.Maximum = 24;
            trackBarKeyShift.Minimum = -24;
            trackBarKeyShift.Name = "trackBarKeyShift";
            trackBarKeyShift.Orientation = Orientation.Vertical;
            trackBarKeyShift.Size = new Size(45, 104);
            trackBarKeyShift.TabIndex = 9;
            trackBarKeyShift.TickFrequency = 2;
            trackBarKeyShift.TickStyle = TickStyle.Both;
            trackBarKeyShift.ValueChanged += trackBarKeyShift_ValueChanged;
            // 
            // trackBarFineTune
            // 
            trackBarFineTune.Location = new Point(165, 177);
            trackBarFineTune.Maximum = 50;
            trackBarFineTune.Minimum = -50;
            trackBarFineTune.Name = "trackBarFineTune";
            trackBarFineTune.Orientation = Orientation.Vertical;
            trackBarFineTune.Size = new Size(45, 104);
            trackBarFineTune.TabIndex = 10;
            trackBarFineTune.TickFrequency = 10;
            trackBarFineTune.TickStyle = TickStyle.Both;
            trackBarFineTune.ValueChanged += trackBarFineTune_ValueChanged;
            // 
            // trackBarBenderRange
            // 
            trackBarBenderRange.LargeChange = 2;
            trackBarBenderRange.Location = new Point(230, 177);
            trackBarBenderRange.Maximum = 24;
            trackBarBenderRange.Name = "trackBarBenderRange";
            trackBarBenderRange.Orientation = Orientation.Vertical;
            trackBarBenderRange.Size = new Size(45, 104);
            trackBarBenderRange.TabIndex = 11;
            trackBarBenderRange.TickFrequency = 2;
            trackBarBenderRange.TickStyle = TickStyle.Both;
            trackBarBenderRange.Value = 12;
            trackBarBenderRange.ValueChanged += trackBarBenderRange_ValueChanged;
            // 
            // radioButtonReverbOn
            // 
            radioButtonReverbOn.AutoSize = true;
            radioButtonReverbOn.ForeColor = SystemColors.Control;
            radioButtonReverbOn.Location = new Point(314, 177);
            radioButtonReverbOn.Name = "radioButtonReverbOn";
            radioButtonReverbOn.Size = new Size(41, 19);
            radioButtonReverbOn.TabIndex = 14;
            radioButtonReverbOn.TabStop = true;
            radioButtonReverbOn.Text = "On";
            radioButtonReverbOn.UseVisualStyleBackColor = true;
            radioButtonReverbOn.CheckedChanged += radioButtonReverbOn_CheckedChanged;
            // 
            // radioButtonReverbOff
            // 
            radioButtonReverbOff.AutoSize = true;
            radioButtonReverbOff.ForeColor = SystemColors.Control;
            radioButtonReverbOff.Location = new Point(314, 202);
            radioButtonReverbOff.Name = "radioButtonReverbOff";
            radioButtonReverbOff.Size = new Size(42, 19);
            radioButtonReverbOff.TabIndex = 15;
            radioButtonReverbOff.TabStop = true;
            radioButtonReverbOff.Text = "Off";
            radioButtonReverbOff.UseVisualStyleBackColor = true;
            // 
            // labelKeyShift
            // 
            labelKeyShift.AutoSize = true;
            labelKeyShift.ForeColor = SystemColors.Control;
            labelKeyShift.Location = new Point(96, 159);
            labelKeyShift.Name = "labelKeyShift";
            labelKeyShift.Size = new Size(53, 15);
            labelKeyShift.TabIndex = 16;
            labelKeyShift.Text = "Key Shift";
            // 
            // labelFineTune
            // 
            labelFineTune.AutoSize = true;
            labelFineTune.ForeColor = SystemColors.Control;
            labelFineTune.Location = new Point(155, 159);
            labelFineTune.Name = "labelFineTune";
            labelFineTune.Size = new Size(58, 15);
            labelFineTune.TabIndex = 17;
            labelFineTune.Text = "Fine Tune";
            // 
            // labelBendRange
            // 
            labelBendRange.AutoSize = true;
            labelBendRange.ForeColor = SystemColors.Control;
            labelBendRange.Location = new Point(219, 159);
            labelBendRange.Name = "labelBendRange";
            labelBendRange.Size = new Size(70, 15);
            labelBendRange.TabIndex = 18;
            labelBendRange.Text = "Bend Range";
            // 
            // labelReverb
            // 
            labelReverb.AutoSize = true;
            labelReverb.ForeColor = SystemColors.Control;
            labelReverb.Location = new Point(312, 159);
            labelReverb.Name = "labelReverb";
            labelReverb.Size = new Size(43, 15);
            labelReverb.TabIndex = 21;
            labelReverb.Text = "Reverb";
            // 
            // comboBoxAssignMode
            // 
            comboBoxAssignMode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAssignMode.FormattingEnabled = true;
            comboBoxAssignMode.Items.AddRange(new object[] { "1: Single Assign", "2: Multi Assign", "3: First In, First Out", "4: First In, Last Out" });
            comboBoxAssignMode.Location = new Point(312, 256);
            comboBoxAssignMode.Name = "comboBoxAssignMode";
            comboBoxAssignMode.Size = new Size(142, 23);
            comboBoxAssignMode.TabIndex = 22;
            comboBoxAssignMode.SelectedValueChanged += comboBoxAssignMode_SelectedValueChanged;
            // 
            // labelAssignMode
            // 
            labelAssignMode.AutoSize = true;
            labelAssignMode.ForeColor = SystemColors.Control;
            labelAssignMode.Location = new Point(312, 237);
            labelAssignMode.Name = "labelAssignMode";
            labelAssignMode.Size = new Size(76, 15);
            labelAssignMode.TabIndex = 23;
            labelAssignMode.Text = "Assign Mode";
            // 
            // labelUnitNoWarning
            // 
            labelUnitNoWarning.AutoSize = true;
            labelUnitNoWarning.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelUnitNoWarning.ForeColor = Color.Yellow;
            labelUnitNoWarning.Location = new Point(15, 74);
            labelUnitNoWarning.Name = "labelUnitNoWarning";
            labelUnitNoWarning.Size = new Size(439, 15);
            labelUnitNoWarning.TabIndex = 62;
            labelUnitNoWarning.Text = "⚠ Unit No. set to non-default value! To revert, edit/delete MT32Edit.ini and reload.";
            toolTipParameterValue.SetToolTip(labelUnitNoWarning, resources.GetString("labelUnitNoWarning.ToolTip"));
            labelUnitNoWarning.Visible = false;
            // 
            // labelHeading
            // 
            labelHeading.AutoSize = true;
            labelHeading.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelHeading.ForeColor = SystemColors.ActiveCaption;
            labelHeading.Location = new Point(14, 41);
            labelHeading.Name = "labelHeading";
            labelHeading.Size = new Size(98, 21);
            labelHeading.TabIndex = 31;
            labelHeading.Text = "Patch Editor";
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 500;
            timer.Tick += timer_Tick;
            // 
            // buttonEditPreset
            // 
            buttonEditPreset.BackColor = Color.FromArgb(224, 224, 224);
            buttonEditPreset.Location = new Point(350, 113);
            buttonEditPreset.Name = "buttonEditPreset";
            buttonEditPreset.Size = new Size(134, 23);
            buttonEditPreset.TabIndex = 32;
            buttonEditPreset.Text = "Edit Preset Timbre";
            buttonEditPreset.UseVisualStyleBackColor = false;
            buttonEditPreset.Click += buttonEditPreset_Click;
            // 
            // labelNoChannelAssigned
            // 
            labelNoChannelAssigned.AutoSize = true;
            labelNoChannelAssigned.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelNoChannelAssigned.ForeColor = Color.Yellow;
            labelNoChannelAssigned.Location = new Point(48, 284);
            labelNoChannelAssigned.Name = "labelNoChannelAssigned";
            labelNoChannelAssigned.Size = new Size(416, 15);
            labelNoChannelAssigned.TabIndex = 61;
            labelNoChannelAssigned.Text = "Part 1 muted- no MIDI channel assigned. Assign a channel in System Settings.";
            labelNoChannelAssigned.Visible = false;
            // 
            // FormPatchEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(540, 960);
            ControlBox = false;
            Controls.Add(labelUnitNoWarning);
            Controls.Add(labelNoChannelAssigned);
            Controls.Add(buttonEditPreset);
            Controls.Add(labelHeading);
            Controls.Add(labelAssignMode);
            Controls.Add(comboBoxAssignMode);
            Controls.Add(labelReverb);
            Controls.Add(labelBendRange);
            Controls.Add(labelFineTune);
            Controls.Add(labelKeyShift);
            Controls.Add(radioButtonReverbOff);
            Controls.Add(radioButtonReverbOn);
            Controls.Add(trackBarBenderRange);
            Controls.Add(trackBarFineTune);
            Controls.Add(trackBarKeyShift);
            Controls.Add(labelTimbreName);
            Controls.Add(labelTimbreGroup);
            Controls.Add(labelPatchNo);
            Controls.Add(comboBoxTimbreName);
            Controls.Add(numericUpDownPatchNo);
            Controls.Add(comboBoxTimbreGroup);
            Controls.Add(listViewPatches);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(350, 200);
            Name = "FormPatchEditor";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "MT-32 Patch Editor";
            Activated += FormPatchEditor_Activated;
            FormClosing += FormPatchEditor_FormClosing;
            Leave += FormPatchEditor_Leave;
            Resize += FormPatchEditor_Resize;
            ((System.ComponentModel.ISupportInitialize)numericUpDownPatchNo).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarKeyShift).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarFineTune).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarBenderRange).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListView listViewPatches;
        private ColumnHeader columnHeaderPatchNo;
        private ColumnHeader columnHeaderTimbreGroup;
        private ColumnHeader columnHeaderTimbreName;
        private ComboBox comboBoxTimbreGroup;
        private NumericUpDown numericUpDownPatchNo;
        private ComboBox comboBoxTimbreName;
        private Label labelPatchNo;
        private Label labelTimbreGroup;
        private Label labelTimbreName;
        private TrackBar trackBarKeyShift;
        private TrackBar trackBarFineTune;
        private TrackBar trackBarBenderRange;
        private RadioButton radioButtonReverbOn;
        private RadioButton radioButtonReverbOff;
        private Label labelKeyShift;
        private Label labelFineTune;
        private Label labelBendRange;
        private Label labelReverb;
        private ComboBox comboBoxAssignMode;
        private Label labelAssignMode;
        private ColumnHeader columnHeaderKeyShift;
        private ColumnHeader columnHeaderFineTune;
        private ColumnHeader columnHeaderBendRange;
        private ColumnHeader columnHeaderAssignMode;
        private ColumnHeader columnHeaderReverb;
        private ToolTip toolTipParameterValue;
        private Label labelHeading;
        private System.Windows.Forms.Timer timer;
        private Button buttonEditPreset;
        private Label labelNoChannelAssigned;
        private Label labelUnitNoWarning;
    }
}
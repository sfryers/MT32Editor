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
            ListViewItem listViewItem1 = new ListViewItem("");
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            trackBarKeyShift = new TrackBar();
            trackBarFineTune = new TrackBar();
            trackBarBenderRange = new TrackBar();
            radioButtonReverbOn = new RadioButton();
            radioButtonReverbOff = new RadioButton();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label9 = new Label();
            comboBoxAssignMode = new ComboBox();
            label10 = new Label();
            toolTipParameterValue = new ToolTip(components);
            labelHeading = new Label();
            timer = new System.Windows.Forms.Timer(components);
            buttonEditPreset = new Button();
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
            listViewPatches.Items.AddRange(new ListViewItem[] { listViewItem1 });
            listViewPatches.Location = new Point(42, 277);
            listViewPatches.MultiSelect = false;
            listViewPatches.Name = "listViewPatches";
            listViewPatches.Size = new Size(462, 655);
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
            comboBoxTimbreGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTimbreGroup.FormattingEnabled = true;
            comboBoxTimbreGroup.Items.AddRange(new object[] { "Preset A", "Preset B", "Memory", "Rhythm" });
            comboBoxTimbreGroup.Location = new Point(106, 86);
            comboBoxTimbreGroup.Name = "comboBoxTimbreGroup";
            comboBoxTimbreGroup.Size = new Size(121, 23);
            comboBoxTimbreGroup.TabIndex = 3;
            comboBoxTimbreGroup.SelectionChangeCommitted += comboBoxTimbreGroup_SelectionChangeCommitted;
            // 
            // numericUpDownPatchNo
            // 
            numericUpDownPatchNo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            numericUpDownPatchNo.Location = new Point(389, 16);
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
            comboBoxTimbreName.Location = new Point(233, 86);
            comboBoxTimbreName.Name = "comboBoxTimbreName";
            comboBoxTimbreName.Size = new Size(99, 23);
            comboBoxTimbreName.TabIndex = 5;
            comboBoxTimbreName.SelectionChangeCommitted += comboBoxTimbreName_SelectionChangeCommitted;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(324, 23);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 6;
            label1.Text = "Patch No.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(106, 68);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 7;
            label2.Text = "Timbre Group";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(233, 68);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 8;
            label3.Text = "Timbre Name";
            // 
            // trackBarKeyShift
            // 
            trackBarKeyShift.LargeChange = 12;
            trackBarKeyShift.Location = new Point(116, 150);
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
            trackBarFineTune.Location = new Point(179, 150);
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
            trackBarBenderRange.Location = new Point(244, 150);
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
            radioButtonReverbOn.Location = new Point(328, 150);
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
            radioButtonReverbOff.Location = new Point(328, 175);
            radioButtonReverbOff.Name = "radioButtonReverbOff";
            radioButtonReverbOff.Size = new Size(42, 19);
            radioButtonReverbOff.TabIndex = 15;
            radioButtonReverbOff.TabStop = true;
            radioButtonReverbOff.Text = "Off";
            radioButtonReverbOff.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(110, 132);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 16;
            label4.Text = "Key Shift";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(169, 132);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 17;
            label5.Text = "Fine Tune";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(233, 132);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 18;
            label6.Text = "Bend Range";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = SystemColors.Control;
            label9.Location = new Point(326, 132);
            label9.Name = "label9";
            label9.Size = new Size(43, 15);
            label9.TabIndex = 21;
            label9.Text = "Reverb";
            // 
            // comboBoxAssignMode
            // 
            comboBoxAssignMode.FormattingEnabled = true;
            comboBoxAssignMode.Items.AddRange(new object[] { "1: Single Assign", "2: Multi Assign", "3: First In, First Out", "4: First In, Last Out" });
            comboBoxAssignMode.Location = new Point(326, 229);
            comboBoxAssignMode.Name = "comboBoxAssignMode";
            comboBoxAssignMode.Size = new Size(129, 23);
            comboBoxAssignMode.TabIndex = 22;
            comboBoxAssignMode.SelectedValueChanged += comboBoxAssignMode_SelectedValueChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = SystemColors.Control;
            label10.Location = new Point(326, 210);
            label10.Name = "label10";
            label10.Size = new Size(76, 15);
            label10.TabIndex = 23;
            label10.Text = "Assign Mode";
            // 
            // labelHeading
            // 
            labelHeading.AutoSize = true;
            labelHeading.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelHeading.ForeColor = SystemColors.ActiveCaption;
            labelHeading.Location = new Point(25, 9);
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
            buttonEditPreset.Location = new Point(340, 86);
            buttonEditPreset.Name = "buttonEditPreset";
            buttonEditPreset.Size = new Size(105, 23);
            buttonEditPreset.TabIndex = 32;
            buttonEditPreset.Text = "Edit Preset Timbre";
            buttonEditPreset.UseVisualStyleBackColor = true;
            buttonEditPreset.Click += buttonEditPreset_Click;
            // 
            // FormPatchEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(540, 960);
            ControlBox = false;
            Controls.Add(buttonEditPreset);
            Controls.Add(labelHeading);
            Controls.Add(label10);
            Controls.Add(comboBoxAssignMode);
            Controls.Add(label9);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(radioButtonReverbOff);
            Controls.Add(radioButtonReverbOn);
            Controls.Add(trackBarBenderRange);
            Controls.Add(trackBarFineTune);
            Controls.Add(trackBarKeyShift);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxTimbreName);
            Controls.Add(numericUpDownPatchNo);
            Controls.Add(comboBoxTimbreGroup);
            Controls.Add(listViewPatches);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MaximumSize = new Size(540, 2160);
            MinimizeBox = false;
            MinimumSize = new Size(540, 423);
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
        private Label label1;
        private Label label2;
        private Label label3;
        private TrackBar trackBarKeyShift;
        private TrackBar trackBarFineTune;
        private TrackBar trackBarBenderRange;
        private RadioButton radioButtonReverbOn;
        private RadioButton radioButtonReverbOff;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label9;
        private ComboBox comboBoxAssignMode;
        private Label label10;
        private ColumnHeader columnHeaderKeyShift;
        private ColumnHeader columnHeaderFineTune;
        private ColumnHeader columnHeaderBendRange;
        private ColumnHeader columnHeaderAssignMode;
        private ColumnHeader columnHeaderReverb;
        private ToolTip toolTipParameterValue;
        private Label labelHeading;
        private System.Windows.Forms.Timer timer;
        private Button buttonEditPreset;
    }
}
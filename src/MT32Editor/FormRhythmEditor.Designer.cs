namespace MT32Edit
{
    partial class FormRhythmEditor
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
            ListViewItem listViewItem1 = new ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRhythmEditor));
            labelReverb = new Label();
            labelPan = new Label();
            labelLevel = new Label();
            radioButtonReverbOff = new RadioButton();
            radioButtonReverbOn = new RadioButton();
            trackBarPanPot = new TrackBar();
            trackBarLevel = new TrackBar();
            labelTimbreName = new Label();
            labelTimbreGroup = new Label();
            labelKeyNo = new Label();
            comboBoxTimbreName = new ComboBox();
            numericUpDownKeyNo = new NumericUpDown();
            comboBoxTimbreGroup = new ComboBox();
            listViewRhythmBank = new ListView();
            columnHeaderKeyNo = new ColumnHeader();
            columnHeaderNote = new ColumnHeader();
            columnHeaderTimbreGroup = new ColumnHeader();
            columnHeaderTimbreName = new ColumnHeader();
            columnHeaderReverb = new ColumnHeader();
            columnHeaderPanPot = new ColumnHeader();
            columnHeaderLevel = new ColumnHeader();
            toolTipParameterValue = new ToolTip(components);
            buttonPlayNote = new Button();
            labelUnitNoWarning = new Label();
            labelHeading = new Label();
            timer = new System.Windows.Forms.Timer(components);
            labelNoChannelAssigned = new Label();
            labelMT32ModeWarning1 = new Label();
            labelMT32ModeWarning2 = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBarPanPot).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarLevel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownKeyNo).BeginInit();
            SuspendLayout();
            // 
            // labelReverb
            // 
            labelReverb.AutoSize = true;
            labelReverb.ForeColor = SystemColors.Control;
            labelReverb.Location = new Point(174, 159);
            labelReverb.Name = "labelReverb";
            labelReverb.Size = new Size(43, 15);
            labelReverb.TabIndex = 47;
            labelReverb.Text = "Reverb";
            // 
            // labelPan
            // 
            labelPan.AutoSize = true;
            labelPan.ForeColor = SystemColors.Control;
            labelPan.Location = new Point(246, 206);
            labelPan.Name = "labelPan";
            labelPan.Size = new Size(94, 15);
            labelPan.TabIndex = 45;
            labelPan.Text = "L         Pan         R";
            // 
            // labelLevel
            // 
            labelLevel.AutoSize = true;
            labelLevel.ForeColor = SystemColors.Control;
            labelLevel.Location = new Point(119, 159);
            labelLevel.Name = "labelLevel";
            labelLevel.Size = new Size(34, 15);
            labelLevel.TabIndex = 44;
            labelLevel.Text = "Level";
            // 
            // radioButtonReverbOff
            // 
            radioButtonReverbOff.AutoSize = true;
            radioButtonReverbOff.ForeColor = SystemColors.Control;
            radioButtonReverbOff.Location = new Point(176, 202);
            radioButtonReverbOff.Name = "radioButtonReverbOff";
            radioButtonReverbOff.Size = new Size(42, 19);
            radioButtonReverbOff.TabIndex = 43;
            radioButtonReverbOff.TabStop = true;
            radioButtonReverbOff.Text = "Off";
            radioButtonReverbOff.UseVisualStyleBackColor = true;
            // 
            // radioButtonReverbOn
            // 
            radioButtonReverbOn.AutoSize = true;
            radioButtonReverbOn.ForeColor = SystemColors.Control;
            radioButtonReverbOn.Location = new Point(176, 177);
            radioButtonReverbOn.Name = "radioButtonReverbOn";
            radioButtonReverbOn.Size = new Size(41, 19);
            radioButtonReverbOn.TabIndex = 42;
            radioButtonReverbOn.TabStop = true;
            radioButtonReverbOn.Text = "On";
            radioButtonReverbOn.UseVisualStyleBackColor = true;
            radioButtonReverbOn.CheckedChanged += radioButtonReverbOn_CheckedChanged;
            // 
            // trackBarPanPot
            // 
            trackBarPanPot.LargeChange = 2;
            trackBarPanPot.Location = new Point(240, 159);
            trackBarPanPot.Maximum = 7;
            trackBarPanPot.Minimum = -7;
            trackBarPanPot.Name = "trackBarPanPot";
            trackBarPanPot.Size = new Size(104, 45);
            trackBarPanPot.TabIndex = 40;
            trackBarPanPot.TickStyle = TickStyle.Both;
            trackBarPanPot.ValueChanged += trackBarPanPot_ValueChanged;
            // 
            // trackBarLevel
            // 
            trackBarLevel.LargeChange = 10;
            trackBarLevel.Location = new Point(114, 175);
            trackBarLevel.Maximum = 100;
            trackBarLevel.Name = "trackBarLevel";
            trackBarLevel.Orientation = Orientation.Vertical;
            trackBarLevel.Size = new Size(45, 104);
            trackBarLevel.TabIndex = 39;
            trackBarLevel.TickFrequency = 10;
            trackBarLevel.TickStyle = TickStyle.Both;
            trackBarLevel.Value = 75;
            trackBarLevel.ValueChanged += trackBarLevel_ValueChanged;
            // 
            // labelTimbreName
            // 
            labelTimbreName.AutoSize = true;
            labelTimbreName.ForeColor = SystemColors.Control;
            labelTimbreName.Location = new Point(219, 95);
            labelTimbreName.Name = "labelTimbreName";
            labelTimbreName.Size = new Size(79, 15);
            labelTimbreName.TabIndex = 38;
            labelTimbreName.Text = "Timbre Name";
            // 
            // labelTimbreGroup
            // 
            labelTimbreGroup.AutoSize = true;
            labelTimbreGroup.ForeColor = SystemColors.Control;
            labelTimbreGroup.Location = new Point(92, 95);
            labelTimbreGroup.Name = "labelTimbreGroup";
            labelTimbreGroup.Size = new Size(80, 15);
            labelTimbreGroup.TabIndex = 37;
            labelTimbreGroup.Text = "Timbre Group";
            // 
            // labelKeyNo
            // 
            labelKeyNo.AutoSize = true;
            labelKeyNo.ForeColor = SystemColors.Control;
            labelKeyNo.Location = new Point(328, 46);
            labelKeyNo.Name = "labelKeyNo";
            labelKeyNo.Size = new Size(48, 15);
            labelKeyNo.TabIndex = 36;
            labelKeyNo.Text = "Key No.";
            // 
            // comboBoxTimbreName
            // 
            comboBoxTimbreName.DrawMode = DrawMode.OwnerDrawFixed;
            comboBoxTimbreName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTimbreName.FormattingEnabled = true;
            comboBoxTimbreName.Location = new Point(219, 113);
            comboBoxTimbreName.Name = "comboBoxTimbreName";
            comboBoxTimbreName.Size = new Size(125, 24);
            comboBoxTimbreName.TabIndex = 35;
            comboBoxTimbreName.DrawItem += comboBoxTimbreName_DrawItem;
            comboBoxTimbreName.SelectionChangeCommitted += comboBoxTimbreName_SelectionChangeCommitted;
            // 
            // numericUpDownKeyNo
            // 
            numericUpDownKeyNo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            numericUpDownKeyNo.Location = new Point(385, 39);
            numericUpDownKeyNo.Maximum = new decimal(new int[] { 108, 0, 0, 0 });
            numericUpDownKeyNo.Minimum = new decimal(new int[] { 24, 0, 0, 0 });
            numericUpDownKeyNo.Name = "numericUpDownKeyNo";
            numericUpDownKeyNo.Size = new Size(56, 29);
            numericUpDownKeyNo.TabIndex = 34;
            numericUpDownKeyNo.Value = new decimal(new int[] { 24, 0, 0, 0 });
            numericUpDownKeyNo.ValueChanged += numericUpDownKeyNo_ValueChanged;
            // 
            // comboBoxTimbreGroup
            // 
            comboBoxTimbreGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTimbreGroup.FormattingEnabled = true;
            comboBoxTimbreGroup.Items.AddRange(new object[] { "Memory", "Rhythm" });
            comboBoxTimbreGroup.Location = new Point(92, 113);
            comboBoxTimbreGroup.Name = "comboBoxTimbreGroup";
            comboBoxTimbreGroup.Size = new Size(121, 23);
            comboBoxTimbreGroup.TabIndex = 33;
            comboBoxTimbreGroup.SelectionChangeCommitted += comboBoxTimbreGroup_SelectionChangeCommitted;
            // 
            // listViewRhythmBank
            // 
            listViewRhythmBank.BackColor = Color.FromArgb(84, 84, 84);
            listViewRhythmBank.Columns.AddRange(new ColumnHeader[] { columnHeaderKeyNo, columnHeaderNote, columnHeaderTimbreGroup, columnHeaderTimbreName, columnHeaderReverb, columnHeaderPanPot, columnHeaderLevel });
            listViewRhythmBank.ForeColor = SystemColors.Control;
            listViewRhythmBank.FullRowSelect = true;
            listViewRhythmBank.GridLines = true;
            listViewRhythmBank.Items.AddRange(new ListViewItem[] { listViewItem1 });
            listViewRhythmBank.Location = new Point(14, 305);
            listViewRhythmBank.MinimumSize = new Size(0, 28);
            listViewRhythmBank.MultiSelect = false;
            listViewRhythmBank.Name = "listViewRhythmBank";
            listViewRhythmBank.Size = new Size(495, 591);
            listViewRhythmBank.TabIndex = 32;
            listViewRhythmBank.TileSize = new Size(50, 20);
            listViewRhythmBank.UseCompatibleStateImageBehavior = false;
            listViewRhythmBank.View = View.Details;
            listViewRhythmBank.SelectedIndexChanged += listViewRhythmBank_SelectedIndexChanged;
            // 
            // columnHeaderKeyNo
            // 
            columnHeaderKeyNo.Text = "Key#";
            columnHeaderKeyNo.Width = 42;
            // 
            // columnHeaderNote
            // 
            columnHeaderNote.Text = "Note";
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
            // columnHeaderReverb
            // 
            columnHeaderReverb.Text = "Reverb";
            columnHeaderReverb.Width = 48;
            // 
            // columnHeaderPanPot
            // 
            columnHeaderPanPot.Text = "Pan";
            columnHeaderPanPot.Width = 38;
            // 
            // columnHeaderLevel
            // 
            columnHeaderLevel.Text = "Level";
            columnHeaderLevel.Width = 42;
            // 
            // buttonPlayNote
            // 
            buttonPlayNote.Image = (Image)resources.GetObject("buttonPlayNote.Image");
            buttonPlayNote.Location = new Point(14, 269);
            buttonPlayNote.Name = "buttonPlayNote";
            buttonPlayNote.Size = new Size(41, 30);
            buttonPlayNote.TabIndex = 58;
            toolTipParameterValue.SetToolTip(buttonPlayNote, "Play selected sound on device");
            buttonPlayNote.UseVisualStyleBackColor = true;
            buttonPlayNote.MouseDown += buttonPlayNote_MouseDown;
            buttonPlayNote.MouseUp += buttonPlayNote_MouseUp;
            // 
            // labelUnitNoWarning
            // 
            labelUnitNoWarning.AutoSize = true;
            labelUnitNoWarning.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelUnitNoWarning.ForeColor = Color.Yellow;
            labelUnitNoWarning.Location = new Point(15, 74);
            labelUnitNoWarning.Name = "labelUnitNoWarning";
            labelUnitNoWarning.Size = new Size(439, 15);
            labelUnitNoWarning.TabIndex = 63;
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
            labelHeading.Size = new Size(153, 21);
            labelHeading.TabIndex = 59;
            labelHeading.Text = "Rhythm Bank Editor";
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 500;
            timer.Tick += timer_Tick;
            // 
            // labelNoChannelAssigned
            // 
            labelNoChannelAssigned.AutoSize = true;
            labelNoChannelAssigned.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelNoChannelAssigned.ForeColor = Color.Yellow;
            labelNoChannelAssigned.Location = new Point(58, 277);
            labelNoChannelAssigned.Name = "labelNoChannelAssigned";
            labelNoChannelAssigned.Size = new Size(460, 15);
            labelNoChannelAssigned.TabIndex = 60;
            labelNoChannelAssigned.Text = "Rhythm part muted- no MIDI channel assigned. Open System Area Settings to resolve.";
            labelNoChannelAssigned.Visible = false;
            // 
            // labelMT32ModeWarning1
            // 
            labelMT32ModeWarning1.AutoSize = true;
            labelMT32ModeWarning1.ForeColor = Color.IndianRed;
            labelMT32ModeWarning1.Location = new Point(170, 230);
            labelMT32ModeWarning1.Name = "labelMT32ModeWarning1";
            labelMT32ModeWarning1.Size = new Size(313, 15);
            labelMT32ModeWarning1.TabIndex = 64;
            labelMT32ModeWarning1.Text = "MT-32 mode selected: Unsupported timbres shown in red.";
            // 
            // labelMT32ModeWarning2
            // 
            labelMT32ModeWarning2.AutoSize = true;
            labelMT32ModeWarning2.ForeColor = Color.Gray;
            labelMT32ModeWarning2.Location = new Point(171, 248);
            labelMT32ModeWarning2.Name = "labelMT32ModeWarning2";
            labelMT32ModeWarning2.Size = new Size(232, 15);
            labelMT32ModeWarning2.TabIndex = 65;
            labelMT32ModeWarning2.Text = "Unsupported rhythm banks shown in grey.";
            // 
            // FormRhythmEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(526, 960);
            ControlBox = false;
            Controls.Add(labelMT32ModeWarning2);
            Controls.Add(labelMT32ModeWarning1);
            Controls.Add(labelUnitNoWarning);
            Controls.Add(labelNoChannelAssigned);
            Controls.Add(labelHeading);
            Controls.Add(buttonPlayNote);
            Controls.Add(labelReverb);
            Controls.Add(labelPan);
            Controls.Add(labelLevel);
            Controls.Add(radioButtonReverbOff);
            Controls.Add(radioButtonReverbOn);
            Controls.Add(trackBarPanPot);
            Controls.Add(trackBarLevel);
            Controls.Add(labelTimbreName);
            Controls.Add(labelTimbreGroup);
            Controls.Add(labelKeyNo);
            Controls.Add(comboBoxTimbreName);
            Controls.Add(numericUpDownKeyNo);
            Controls.Add(comboBoxTimbreGroup);
            Controls.Add(listViewRhythmBank);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(526, 200);
            Name = "FormRhythmEditor";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "MT-32 Rhythm Bank Editor";
            Activated += FormRhythmEditor_Activated;
            FormClosing += FormRhythmEditor_FormClosing;
            Leave += FormRhythmEditor_Leave;
            Resize += FormRhythmEditor_Resize;
            ((System.ComponentModel.ISupportInitialize)trackBarPanPot).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarLevel).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownKeyNo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelReverb;
        private Label labelPan;
        private Label labelLevel;
        private RadioButton radioButtonReverbOff;
        private RadioButton radioButtonReverbOn;
        private TrackBar trackBarPanPot;
        private TrackBar trackBarLevel;
        private Label labelTimbreName;
        private Label labelTimbreGroup;
        private Label labelKeyNo;
        private ComboBox comboBoxTimbreName;
        private NumericUpDown numericUpDownKeyNo;
        private ComboBox comboBoxTimbreGroup;
        private ListView listViewRhythmBank;
        private ColumnHeader columnHeaderKeyNo;
        private ColumnHeader columnHeaderTimbreGroup;
        private ColumnHeader columnHeaderTimbreName;
        private ColumnHeader columnHeaderNote;
        private ColumnHeader columnHeaderReverb;
        private ColumnHeader columnHeaderPanPot;
        private ColumnHeader columnHeaderLevel;
        private ToolTip toolTipParameterValue;
        private Button buttonPlayNote;
        private Label labelHeading;
        private System.Windows.Forms.Timer timer;
        private Label labelNoChannelAssigned;
        private Label labelUnitNoWarning;
        private Label labelMT32ModeWarning1;
        private Label labelMT32ModeWarning2;
    }
}
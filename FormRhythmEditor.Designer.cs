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
            label9 = new Label();
            label5 = new Label();
            label4 = new Label();
            radioButtonReverbOff = new RadioButton();
            radioButtonReverbOn = new RadioButton();
            trackBarPanPot = new TrackBar();
            trackBarLevel = new TrackBar();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
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
            labelHeading = new Label();
            timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)trackBarPanPot).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarLevel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownKeyNo).BeginInit();
            SuspendLayout();
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = SystemColors.Control;
            label9.Location = new Point(174, 159);
            label9.Name = "label9";
            label9.Size = new Size(43, 15);
            label9.TabIndex = 47;
            label9.Text = "Reverb";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(240, 207);
            label5.Name = "label5";
            label5.Size = new Size(94, 15);
            label5.TabIndex = 45;
            label5.Text = "L         Pan         R";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(119, 159);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 44;
            label4.Text = "Level";
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
            trackBarPanPot.Size = new Size(94, 45);
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
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(219, 95);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 38;
            label3.Text = "Timbre Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(92, 95);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 37;
            label2.Text = "Timbre Group";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(328, 46);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 36;
            label1.Text = "Key No.";
            // 
            // comboBoxTimbreName
            // 
            comboBoxTimbreName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTimbreName.FormattingEnabled = true;
            comboBoxTimbreName.Location = new Point(219, 113);
            comboBoxTimbreName.Name = "comboBoxTimbreName";
            comboBoxTimbreName.Size = new Size(125, 23);
            comboBoxTimbreName.TabIndex = 35;
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
            // labelHeading
            // 
            labelHeading.AutoSize = true;
            labelHeading.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelHeading.ForeColor = SystemColors.ActiveCaption;
            labelHeading.Location = new Point(17, 41);
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
            // FormRhythmEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(533, 960);
            ControlBox = false;
            Controls.Add(labelHeading);
            Controls.Add(buttonPlayNote);
            Controls.Add(label9);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(radioButtonReverbOff);
            Controls.Add(radioButtonReverbOn);
            Controls.Add(trackBarPanPot);
            Controls.Add(trackBarLevel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxTimbreName);
            Controls.Add(numericUpDownKeyNo);
            Controls.Add(comboBoxTimbreGroup);
            Controls.Add(listViewRhythmBank);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(350, 200);
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
        private Label label9;
        private Label label5;
        private Label label4;
        private RadioButton radioButtonReverbOff;
        private RadioButton radioButtonReverbOn;
        private TrackBar trackBarPanPot;
        private TrackBar trackBarLevel;
        private Label label3;
        private Label label2;
        private Label label1;
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
    }
}
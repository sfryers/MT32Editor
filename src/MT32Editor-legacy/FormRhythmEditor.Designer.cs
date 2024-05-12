using System.Windows.Forms;
using System;
namespace MT32Edit_legacy
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            this.labelReverb = new System.Windows.Forms.Label();
            this.labelPan = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            this.radioButtonReverbOff = new System.Windows.Forms.RadioButton();
            this.radioButtonReverbOn = new System.Windows.Forms.RadioButton();
            this.trackBarPanPot = new System.Windows.Forms.TrackBar();
            this.trackBarLevel = new System.Windows.Forms.TrackBar();
            this.labelTimbreName = new System.Windows.Forms.Label();
            this.labelTimbreGroup = new System.Windows.Forms.Label();
            this.labelKeyNo = new System.Windows.Forms.Label();
            this.comboBoxTimbreName = new System.Windows.Forms.ComboBox();
            this.numericUpDownKeyNo = new System.Windows.Forms.NumericUpDown();
            this.comboBoxTimbreGroup = new System.Windows.Forms.ComboBox();
            this.listViewRhythmBank = new System.Windows.Forms.ListView();
            this.columnHeaderKeyNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNote = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTimbreGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTimbreName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderReverb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPanPot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolTipParameterValue = new System.Windows.Forms.ToolTip(this.components);
            this.buttonPlayNote = new System.Windows.Forms.Button();
            this.labelUnitNoWarning = new System.Windows.Forms.Label();
            this.labelHeading = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.labelNoChannelAssigned = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPanPot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKeyNo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelReverb
            // 
            this.labelReverb.AutoSize = true;
            this.labelReverb.ForeColor = System.Drawing.SystemColors.Control;
            this.labelReverb.Location = new System.Drawing.Point(204, 139);
            this.labelReverb.Name = "labelReverb";
            this.labelReverb.Size = new System.Drawing.Size(42, 13);
            this.labelReverb.TabIndex = 47;
            this.labelReverb.Text = "Reverb";
            // 
            // labelPan
            // 
            this.labelPan.AutoSize = true;
            this.labelPan.ForeColor = System.Drawing.SystemColors.Control;
            this.labelPan.Location = new System.Drawing.Point(115, 182);
            this.labelPan.Name = "labelPan";
            this.labelPan.Size = new System.Drawing.Size(76, 13);
            this.labelPan.TabIndex = 45;
            this.labelPan.Text = "L      Pan      R";
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.ForeColor = System.Drawing.SystemColors.Control;
            this.labelLevel.Location = new System.Drawing.Point(60, 214);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(33, 13);
            this.labelLevel.TabIndex = 44;
            this.labelLevel.Text = "Level";
            // 
            // radioButtonReverbOff
            // 
            this.radioButtonReverbOff.AutoSize = true;
            this.radioButtonReverbOff.ForeColor = System.Drawing.SystemColors.Control;
            this.radioButtonReverbOff.Location = new System.Drawing.Point(206, 176);
            this.radioButtonReverbOff.Name = "radioButtonReverbOff";
            this.radioButtonReverbOff.Size = new System.Drawing.Size(39, 17);
            this.radioButtonReverbOff.TabIndex = 43;
            this.radioButtonReverbOff.TabStop = true;
            this.radioButtonReverbOff.Text = "Off";
            this.radioButtonReverbOff.UseVisualStyleBackColor = true;
            // 
            // radioButtonReverbOn
            // 
            this.radioButtonReverbOn.AutoSize = true;
            this.radioButtonReverbOn.ForeColor = System.Drawing.SystemColors.Control;
            this.radioButtonReverbOn.Location = new System.Drawing.Point(206, 154);
            this.radioButtonReverbOn.Name = "radioButtonReverbOn";
            this.radioButtonReverbOn.Size = new System.Drawing.Size(39, 17);
            this.radioButtonReverbOn.TabIndex = 42;
            this.radioButtonReverbOn.TabStop = true;
            this.radioButtonReverbOn.Text = "On";
            this.radioButtonReverbOn.UseVisualStyleBackColor = true;
            this.radioButtonReverbOn.CheckedChanged += new System.EventHandler(this.radioButtonReverbOn_CheckedChanged);
            // 
            // trackBarPanPot
            // 
            this.trackBarPanPot.LargeChange = 2;
            this.trackBarPanPot.Location = new System.Drawing.Point(107, 136);
            this.trackBarPanPot.Maximum = 7;
            this.trackBarPanPot.Minimum = -7;
            this.trackBarPanPot.Name = "trackBarPanPot";
            this.trackBarPanPot.Size = new System.Drawing.Size(89, 45);
            this.trackBarPanPot.TabIndex = 40;
            this.trackBarPanPot.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarPanPot.ValueChanged += new System.EventHandler(this.trackBarPanPot_ValueChanged);
            // 
            // trackBarLevel
            // 
            this.trackBarLevel.LargeChange = 10;
            this.trackBarLevel.Location = new System.Drawing.Point(56, 126);
            this.trackBarLevel.Maximum = 100;
            this.trackBarLevel.Name = "trackBarLevel";
            this.trackBarLevel.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarLevel.Size = new System.Drawing.Size(45, 90);
            this.trackBarLevel.TabIndex = 39;
            this.trackBarLevel.TickFrequency = 10;
            this.trackBarLevel.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarLevel.Value = 75;
            this.trackBarLevel.ValueChanged += new System.EventHandler(this.trackBarLevel_ValueChanged);
            // 
            // labelTimbreName
            // 
            this.labelTimbreName.AutoSize = true;
            this.labelTimbreName.ForeColor = System.Drawing.SystemColors.Control;
            this.labelTimbreName.Location = new System.Drawing.Point(104, 83);
            this.labelTimbreName.Name = "labelTimbreName";
            this.labelTimbreName.Size = new System.Drawing.Size(70, 13);
            this.labelTimbreName.TabIndex = 38;
            this.labelTimbreName.Text = "Timbre Name";
            // 
            // labelTimbreGroup
            // 
            this.labelTimbreGroup.AutoSize = true;
            this.labelTimbreGroup.ForeColor = System.Drawing.SystemColors.Control;
            this.labelTimbreGroup.Location = new System.Drawing.Point(16, 83);
            this.labelTimbreGroup.Name = "labelTimbreGroup";
            this.labelTimbreGroup.Size = new System.Drawing.Size(71, 13);
            this.labelTimbreGroup.TabIndex = 37;
            this.labelTimbreGroup.Text = "Timbre Group";
            // 
            // labelKeyNo
            // 
            this.labelKeyNo.AutoSize = true;
            this.labelKeyNo.ForeColor = System.Drawing.SystemColors.Control;
            this.labelKeyNo.Location = new System.Drawing.Point(225, 40);
            this.labelKeyNo.Name = "labelKeyNo";
            this.labelKeyNo.Size = new System.Drawing.Size(45, 13);
            this.labelKeyNo.TabIndex = 36;
            this.labelKeyNo.Text = "Key No.";
            // 
            // comboBoxTimbreName
            // 
            this.comboBoxTimbreName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTimbreName.FormattingEnabled = true;
            this.comboBoxTimbreName.Location = new System.Drawing.Point(104, 99);
            this.comboBoxTimbreName.Name = "comboBoxTimbreName";
            this.comboBoxTimbreName.Size = new System.Drawing.Size(108, 21);
            this.comboBoxTimbreName.TabIndex = 35;
            this.comboBoxTimbreName.SelectionChangeCommitted += new System.EventHandler(this.comboBoxTimbreName_SelectionChangeCommitted);
            // 
            // numericUpDownKeyNo
            // 
            this.numericUpDownKeyNo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.numericUpDownKeyNo.Location = new System.Drawing.Point(278, 34);
            this.numericUpDownKeyNo.Maximum = new decimal(new int[] {
            108,
            0,
            0,
            0});
            this.numericUpDownKeyNo.Minimum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDownKeyNo.Name = "numericUpDownKeyNo";
            this.numericUpDownKeyNo.Size = new System.Drawing.Size(60, 29);
            this.numericUpDownKeyNo.TabIndex = 34;
            this.numericUpDownKeyNo.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDownKeyNo.ValueChanged += new System.EventHandler(this.numericUpDownKeyNo_ValueChanged);
            // 
            // comboBoxTimbreGroup
            // 
            this.comboBoxTimbreGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTimbreGroup.FormattingEnabled = true;
            this.comboBoxTimbreGroup.Items.AddRange(new object[] {
            "Memory",
            "Rhythm"});
            this.comboBoxTimbreGroup.Location = new System.Drawing.Point(16, 99);
            this.comboBoxTimbreGroup.Name = "comboBoxTimbreGroup";
            this.comboBoxTimbreGroup.Size = new System.Drawing.Size(82, 21);
            this.comboBoxTimbreGroup.TabIndex = 33;
            this.comboBoxTimbreGroup.SelectionChangeCommitted += new System.EventHandler(this.comboBoxTimbreGroup_SelectionChangeCommitted);
            // 
            // listViewRhythmBank
            // 
            this.listViewRhythmBank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.listViewRhythmBank.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderKeyNo,
            this.columnHeaderNote,
            this.columnHeaderTimbreGroup,
            this.columnHeaderTimbreName,
            this.columnHeaderReverb,
            this.columnHeaderPanPot,
            this.columnHeaderLevel});
            this.listViewRhythmBank.ForeColor = System.Drawing.SystemColors.Control;
            this.listViewRhythmBank.FullRowSelect = true;
            this.listViewRhythmBank.GridLines = true;
            this.listViewRhythmBank.HideSelection = false;
            this.listViewRhythmBank.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.listViewRhythmBank.Location = new System.Drawing.Point(12, 264);
            this.listViewRhythmBank.MinimumSize = new System.Drawing.Size(4, 25);
            this.listViewRhythmBank.MultiSelect = false;
            this.listViewRhythmBank.Name = "listViewRhythmBank";
            this.listViewRhythmBank.Size = new System.Drawing.Size(425, 513);
            this.listViewRhythmBank.TabIndex = 32;
            this.listViewRhythmBank.TileSize = new System.Drawing.Size(50, 20);
            this.listViewRhythmBank.UseCompatibleStateImageBehavior = false;
            this.listViewRhythmBank.View = System.Windows.Forms.View.Details;
            this.listViewRhythmBank.SelectedIndexChanged += new System.EventHandler(this.listViewRhythmBank_SelectedIndexChanged);
            // 
            // columnHeaderKeyNo
            // 
            this.columnHeaderKeyNo.Text = "Key#";
            this.columnHeaderKeyNo.Width = 42;
            // 
            // columnHeaderNote
            // 
            this.columnHeaderNote.Text = "Note";
            // 
            // columnHeaderTimbreGroup
            // 
            this.columnHeaderTimbreGroup.Text = "Timbre Group";
            this.columnHeaderTimbreGroup.Width = 86;
            // 
            // columnHeaderTimbreName
            // 
            this.columnHeaderTimbreName.Text = "Timbre Name";
            this.columnHeaderTimbreName.Width = 90;
            // 
            // columnHeaderReverb
            // 
            this.columnHeaderReverb.Text = "Reverb";
            this.columnHeaderReverb.Width = 48;
            // 
            // columnHeaderPanPot
            // 
            this.columnHeaderPanPot.Text = "Pan";
            this.columnHeaderPanPot.Width = 38;
            // 
            // columnHeaderLevel
            // 
            this.columnHeaderLevel.Text = "Level";
            this.columnHeaderLevel.Width = 42;
            // 
            // buttonPlayNote
            // 
            this.buttonPlayNote.Image = global::MT32Edit_legacy.Properties.Resources.Play;
            this.buttonPlayNote.Location = new System.Drawing.Point(12, 233);
            this.buttonPlayNote.Name = "buttonPlayNote";
            this.buttonPlayNote.Size = new System.Drawing.Size(35, 26);
            this.buttonPlayNote.TabIndex = 58;
            this.toolTipParameterValue.SetToolTip(this.buttonPlayNote, "Play selected sound on device");
            this.buttonPlayNote.UseVisualStyleBackColor = true;
            this.buttonPlayNote.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonPlayNote_MouseDown);
            this.buttonPlayNote.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonPlayNote_MouseUp);
            // 
            // labelUnitNoWarning
            // 
            this.labelUnitNoWarning.AutoSize = true;
            this.labelUnitNoWarning.ForeColor = System.Drawing.Color.Yellow;
            this.labelUnitNoWarning.Location = new System.Drawing.Point(13, 64);
            this.labelUnitNoWarning.Name = "labelUnitNoWarning";
            this.labelUnitNoWarning.Size = new System.Drawing.Size(384, 13);
            this.labelUnitNoWarning.TabIndex = 63;
            this.labelUnitNoWarning.Text = "Unit No. set to non-default value! To revert, edit/delete MT32Edit.ini and reload" +
    ".";
            this.labelUnitNoWarning.Visible = false;
            // 
            // labelHeading
            // 
            this.labelHeading.AutoSize = true;
            this.labelHeading.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelHeading.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelHeading.Location = new System.Drawing.Point(12, 36);
            this.labelHeading.Name = "labelHeading";
            this.labelHeading.Size = new System.Drawing.Size(153, 21);
            this.labelHeading.TabIndex = 59;
            this.labelHeading.Text = "Rhythm Bank Editor";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // labelNoChannelAssigned
            // 
            this.labelNoChannelAssigned.AutoSize = true;
            this.labelNoChannelAssigned.ForeColor = System.Drawing.Color.Yellow;
            this.labelNoChannelAssigned.Location = new System.Drawing.Point(50, 240);
            this.labelNoChannelAssigned.Name = "labelNoChannelAssigned";
            this.labelNoChannelAssigned.Size = new System.Drawing.Size(300, 13);
            this.labelNoChannelAssigned.TabIndex = 60;
            this.labelNoChannelAssigned.Text = "Rhythm part muted- assign a MIDI channel in System Settings.";
            this.labelNoChannelAssigned.Visible = false;
            // 
            // FormRhythmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(457, 832);
            this.ControlBox = false;
            this.Controls.Add(this.labelUnitNoWarning);
            this.Controls.Add(this.labelNoChannelAssigned);
            this.Controls.Add(this.labelHeading);
            this.Controls.Add(this.buttonPlayNote);
            this.Controls.Add(this.labelReverb);
            this.Controls.Add(this.labelPan);
            this.Controls.Add(this.labelLevel);
            this.Controls.Add(this.radioButtonReverbOff);
            this.Controls.Add(this.radioButtonReverbOn);
            this.Controls.Add(this.trackBarPanPot);
            this.Controls.Add(this.trackBarLevel);
            this.Controls.Add(this.labelTimbreName);
            this.Controls.Add(this.labelTimbreGroup);
            this.Controls.Add(this.labelKeyNo);
            this.Controls.Add(this.comboBoxTimbreName);
            this.Controls.Add(this.numericUpDownKeyNo);
            this.Controls.Add(this.comboBoxTimbreGroup);
            this.Controls.Add(this.listViewRhythmBank);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(348, 263);
            this.Name = "FormRhythmEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MT-32 Rhythm Bank Editor";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.FormRhythmEditor_Activated);
            this.Leave += new System.EventHandler(this.FormRhythmEditor_Leave);
            this.Resize += new System.EventHandler(this.FormRhythmEditor_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPanPot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKeyNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}
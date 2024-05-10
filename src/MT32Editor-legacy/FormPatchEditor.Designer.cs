using System.Windows.Forms;
namespace MT32Edit_legacy
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.listViewPatches = new System.Windows.Forms.ListView();
            this.columnHeaderPatchNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTimbreGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTimbreName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderKeyShift = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFineTune = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderBendRange = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderReverb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAssignMode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboBoxTimbreGroup = new System.Windows.Forms.ComboBox();
            this.numericUpDownPatchNo = new System.Windows.Forms.NumericUpDown();
            this.comboBoxTimbreName = new System.Windows.Forms.ComboBox();
            this.labelPatchNo = new System.Windows.Forms.Label();
            this.labelTimbreGroup = new System.Windows.Forms.Label();
            this.labelTimbreName = new System.Windows.Forms.Label();
            this.trackBarKeyShift = new System.Windows.Forms.TrackBar();
            this.trackBarFineTune = new System.Windows.Forms.TrackBar();
            this.trackBarBenderRange = new System.Windows.Forms.TrackBar();
            this.radioButtonReverbOn = new System.Windows.Forms.RadioButton();
            this.radioButtonReverbOff = new System.Windows.Forms.RadioButton();
            this.labelKeyShift = new System.Windows.Forms.Label();
            this.labelFineTune = new System.Windows.Forms.Label();
            this.labelBendRange = new System.Windows.Forms.Label();
            this.labelReverb = new System.Windows.Forms.Label();
            this.comboBoxAssignMode = new System.Windows.Forms.ComboBox();
            this.labelAssignMode = new System.Windows.Forms.Label();
            this.toolTipParameterValue = new System.Windows.Forms.ToolTip(this.components);
            this.labelUnitNoWarning = new System.Windows.Forms.Label();
            this.labelHeading = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.buttonEditPreset = new System.Windows.Forms.Button();
            this.labelNoChannelAssigned = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPatchNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarKeyShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFineTune)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBenderRange)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewPatches
            // 
            this.listViewPatches.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.listViewPatches.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPatchNo,
            this.columnHeaderTimbreGroup,
            this.columnHeaderTimbreName,
            this.columnHeaderKeyShift,
            this.columnHeaderFineTune,
            this.columnHeaderBendRange,
            this.columnHeaderReverb,
            this.columnHeaderAssignMode});
            this.listViewPatches.ForeColor = System.Drawing.SystemColors.Control;
            this.listViewPatches.FullRowSelect = true;
            this.listViewPatches.GridLines = true;
            this.listViewPatches.HideSelection = false;
            this.listViewPatches.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listViewPatches.Location = new System.Drawing.Point(12, 264);
            this.listViewPatches.MinimumSize = new System.Drawing.Size(4, 25);
            this.listViewPatches.MultiSelect = false;
            this.listViewPatches.Name = "listViewPatches";
            this.listViewPatches.Size = new System.Drawing.Size(428, 513);
            this.listViewPatches.TabIndex = 1;
            this.listViewPatches.TileSize = new System.Drawing.Size(50, 20);
            this.listViewPatches.UseCompatibleStateImageBehavior = false;
            this.listViewPatches.View = System.Windows.Forms.View.Details;
            this.listViewPatches.SelectedIndexChanged += new System.EventHandler(this.listViewPatches_SelectedIndexChanged);
            // 
            // columnHeaderPatchNo
            // 
            this.columnHeaderPatchNo.Text = "Patch";
            this.columnHeaderPatchNo.Width = 42;
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
            // columnHeaderKeyShift
            // 
            this.columnHeaderKeyShift.Text = "Key";
            this.columnHeaderKeyShift.Width = 40;
            // 
            // columnHeaderFineTune
            // 
            this.columnHeaderFineTune.Text = "Fine";
            this.columnHeaderFineTune.Width = 40;
            // 
            // columnHeaderBendRange
            // 
            this.columnHeaderBendRange.Text = "Bend";
            this.columnHeaderBendRange.Width = 40;
            // 
            // columnHeaderReverb
            // 
            this.columnHeaderReverb.Tag = "";
            this.columnHeaderReverb.Text = "Reverb";
            this.columnHeaderReverb.Width = 48;
            // 
            // columnHeaderAssignMode
            // 
            this.columnHeaderAssignMode.Text = "A.Mode";
            this.columnHeaderAssignMode.Width = 54;
            // 
            // comboBoxTimbreGroup
            // 
            this.comboBoxTimbreGroup.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxTimbreGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTimbreGroup.FormattingEnabled = true;
            this.comboBoxTimbreGroup.Items.AddRange(new object[] {
            "Preset A",
            "Preset B",
            "Memory",
            "Rhythm"});
            this.comboBoxTimbreGroup.Location = new System.Drawing.Point(16, 99);
            this.comboBoxTimbreGroup.Name = "comboBoxTimbreGroup";
            this.comboBoxTimbreGroup.Size = new System.Drawing.Size(82, 21);
            this.comboBoxTimbreGroup.TabIndex = 3;
            this.comboBoxTimbreGroup.SelectionChangeCommitted += new System.EventHandler(this.comboBoxTimbreGroup_SelectionChangeCommitted);
            // 
            // numericUpDownPatchNo
            // 
            this.numericUpDownPatchNo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.numericUpDownPatchNo.Location = new System.Drawing.Point(278, 34);
            this.numericUpDownPatchNo.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDownPatchNo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPatchNo.Name = "numericUpDownPatchNo";
            this.numericUpDownPatchNo.Size = new System.Drawing.Size(60, 29);
            this.numericUpDownPatchNo.TabIndex = 4;
            this.numericUpDownPatchNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPatchNo.ValueChanged += new System.EventHandler(this.numericUpDownPatchNo_ValueChanged);
            // 
            // comboBoxTimbreName
            // 
            this.comboBoxTimbreName.FormattingEnabled = true;
            this.comboBoxTimbreName.Location = new System.Drawing.Point(104, 99);
            this.comboBoxTimbreName.Name = "comboBoxTimbreName";
            this.comboBoxTimbreName.Size = new System.Drawing.Size(108, 21);
            this.comboBoxTimbreName.TabIndex = 5;
            this.comboBoxTimbreName.SelectionChangeCommitted += new System.EventHandler(this.comboBoxTimbreName_SelectionChangeCommitted);
            // 
            // labelPatchNo
            // 
            this.labelPatchNo.AutoSize = true;
            this.labelPatchNo.ForeColor = System.Drawing.SystemColors.Control;
            this.labelPatchNo.Location = new System.Drawing.Point(214, 40);
            this.labelPatchNo.Name = "labelPatchNo";
            this.labelPatchNo.Size = new System.Drawing.Size(55, 13);
            this.labelPatchNo.TabIndex = 6;
            this.labelPatchNo.Text = "Patch No.";
            // 
            // labelTimbreGroup
            // 
            this.labelTimbreGroup.AutoSize = true;
            this.labelTimbreGroup.ForeColor = System.Drawing.SystemColors.Control;
            this.labelTimbreGroup.Location = new System.Drawing.Point(16, 83);
            this.labelTimbreGroup.Name = "labelTimbreGroup";
            this.labelTimbreGroup.Size = new System.Drawing.Size(71, 13);
            this.labelTimbreGroup.TabIndex = 7;
            this.labelTimbreGroup.Text = "Timbre Group";
            // 
            // labelTimbreName
            // 
            this.labelTimbreName.AutoSize = true;
            this.labelTimbreName.ForeColor = System.Drawing.SystemColors.Control;
            this.labelTimbreName.Location = new System.Drawing.Point(104, 83);
            this.labelTimbreName.Name = "labelTimbreName";
            this.labelTimbreName.Size = new System.Drawing.Size(70, 13);
            this.labelTimbreName.TabIndex = 8;
            this.labelTimbreName.Text = "Timbre Name";
            // 
            // trackBarKeyShift
            // 
            this.trackBarKeyShift.LargeChange = 12;
            this.trackBarKeyShift.Location = new System.Drawing.Point(24, 154);
            this.trackBarKeyShift.Maximum = 24;
            this.trackBarKeyShift.Minimum = -24;
            this.trackBarKeyShift.Name = "trackBarKeyShift";
            this.trackBarKeyShift.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarKeyShift.Size = new System.Drawing.Size(45, 90);
            this.trackBarKeyShift.TabIndex = 9;
            this.trackBarKeyShift.TickFrequency = 2;
            this.trackBarKeyShift.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarKeyShift.ValueChanged += new System.EventHandler(this.trackBarKeyShift_ValueChanged);
            // 
            // trackBarFineTune
            // 
            this.trackBarFineTune.Location = new System.Drawing.Point(78, 154);
            this.trackBarFineTune.Maximum = 50;
            this.trackBarFineTune.Minimum = -50;
            this.trackBarFineTune.Name = "trackBarFineTune";
            this.trackBarFineTune.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarFineTune.Size = new System.Drawing.Size(45, 90);
            this.trackBarFineTune.TabIndex = 10;
            this.trackBarFineTune.TickFrequency = 10;
            this.trackBarFineTune.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarFineTune.ValueChanged += new System.EventHandler(this.trackBarFineTune_ValueChanged);
            // 
            // trackBarBenderRange
            // 
            this.trackBarBenderRange.LargeChange = 2;
            this.trackBarBenderRange.Location = new System.Drawing.Point(134, 154);
            this.trackBarBenderRange.Maximum = 24;
            this.trackBarBenderRange.Name = "trackBarBenderRange";
            this.trackBarBenderRange.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarBenderRange.Size = new System.Drawing.Size(45, 90);
            this.trackBarBenderRange.TabIndex = 11;
            this.trackBarBenderRange.TickFrequency = 2;
            this.trackBarBenderRange.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarBenderRange.Value = 12;
            this.trackBarBenderRange.ValueChanged += new System.EventHandler(this.trackBarBenderRange_ValueChanged);
            // 
            // radioButtonReverbOn
            // 
            this.radioButtonReverbOn.AutoSize = true;
            this.radioButtonReverbOn.ForeColor = System.Drawing.SystemColors.Control;
            this.radioButtonReverbOn.Location = new System.Drawing.Point(206, 154);
            this.radioButtonReverbOn.Name = "radioButtonReverbOn";
            this.radioButtonReverbOn.Size = new System.Drawing.Size(39, 17);
            this.radioButtonReverbOn.TabIndex = 14;
            this.radioButtonReverbOn.TabStop = true;
            this.radioButtonReverbOn.Text = "On";
            this.radioButtonReverbOn.UseVisualStyleBackColor = true;
            this.radioButtonReverbOn.CheckedChanged += new System.EventHandler(this.radioButtonReverbOn_CheckedChanged);
            // 
            // radioButtonReverbOff
            // 
            this.radioButtonReverbOff.AutoSize = true;
            this.radioButtonReverbOff.ForeColor = System.Drawing.SystemColors.Control;
            this.radioButtonReverbOff.Location = new System.Drawing.Point(206, 176);
            this.radioButtonReverbOff.Name = "radioButtonReverbOff";
            this.radioButtonReverbOff.Size = new System.Drawing.Size(39, 17);
            this.radioButtonReverbOff.TabIndex = 15;
            this.radioButtonReverbOff.TabStop = true;
            this.radioButtonReverbOff.Text = "Off";
            this.radioButtonReverbOff.UseVisualStyleBackColor = true;
            // 
            // labelKeyShift
            // 
            this.labelKeyShift.AutoSize = true;
            this.labelKeyShift.ForeColor = System.Drawing.SystemColors.Control;
            this.labelKeyShift.Location = new System.Drawing.Point(19, 139);
            this.labelKeyShift.Name = "labelKeyShift";
            this.labelKeyShift.Size = new System.Drawing.Size(49, 13);
            this.labelKeyShift.TabIndex = 16;
            this.labelKeyShift.Text = "Key Shift";
            // 
            // labelFineTune
            // 
            this.labelFineTune.AutoSize = true;
            this.labelFineTune.ForeColor = System.Drawing.SystemColors.Control;
            this.labelFineTune.Location = new System.Drawing.Point(70, 139);
            this.labelFineTune.Name = "labelFineTune";
            this.labelFineTune.Size = new System.Drawing.Size(55, 13);
            this.labelFineTune.TabIndex = 17;
            this.labelFineTune.Text = "Fine Tune";
            // 
            // labelBendRange
            // 
            this.labelBendRange.AutoSize = true;
            this.labelBendRange.ForeColor = System.Drawing.SystemColors.Control;
            this.labelBendRange.Location = new System.Drawing.Point(125, 139);
            this.labelBendRange.Name = "labelBendRange";
            this.labelBendRange.Size = new System.Drawing.Size(67, 13);
            this.labelBendRange.TabIndex = 18;
            this.labelBendRange.Text = "Bend Range";
            // 
            // labelReverb
            // 
            this.labelReverb.AutoSize = true;
            this.labelReverb.ForeColor = System.Drawing.SystemColors.Control;
            this.labelReverb.Location = new System.Drawing.Point(204, 139);
            this.labelReverb.Name = "labelReverb";
            this.labelReverb.Size = new System.Drawing.Size(42, 13);
            this.labelReverb.TabIndex = 21;
            this.labelReverb.Text = "Reverb";
            // 
            // comboBoxAssignMode
            // 
            this.comboBoxAssignMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAssignMode.FormattingEnabled = true;
            this.comboBoxAssignMode.Items.AddRange(new object[] {
            "1: Single Assign",
            "2: Multi Assign",
            "3: First In, First Out",
            "4: First In, Last Out"});
            this.comboBoxAssignMode.Location = new System.Drawing.Point(204, 223);
            this.comboBoxAssignMode.Name = "comboBoxAssignMode";
            this.comboBoxAssignMode.Size = new System.Drawing.Size(134, 21);
            this.comboBoxAssignMode.TabIndex = 22;
            this.comboBoxAssignMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxAssignMode_SelectedValueChanged);
            // 
            // labelAssignMode
            // 
            this.labelAssignMode.AutoSize = true;
            this.labelAssignMode.ForeColor = System.Drawing.SystemColors.Control;
            this.labelAssignMode.Location = new System.Drawing.Point(204, 206);
            this.labelAssignMode.Name = "labelAssignMode";
            this.labelAssignMode.Size = new System.Drawing.Size(68, 13);
            this.labelAssignMode.TabIndex = 23;
            this.labelAssignMode.Text = "Assign Mode";
            // 
            // labelUnitNoWarning
            // 
            this.labelUnitNoWarning.AutoSize = true;
            this.labelUnitNoWarning.ForeColor = System.Drawing.Color.Yellow;
            this.labelUnitNoWarning.Location = new System.Drawing.Point(13, 64);
            this.labelUnitNoWarning.Name = "labelUnitNoWarning";
            this.labelUnitNoWarning.Size = new System.Drawing.Size(384, 13);
            this.labelUnitNoWarning.TabIndex = 62;
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
            this.labelHeading.Size = new System.Drawing.Size(98, 21);
            this.labelHeading.TabIndex = 31;
            this.labelHeading.Text = "Patch Editor";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // buttonEditPreset
            // 
            this.buttonEditPreset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonEditPreset.Location = new System.Drawing.Point(218, 99);
            this.buttonEditPreset.Name = "buttonEditPreset";
            this.buttonEditPreset.Size = new System.Drawing.Size(121, 22);
            this.buttonEditPreset.TabIndex = 32;
            this.buttonEditPreset.Text = "Edit Preset Timbre";
            this.buttonEditPreset.UseVisualStyleBackColor = false;
            this.buttonEditPreset.Click += new System.EventHandler(this.buttonEditPreset_Click);
            // 
            // labelNoChannelAssigned
            // 
            this.labelNoChannelAssigned.AutoSize = true;
            this.labelNoChannelAssigned.ForeColor = System.Drawing.Color.Yellow;
            this.labelNoChannelAssigned.Location = new System.Drawing.Point(12, 246);
            this.labelNoChannelAssigned.Name = "labelNoChannelAssigned";
            this.labelNoChannelAssigned.Size = new System.Drawing.Size(272, 13);
            this.labelNoChannelAssigned.TabIndex = 61;
            this.labelNoChannelAssigned.Text = "Part 1 muted- Assign a MIDI channel in System Settings.";
            this.labelNoChannelAssigned.Visible = false;
            // 
            // FormPatchEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(472, 806);
            this.ControlBox = false;
            this.Controls.Add(this.labelUnitNoWarning);
            this.Controls.Add(this.labelNoChannelAssigned);
            this.Controls.Add(this.buttonEditPreset);
            this.Controls.Add(this.labelHeading);
            this.Controls.Add(this.labelAssignMode);
            this.Controls.Add(this.comboBoxAssignMode);
            this.Controls.Add(this.labelReverb);
            this.Controls.Add(this.labelBendRange);
            this.Controls.Add(this.labelFineTune);
            this.Controls.Add(this.labelKeyShift);
            this.Controls.Add(this.radioButtonReverbOff);
            this.Controls.Add(this.radioButtonReverbOn);
            this.Controls.Add(this.trackBarBenderRange);
            this.Controls.Add(this.trackBarFineTune);
            this.Controls.Add(this.trackBarKeyShift);
            this.Controls.Add(this.labelTimbreName);
            this.Controls.Add(this.labelTimbreGroup);
            this.Controls.Add(this.labelPatchNo);
            this.Controls.Add(this.comboBoxTimbreName);
            this.Controls.Add(this.numericUpDownPatchNo);
            this.Controls.Add(this.comboBoxTimbreGroup);
            this.Controls.Add(this.listViewPatches);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(348, 263);
            this.Name = "FormPatchEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MT-32 Patch Editor";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.FormPatchEditor_Activated);
            this.Leave += new System.EventHandler(this.FormPatchEditor_Leave);
            this.Resize += new System.EventHandler(this.FormPatchEditor_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPatchNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarKeyShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFineTune)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBenderRange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
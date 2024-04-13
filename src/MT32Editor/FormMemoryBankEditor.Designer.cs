namespace MT32Edit
{
    partial class FormMemoryBankEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMemoryBankEditor));
            listViewTimbres = new ListView();
            columnHeaderTimbreNo = new ColumnHeader();
            columnHeaderTimbreName = new ColumnHeader();
            labelTimbreNo = new Label();
            numericUpDownTimbreNo = new NumericUpDown();
            buttonCopyTimbre = new Button();
            buttonPasteTimbre = new Button();
            buttonClearTimbre = new Button();
            buttonClearAll = new Button();
            toolTip = new ToolTip(components);
            labelHeading = new Label();
            timer = new System.Windows.Forms.Timer(components);
            labelTimbreName = new Label();
            labelCopy = new Label();
            labelPaste = new Label();
            labelClearSelected = new Label();
            labelClearAll = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTimbreNo).BeginInit();
            SuspendLayout();
            // 
            // listViewTimbres
            // 
            listViewTimbres.BackColor = Color.FromArgb(84, 84, 84);
            listViewTimbres.Columns.AddRange(new ColumnHeader[] { columnHeaderTimbreNo, columnHeaderTimbreName });
            listViewTimbres.ForeColor = SystemColors.Control;
            listViewTimbres.FullRowSelect = true;
            listViewTimbres.GridLines = true;
            listViewTimbres.Items.AddRange(new ListViewItem[] { listViewItem1 });
            listViewTimbres.Location = new Point(14, 256);
            listViewTimbres.MinimumSize = new Size(0, 28);
            listViewTimbres.MultiSelect = false;
            listViewTimbres.Name = "listViewTimbres";
            listViewTimbres.Size = new Size(192, 489);
            listViewTimbres.TabIndex = 2;
            listViewTimbres.TileSize = new Size(50, 20);
            listViewTimbres.UseCompatibleStateImageBehavior = false;
            listViewTimbres.View = View.Details;
            listViewTimbres.SelectedIndexChanged += listViewTimbres_SelectedIndexChanged;
            // 
            // columnHeaderTimbreNo
            // 
            columnHeaderTimbreNo.Text = "Mem#";
            columnHeaderTimbreNo.Width = 48;
            // 
            // columnHeaderTimbreName
            // 
            columnHeaderTimbreName.Text = "Timbre Name";
            columnHeaderTimbreName.Width = 90;
            // 
            // labelTimbreNo
            // 
            labelTimbreNo.AutoSize = true;
            labelTimbreNo.ForeColor = SystemColors.Control;
            labelTimbreNo.Location = new Point(31, 82);
            labelTimbreNo.Name = "labelTimbreNo";
            labelTimbreNo.Size = new Size(74, 15);
            labelTimbreNo.TabIndex = 8;
            labelTimbreNo.Text = "Memory No.";
            // 
            // numericUpDownTimbreNo
            // 
            numericUpDownTimbreNo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            numericUpDownTimbreNo.Location = new Point(117, 75);
            numericUpDownTimbreNo.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
            numericUpDownTimbreNo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownTimbreNo.Name = "numericUpDownTimbreNo";
            numericUpDownTimbreNo.Size = new Size(51, 29);
            numericUpDownTimbreNo.TabIndex = 7;
            numericUpDownTimbreNo.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownTimbreNo.ValueChanged += numericUpDownTimbreNo_ValueChanged;
            // 
            // buttonCopyTimbre
            // 
            buttonCopyTimbre.AccessibleDescription = "Copy timbre";
            buttonCopyTimbre.AccessibleName = "Copy timbre";
            buttonCopyTimbre.BackColor = Color.FromArgb(224, 224, 224);
            buttonCopyTimbre.ForeColor = SystemColors.ActiveCaptionText;
            buttonCopyTimbre.Image = Properties.Resources.Copy;
            buttonCopyTimbre.Location = new Point(17, 156);
            buttonCopyTimbre.Name = "buttonCopyTimbre";
            buttonCopyTimbre.Size = new Size(28, 28);
            buttonCopyTimbre.TabIndex = 58;
            buttonCopyTimbre.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(buttonCopyTimbre, "Copy the selected timbre");
            buttonCopyTimbre.UseVisualStyleBackColor = false;
            buttonCopyTimbre.Click += buttonCopyTimbre_Click;
            // 
            // buttonPasteTimbre
            // 
            buttonPasteTimbre.AccessibleDescription = "Paste timbre";
            buttonPasteTimbre.BackColor = Color.FromArgb(224, 224, 224);
            buttonPasteTimbre.Enabled = false;
            buttonPasteTimbre.ForeColor = SystemColors.ActiveCaptionText;
            buttonPasteTimbre.Image = Properties.Resources.Paste;
            buttonPasteTimbre.Location = new Point(101, 156);
            buttonPasteTimbre.Name = "buttonPasteTimbre";
            buttonPasteTimbre.Size = new Size(28, 28);
            buttonPasteTimbre.TabIndex = 57;
            buttonPasteTimbre.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(buttonPasteTimbre, "Paste timbre into the selected position");
            buttonPasteTimbre.UseVisualStyleBackColor = false;
            buttonPasteTimbre.Click += buttonPasteTimbre_Click;
            // 
            // buttonClearTimbre
            // 
            buttonClearTimbre.AccessibleDescription = "Clear timbre";
            buttonClearTimbre.AccessibleName = "Clear timbre";
            buttonClearTimbre.BackColor = Color.FromArgb(224, 224, 224);
            buttonClearTimbre.ForeColor = SystemColors.ActiveCaptionText;
            buttonClearTimbre.Image = (Image)resources.GetObject("buttonClearTimbre.Image");
            buttonClearTimbre.Location = new Point(17, 186);
            buttonClearTimbre.Name = "buttonClearTimbre";
            buttonClearTimbre.Size = new Size(28, 28);
            buttonClearTimbre.TabIndex = 59;
            buttonClearTimbre.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(buttonClearTimbre, "Clear the selected timbre");
            buttonClearTimbre.UseVisualStyleBackColor = false;
            buttonClearTimbre.Click += buttonClearTimbre_Click;
            // 
            // buttonClearAll
            // 
            buttonClearAll.AccessibleDescription = "Clear All";
            buttonClearAll.AccessibleName = "Clear All";
            buttonClearAll.BackColor = Color.FromArgb(224, 224, 224);
            buttonClearAll.ForeColor = SystemColors.ActiveCaptionText;
            buttonClearAll.Image = (Image)resources.GetObject("buttonClearAll.Image");
            buttonClearAll.Location = new Point(17, 216);
            buttonClearAll.Name = "buttonClearAll";
            buttonClearAll.Size = new Size(28, 28);
            buttonClearAll.TabIndex = 60;
            buttonClearAll.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(buttonClearAll, "Clear all memory timbres");
            buttonClearAll.UseVisualStyleBackColor = false;
            buttonClearAll.Click += buttonClearAll_Click;
            // 
            // labelHeading
            // 
            labelHeading.AutoSize = true;
            labelHeading.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelHeading.ForeColor = SystemColors.ActiveCaption;
            labelHeading.Location = new Point(14, 39);
            labelHeading.Name = "labelHeading";
            labelHeading.Size = new Size(167, 21);
            labelHeading.TabIndex = 62;
            labelHeading.Text = "Timbre Memory Area";
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Tick += timer_Tick;
            // 
            // labelTimbreName
            // 
            labelTimbreName.AutoSize = true;
            labelTimbreName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelTimbreName.ForeColor = SystemColors.Control;
            labelTimbreName.Location = new Point(17, 114);
            labelTimbreName.Name = "labelTimbreName";
            labelTimbreName.Size = new Size(57, 21);
            labelTimbreName.TabIndex = 63;
            labelTimbreName.Text = "[none]";
            // 
            // labelCopy
            // 
            labelCopy.AutoSize = true;
            labelCopy.ForeColor = SystemColors.Control;
            labelCopy.Location = new Point(47, 163);
            labelCopy.Name = "labelCopy";
            labelCopy.Size = new Size(35, 15);
            labelCopy.TabIndex = 64;
            labelCopy.Text = "Copy";
            // 
            // labelPaste
            // 
            labelPaste.AutoSize = true;
            labelPaste.ForeColor = SystemColors.Control;
            labelPaste.Location = new Point(135, 163);
            labelPaste.Name = "labelPaste";
            labelPaste.Size = new Size(35, 15);
            labelPaste.TabIndex = 65;
            labelPaste.Text = "Paste";
            // 
            // labelClearSelected
            // 
            labelClearSelected.AutoSize = true;
            labelClearSelected.ForeColor = SystemColors.Control;
            labelClearSelected.Location = new Point(47, 193);
            labelClearSelected.Name = "labelClearSelected";
            labelClearSelected.Size = new Size(121, 15);
            labelClearSelected.TabIndex = 66;
            labelClearSelected.Text = "Clear Selected Timbre";
            // 
            // labelClearAll
            // 
            labelClearAll.AutoSize = true;
            labelClearAll.ForeColor = SystemColors.Control;
            labelClearAll.Location = new Point(45, 223);
            labelClearAll.Name = "labelClearAll";
            labelClearAll.Size = new Size(96, 15);
            labelClearAll.TabIndex = 67;
            labelClearAll.Text = "Clear All Timbres";
            // 
            // FormMemoryBankEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(226, 960);
            ControlBox = false;
            Controls.Add(labelClearAll);
            Controls.Add(labelClearSelected);
            Controls.Add(labelPaste);
            Controls.Add(labelCopy);
            Controls.Add(labelTimbreName);
            Controls.Add(labelHeading);
            Controls.Add(buttonClearAll);
            Controls.Add(buttonClearTimbre);
            Controls.Add(buttonCopyTimbre);
            Controls.Add(buttonPasteTimbre);
            Controls.Add(labelTimbreNo);
            Controls.Add(numericUpDownTimbreNo);
            Controls.Add(listViewTimbres);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(200, 150);
            Name = "FormMemoryBankEditor";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "MT-32 Memory Bank Editor";
            Activated += FormMemoryBankEditor_Activated;
            Resize += FormMemoryBankEditor_Resize;
            ((System.ComponentModel.ISupportInitialize)numericUpDownTimbreNo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listViewTimbres;
        private ColumnHeader columnHeaderTimbreNo;
        private ColumnHeader columnHeaderTimbreName;
        private Label labelTimbreNo;
        private NumericUpDown numericUpDownTimbreNo;
        private Button buttonCopyTimbre;
        private Button buttonPasteTimbre;
        private Button buttonClearTimbre;
        private Button buttonClearAll;
        private ToolTip toolTip;
        private Label labelHeading;
        private System.Windows.Forms.Timer timer;
        private Label labelTimbreName;
        private Label labelCopy;
        private Label labelPaste;
        private Label labelClearSelected;
        private Label labelClearAll;
    }
}
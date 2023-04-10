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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
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
            listViewTimbres.Location = new Point(43, 229);
            listViewTimbres.MultiSelect = false;
            listViewTimbres.Name = "listViewTimbres";
            listViewTimbres.Size = new Size(159, 710);
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
            labelTimbreNo.Location = new Point(43, 52);
            labelTimbreNo.Name = "labelTimbreNo";
            labelTimbreNo.Size = new Size(74, 15);
            labelTimbreNo.TabIndex = 8;
            labelTimbreNo.Text = "Memory No.";
            // 
            // numericUpDownTimbreNo
            // 
            numericUpDownTimbreNo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            numericUpDownTimbreNo.Location = new Point(129, 45);
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
            buttonCopyTimbre.ForeColor = SystemColors.ActiveCaptionText;
            buttonCopyTimbre.Image = Properties.Resources.Copy;
            buttonCopyTimbre.Location = new Point(43, 131);
            buttonCopyTimbre.Name = "buttonCopyTimbre";
            buttonCopyTimbre.Size = new Size(27, 23);
            buttonCopyTimbre.TabIndex = 58;
            buttonCopyTimbre.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(buttonCopyTimbre, "Copy the selected timbre");
            buttonCopyTimbre.UseVisualStyleBackColor = true;
            buttonCopyTimbre.Click += buttonCopyTimbre_Click;
            // 
            // buttonPasteTimbre
            // 
            buttonPasteTimbre.AccessibleDescription = "Paste timbre";
            buttonPasteTimbre.Enabled = false;
            buttonPasteTimbre.ForeColor = SystemColors.ActiveCaptionText;
            buttonPasteTimbre.Image = Properties.Resources.Paste;
            buttonPasteTimbre.Location = new Point(118, 131);
            buttonPasteTimbre.Name = "buttonPasteTimbre";
            buttonPasteTimbre.Size = new Size(25, 23);
            buttonPasteTimbre.TabIndex = 57;
            buttonPasteTimbre.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(buttonPasteTimbre, "Paste timbre into the selected position");
            buttonPasteTimbre.UseVisualStyleBackColor = true;
            buttonPasteTimbre.Click += buttonPasteTimbre_Click;
            // 
            // buttonClearTimbre
            // 
            buttonClearTimbre.AccessibleDescription = "Clear timbre";
            buttonClearTimbre.AccessibleName = "Clear timbre";
            buttonClearTimbre.ForeColor = SystemColors.ActiveCaptionText;
            buttonClearTimbre.Image = (Image)resources.GetObject("buttonClearTimbre.Image");
            buttonClearTimbre.Location = new Point(43, 160);
            buttonClearTimbre.Name = "buttonClearTimbre";
            buttonClearTimbre.Size = new Size(27, 24);
            buttonClearTimbre.TabIndex = 59;
            buttonClearTimbre.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(buttonClearTimbre, "Clear the selected timbre");
            buttonClearTimbre.UseVisualStyleBackColor = true;
            buttonClearTimbre.Click += buttonClearTimbre_Click;
            // 
            // buttonClearAll
            // 
            buttonClearAll.AccessibleDescription = "Clear All";
            buttonClearAll.AccessibleName = "Clear All";
            buttonClearAll.ForeColor = SystemColors.ActiveCaptionText;
            buttonClearAll.Image = (Image)resources.GetObject("buttonClearAll.Image");
            buttonClearAll.Location = new Point(43, 190);
            buttonClearAll.Name = "buttonClearAll";
            buttonClearAll.Size = new Size(27, 24);
            buttonClearAll.TabIndex = 60;
            buttonClearAll.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(buttonClearAll, "Clear all memory timbres");
            buttonClearAll.UseVisualStyleBackColor = true;
            buttonClearAll.Click += buttonClearAll_Click;
            // 
            // labelHeading
            // 
            labelHeading.AutoSize = true;
            labelHeading.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelHeading.ForeColor = SystemColors.ActiveCaption;
            labelHeading.Location = new Point(35, 9);
            labelHeading.Name = "labelHeading";
            labelHeading.Size = new Size(167, 21);
            labelHeading.TabIndex = 62;
            labelHeading.Text = "Timbre Memory Area";
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 500;
            timer.Tick += timer_Tick;
            // 
            // labelTimbreName
            // 
            labelTimbreName.AutoSize = true;
            labelTimbreName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelTimbreName.ForeColor = SystemColors.Control;
            labelTimbreName.Location = new Point(43, 88);
            labelTimbreName.Name = "labelTimbreName";
            labelTimbreName.Size = new Size(57, 21);
            labelTimbreName.TabIndex = 63;
            labelTimbreName.Text = "[none]";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(71, 135);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 64;
            label1.Text = "Copy";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(143, 135);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 65;
            label2.Text = "Paste";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(71, 165);
            label3.Name = "label3";
            label3.Size = new Size(121, 15);
            label3.TabIndex = 66;
            label3.Text = "Clear Selected Timbre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(71, 195);
            label4.Name = "label4";
            label4.Size = new Size(96, 15);
            label4.TabIndex = 67;
            label4.Text = "Clear All Timbres";
            // 
            // FormMemoryBankEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(239, 960);
            ControlBox = false;
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
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
            MaximumSize = new Size(239, 2160);
            MinimizeBox = false;
            MinimumSize = new Size(239, 460);
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
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
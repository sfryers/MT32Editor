namespace MT32Edit_legacy
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMemoryBankEditor));
            this.listViewTimbres = new System.Windows.Forms.ListView();
            this.columnHeaderTimbreNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTimbreName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelTimbreNo = new System.Windows.Forms.Label();
            this.numericUpDownTimbreNo = new System.Windows.Forms.NumericUpDown();
            this.buttonCopyTimbre = new System.Windows.Forms.Button();
            this.buttonPasteTimbre = new System.Windows.Forms.Button();
            this.buttonClearTimbre = new System.Windows.Forms.Button();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.labelHeading = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.labelTimbreName = new System.Windows.Forms.Label();
            this.labelCopy = new System.Windows.Forms.Label();
            this.labelPaste = new System.Windows.Forms.Label();
            this.labelClearSelected = new System.Windows.Forms.Label();
            this.labelClearAll = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimbreNo)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewTimbres
            // 
            this.listViewTimbres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.listViewTimbres.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTimbreNo,
            this.columnHeaderTimbreName});
            this.listViewTimbres.ForeColor = System.Drawing.SystemColors.Control;
            this.listViewTimbres.FullRowSelect = true;
            this.listViewTimbres.GridLines = true;
            this.listViewTimbres.HideSelection = false;
            this.listViewTimbres.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3});
            this.listViewTimbres.Location = new System.Drawing.Point(12, 222);
            this.listViewTimbres.MinimumSize = new System.Drawing.Size(4, 25);
            this.listViewTimbres.MultiSelect = false;
            this.listViewTimbres.Name = "listViewTimbres";
            this.listViewTimbres.Size = new System.Drawing.Size(165, 424);
            this.listViewTimbres.TabIndex = 2;
            this.listViewTimbres.TileSize = new System.Drawing.Size(50, 20);
            this.listViewTimbres.UseCompatibleStateImageBehavior = false;
            this.listViewTimbres.View = System.Windows.Forms.View.Details;
            this.listViewTimbres.SelectedIndexChanged += new System.EventHandler(this.listViewTimbres_SelectedIndexChanged);
            // 
            // columnHeaderTimbreNo
            // 
            this.columnHeaderTimbreNo.Text = "Mem";
            this.columnHeaderTimbreNo.Width = 48;
            // 
            // columnHeaderTimbreName
            // 
            this.columnHeaderTimbreName.Text = "Timbre Name";
            this.columnHeaderTimbreName.Width = 90;
            // 
            // labelTimbreNo
            // 
            this.labelTimbreNo.AutoSize = true;
            this.labelTimbreNo.ForeColor = System.Drawing.SystemColors.Control;
            this.labelTimbreNo.Location = new System.Drawing.Point(46, 70);
            this.labelTimbreNo.Name = "labelTimbreNo";
            this.labelTimbreNo.Size = new System.Drawing.Size(64, 13);
            this.labelTimbreNo.TabIndex = 8;
            this.labelTimbreNo.Text = "Memory No.";
            // 
            // numericUpDownTimbreNo
            // 
            this.numericUpDownTimbreNo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.numericUpDownTimbreNo.Location = new System.Drawing.Point(119, 64);
            this.numericUpDownTimbreNo.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numericUpDownTimbreNo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTimbreNo.Name = "numericUpDownTimbreNo";
            this.numericUpDownTimbreNo.Size = new System.Drawing.Size(44, 29);
            this.numericUpDownTimbreNo.TabIndex = 7;
            this.numericUpDownTimbreNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTimbreNo.ValueChanged += new System.EventHandler(this.numericUpDownTimbreNo_ValueChanged);
            // 
            // buttonCopyTimbre
            // 
            this.buttonCopyTimbre.AccessibleDescription = "Copy timbre";
            this.buttonCopyTimbre.AccessibleName = "Copy timbre";
            this.buttonCopyTimbre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonCopyTimbre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonCopyTimbre.Image = global::MT32Edit_legacy.Properties.Resources.Copy;
            this.buttonCopyTimbre.Location = new System.Drawing.Point(15, 135);
            this.buttonCopyTimbre.Name = "buttonCopyTimbre";
            this.buttonCopyTimbre.Size = new System.Drawing.Size(24, 24);
            this.buttonCopyTimbre.TabIndex = 58;
            this.buttonCopyTimbre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.buttonCopyTimbre, "Copy the selected timbre");
            this.buttonCopyTimbre.UseVisualStyleBackColor = false;
            this.buttonCopyTimbre.Click += new System.EventHandler(this.buttonCopyTimbre_Click);
            // 
            // buttonPasteTimbre
            // 
            this.buttonPasteTimbre.AccessibleDescription = "Paste timbre";
            this.buttonPasteTimbre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonPasteTimbre.Enabled = false;
            this.buttonPasteTimbre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonPasteTimbre.Image = global::MT32Edit_legacy.Properties.Resources.Paste;
            this.buttonPasteTimbre.Location = new System.Drawing.Point(87, 135);
            this.buttonPasteTimbre.Name = "buttonPasteTimbre";
            this.buttonPasteTimbre.Size = new System.Drawing.Size(24, 24);
            this.buttonPasteTimbre.TabIndex = 57;
            this.buttonPasteTimbre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.buttonPasteTimbre, "Paste timbre into the selected position");
            this.buttonPasteTimbre.UseVisualStyleBackColor = false;
            this.buttonPasteTimbre.Click += new System.EventHandler(this.buttonPasteTimbre_Click);
            // 
            // buttonClearTimbre
            // 
            this.buttonClearTimbre.AccessibleDescription = "Clear timbre";
            this.buttonClearTimbre.AccessibleName = "Clear timbre";
            this.buttonClearTimbre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonClearTimbre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonClearTimbre.Image = ((System.Drawing.Image)(resources.GetObject("buttonClearTimbre.Image")));
            this.buttonClearTimbre.Location = new System.Drawing.Point(15, 161);
            this.buttonClearTimbre.Name = "buttonClearTimbre";
            this.buttonClearTimbre.Size = new System.Drawing.Size(24, 24);
            this.buttonClearTimbre.TabIndex = 59;
            this.buttonClearTimbre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.buttonClearTimbre, "Clear the selected timbre");
            this.buttonClearTimbre.UseVisualStyleBackColor = false;
            this.buttonClearTimbre.Click += new System.EventHandler(this.buttonClearTimbre_Click);
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.AccessibleDescription = "Clear All";
            this.buttonClearAll.AccessibleName = "Clear All";
            this.buttonClearAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonClearAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonClearAll.Image = ((System.Drawing.Image)(resources.GetObject("buttonClearAll.Image")));
            this.buttonClearAll.Location = new System.Drawing.Point(15, 187);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(24, 24);
            this.buttonClearAll.TabIndex = 60;
            this.buttonClearAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.buttonClearAll, "Clear all memory timbres");
            this.buttonClearAll.UseVisualStyleBackColor = false;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // labelHeading
            // 
            this.labelHeading.AutoSize = true;
            this.labelHeading.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelHeading.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelHeading.Location = new System.Drawing.Point(12, 34);
            this.labelHeading.Name = "labelHeading";
            this.labelHeading.Size = new System.Drawing.Size(129, 21);
            this.labelHeading.TabIndex = 62;
            this.labelHeading.Text = "Timbre Memory";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // labelTimbreName
            // 
            this.labelTimbreName.AutoSize = true;
            this.labelTimbreName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelTimbreName.ForeColor = System.Drawing.SystemColors.Control;
            this.labelTimbreName.Location = new System.Drawing.Point(15, 99);
            this.labelTimbreName.Name = "labelTimbreName";
            this.labelTimbreName.Size = new System.Drawing.Size(57, 21);
            this.labelTimbreName.TabIndex = 63;
            this.labelTimbreName.Text = "[none]";
            // 
            // labelCopy
            // 
            this.labelCopy.AutoSize = true;
            this.labelCopy.ForeColor = System.Drawing.SystemColors.Control;
            this.labelCopy.Location = new System.Drawing.Point(40, 141);
            this.labelCopy.Name = "labelCopy";
            this.labelCopy.Size = new System.Drawing.Size(31, 13);
            this.labelCopy.TabIndex = 64;
            this.labelCopy.Text = "Copy";
            // 
            // labelPaste
            // 
            this.labelPaste.AutoSize = true;
            this.labelPaste.ForeColor = System.Drawing.SystemColors.Control;
            this.labelPaste.Location = new System.Drawing.Point(116, 141);
            this.labelPaste.Name = "labelPaste";
            this.labelPaste.Size = new System.Drawing.Size(34, 13);
            this.labelPaste.TabIndex = 65;
            this.labelPaste.Text = "Paste";
            // 
            // labelClearSelected
            // 
            this.labelClearSelected.AutoSize = true;
            this.labelClearSelected.ForeColor = System.Drawing.SystemColors.Control;
            this.labelClearSelected.Location = new System.Drawing.Point(40, 167);
            this.labelClearSelected.Name = "labelClearSelected";
            this.labelClearSelected.Size = new System.Drawing.Size(111, 13);
            this.labelClearSelected.TabIndex = 66;
            this.labelClearSelected.Text = "Clear Selected Timbre";
            // 
            // labelClearAll
            // 
            this.labelClearAll.AutoSize = true;
            this.labelClearAll.ForeColor = System.Drawing.SystemColors.Control;
            this.labelClearAll.Location = new System.Drawing.Point(39, 193);
            this.labelClearAll.Name = "labelClearAll";
            this.labelClearAll.Size = new System.Drawing.Size(85, 13);
            this.labelClearAll.TabIndex = 67;
            this.labelClearAll.Text = "Clear All Timbres";
            // 
            // FormMemoryBankEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(175, 712);
            this.ControlBox = false;
            this.Controls.Add(this.labelClearAll);
            this.Controls.Add(this.labelClearSelected);
            this.Controls.Add(this.labelPaste);
            this.Controls.Add(this.labelCopy);
            this.Controls.Add(this.labelTimbreName);
            this.Controls.Add(this.labelHeading);
            this.Controls.Add(this.buttonClearAll);
            this.Controls.Add(this.buttonClearTimbre);
            this.Controls.Add(this.buttonCopyTimbre);
            this.Controls.Add(this.buttonPasteTimbre);
            this.Controls.Add(this.labelTimbreNo);
            this.Controls.Add(this.numericUpDownTimbreNo);
            this.Controls.Add(this.listViewTimbres);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(175, 130);
            this.Name = "FormMemoryBankEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MT-32 Memory Bank Editor";
            this.Activated += new System.EventHandler(this.FormMemoryBankEditor_Activated);
            this.Resize += new System.EventHandler(this.FormMemoryBankEditor_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimbreNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
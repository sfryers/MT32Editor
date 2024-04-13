namespace MT32Edit
{
    partial class FormSelectMemoryBank
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectMemoryBank));
            labelSelectMemoryBank = new Label();
            comboBoxMemoryBank = new ComboBox();
            buttonOK = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelSelectMemoryBank
            // 
            labelSelectMemoryBank.AutoSize = true;
            labelSelectMemoryBank.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelSelectMemoryBank.ForeColor = SystemColors.ControlLight;
            labelSelectMemoryBank.Location = new Point(12, 18);
            labelSelectMemoryBank.Name = "labelSelectMemoryBank";
            labelSelectMemoryBank.Size = new Size(225, 15);
            labelSelectMemoryBank.TabIndex = 0;
            labelSelectMemoryBank.Text = "Select memory bank slot for AcouPiano1:";
            // 
            // comboBoxMemoryBank
            // 
            comboBoxMemoryBank.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMemoryBank.FormattingEnabled = true;
            comboBoxMemoryBank.Location = new Point(15, 45);
            comboBoxMemoryBank.Name = "comboBoxMemoryBank";
            comboBoxMemoryBank.Size = new Size(172, 23);
            comboBoxMemoryBank.TabIndex = 1;
            comboBoxMemoryBank.SelectedIndexChanged += comboBoxMemoryBank_SelectedIndexChanged;
            // 
            // buttonOK
            // 
            buttonOK.BackColor = Color.FromArgb(224, 224, 224);
            buttonOK.Location = new Point(212, 45);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(71, 25);
            buttonOK.TabIndex = 3;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = false;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.FromArgb(224, 224, 224);
            buttonCancel.Location = new Point(212, 74);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(71, 26);
            buttonCancel.TabIndex = 4;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // FormSelectMemoryBank
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(308, 109);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(comboBoxMemoryBank);
            Controls.Add(labelSelectMemoryBank);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormSelectMemoryBank";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Select Memory Bank";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelSelectMemoryBank;
        private ComboBox comboBoxMemoryBank;
        private Button buttonOK;
        private Button buttonCancel;
    }
}
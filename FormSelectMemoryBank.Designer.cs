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
            labelPresetTimbreName = new Label();
            buttonOK = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelSelectMemoryBank
            // 
            labelSelectMemoryBank.AutoSize = true;
            labelSelectMemoryBank.ForeColor = SystemColors.ControlLight;
            labelSelectMemoryBank.Location = new Point(12, 18);
            labelSelectMemoryBank.Name = "labelSelectMemoryBank";
            labelSelectMemoryBank.Size = new Size(155, 15);
            labelSelectMemoryBank.TabIndex = 0;
            labelSelectMemoryBank.Text = "Select memory bank slot for";
            // 
            // comboBoxMemoryBank
            // 
            comboBoxMemoryBank.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMemoryBank.FormattingEnabled = true;
            comboBoxMemoryBank.Location = new Point(22, 45);
            comboBoxMemoryBank.Name = "comboBoxMemoryBank";
            comboBoxMemoryBank.Size = new Size(145, 23);
            comboBoxMemoryBank.TabIndex = 1;
            comboBoxMemoryBank.SelectedIndexChanged += comboBoxMemoryBank_SelectedIndexChanged;
            // 
            // labelPresetTimbreName
            // 
            labelPresetTimbreName.AutoSize = true;
            labelPresetTimbreName.ForeColor = SystemColors.ControlLightLight;
            labelPresetTimbreName.Location = new Point(164, 18);
            labelPresetTimbreName.Name = "labelPresetTimbreName";
            labelPresetTimbreName.Size = new Size(68, 15);
            labelPresetTimbreName.TabIndex = 2;
            labelPresetTimbreName.Text = "AcouPiano:";
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(173, 45);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(59, 23);
            buttonOK.TabIndex = 3;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(173, 74);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(59, 23);
            buttonCancel.TabIndex = 4;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // FormSelectMemoryBank
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(254, 109);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(labelPresetTimbreName);
            Controls.Add(comboBoxMemoryBank);
            Controls.Add(labelSelectMemoryBank);
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
        private Label labelPresetTimbreName;
        private Button buttonOK;
        private Button buttonCancel;
    }
}
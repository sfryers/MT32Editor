using System.Windows.Forms;
namespace MT32Edit_legacy
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
            this.labelSelectMemoryBank = new System.Windows.Forms.Label();
            this.comboBoxMemoryBank = new System.Windows.Forms.ComboBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelSelectMemoryBank
            // 
            this.labelSelectMemoryBank.AutoSize = true;
            this.labelSelectMemoryBank.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelSelectMemoryBank.Location = new System.Drawing.Point(10, 16);
            this.labelSelectMemoryBank.Name = "labelSelectMemoryBank";
            this.labelSelectMemoryBank.Size = new System.Drawing.Size(201, 13);
            this.labelSelectMemoryBank.TabIndex = 0;
            this.labelSelectMemoryBank.Text = "Select memory bank slot for AcouPiano1:";
            // 
            // comboBoxMemoryBank
            // 
            this.comboBoxMemoryBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMemoryBank.FormattingEnabled = true;
            this.comboBoxMemoryBank.Location = new System.Drawing.Point(13, 39);
            this.comboBoxMemoryBank.Name = "comboBoxMemoryBank";
            this.comboBoxMemoryBank.Size = new System.Drawing.Size(148, 21);
            this.comboBoxMemoryBank.TabIndex = 1;
            this.comboBoxMemoryBank.SelectedIndexChanged += new System.EventHandler(this.comboBoxMemoryBank_SelectedIndexChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonOK.Location = new System.Drawing.Point(201, 37);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(61, 22);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonCancel.Location = new System.Drawing.Point(201, 62);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(61, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormSelectMemoryBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(283, 94);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.comboBoxMemoryBank);
            this.Controls.Add(this.labelSelectMemoryBank);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormSelectMemoryBank";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Memory Bank";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelSelectMemoryBank;
        private ComboBox comboBoxMemoryBank;
        private Button buttonOK;
        private Button buttonCancel;
    }
}
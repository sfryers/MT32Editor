namespace MT32Edit_legacy
{
    partial class FormEnvelopeDiagrams
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEnvelopeDiagrams));
            this.pictureBoxTVATVFEnvDiagram = new System.Windows.Forms.PictureBox();
            this.pictureBoxPitchEnvDiagram = new System.Windows.Forms.PictureBox();
            this.labelPitchEnv = new System.Windows.Forms.Label();
            this.labelTVATVFEnv = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTVATVFEnvDiagram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPitchEnvDiagram)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxTVATVFEnvDiagram
            // 
            this.pictureBoxTVATVFEnvDiagram.Image = global::MT32Edit_legacy.Properties.Resources.TVA_TVF_env_diagram;
            this.pictureBoxTVATVFEnvDiagram.Location = new System.Drawing.Point(12, 170);
            this.pictureBoxTVATVFEnvDiagram.Name = "pictureBoxTVATVFEnvDiagram";
            this.pictureBoxTVATVFEnvDiagram.Size = new System.Drawing.Size(314, 110);
            this.pictureBoxTVATVFEnvDiagram.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTVATVFEnvDiagram.TabIndex = 1;
            this.pictureBoxTVATVFEnvDiagram.TabStop = false;
            // 
            // pictureBoxPitchEnvDiagram
            // 
            this.pictureBoxPitchEnvDiagram.Image = global::MT32Edit_legacy.Properties.Resources.Pitch_env_diagram;
            this.pictureBoxPitchEnvDiagram.Location = new System.Drawing.Point(12, 31);
            this.pictureBoxPitchEnvDiagram.Name = "pictureBoxPitchEnvDiagram";
            this.pictureBoxPitchEnvDiagram.Size = new System.Drawing.Size(314, 110);
            this.pictureBoxPitchEnvDiagram.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPitchEnvDiagram.TabIndex = 0;
            this.pictureBoxPitchEnvDiagram.TabStop = false;
            // 
            // labelPitchEnv
            // 
            this.labelPitchEnv.AutoSize = true;
            this.labelPitchEnv.ForeColor = System.Drawing.Color.Black;
            this.labelPitchEnv.Location = new System.Drawing.Point(9, 15);
            this.labelPitchEnv.Name = "labelPitchEnv";
            this.labelPitchEnv.Size = new System.Drawing.Size(170, 13);
            this.labelPitchEnv.TabIndex = 2;
            this.labelPitchEnv.Text = "Pitch Envelope Graph Parameters:";
            // 
            // labelTVATVFEnv
            // 
            this.labelTVATVFEnv.AutoSize = true;
            this.labelTVATVFEnv.ForeColor = System.Drawing.Color.Black;
            this.labelTVATVFEnv.Location = new System.Drawing.Point(9, 154);
            this.labelTVATVFEnv.Name = "labelTVATVFEnv";
            this.labelTVATVFEnv.Size = new System.Drawing.Size(192, 13);
            this.labelTVATVFEnv.TabIndex = 3;
            this.labelTVATVFEnv.Text = "TVA/TVF Envelope Graph Parameters:";
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonClose.ForeColor = System.Drawing.Color.Black;
            this.buttonClose.Location = new System.Drawing.Point(270, 286);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(56, 25);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // FormEnvelopeDiagrams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(334, 316);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelTVATVFEnv);
            this.Controls.Add(this.labelPitchEnv);
            this.Controls.Add(this.pictureBoxTVATVFEnvDiagram);
            this.Controls.Add(this.pictureBoxPitchEnvDiagram);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(350, 355);
            this.MinimumSize = new System.Drawing.Size(350, 355);
            this.Name = "FormEnvelopeDiagrams";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Envelope Diagrams";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTVATVFEnvDiagram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPitchEnvDiagram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPitchEnvDiagram;
        private System.Windows.Forms.PictureBox pictureBoxTVATVFEnvDiagram;
        private System.Windows.Forms.Label labelPitchEnv;
        private System.Windows.Forms.Label labelTVATVFEnv;
        private System.Windows.Forms.Button buttonClose;
    }
}
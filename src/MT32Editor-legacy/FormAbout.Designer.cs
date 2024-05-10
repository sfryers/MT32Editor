using System.Windows.Forms;
using System.Drawing;
namespace MT32Edit_legacy
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.label1 = new System.Windows.Forms.Label();
            this.labelVersionNo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelReleaseDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.linkLabelProject = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelFramework = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "MT-32 Editor";
            // 
            // labelVersionNo
            // 
            this.labelVersionNo.AutoSize = true;
            this.labelVersionNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelVersionNo.Location = new System.Drawing.Point(163, 15);
            this.labelVersionNo.Name = "labelVersionNo";
            this.labelVersionNo.Size = new System.Drawing.Size(59, 13);
            this.labelVersionNo.TabIndex = 1;
            this.labelVersionNo.Text = "version no.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(10, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = " by S. Fryers";
            // 
            // labelReleaseDate
            // 
            this.labelReleaseDate.AutoSize = true;
            this.labelReleaseDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelReleaseDate.Location = new System.Drawing.Point(163, 45);
            this.labelReleaseDate.Name = "labelReleaseDate";
            this.labelReleaseDate.Size = new System.Drawing.Size(65, 13);
            this.labelReleaseDate.TabIndex = 3;
            this.labelReleaseDate.Text = "release date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(12, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Licenced under GPL 3.0";
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonClose.Location = new System.Drawing.Point(231, 138);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(46, 20);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // linkLabelProject
            // 
            this.linkLabelProject.AutoSize = true;
            this.linkLabelProject.Location = new System.Drawing.Point(12, 115);
            this.linkLabelProject.Name = "linkLabelProject";
            this.linkLabelProject.Size = new System.Drawing.Size(190, 13);
            this.linkLabelProject.TabIndex = 8;
            this.linkLabelProject.TabStop = true;
            this.linkLabelProject.Text = "https://github.com/sfryers/MT32Editor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "A patch/timbre editor and SysEx librarian for";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(218, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "MT-32/CM-32L and compatible synthesizers.";
            // 
            // labelFramework
            // 
            this.labelFramework.AutoSize = true;
            this.labelFramework.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelFramework.Location = new System.Drawing.Point(163, 29);
            this.labelFramework.Name = "labelFramework";
            this.labelFramework.Size = new System.Drawing.Size(56, 13);
            this.labelFramework.TabIndex = 11;
            this.labelFramework.Text = "framework";
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(290, 167);
            this.Controls.Add(this.labelFramework);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabelProject);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelReleaseDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelVersionNo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About MT-32 Editor";
            this.Load += new System.EventHandler(this.FormAbout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label labelVersionNo;
        private Label label3;
        private Label labelReleaseDate;
        private Label label5;
        private Button buttonClose;
        private LinkLabel linkLabelProject;
        private Label label2;
        private Label label6;
        private Label labelFramework;
    }
}
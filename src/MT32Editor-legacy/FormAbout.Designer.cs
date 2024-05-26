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
            this.labelVersionNo = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelReleaseDate = new System.Windows.Forms.Label();
            this.labelLicence = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.linkLabelProject = new System.Windows.Forms.LinkLabel();
            this.labelDescriptionLine1 = new System.Windows.Forms.Label();
            this.labelDescriptionLine2 = new System.Windows.Forms.Label();
            this.labelFramework = new System.Windows.Forms.Label();
            this.pictureBoxMT32EditorLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMT32EditorLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelVersionNo
            // 
            this.labelVersionNo.AutoSize = true;
            this.labelVersionNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelVersionNo.Location = new System.Drawing.Point(99, 12);
            this.labelVersionNo.Name = "labelVersionNo";
            this.labelVersionNo.Size = new System.Drawing.Size(59, 13);
            this.labelVersionNo.TabIndex = 1;
            this.labelVersionNo.Text = "version no.";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelAuthor.Location = new System.Drawing.Point(9, 75);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(65, 13);
            this.labelAuthor.TabIndex = 2;
            this.labelAuthor.Text = " by S. Fryers";
            // 
            // labelReleaseDate
            // 
            this.labelReleaseDate.AutoSize = true;
            this.labelReleaseDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelReleaseDate.Location = new System.Drawing.Point(99, 42);
            this.labelReleaseDate.Name = "labelReleaseDate";
            this.labelReleaseDate.Size = new System.Drawing.Size(65, 13);
            this.labelReleaseDate.TabIndex = 3;
            this.labelReleaseDate.Text = "release date";
            // 
            // labelLicence
            // 
            this.labelLicence.AutoSize = true;
            this.labelLicence.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelLicence.Location = new System.Drawing.Point(12, 129);
            this.labelLicence.Name = "labelLicence";
            this.labelLicence.Size = new System.Drawing.Size(123, 13);
            this.labelLicence.TabIndex = 4;
            this.labelLicence.Text = "Licenced under GPL 3.0";
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonClose.ForeColor = System.Drawing.Color.Black;
            this.buttonClose.Location = new System.Drawing.Point(187, 162);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(51, 23);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // linkLabelProject
            // 
            this.linkLabelProject.AutoSize = true;
            this.linkLabelProject.Location = new System.Drawing.Point(12, 142);
            this.linkLabelProject.Name = "linkLabelProject";
            this.linkLabelProject.Size = new System.Drawing.Size(190, 13);
            this.linkLabelProject.TabIndex = 8;
            this.linkLabelProject.TabStop = true;
            this.linkLabelProject.Text = "https://github.com/sfryers/MT32Editor";
            this.linkLabelProject.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelProject_LinkClicked);
            // 
            // labelDescriptionLine1
            // 
            this.labelDescriptionLine1.AutoSize = true;
            this.labelDescriptionLine1.Location = new System.Drawing.Point(12, 94);
            this.labelDescriptionLine1.Name = "labelDescriptionLine1";
            this.labelDescriptionLine1.Size = new System.Drawing.Size(213, 13);
            this.labelDescriptionLine1.TabIndex = 9;
            this.labelDescriptionLine1.Text = "A patch/timbre editor and SysEx librarian for";
            // 
            // labelDescriptionLine2
            // 
            this.labelDescriptionLine2.AutoSize = true;
            this.labelDescriptionLine2.Location = new System.Drawing.Point(12, 107);
            this.labelDescriptionLine2.Name = "labelDescriptionLine2";
            this.labelDescriptionLine2.Size = new System.Drawing.Size(219, 13);
            this.labelDescriptionLine2.TabIndex = 10;
            this.labelDescriptionLine2.Text = "MT-32, CM-32L and compatible synthesizers.";
            // 
            // labelFramework
            // 
            this.labelFramework.AutoSize = true;
            this.labelFramework.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelFramework.Location = new System.Drawing.Point(99, 26);
            this.labelFramework.Name = "labelFramework";
            this.labelFramework.Size = new System.Drawing.Size(56, 13);
            this.labelFramework.TabIndex = 11;
            this.labelFramework.Text = "framework";
            // 
            // pictureBoxMT32EditorLogo
            // 
            this.pictureBoxMT32EditorLogo.Image = global::MT32Edit_legacy.Properties.Resources.MT32Editor;
            this.pictureBoxMT32EditorLogo.Location = new System.Drawing.Point(15, 12);
            this.pictureBoxMT32EditorLogo.Name = "pictureBoxMT32EditorLogo";
            this.pictureBoxMT32EditorLogo.Size = new System.Drawing.Size(62, 59);
            this.pictureBoxMT32EditorLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMT32EditorLogo.TabIndex = 12;
            this.pictureBoxMT32EditorLogo.TabStop = false;
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(246, 193);
            this.Controls.Add(this.pictureBoxMT32EditorLogo);
            this.Controls.Add(this.labelFramework);
            this.Controls.Add(this.labelDescriptionLine2);
            this.Controls.Add(this.labelDescriptionLine1);
            this.Controls.Add(this.linkLabelProject);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelLicence);
            this.Controls.Add(this.labelReleaseDate);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.labelVersionNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About MT-32 Editor";
            this.Load += new System.EventHandler(this.FormAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMT32EditorLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label labelVersionNo;
        private Label labelAuthor;
        private Label labelReleaseDate;
        private Label labelLicence;
        private Button buttonClose;
        private LinkLabel linkLabelProject;
        private Label labelDescriptionLine1;
        private Label labelDescriptionLine2;
        private Label labelFramework;
        private PictureBox pictureBoxMT32EditorLogo;
    }
}
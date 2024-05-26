namespace MT32Edit
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
            labelVersionNo = new Label();
            labelAuthor = new Label();
            labelReleaseDate = new Label();
            labelLicense = new Label();
            buttonClose = new Button();
            linkLabelProject = new LinkLabel();
            labelDescriptionLine1 = new Label();
            labelDescriptionLine2 = new Label();
            labelFramework = new Label();
            pictureBoxMT32EditorLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMT32EditorLogo).BeginInit();
            SuspendLayout();
            // 
            // labelVersionNo
            // 
            labelVersionNo.AutoSize = true;
            labelVersionNo.ForeColor = SystemColors.ActiveCaptionText;
            labelVersionNo.Location = new Point(161, 17);
            labelVersionNo.Name = "labelVersionNo";
            labelVersionNo.Size = new Size(65, 15);
            labelVersionNo.TabIndex = 1;
            labelVersionNo.Text = "version no.";
            // 
            // labelAuthor
            // 
            labelAuthor.AutoSize = true;
            labelAuthor.ForeColor = SystemColors.ControlLightLight;
            labelAuthor.Location = new Point(13, 147);
            labelAuthor.Name = "labelAuthor";
            labelAuthor.Size = new Size(69, 15);
            labelAuthor.TabIndex = 2;
            labelAuthor.Text = " by S. Fryers";
            // 
            // labelReleaseDate
            // 
            labelReleaseDate.AutoSize = true;
            labelReleaseDate.ForeColor = SystemColors.ActiveCaptionText;
            labelReleaseDate.Location = new Point(161, 52);
            labelReleaseDate.Name = "labelReleaseDate";
            labelReleaseDate.Size = new Size(69, 15);
            labelReleaseDate.TabIndex = 3;
            labelReleaseDate.Text = "release date";
            // 
            // labelLicense
            // 
            labelLicense.AutoSize = true;
            labelLicense.ForeColor = SystemColors.ActiveCaptionText;
            labelLicense.Location = new Point(17, 213);
            labelLicense.Name = "labelLicense";
            labelLicense.Size = new Size(130, 15);
            labelLicense.TabIndex = 4;
            labelLicense.Text = "Licenced under GPL 3.0";
            // 
            // buttonClose
            // 
            buttonClose.BackColor = Color.FromArgb(224, 224, 224);
            buttonClose.Location = new Point(240, 251);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(54, 23);
            buttonClose.TabIndex = 7;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += ButtonClose_Click;
            // 
            // linkLabelProject
            // 
            linkLabelProject.AutoSize = true;
            linkLabelProject.Location = new Point(17, 228);
            linkLabelProject.Name = "linkLabelProject";
            linkLabelProject.Size = new Size(213, 15);
            linkLabelProject.TabIndex = 8;
            linkLabelProject.TabStop = true;
            linkLabelProject.Text = "https://github.com/sfryers/MT32Editor";
            linkLabelProject.LinkClicked += LinkLabelProject_LinkClicked;
            // 
            // labelDescriptionLine1
            // 
            labelDescriptionLine1.AutoSize = true;
            labelDescriptionLine1.Location = new Point(17, 172);
            labelDescriptionLine1.Name = "labelDescriptionLine1";
            labelDescriptionLine1.Size = new Size(241, 15);
            labelDescriptionLine1.TabIndex = 9;
            labelDescriptionLine1.Text = "A patch/timbre editor and SysEx librarian for";
            // 
            // labelDescriptionLine2
            // 
            labelDescriptionLine2.AutoSize = true;
            labelDescriptionLine2.Location = new Point(17, 187);
            labelDescriptionLine2.Name = "labelDescriptionLine2";
            labelDescriptionLine2.Size = new Size(244, 15);
            labelDescriptionLine2.TabIndex = 10;
            labelDescriptionLine2.Text = "MT-32, CM-32L and compatible synthesizers.";
            // 
            // labelFramework
            // 
            labelFramework.AutoSize = true;
            labelFramework.ForeColor = SystemColors.ActiveCaptionText;
            labelFramework.Location = new Point(161, 34);
            labelFramework.Name = "labelFramework";
            labelFramework.Size = new Size(64, 15);
            labelFramework.TabIndex = 11;
            labelFramework.Text = "framework";
            // 
            // pictureBoxMT32EditorLogo
            // 
            pictureBoxMT32EditorLogo.AccessibleDescription = "MT32 Editor logo";
            pictureBoxMT32EditorLogo.AccessibleName = "MT32 Editor";
            pictureBoxMT32EditorLogo.Image = Properties.Resources.MT32Editor;
            pictureBoxMT32EditorLogo.Location = new Point(17, 18);
            pictureBoxMT32EditorLogo.Name = "pictureBoxMT32EditorLogo";
            pictureBoxMT32EditorLogo.Size = new Size(123, 122);
            pictureBoxMT32EditorLogo.TabIndex = 12;
            pictureBoxMT32EditorLogo.TabStop = false;
            // 
            // FormAbout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(160, 160, 150);
            ClientSize = new Size(306, 286);
            Controls.Add(pictureBoxMT32EditorLogo);
            Controls.Add(labelFramework);
            Controls.Add(labelDescriptionLine2);
            Controls.Add(labelDescriptionLine1);
            Controls.Add(linkLabelProject);
            Controls.Add(buttonClose);
            Controls.Add(labelLicense);
            Controls.Add(labelReleaseDate);
            Controls.Add(labelAuthor);
            Controls.Add(labelVersionNo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormAbout";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "About MT-32 Editor";
            Load += FormAbout_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxMT32EditorLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelVersionNo;
        private Label labelAuthor;
        private Label labelReleaseDate;
        private Label labelLicense;
        private Button buttonClose;
        private LinkLabel linkLabelProject;
        private Label labelDescriptionLine1;
        private Label labelDescriptionLine2;
        private Label labelFramework;
        private PictureBox pictureBoxMT32EditorLogo;
    }
}
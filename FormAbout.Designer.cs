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
            label1 = new Label();
            labelVersionNo = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            buttonClose = new Button();
            linkLabelProject = new LinkLabel();
            label2 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(130, 25);
            label1.TabIndex = 0;
            label1.Text = "MT-32 Editor";
            // 
            // labelVersionNo
            // 
            labelVersionNo.AutoSize = true;
            labelVersionNo.ForeColor = SystemColors.ActiveCaptionText;
            labelVersionNo.Location = new Point(179, 17);
            labelVersionNo.Name = "labelVersionNo";
            labelVersionNo.Size = new Size(78, 15);
            labelVersionNo.TabIndex = 1;
            labelVersionNo.Text = "version 0.9.0a";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(12, 34);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 2;
            label3.Text = " by S. Fryers";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(198, 34);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 3;
            label4.Text = "April 2023";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(17, 105);
            label5.Name = "label5";
            label5.Size = new Size(130, 15);
            label5.TabIndex = 4;
            label5.Text = "Licenced under GPL 3.0";
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(216, 146);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(46, 23);
            buttonClose.TabIndex = 7;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // linkLabelProject
            // 
            linkLabelProject.AutoSize = true;
            linkLabelProject.Location = new Point(17, 120);
            linkLabelProject.Name = "linkLabelProject";
            linkLabelProject.Size = new Size(213, 15);
            linkLabelProject.TabIndex = 8;
            linkLabelProject.TabStop = true;
            linkLabelProject.Text = "https://github.com/sfryers/MT32Editor";
            linkLabelProject.LinkClicked += linkLabelProject_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 64);
            label2.Name = "label2";
            label2.Size = new Size(241, 15);
            label2.TabIndex = 9;
            label2.Text = "A patch/timbre editor and SysEx librarian for";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 79);
            label6.Name = "label6";
            label6.Size = new Size(243, 15);
            label6.TabIndex = 10;
            label6.Text = "MT-32/CM-32L and compatible synthesizers.";
            // 
            // FormAbout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(160, 160, 150);
            ClientSize = new Size(274, 181);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(linkLabelProject);
            Controls.Add(buttonClose);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(labelVersionNo);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormAbout";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "About MT-32 Editor";
            Load += FormAbout_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label labelVersionNo;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button buttonClose;
        private LinkLabel linkLabelProject;
        private Label label2;
        private Label label6;
    }
}
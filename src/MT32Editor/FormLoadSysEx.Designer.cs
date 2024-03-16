namespace MT32Edit
{
    partial class FormLoadSysEx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoadSysEx));
            progressBar = new ProgressBar();
            labelLoadProgress = new Label();
            timer = new System.Windows.Forms.Timer(components);
            buttonClose = new Button();
            labelMT32Text1 = new Label();
            labelMT32Text2 = new Label();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(12, 38);
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Maximum = 72;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(312, 23);
            progressBar.TabIndex = 0;
            // 
            // labelLoadProgress
            // 
            labelLoadProgress.AutoSize = true;
            labelLoadProgress.ForeColor = SystemColors.Control;
            labelLoadProgress.Location = new Point(12, 74);
            labelLoadProgress.Name = "labelLoadProgress";
            labelLoadProgress.Size = new Size(120, 15);
            labelLoadProgress.TabIndex = 1;
            labelLoadProgress.Text = "Uploading SysEx data";
            // 
            // timer
            // 
            timer.Interval = 50;
            timer.Tick += timer_Tick;
            // 
            // buttonClose
            // 
            buttonClose.BackColor = Color.FromArgb(224, 224, 224);
            buttonClose.Location = new Point(274, 68);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(50, 26);
            buttonClose.TabIndex = 2;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Visible = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // labelMT32Text1
            // 
            labelMT32Text1.AutoSize = true;
            labelMT32Text1.ForeColor = SystemColors.ControlLightLight;
            labelMT32Text1.Location = new Point(12, 9);
            labelMT32Text1.Name = "labelMT32Text1";
            labelMT32Text1.Size = new Size(42, 15);
            labelMT32Text1.TabIndex = 3;
            labelMT32Text1.Text = "[none]";
            // 
            // labelMT32Text2
            // 
            labelMT32Text2.AutoSize = true;
            labelMT32Text2.ForeColor = SystemColors.ControlLightLight;
            labelMT32Text2.Location = new Point(159, 9);
            labelMT32Text2.Name = "labelMT32Text2";
            labelMT32Text2.Size = new Size(42, 15);
            labelMT32Text2.TabIndex = 4;
            labelMT32Text2.Text = "[none]";
            // 
            // FormLoadSysEx
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(48, 48, 48);
            ClientSize = new Size(336, 103);
            Controls.Add(labelMT32Text2);
            Controls.Add(labelMT32Text1);
            Controls.Add(buttonClose);
            Controls.Add(labelLoadProgress);
            Controls.Add(progressBar);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormLoadSysEx";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Uploading SysEx Data";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar;
        private Label labelLoadProgress;
        private System.Windows.Forms.Timer timer;
        private Button buttonClose;
        private Label labelMT32Text1;
        private Label labelMT32Text2;
    }
}
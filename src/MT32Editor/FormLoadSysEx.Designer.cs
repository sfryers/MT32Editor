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
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(12, 12);
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
            labelLoadProgress.Location = new Point(12, 48);
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
            buttonClose.Location = new Point(280, 42);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(44, 26);
            buttonClose.TabIndex = 2;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Visible = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // FormLoadSysEx
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(48, 48, 48);
            ClientSize = new Size(336, 72);
            Controls.Add(buttonClose);
            Controls.Add(labelLoadProgress);
            Controls.Add(progressBar);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormLoadSysEx";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Uploading SysEx File";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar;
        private Label labelLoadProgress;
        private System.Windows.Forms.Timer timer;
        private Button buttonClose;
    }
}
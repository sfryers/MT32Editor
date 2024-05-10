using System.Windows.Forms;
using System.Drawing;
namespace MT32Edit_legacy
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoadSysEx));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelLoadProgress = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelMT32Text1 = new System.Windows.Forms.Label();
            this.labelMT32Text2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(10, 33);
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.progressBar.Maximum = 72;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(267, 20);
            this.progressBar.TabIndex = 0;
            // 
            // labelLoadProgress
            // 
            this.labelLoadProgress.AutoSize = true;
            this.labelLoadProgress.ForeColor = System.Drawing.SystemColors.Control;
            this.labelLoadProgress.Location = new System.Drawing.Point(10, 64);
            this.labelLoadProgress.Name = "labelLoadProgress";
            this.labelLoadProgress.Size = new System.Drawing.Size(111, 13);
            this.labelLoadProgress.TabIndex = 1;
            this.labelLoadProgress.Text = "Uploading SysEx data";
            // 
            // timer
            // 
            this.timer.Interval = 50;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonClose.Location = new System.Drawing.Point(228, 59);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(50, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Visible = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelMT32Text1
            // 
            this.labelMT32Text1.AutoSize = true;
            this.labelMT32Text1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelMT32Text1.Location = new System.Drawing.Point(10, 8);
            this.labelMT32Text1.Name = "labelMT32Text1";
            this.labelMT32Text1.Size = new System.Drawing.Size(37, 13);
            this.labelMT32Text1.TabIndex = 3;
            this.labelMT32Text1.Text = "[none]";
            // 
            // labelMT32Text2
            // 
            this.labelMT32Text2.AutoSize = true;
            this.labelMT32Text2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelMT32Text2.Location = new System.Drawing.Point(136, 8);
            this.labelMT32Text2.Name = "labelMT32Text2";
            this.labelMT32Text2.Size = new System.Drawing.Size(37, 13);
            this.labelMT32Text2.TabIndex = 4;
            this.labelMT32Text2.Text = "[none]";
            // 
            // FormLoadSysEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(288, 89);
            this.Controls.Add(this.labelMT32Text2);
            this.Controls.Add(this.labelMT32Text1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelLoadProgress);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormLoadSysEx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Uploading SysEx Data";
            this.ResumeLayout(false);
            this.PerformLayout();

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
using System.Windows.Forms;
namespace MT32Edit_legacy
{
    partial class FormMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainMenu));
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSysExFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSysExFileAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSysExToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadTimbreFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTimbreFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllTimbresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patchEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rhythmEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timbreEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autosaveEvery5MinutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ignoreSysConfigOnLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excludeSysConfigonSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardwareMT32ConnectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMessagesToMT32DisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allowMT32ResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verboseConsoleMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MidiInLabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.midiInToolStripMenuItem = new System.Windows.Forms.ToolStripComboBox();
            this.MidiOutLabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.midiOutToolStripMenuItem = new System.Windows.Forms.ToolStripComboBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timerAutoSave = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip.AutoSize = false;
            this.menuStrip.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem1,
            this.MidiInLabelToolStripMenuItem,
            this.midiInToolStripMenuItem,
            this.MidiOutLabelToolStripMenuItem,
            this.midiOutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(1, 1);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1351, 26);
            this.menuStrip.Stretch = false;
            this.menuStrip.TabIndex = 40;
            this.menuStrip.Text = "menuStrip";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadSysExFileToolStripMenuItem,
            this.saveSysExFileAsToolStripMenuItem,
            this.saveSysExToolStripMenuItem,
            this.toolStripSeparator1,
            this.loadTimbreFileToolStripMenuItem,
            this.saveTimbreFileToolStripMenuItem,
            this.saveAllTimbresToolStripMenuItem,
            this.toolStripSeparator2,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadSysExFileToolStripMenuItem
            // 
            this.loadSysExFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadSysExFileToolStripMenuItem.Image")));
            this.loadSysExFileToolStripMenuItem.Name = "loadSysExFileToolStripMenuItem";
            this.loadSysExFileToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.loadSysExFileToolStripMenuItem.Text = "Load SysEx File";
            this.loadSysExFileToolStripMenuItem.Click += new System.EventHandler(this.loadSysExFileToolStripMenuItem_Click);
            // 
            // saveSysExFileAsToolStripMenuItem
            // 
            this.saveSysExFileAsToolStripMenuItem.Image = global::MT32Edit_legacy.Properties.Resources.SaveAs;
            this.saveSysExFileAsToolStripMenuItem.Name = "saveSysExFileAsToolStripMenuItem";
            this.saveSysExFileAsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.saveSysExFileAsToolStripMenuItem.Text = "Save SysEx File As..";
            this.saveSysExFileAsToolStripMenuItem.Click += new System.EventHandler(this.saveSysExFileAsToolStripMenuItem_Click);
            // 
            // saveSysExToolStripMenuItem
            // 
            this.saveSysExToolStripMenuItem.Enabled = false;
            this.saveSysExToolStripMenuItem.Image = global::MT32Edit_legacy.Properties.Resources.Save;
            this.saveSysExToolStripMenuItem.Name = "saveSysExToolStripMenuItem";
            this.saveSysExToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.saveSysExToolStripMenuItem.Text = "Save SysEx File";
            this.saveSysExToolStripMenuItem.Click += new System.EventHandler(this.saveSysExToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // loadTimbreFileToolStripMenuItem
            // 
            this.loadTimbreFileToolStripMenuItem.Image = global::MT32Edit_legacy.Properties.Resources.Open;
            this.loadTimbreFileToolStripMenuItem.Name = "loadTimbreFileToolStripMenuItem";
            this.loadTimbreFileToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.loadTimbreFileToolStripMenuItem.Text = "Load Timbre File";
            this.loadTimbreFileToolStripMenuItem.Click += new System.EventHandler(this.loadTimbreFileToolStripMenuItem_Click);
            // 
            // saveTimbreFileToolStripMenuItem
            // 
            this.saveTimbreFileToolStripMenuItem.Image = global::MT32Edit_legacy.Properties.Resources.Save;
            this.saveTimbreFileToolStripMenuItem.Name = "saveTimbreFileToolStripMenuItem";
            this.saveTimbreFileToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.saveTimbreFileToolStripMenuItem.Text = "Save Timbre File";
            this.saveTimbreFileToolStripMenuItem.Click += new System.EventHandler(this.saveTimbreFileToolStripMenuItem_Click);
            // 
            // saveAllTimbresToolStripMenuItem
            // 
            this.saveAllTimbresToolStripMenuItem.Name = "saveAllTimbresToolStripMenuItem";
            this.saveAllTimbresToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.saveAllTimbresToolStripMenuItem.Text = "Save All Timbres";
            this.saveAllTimbresToolStripMenuItem.Click += new System.EventHandler(this.saveAllTimbresToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(170, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.closeToolStripMenuItem.Text = "Exit";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patchEditorToolStripMenuItem,
            this.rhythmEditorToolStripMenuItem,
            this.timbreEditorToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // patchEditorToolStripMenuItem
            // 
            this.patchEditorToolStripMenuItem.Checked = true;
            this.patchEditorToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.patchEditorToolStripMenuItem.Name = "patchEditorToolStripMenuItem";
            this.patchEditorToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.patchEditorToolStripMenuItem.Text = "Patch Editor";
            this.patchEditorToolStripMenuItem.Click += new System.EventHandler(this.patchEditorToolStripMenuItem_Click);
            // 
            // rhythmEditorToolStripMenuItem
            // 
            this.rhythmEditorToolStripMenuItem.Name = "rhythmEditorToolStripMenuItem";
            this.rhythmEditorToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.rhythmEditorToolStripMenuItem.Text = "Rhythm Bank Editor";
            this.rhythmEditorToolStripMenuItem.Click += new System.EventHandler(this.rhythmEditorToolStripMenuItem_Click);
            // 
            // timbreEditorToolStripMenuItem
            // 
            this.timbreEditorToolStripMenuItem.Name = "timbreEditorToolStripMenuItem";
            this.timbreEditorToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.timbreEditorToolStripMenuItem.Text = "Timbre Editor";
            this.timbreEditorToolStripMenuItem.CheckedChanged += new System.EventHandler(this.timbreEditorToolStripMenuItem_CheckedChanged);
            this.timbreEditorToolStripMenuItem.Click += new System.EventHandler(this.timbreEditorToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterSettingsToolStripMenuItem,
            this.autosaveEvery5MinutesToolStripMenuItem,
            this.ignoreSysConfigOnLoadToolStripMenuItem,
            this.excludeSysConfigonSaveToolStripMenuItem,
            this.hardwareMT32ConnectedToolStripMenuItem,
            this.sendMessagesToMT32DisplayToolStripMenuItem,
            this.allowMT32ResetToolStripMenuItem,
            this.darkModeToolStripMenuItem,
            this.showConsoleToolStripMenuItem,
            this.verboseConsoleMessagesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // masterSettingsToolStripMenuItem
            // 
            this.masterSettingsToolStripMenuItem.Image = global::MT32Edit_legacy.Properties.Resources.Settings;
            this.masterSettingsToolStripMenuItem.Name = "masterSettingsToolStripMenuItem";
            this.masterSettingsToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.masterSettingsToolStripMenuItem.Text = "System area settings";
            this.masterSettingsToolStripMenuItem.Click += new System.EventHandler(this.masterSettingsToolStripMenuItem_Click);
            // 
            // autosaveEvery5MinutesToolStripMenuItem
            // 
            this.autosaveEvery5MinutesToolStripMenuItem.Checked = true;
            this.autosaveEvery5MinutesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autosaveEvery5MinutesToolStripMenuItem.Name = "autosaveEvery5MinutesToolStripMenuItem";
            this.autosaveEvery5MinutesToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.autosaveEvery5MinutesToolStripMenuItem.Text = "Autosave every 5 minutes";
            this.autosaveEvery5MinutesToolStripMenuItem.ToolTipText = "Saves current status to autosave.syx";
            this.autosaveEvery5MinutesToolStripMenuItem.Click += new System.EventHandler(this.autosaveEvery5MinutesToolStripMenuItem_Click);
            // 
            // ignoreSysConfigOnLoadToolStripMenuItem
            // 
            this.ignoreSysConfigOnLoadToolStripMenuItem.Name = "ignoreSysConfigOnLoadToolStripMenuItem";
            this.ignoreSysConfigOnLoadToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.ignoreSysConfigOnLoadToolStripMenuItem.Text = "Ignore system config messages when loading SysEx file";
            this.ignoreSysConfigOnLoadToolStripMenuItem.Click += new System.EventHandler(this.ignoreSysConfigOnLoadToolStripMenuItem_Click);
            // 
            // excludeSysConfigonSaveToolStripMenuItem
            // 
            this.excludeSysConfigonSaveToolStripMenuItem.Name = "excludeSysConfigonSaveToolStripMenuItem";
            this.excludeSysConfigonSaveToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.excludeSysConfigonSaveToolStripMenuItem.Text = "Exclude system config messages when saving SysEx file";
            this.excludeSysConfigonSaveToolStripMenuItem.Click += new System.EventHandler(this.excludeSysConfigonSaveToolStripMenuItem_Click);
            // 
            // hardwareMT32ConnectedToolStripMenuItem
            // 
            this.hardwareMT32ConnectedToolStripMenuItem.Checked = true;
            this.hardwareMT32ConnectedToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hardwareMT32ConnectedToolStripMenuItem.Name = "hardwareMT32ConnectedToolStripMenuItem";
            this.hardwareMT32ConnectedToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.hardwareMT32ConnectedToolStripMenuItem.Text = "Hardware MT-32 connected";
            this.hardwareMT32ConnectedToolStripMenuItem.Click += new System.EventHandler(this.hardwareMT32ConnectedToolStripMenuItem_Click);
            // 
            // sendMessagesToMT32DisplayToolStripMenuItem
            // 
            this.sendMessagesToMT32DisplayToolStripMenuItem.Checked = true;
            this.sendMessagesToMT32DisplayToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sendMessagesToMT32DisplayToolStripMenuItem.Name = "sendMessagesToMT32DisplayToolStripMenuItem";
            this.sendMessagesToMT32DisplayToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.sendMessagesToMT32DisplayToolStripMenuItem.Text = "Send info to MT-32 display";
            this.sendMessagesToMT32DisplayToolStripMenuItem.Click += new System.EventHandler(this.sendMessagesToMT32DisplayToolStripMenuItem_Click);
            // 
            // allowMT32ResetToolStripMenuItem
            // 
            this.allowMT32ResetToolStripMenuItem.Name = "allowMT32ResetToolStripMenuItem";
            this.allowMT32ResetToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.allowMT32ResetToolStripMenuItem.Text = "Allow MT-32 reset from SysEx";
            this.allowMT32ResetToolStripMenuItem.Click += new System.EventHandler(this.allowMT32ResetToolStripMenuItem_Click);
            // 
            // darkModeToolStripMenuItem
            // 
            this.darkModeToolStripMenuItem.Name = "darkModeToolStripMenuItem";
            this.darkModeToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.darkModeToolStripMenuItem.Text = "Dark mode";
            this.darkModeToolStripMenuItem.Click += new System.EventHandler(this.darkModeToolStripMenuItem_Click);
            // 
            // showConsoleToolStripMenuItem
            // 
            this.showConsoleToolStripMenuItem.Checked = true;
            this.showConsoleToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showConsoleToolStripMenuItem.Name = "showConsoleToolStripMenuItem";
            this.showConsoleToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.showConsoleToolStripMenuItem.Text = "Show console";
            this.showConsoleToolStripMenuItem.Click += new System.EventHandler(this.showConsoleToolStripMenuItem_Click);
            // 
            // verboseConsoleMessagesToolStripMenuItem
            // 
            this.verboseConsoleMessagesToolStripMenuItem.Name = "verboseConsoleMessagesToolStripMenuItem";
            this.verboseConsoleMessagesToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.verboseConsoleMessagesToolStripMenuItem.Text = "Verbose console messages";
            this.verboseConsoleMessagesToolStripMenuItem.Click += new System.EventHandler(this.verboseConsoleMessagesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(44, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MidiInLabelToolStripMenuItem
            // 
            this.MidiInLabelToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MidiInLabelToolStripMenuItem.Enabled = false;
            this.MidiInLabelToolStripMenuItem.Margin = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.MidiInLabelToolStripMenuItem.Name = "MidiInLabelToolStripMenuItem";
            this.MidiInLabelToolStripMenuItem.Size = new System.Drawing.Size(57, 22);
            this.MidiInLabelToolStripMenuItem.Text = "MIDI In";
            // 
            // midiInToolStripMenuItem
            // 
            this.midiInToolStripMenuItem.AutoSize = false;
            this.midiInToolStripMenuItem.CausesValidation = false;
            this.midiInToolStripMenuItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.midiInToolStripMenuItem.DropDownWidth = 200;
            this.midiInToolStripMenuItem.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.midiInToolStripMenuItem.MaxDropDownItems = 10;
            this.midiInToolStripMenuItem.Name = "midiInToolStripMenuItem";
            this.midiInToolStripMenuItem.Size = new System.Drawing.Size(215, 23);
            this.midiInToolStripMenuItem.DropDownClosed += new System.EventHandler(this.midiInToolStripMenuItem_DropDownClosed);
            // 
            // MidiOutLabelToolStripMenuItem
            // 
            this.MidiOutLabelToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MidiOutLabelToolStripMenuItem.Enabled = false;
            this.MidiOutLabelToolStripMenuItem.Margin = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.MidiOutLabelToolStripMenuItem.Name = "MidiOutLabelToolStripMenuItem";
            this.MidiOutLabelToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            this.MidiOutLabelToolStripMenuItem.Text = "MIDI Out";
            // 
            // midiOutToolStripMenuItem
            // 
            this.midiOutToolStripMenuItem.AutoSize = false;
            this.midiOutToolStripMenuItem.CausesValidation = false;
            this.midiOutToolStripMenuItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.midiOutToolStripMenuItem.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.midiOutToolStripMenuItem.MaxDropDownItems = 10;
            this.midiOutToolStripMenuItem.Name = "midiOutToolStripMenuItem";
            this.midiOutToolStripMenuItem.Size = new System.Drawing.Size(215, 23);
            this.midiOutToolStripMenuItem.DropDownClosed += new System.EventHandler(this.midiOutToolStripMenuItem_DropDownClosed);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timerAutoSave
            // 
            this.timerAutoSave.Enabled = true;
            this.timerAutoSave.Interval = 300000;
            this.timerAutoSave.Tick += new System.EventHandler(this.timerAutoSave_Tick);
            // 
            // FormMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(979, 656);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(995, 695);
            this.Name = "FormMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Untitled - MT-32 Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMainMenu_FormClosed);
            this.Load += new System.EventHandler(this.FormMainMenu_Load);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.FormMainMenu_Scroll);
            this.Resize += new System.EventHandler(this.FormMainMenu_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ToolTip toolTips;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem loadSysExFileToolStripMenuItem;
        private ToolStripMenuItem saveSysExFileAsToolStripMenuItem;
        private ToolStripMenuItem saveSysExToolStripMenuItem;
        private ToolStripMenuItem loadTimbreFileToolStripMenuItem;
        private ToolStripMenuItem saveTimbreFileToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem patchEditorToolStripMenuItem;
        private ToolStripMenuItem rhythmEditorToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem masterSettingsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem saveAllTimbresToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripComboBox midiInToolStripMenuItem;
        private ToolStripComboBox midiOutToolStripMenuItem;
        private ToolStripMenuItem MidiInLabelToolStripMenuItem;
        private ToolStripMenuItem MidiOutLabelToolStripMenuItem;
        private ToolStripMenuItem hardwareMT32ConnectedToolStripMenuItem;
        private ToolStripMenuItem sendMessagesToMT32DisplayToolStripMenuItem;
        private ToolStripMenuItem verboseConsoleMessagesToolStripMenuItem;
        private ToolStripMenuItem allowMT32ResetToolStripMenuItem;
        private ToolStripMenuItem showConsoleToolStripMenuItem;
        private ToolStripMenuItem ignoreSysConfigOnLoadToolStripMenuItem;
        private ToolStripMenuItem excludeSysConfigonSaveToolStripMenuItem;
        private System.Windows.Forms.Timer timerAutoSave;
        private ToolStripMenuItem autosaveEvery5MinutesToolStripMenuItem;
        private ToolStripMenuItem darkModeToolStripMenuItem;
        private ToolStripMenuItem timbreEditorToolStripMenuItem;
    }
}
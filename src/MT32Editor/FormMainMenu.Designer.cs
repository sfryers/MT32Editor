namespace MT32Edit
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainMenu));
            toolTips = new ToolTip(components);
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            loadSysExFileToolStripMenuItem = new ToolStripMenuItem();
            saveSysExFileAsToolStripMenuItem = new ToolStripMenuItem();
            saveSysExToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            loadTimbreFileToolStripMenuItem = new ToolStripMenuItem();
            saveTimbreFileToolStripMenuItem = new ToolStripMenuItem();
            saveAllTimbresToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            closeToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            patchEditorToolStripMenuItem = new ToolStripMenuItem();
            rhythmEditorToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            masterSettingsToolStripMenuItem = new ToolStripMenuItem();
            hardwareMT32ConnectedToolStripMenuItem = new ToolStripMenuItem();
            sendMessagesToMT32DisplayToolStripMenuItem = new ToolStripMenuItem();
            allowMT32ResetToolStripMenuItem = new ToolStripMenuItem();
            verboseConsoleMessagesToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem1 = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            MidiInLabelToolStripMenuItem = new ToolStripMenuItem();
            midiInToolStripMenuItem = new ToolStripComboBox();
            MidiOutLabelToolStripMenuItem = new ToolStripMenuItem();
            midiOutToolStripMenuItem = new ToolStripComboBox();
            timer = new System.Windows.Forms.Timer(components);
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            menuStrip.AutoSize = false;
            menuStrip.BackColor = SystemColors.MenuBar;
            menuStrip.Dock = DockStyle.None;
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem, optionsToolStripMenuItem, helpToolStripMenuItem1, MidiInLabelToolStripMenuItem, midiInToolStripMenuItem, MidiOutLabelToolStripMenuItem, midiOutToolStripMenuItem });
            menuStrip.Location = new Point(1, 1);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(2192, 30);
            menuStrip.Stretch = false;
            menuStrip.TabIndex = 40;
            menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadSysExFileToolStripMenuItem, saveSysExFileAsToolStripMenuItem, saveSysExToolStripMenuItem, toolStripSeparator1, loadTimbreFileToolStripMenuItem, saveTimbreFileToolStripMenuItem, saveAllTimbresToolStripMenuItem, toolStripSeparator2, closeToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 26);
            fileToolStripMenuItem.Text = "File";
            // 
            // loadSysExFileToolStripMenuItem
            // 
            loadSysExFileToolStripMenuItem.Image = (Image)resources.GetObject("loadSysExFileToolStripMenuItem.Image");
            loadSysExFileToolStripMenuItem.Name = "loadSysExFileToolStripMenuItem";
            loadSysExFileToolStripMenuItem.Size = new Size(173, 22);
            loadSysExFileToolStripMenuItem.Text = "Load SysEx File";
            loadSysExFileToolStripMenuItem.Click += loadSysExFileToolStripMenuItem_Click;
            // 
            // saveSysExFileAsToolStripMenuItem
            // 
            saveSysExFileAsToolStripMenuItem.Image = Properties.Resources.SaveAs;
            saveSysExFileAsToolStripMenuItem.Name = "saveSysExFileAsToolStripMenuItem";
            saveSysExFileAsToolStripMenuItem.Size = new Size(173, 22);
            saveSysExFileAsToolStripMenuItem.Text = "Save SysEx File As..";
            saveSysExFileAsToolStripMenuItem.Click += saveSysExFileAsToolStripMenuItem_Click;
            // 
            // saveSysExToolStripMenuItem
            // 
            saveSysExToolStripMenuItem.Enabled = false;
            saveSysExToolStripMenuItem.Image = Properties.Resources.Save;
            saveSysExToolStripMenuItem.Name = "saveSysExToolStripMenuItem";
            saveSysExToolStripMenuItem.Size = new Size(173, 22);
            saveSysExToolStripMenuItem.Text = "Save SysEx File";
            saveSysExToolStripMenuItem.Click += saveSysExToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(170, 6);
            // 
            // loadTimbreFileToolStripMenuItem
            // 
            loadTimbreFileToolStripMenuItem.Image = Properties.Resources.Open;
            loadTimbreFileToolStripMenuItem.Name = "loadTimbreFileToolStripMenuItem";
            loadTimbreFileToolStripMenuItem.Size = new Size(173, 22);
            loadTimbreFileToolStripMenuItem.Text = "Load Timbre File";
            loadTimbreFileToolStripMenuItem.Click += loadTimbreFileToolStripMenuItem_Click;
            // 
            // saveTimbreFileToolStripMenuItem
            // 
            saveTimbreFileToolStripMenuItem.Image = Properties.Resources.Save;
            saveTimbreFileToolStripMenuItem.Name = "saveTimbreFileToolStripMenuItem";
            saveTimbreFileToolStripMenuItem.Size = new Size(173, 22);
            saveTimbreFileToolStripMenuItem.Text = "Save Timbre File";
            saveTimbreFileToolStripMenuItem.Click += saveTimbreFileToolStripMenuItem_Click;
            // 
            // saveAllTimbresToolStripMenuItem
            // 
            saveAllTimbresToolStripMenuItem.Name = "saveAllTimbresToolStripMenuItem";
            saveAllTimbresToolStripMenuItem.Size = new Size(173, 22);
            saveAllTimbresToolStripMenuItem.Text = "Save All Timbres";
            saveAllTimbresToolStripMenuItem.Click += saveAllTimbresToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(170, 6);
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(173, 22);
            closeToolStripMenuItem.Text = "Exit";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { patchEditorToolStripMenuItem, rhythmEditorToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 26);
            viewToolStripMenuItem.Text = "View";
            // 
            // patchEditorToolStripMenuItem
            // 
            patchEditorToolStripMenuItem.Checked = true;
            patchEditorToolStripMenuItem.CheckState = CheckState.Checked;
            patchEditorToolStripMenuItem.Name = "patchEditorToolStripMenuItem";
            patchEditorToolStripMenuItem.Size = new Size(179, 22);
            patchEditorToolStripMenuItem.Text = "Patch Editor";
            patchEditorToolStripMenuItem.Click += patchEditorToolStripMenuItem_Click;
            // 
            // rhythmEditorToolStripMenuItem
            // 
            rhythmEditorToolStripMenuItem.Name = "rhythmEditorToolStripMenuItem";
            rhythmEditorToolStripMenuItem.Size = new Size(179, 22);
            rhythmEditorToolStripMenuItem.Text = "Rhythm Bank Editor";
            rhythmEditorToolStripMenuItem.Click += rhythmEditorToolStripMenuItem_Click;
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { masterSettingsToolStripMenuItem, hardwareMT32ConnectedToolStripMenuItem, sendMessagesToMT32DisplayToolStripMenuItem, allowMT32ResetToolStripMenuItem, verboseConsoleMessagesToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(61, 26);
            optionsToolStripMenuItem.Text = "Options";
            // 
            // masterSettingsToolStripMenuItem
            // 
            masterSettingsToolStripMenuItem.Image = Properties.Resources.Settings;
            masterSettingsToolStripMenuItem.Name = "masterSettingsToolStripMenuItem";
            masterSettingsToolStripMenuItem.Size = new Size(230, 22);
            masterSettingsToolStripMenuItem.Text = "System area settings";
            masterSettingsToolStripMenuItem.Click += masterSettingsToolStripMenuItem_Click;
            // 
            // hardwareMT32ConnectedToolStripMenuItem
            // 
            hardwareMT32ConnectedToolStripMenuItem.Checked = true;
            hardwareMT32ConnectedToolStripMenuItem.CheckState = CheckState.Checked;
            hardwareMT32ConnectedToolStripMenuItem.Name = "hardwareMT32ConnectedToolStripMenuItem";
            hardwareMT32ConnectedToolStripMenuItem.Size = new Size(230, 22);
            hardwareMT32ConnectedToolStripMenuItem.Text = "Hardware MT-32 connected";
            hardwareMT32ConnectedToolStripMenuItem.Click += hardwareMT32ConnectedToolStripMenuItem_Click;
            // 
            // sendMessagesToMT32DisplayToolStripMenuItem
            // 
            sendMessagesToMT32DisplayToolStripMenuItem.Checked = true;
            sendMessagesToMT32DisplayToolStripMenuItem.CheckState = CheckState.Checked;
            sendMessagesToMT32DisplayToolStripMenuItem.Name = "sendMessagesToMT32DisplayToolStripMenuItem";
            sendMessagesToMT32DisplayToolStripMenuItem.Size = new Size(230, 22);
            sendMessagesToMT32DisplayToolStripMenuItem.Text = "Send info to MT-32 display";
            sendMessagesToMT32DisplayToolStripMenuItem.Click += sendMessagesToMT32DisplayToolStripMenuItem_Click;
            // 
            // allowMT32ResetToolStripMenuItem
            // 
            allowMT32ResetToolStripMenuItem.Name = "allowMT32ResetToolStripMenuItem";
            allowMT32ResetToolStripMenuItem.Size = new Size(230, 22);
            allowMT32ResetToolStripMenuItem.Text = "Allow MT-32 reset from SysEx";
            allowMT32ResetToolStripMenuItem.Click += allowMT32ResetToolStripMenuItem_Click;
            // 
            // verboseConsoleMessagesToolStripMenuItem
            // 
            verboseConsoleMessagesToolStripMenuItem.Name = "verboseConsoleMessagesToolStripMenuItem";
            verboseConsoleMessagesToolStripMenuItem.Size = new Size(230, 22);
            verboseConsoleMessagesToolStripMenuItem.Text = "Verbose console messages";
            verboseConsoleMessagesToolStripMenuItem.Click += verboseConsoleMessagesToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem1
            // 
            helpToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            helpToolStripMenuItem1.Size = new Size(44, 26);
            helpToolStripMenuItem1.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(107, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // MidiInLabelToolStripMenuItem
            // 
            MidiInLabelToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            MidiInLabelToolStripMenuItem.Enabled = false;
            MidiInLabelToolStripMenuItem.Margin = new Padding(60, 0, 0, 0);
            MidiInLabelToolStripMenuItem.Name = "MidiInLabelToolStripMenuItem";
            MidiInLabelToolStripMenuItem.Size = new Size(57, 26);
            MidiInLabelToolStripMenuItem.Text = "MIDI In";
            // 
            // midiInToolStripMenuItem
            // 
            midiInToolStripMenuItem.AutoSize = false;
            midiInToolStripMenuItem.CausesValidation = false;
            midiInToolStripMenuItem.DropDownStyle = ComboBoxStyle.DropDownList;
            midiInToolStripMenuItem.DropDownWidth = 200;
            midiInToolStripMenuItem.FlatStyle = FlatStyle.Standard;
            midiInToolStripMenuItem.MaxDropDownItems = 10;
            midiInToolStripMenuItem.Name = "midiInToolStripMenuItem";
            midiInToolStripMenuItem.Size = new Size(200, 23);
            midiInToolStripMenuItem.DropDownClosed += midiInToolStripMenuItem_DropDownClosed;
            // 
            // MidiOutLabelToolStripMenuItem
            // 
            MidiOutLabelToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            MidiOutLabelToolStripMenuItem.Enabled = false;
            MidiOutLabelToolStripMenuItem.Margin = new Padding(20, 0, 0, 0);
            MidiOutLabelToolStripMenuItem.Name = "MidiOutLabelToolStripMenuItem";
            MidiOutLabelToolStripMenuItem.Size = new Size(67, 26);
            MidiOutLabelToolStripMenuItem.Text = "MIDI Out";
            // 
            // midiOutToolStripMenuItem
            // 
            midiOutToolStripMenuItem.AutoSize = false;
            midiOutToolStripMenuItem.CausesValidation = false;
            midiOutToolStripMenuItem.DropDownStyle = ComboBoxStyle.DropDownList;
            midiOutToolStripMenuItem.FlatStyle = FlatStyle.Standard;
            midiOutToolStripMenuItem.MaxDropDownItems = 10;
            midiOutToolStripMenuItem.Name = "midiOutToolStripMenuItem";
            midiOutToolStripMenuItem.Size = new Size(200, 23);
            midiOutToolStripMenuItem.DropDownClosed += midiOutToolStripMenuItem_DropDownClosed;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Tick += timer_Tick;
            // 
            // FormMainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(48, 48, 48);
            ClientSize = new Size(1758, 1001);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(1774, 1038);
            Name = "FormMainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MT-32 Editor";
            FormClosing += FormMainMenu_FormClosing;
            Load += FormMainMenu_Load;
            Resize += FormMainMenu_Resize;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label labelMidiOut;
        private Label labelMidiIn;
        private ComboBox comboBoxMidiOut;
        private ComboBox comboBoxMidiIn;
        private ToolTip toolTips;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem loadSysExFileToolStripMenuItem;
        private ToolStripMenuItem saveSysExFileAsToolStripMenuItem;
        private ToolStripMenuItem saveSysExToolStripMenuItem;
        private ToolStripMenuItem loadTimbreFileToolStripMenuItem;
        private ToolStripMenuItem saveTimbreFileToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem mIDIToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem patchEditorToolStripMenuItem;
        private ToolStripMenuItem rhythmEditorToolStripMenuItem;
        private ToolStripMenuItem selectMIDIDevicesToolStripMenuItem;
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
    }
}
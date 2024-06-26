﻿using System.Windows.Forms;
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
            this.saveWindowSizeAndPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ignoreSysConfigOnLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excludeSysConfigonSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardwareMT32ConnectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMessagesToMT32DisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allowMT32ResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cM32LModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verboseConsoleMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.envelopeDiagramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MidiInLabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.midiInToolStripMenuItem = new System.Windows.Forms.ToolStripComboBox();
            this.MidiOutLabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.midiOutToolStripMenuItem = new System.Windows.Forms.ToolStripComboBox();
            this.auditionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip.BackColor = System.Drawing.Color.Gainsboro;
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
            this.midiOutToolStripMenuItem,
            this.auditionToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(1, 1);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1552, 26);
            this.menuStrip.Stretch = false;
            this.menuStrip.TabIndex = 40;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
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
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.menuStrip_Item_Clicked);
            // 
            // loadSysExFileToolStripMenuItem
            // 
            this.loadSysExFileToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.loadSysExFileToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.loadSysExFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadSysExFileToolStripMenuItem.Image")));
            this.loadSysExFileToolStripMenuItem.Name = "loadSysExFileToolStripMenuItem";
            this.loadSysExFileToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.loadSysExFileToolStripMenuItem.Text = "Load SysEx File";
            this.loadSysExFileToolStripMenuItem.Click += new System.EventHandler(this.loadSysExFileToolStripMenuItem_Click);
            // 
            // saveSysExFileAsToolStripMenuItem
            // 
            this.saveSysExFileAsToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.saveSysExFileAsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.saveSysExFileAsToolStripMenuItem.Image = global::MT32Edit_legacy.Properties.Resources.SaveAs;
            this.saveSysExFileAsToolStripMenuItem.Name = "saveSysExFileAsToolStripMenuItem";
            this.saveSysExFileAsToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.saveSysExFileAsToolStripMenuItem.Text = "Save SysEx File As..";
            this.saveSysExFileAsToolStripMenuItem.Click += new System.EventHandler(this.saveSysExFileAsToolStripMenuItem_Click);
            // 
            // saveSysExToolStripMenuItem
            // 
            this.saveSysExToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.saveSysExToolStripMenuItem.Enabled = false;
            this.saveSysExToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.saveSysExToolStripMenuItem.Image = global::MT32Edit_legacy.Properties.Resources.Save;
            this.saveSysExToolStripMenuItem.Name = "saveSysExToolStripMenuItem";
            this.saveSysExToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.saveSysExToolStripMenuItem.Text = "Save SysEx File";
            this.saveSysExToolStripMenuItem.Click += new System.EventHandler(this.saveSysExToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // loadTimbreFileToolStripMenuItem
            // 
            this.loadTimbreFileToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.loadTimbreFileToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.loadTimbreFileToolStripMenuItem.Image = global::MT32Edit_legacy.Properties.Resources.Open;
            this.loadTimbreFileToolStripMenuItem.Name = "loadTimbreFileToolStripMenuItem";
            this.loadTimbreFileToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.loadTimbreFileToolStripMenuItem.Text = "Load Timbre File";
            this.loadTimbreFileToolStripMenuItem.Click += new System.EventHandler(this.loadTimbreFileToolStripMenuItem_Click);
            // 
            // saveTimbreFileToolStripMenuItem
            // 
            this.saveTimbreFileToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.saveTimbreFileToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.saveTimbreFileToolStripMenuItem.Image = global::MT32Edit_legacy.Properties.Resources.Save;
            this.saveTimbreFileToolStripMenuItem.Name = "saveTimbreFileToolStripMenuItem";
            this.saveTimbreFileToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.saveTimbreFileToolStripMenuItem.Text = "Save Timbre File";
            this.saveTimbreFileToolStripMenuItem.Click += new System.EventHandler(this.saveTimbreFileToolStripMenuItem_Click);
            // 
            // saveAllTimbresToolStripMenuItem
            // 
            this.saveAllTimbresToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.saveAllTimbresToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.saveAllTimbresToolStripMenuItem.Name = "saveAllTimbresToolStripMenuItem";
            this.saveAllTimbresToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.saveAllTimbresToolStripMenuItem.Text = "Save All Timbres";
            this.saveAllTimbresToolStripMenuItem.Click += new System.EventHandler(this.saveAllTimbresToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.closeToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.closeToolStripMenuItem.Text = "Exit";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patchEditorToolStripMenuItem,
            this.rhythmEditorToolStripMenuItem,
            this.timbreEditorToolStripMenuItem});
            this.viewToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.menuStrip_Item_Clicked);
            // 
            // patchEditorToolStripMenuItem
            // 
            this.patchEditorToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.patchEditorToolStripMenuItem.Checked = true;
            this.patchEditorToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.patchEditorToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.patchEditorToolStripMenuItem.Name = "patchEditorToolStripMenuItem";
            this.patchEditorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.patchEditorToolStripMenuItem.Text = "Patch Editor";
            this.patchEditorToolStripMenuItem.Click += new System.EventHandler(this.patchEditorToolStripMenuItem_Click);
            // 
            // rhythmEditorToolStripMenuItem
            // 
            this.rhythmEditorToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.rhythmEditorToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.rhythmEditorToolStripMenuItem.Name = "rhythmEditorToolStripMenuItem";
            this.rhythmEditorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rhythmEditorToolStripMenuItem.Text = "Rhythm Bank Editor";
            this.rhythmEditorToolStripMenuItem.Click += new System.EventHandler(this.rhythmEditorToolStripMenuItem_Click);
            // 
            // timbreEditorToolStripMenuItem
            // 
            this.timbreEditorToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.timbreEditorToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.timbreEditorToolStripMenuItem.Name = "timbreEditorToolStripMenuItem";
            this.timbreEditorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.timbreEditorToolStripMenuItem.Text = "Timbre Editor";
            this.timbreEditorToolStripMenuItem.CheckedChanged += new System.EventHandler(this.timbreEditorToolStripMenuItem_CheckedChanged);
            this.timbreEditorToolStripMenuItem.Click += new System.EventHandler(this.timbreEditorToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterSettingsToolStripMenuItem,
            this.autosaveEvery5MinutesToolStripMenuItem,
            this.saveWindowSizeAndPositionToolStripMenuItem,
            this.ignoreSysConfigOnLoadToolStripMenuItem,
            this.excludeSysConfigonSaveToolStripMenuItem,
            this.hardwareMT32ConnectedToolStripMenuItem,
            this.sendMessagesToMT32DisplayToolStripMenuItem,
            this.allowMT32ResetToolStripMenuItem,
            this.cM32LModeToolStripMenuItem,
            this.darkModeToolStripMenuItem,
            this.showConsoleToolStripMenuItem,
            this.verboseConsoleMessagesToolStripMenuItem});
            this.optionsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.menuStrip_Item_Clicked);
            // 
            // masterSettingsToolStripMenuItem
            // 
            this.masterSettingsToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.masterSettingsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.masterSettingsToolStripMenuItem.Image = global::MT32Edit_legacy.Properties.Resources.Settings;
            this.masterSettingsToolStripMenuItem.Name = "masterSettingsToolStripMenuItem";
            this.masterSettingsToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.masterSettingsToolStripMenuItem.Text = "System area settings";
            this.masterSettingsToolStripMenuItem.Click += new System.EventHandler(this.masterSettingsToolStripMenuItem_Click);
            // 
            // autosaveEvery5MinutesToolStripMenuItem
            // 
            this.autosaveEvery5MinutesToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.autosaveEvery5MinutesToolStripMenuItem.Checked = true;
            this.autosaveEvery5MinutesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autosaveEvery5MinutesToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.autosaveEvery5MinutesToolStripMenuItem.Name = "autosaveEvery5MinutesToolStripMenuItem";
            this.autosaveEvery5MinutesToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.autosaveEvery5MinutesToolStripMenuItem.Text = "Autosave every 5 minutes";
            this.autosaveEvery5MinutesToolStripMenuItem.ToolTipText = "Saves current status to autosave.syx";
            this.autosaveEvery5MinutesToolStripMenuItem.Click += new System.EventHandler(this.autosaveEvery5MinutesToolStripMenuItem_Click);
            // 
            // saveWindowSizeAndPositionToolStripMenuItem
            // 
            this.saveWindowSizeAndPositionToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.saveWindowSizeAndPositionToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.saveWindowSizeAndPositionToolStripMenuItem.Name = "saveWindowSizeAndPositionToolStripMenuItem";
            this.saveWindowSizeAndPositionToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.saveWindowSizeAndPositionToolStripMenuItem.Text = "Save window size and position";
            this.saveWindowSizeAndPositionToolStripMenuItem.Click += new System.EventHandler(this.saveWindowSizeAndPositionToolStripMenuItem_Click);
            // 
            // ignoreSysConfigOnLoadToolStripMenuItem
            // 
            this.ignoreSysConfigOnLoadToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.ignoreSysConfigOnLoadToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.ignoreSysConfigOnLoadToolStripMenuItem.Name = "ignoreSysConfigOnLoadToolStripMenuItem";
            this.ignoreSysConfigOnLoadToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.ignoreSysConfigOnLoadToolStripMenuItem.Text = "Ignore system config messages when loading SysEx file";
            this.ignoreSysConfigOnLoadToolStripMenuItem.Click += new System.EventHandler(this.ignoreSysConfigOnLoadToolStripMenuItem_Click);
            // 
            // excludeSysConfigonSaveToolStripMenuItem
            // 
            this.excludeSysConfigonSaveToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.excludeSysConfigonSaveToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.excludeSysConfigonSaveToolStripMenuItem.Name = "excludeSysConfigonSaveToolStripMenuItem";
            this.excludeSysConfigonSaveToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.excludeSysConfigonSaveToolStripMenuItem.Text = "Exclude system config messages when saving SysEx file";
            this.excludeSysConfigonSaveToolStripMenuItem.Click += new System.EventHandler(this.excludeSysConfigonSaveToolStripMenuItem_Click);
            // 
            // hardwareMT32ConnectedToolStripMenuItem
            // 
            this.hardwareMT32ConnectedToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.hardwareMT32ConnectedToolStripMenuItem.Checked = true;
            this.hardwareMT32ConnectedToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hardwareMT32ConnectedToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.hardwareMT32ConnectedToolStripMenuItem.Name = "hardwareMT32ConnectedToolStripMenuItem";
            this.hardwareMT32ConnectedToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.hardwareMT32ConnectedToolStripMenuItem.Text = "Hardware MT-32 connected";
            this.hardwareMT32ConnectedToolStripMenuItem.Click += new System.EventHandler(this.hardwareMT32ConnectedToolStripMenuItem_Click);
            // 
            // sendMessagesToMT32DisplayToolStripMenuItem
            // 
            this.sendMessagesToMT32DisplayToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.sendMessagesToMT32DisplayToolStripMenuItem.Checked = true;
            this.sendMessagesToMT32DisplayToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sendMessagesToMT32DisplayToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.sendMessagesToMT32DisplayToolStripMenuItem.Name = "sendMessagesToMT32DisplayToolStripMenuItem";
            this.sendMessagesToMT32DisplayToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.sendMessagesToMT32DisplayToolStripMenuItem.Text = "Send info to MT-32 display";
            this.sendMessagesToMT32DisplayToolStripMenuItem.Click += new System.EventHandler(this.sendMessagesToMT32DisplayToolStripMenuItem_Click);
            // 
            // allowMT32ResetToolStripMenuItem
            // 
            this.allowMT32ResetToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.allowMT32ResetToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.allowMT32ResetToolStripMenuItem.Name = "allowMT32ResetToolStripMenuItem";
            this.allowMT32ResetToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.allowMT32ResetToolStripMenuItem.Text = "Allow MT-32 reset from SysEx";
            this.allowMT32ResetToolStripMenuItem.Click += new System.EventHandler(this.allowMT32ResetToolStripMenuItem_Click);
            // 
            // cM32LModeToolStripMenuItem
            // 
            this.cM32LModeToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.cM32LModeToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.cM32LModeToolStripMenuItem.Name = "cM32LModeToolStripMenuItem";
            this.cM32LModeToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.cM32LModeToolStripMenuItem.Text = "CM-32L mode (requires restart)";
            this.cM32LModeToolStripMenuItem.Click += new System.EventHandler(this.cM32LModeToolStripMenuItem_Click);
            // 
            // darkModeToolStripMenuItem
            // 
            this.darkModeToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.darkModeToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.darkModeToolStripMenuItem.Name = "darkModeToolStripMenuItem";
            this.darkModeToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.darkModeToolStripMenuItem.Text = "Dark mode";
            this.darkModeToolStripMenuItem.Click += new System.EventHandler(this.darkModeToolStripMenuItem_Click);
            // 
            // showConsoleToolStripMenuItem
            // 
            this.showConsoleToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.showConsoleToolStripMenuItem.Checked = true;
            this.showConsoleToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showConsoleToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.showConsoleToolStripMenuItem.Name = "showConsoleToolStripMenuItem";
            this.showConsoleToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.showConsoleToolStripMenuItem.Text = "Show console";
            this.showConsoleToolStripMenuItem.Click += new System.EventHandler(this.showConsoleToolStripMenuItem_Click);
            // 
            // verboseConsoleMessagesToolStripMenuItem
            // 
            this.verboseConsoleMessagesToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.verboseConsoleMessagesToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.verboseConsoleMessagesToolStripMenuItem.Name = "verboseConsoleMessagesToolStripMenuItem";
            this.verboseConsoleMessagesToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.verboseConsoleMessagesToolStripMenuItem.Text = "Verbose console messages";
            this.verboseConsoleMessagesToolStripMenuItem.Click += new System.EventHandler(this.verboseConsoleMessagesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.envelopeDiagramsToolStripMenuItem});
            this.helpToolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(44, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.menuStrip_Item_Clicked);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // envelopeDiagramsToolStripMenuItem
            // 
            this.envelopeDiagramsToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.envelopeDiagramsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.envelopeDiagramsToolStripMenuItem.Name = "envelopeDiagramsToolStripMenuItem";
            this.envelopeDiagramsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.envelopeDiagramsToolStripMenuItem.Text = "Envelope Diagrams";
            this.envelopeDiagramsToolStripMenuItem.Click += new System.EventHandler(this.envelopeDiagramsToolStripMenuItem_Click);
            // 
            // MidiInLabelToolStripMenuItem
            // 
            this.MidiInLabelToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MidiInLabelToolStripMenuItem.Enabled = false;
            this.MidiInLabelToolStripMenuItem.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.MidiInLabelToolStripMenuItem.Name = "MidiInLabelToolStripMenuItem";
            this.MidiInLabelToolStripMenuItem.Size = new System.Drawing.Size(57, 22);
            this.MidiInLabelToolStripMenuItem.Text = "MIDI In";
            this.MidiInLabelToolStripMenuItem.Click += new System.EventHandler(this.menuStrip_Item_Clicked);
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
            this.MidiOutLabelToolStripMenuItem.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.MidiOutLabelToolStripMenuItem.Name = "MidiOutLabelToolStripMenuItem";
            this.MidiOutLabelToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            this.MidiOutLabelToolStripMenuItem.Text = "MIDI Out";
            this.MidiOutLabelToolStripMenuItem.Click += new System.EventHandler(this.menuStrip_Item_Clicked);
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
            // auditionToolStripMenuItem
            // 
            this.auditionToolStripMenuItem.Image = global::MT32Edit_legacy.Properties.Resources.Play;
            this.auditionToolStripMenuItem.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.auditionToolStripMenuItem.Name = "auditionToolStripMenuItem";
            this.auditionToolStripMenuItem.Size = new System.Drawing.Size(32, 22);
            this.auditionToolStripMenuItem.ToolTipText = "Test selected timbre";
            this.auditionToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.auditionToolStripMenuItem_MouseDown);
            this.auditionToolStripMenuItem.MouseLeave += new System.EventHandler(this.auditionToolStripMenuItem_MouseLeave);
            this.auditionToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.auditionToolStripMenuItem_MouseUp);
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
            this.ClientSize = new System.Drawing.Size(1180, 656);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(998, 695);
            this.Name = "FormMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Untitled - MT-32 Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMainMenu_FormClosing);
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
        private ToolStripMenuItem envelopeDiagramsToolStripMenuItem;
        private ToolStripMenuItem auditionToolStripMenuItem;
        private ToolStripMenuItem saveWindowSizeAndPositionToolStripMenuItem;
        private ToolStripMenuItem cM32LModeToolStripMenuItem;
    }
}
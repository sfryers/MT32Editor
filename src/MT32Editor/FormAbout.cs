﻿namespace MT32Edit;

public partial class FormAbout : Form
{
    private readonly string versionNo = "";
    private readonly string releaseDate = "";

    public FormAbout(string version, string date)
    {
        InitializeComponent();
        versionNo = version;
        releaseDate = date;
    }

    private void ButtonClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void FormAbout_Load(object sender, EventArgs e)
    {
        labelVersionNo.Text = versionNo;
        labelReleaseDate.Text = releaseDate;
    }

    private void LinkLabelProject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        linkLabelProject.LinkVisited = true;
        Clipboard.SetText("https://github.com/sfryers/MT32Editor");
        MessageBox.Show("URL copied to clipboard.");
    }
}
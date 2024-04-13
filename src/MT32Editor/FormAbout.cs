namespace MT32Edit;
/// <summary>
/// Form to display app information, version number
/// and release date
/// </summary>
public partial class FormAbout : Form
{
    // MT32Edit: FormAbout
    // S.Fryers Apr 2024

    private readonly string version;
    private readonly string framework;
    private readonly string releaseDate;

    public FormAbout(string versionNo, string frameworkID, string date)
    {
        InitializeComponent();
        version = versionNo;
        framework = string.IsNullOrWhiteSpace(frameworkID) ? "" : $"({frameworkID})";
        releaseDate = date;
    }

    private void ButtonClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void FormAbout_Load(object sender, EventArgs e)
    {
        labelVersionNo.Text = version;
        labelFramework.Text = framework;
        labelReleaseDate.Text = releaseDate;
    }

    private void LinkLabelProject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        linkLabelProject.LinkVisited = true;
        Clipboard.SetText("https://github.com/sfryers/MT32Editor");
        MessageBox.Show("URL copied to clipboard.");
    }
}
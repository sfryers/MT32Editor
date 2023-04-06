using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MT32Edit
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {

        }

        private void linkLabelProject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelProject.LinkVisited = true;
            Clipboard.SetText("https://github.com/sfryers/MT32Editor");
            MessageBox.Show("URL copied to clipboard.");
        }
    }
}

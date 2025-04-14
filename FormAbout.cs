using System;
using System.Windows.Forms;

namespace HellowWorldWindowFrom
{
    public partial class FormAbout: Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=I3YOXQYM_6o");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

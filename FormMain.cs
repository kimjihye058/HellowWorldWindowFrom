using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HellowWorldWindowFrom
{
    public partial class form1: Form
    {
        public form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "탈락입니다.";
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for(int i = 0; i<5; i++)
            {
                Form formAbout2 = new FormAbout();
                formAbout2.Text = "모달리스창(Medeless)";
                formAbout2.Show();
            }
            
            for(int i = 0; i<5; i++)
            {
                Form formAbout1 = new FormAbout();
                formAbout1.Text = "모달창(Modal)";
                formAbout1.ShowDialog();
            }
            
        }
    }
}

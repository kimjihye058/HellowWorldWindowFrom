using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            Form formAbout2 = new FormAbout();
            formAbout2.Text = "모달리스창(Medeless)";
            formAbout2.Show();
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "텍스트파일(*.txt)|*.txt";   // 파일 형식을 지정해줄 수 있음
            DialogResult result = openFileDialog.ShowDialog();
            switch (result) {
                case DialogResult.OK:
                    // textBox1.Text = openFileDialog.FileName;    // 파일 경로 나옴
                    var fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
                    using(StreamReader reader = new StreamReader(fileStream))
                    {
                        textBox1.Text = reader.ReadToEnd();
                    }
                    break;
                case DialogResult.Cancel:
                    MessageBox.Show("취소했습니다.");
                    break;
            }

        }
    }
}

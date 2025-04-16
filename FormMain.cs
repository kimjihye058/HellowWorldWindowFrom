﻿using System;
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
        private const string FILE_DEFAULT_NAME = "제목 없음";
        private const string FILENAME_FILTER = "텍스트파일(*.txt)|*.txt";
        private const string TEXTBOX_DEFAULT_TEXT = "뭔가 입력하세요.";
        private const string FILE_MODIFY_SYMBOL = "✨";
        private string ORIGINAL_FILE_CONTENT = "";

        public form1()
        {
            InitializeComponent();
            lblFileName.Text = FILE_DEFAULT_NAME;
            textBox1.Text = TEXTBOX_DEFAULT_TEXT;
            ORIGINAL_FILE_CONTENT = textBox1.Text;
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
            openFileDialog.Filter = FILENAME_FILTER;   // 파일 형식을 지정해줄 수 있음
            DialogResult result = openFileDialog.ShowDialog();

            

            switch (result) {
                case DialogResult.OK:
                    // textBox1.Text = openFileDialog.FileName;    // 파일 경로 나옴
                    lblFileName.Text = openFileDialog.FileName;
                    var fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
                    using(StreamReader reader = new StreamReader(fileStream))
                    {
                        textBox1.Text = reader.ReadToEnd();
                        lblModify.Text = ""; 
                        ORIGINAL_FILE_CONTENT = textBox1.Text;
                    }
                    fileStream.Close();
                        break;
                case DialogResult.Cancel:
                    MessageBox.Show("취소했습니다.");
                    break;
            }

        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lblFileName.Text == FILE_DEFAULT_NAME)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = FILENAME_FILTER;   // 파일 형식을 지정해줄 수 있음
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                lblFileName.Text = saveFileDialog.FileName;
            }
            var fileStream = new FileStream(lblFileName.Text, FileMode.Create);
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(textBox1.Text);
                //writer.WriteLine(textBox1.Text);
                writer.Close();
                lblModify.Text = "";
                ORIGINAL_FILE_CONTENT = textBox1.Text;

            }
        }

        private void 다른이름으로저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = FILENAME_FILTER;   // 파일 형식을 지정해줄 수 있음
            saveFileDialog.FileName = lblFileName.Text;
            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }
            lblFileName.Text = saveFileDialog.FileName;
            
            var fileStream = new FileStream(lblFileName.Text, FileMode.Create);
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(textBox1.Text);
                //writer.WriteLine(textBox1.Text);
                writer.Close();
                lblModify.Text = "";
                ORIGINAL_FILE_CONTENT = textBox1.Text;


            }
        }

        private void 새로만들기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = TEXTBOX_DEFAULT_TEXT;
            lblFileName.Text = FILE_DEFAULT_NAME;
            lblModify.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != ORIGINAL_FILE_CONTENT)
            {
                lblModify.Text = FILE_MODIFY_SYMBOL;
            }
            else
            {
                lblModify.Text = "";
            }
        }
    }
}

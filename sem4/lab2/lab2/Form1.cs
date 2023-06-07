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

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    MessageBox.Show("File isn't saved");
                    return;
                }
                string filename = saveFileDialog1.FileName;
                System.IO.File.WriteAllText(filename, errorStack.Text);

                MessageBox.Show("File saved");
            }
            catch (Exception er)
            {
                errorStack.AppendText($"\r\n---------------------------------------\r\n");
                DateTime dateTime = new DateTime();
                errorStack.AppendText($"\r\nDateTime: {dateTime}-------------------\r\n");
                errorStack.AppendText($"InnerException --- \r\n {er.InnerException}\r\n\r\n");
                errorStack.AppendText($"Message --- \r\n {er.Message}\r\n\n");
                errorStack.AppendText($"Source --- \r\n {er.Source}\r\n\r\n");
                errorStack.AppendText($"StackTrace --- \r\n {er.StackTrace}\r\n\r\n");
                errorStack.AppendText($"TargetSite --- \r\n {er.TargetSite}\r\n\r\n");

                errorStack.SelectionStart = errorStack.TextLength;
                errorStack.ScrollToCaret();
                MessageBox.Show("File isn't saved");
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                string filename = openFileDialog1.FileName;
                string filetext = System.IO.File.ReadAllText(filename);
                errorStack.Text = filetext;

                MessageBox.Show("File open");
            }
            catch (Exception er)
            {
                errorStack.AppendText($"\r\n---------------------------------------\r\n");
                DateTime dateTime = new DateTime();
                errorStack.AppendText($"\r\nDateTime: {dateTime}-------------------\r\n");
                errorStack.AppendText($"InnerException --- \r\n {er.InnerException}\r\n\r\n");
                errorStack.AppendText($"Message --- \r\n {er.Message}\r\n\n");
                errorStack.AppendText($"Source --- \r\n {er.Source}\r\n\r\n");
                errorStack.AppendText($"StackTrace --- \r\n {er.StackTrace}\r\n\r\n");
                errorStack.AppendText($"TargetSite --- \r\n {er.TargetSite}\r\n\r\n");

                errorStack.SelectionStart = errorStack.TextLength;
                errorStack.ScrollToCaret();
                MessageBox.Show("File isn't open");
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                errorStack.Clear();
            }
            catch (Exception er)
            {
                errorStack.AppendText($"\r\n---------------------------------------\r\n");
                DateTime dateTime = new DateTime();
                errorStack.AppendText($"\r\nDateTime: {dateTime}-------------------\r\n");
                errorStack.AppendText($"InnerException --- \r\n {er.InnerException}\r\n\r\n");
                errorStack.AppendText($"Message --- \r\n {er.Message}\r\n\n");
                errorStack.AppendText($"Source --- \r\n {er.Source}\r\n\r\n");
                errorStack.AppendText($"StackTrace --- \r\n {er.StackTrace}\r\n\r\n");
                errorStack.AppendText($"TargetSite --- \r\n {er.TargetSite}\r\n\r\n");

                errorStack.SelectionStart = errorStack.TextLength;
                errorStack.ScrollToCaret();
                MessageBox.Show("File could not be created");
            }
        }

        private void lab2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2(this);
            newForm.Show();
        }

        private void lab2dopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 newForm = new Form3(this);
            newForm.Show();
        }
        private void lab3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form newForm = new lab3_1(this);
            newForm.Show();
        }

        private void lab31ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newForm = new lab3_2(this);
            newForm.Show();
        }

        private void parsingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newForm = new Parsing(this);
            newForm.Show();
        }
    }
}

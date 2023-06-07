using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab2
{
    public partial class Form3 : Form
    {
        Form1 form1;
        public Form3(Form1 f)
        {
            InitializeComponent();

            form1 = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.ToString();
            string surname = textBox2.Text;
            string answer;

            try
            {
                if (String.IsNullOrEmpty(name) || Regex.IsMatch(name, @"[^a-zA-Zа-яА-Я]"))
                {
                    MessageBox.Show("Name is incorrect");
                    throw new Exception("Name is incorrect");
                }

                else if (String.IsNullOrEmpty(surname) || Regex.IsMatch(surname, @"[^a-zA-Zа-яА-Я]"))
                {
                    MessageBox.Show("Surname is incorrect.");
                    throw new Exception("Surname is incorrect");
                }
                else
                {
                    answer = "";
                    int shift = (int)numericUpDown1.Value % 26;
                    for (int i = 0; i < name.Length; ++i)
                    {
                        int tmp = name[i] + shift;
                        if (tmp > 122 || (name[i] < 91 && tmp > 90))
                            tmp -= 26;
                        answer += (char)tmp;
                    }

                    answer += " ";

                    for (int i = 0; i < surname.Length; ++i)
                    {
                        int tmp = surname[i] + shift;
                        if (tmp > 122 || (surname[i] < 91 && tmp > 90))
                            tmp -= 26;
                        answer += (char)tmp;
                    }

                    label4.Text = answer;
                    label4.Visible = true;
                }
            }
            catch(Exception er)
            {
                form1.errorStack.AppendText($"\r\n---------------------------------------\r\n");
                DateTime dateTime = new DateTime();
                form1.errorStack.AppendText($"\r\nDateTime: {dateTime}-------------------\r\n");
                form1.errorStack.AppendText($"InnerException --- \r\n {er.InnerException}\r\n\r\n");
                form1.errorStack.AppendText($"Message --- \r\n {er.Message}\r\n\r\n");
                form1.errorStack.AppendText($"Source --- \r\n {er.Source}\r\n\r\n");
                form1.errorStack.AppendText($"StackTrace --- \r\n {er.StackTrace}\r\n\r\n");
                form1.errorStack.AppendText($"TargetSite --- \r\n {er.TargetSite}\n\r\n");

                form1.errorStack.SelectionStart = form1.errorStack.TextLength;
                form1.errorStack.ScrollToCaret();
            }
        }
    }
}

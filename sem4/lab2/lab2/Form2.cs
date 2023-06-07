using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab2
{
    public partial class Form2 : Form
    {
        Form1 form1;
        public Form2 (Form1 f)
        {
            InitializeComponent();
            form1 = f;
        }

        void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                if (rb.Text == "Randomly")
                {
                    button1.Visible = true;
                    checkBox1.Checked = false;
                }
                else if (rb.Text == "Frequence")
                {
                    button1.Visible = false;
                }
            }
        }
        private void newArray(object sender, EventArgs e)
        {
            newArray((int)numericUpDown1.Value);
        }

        void newArray(int length)
        {
            if (k1.Value > k2.Value)
                k1.Value = k2.Value;
            if (k1.Value > numericUpDown1.Value)
                k1.Value = numericUpDown1.Value;
            if (k2.Value > numericUpDown1.Value)
                k2.Value = numericUpDown1.Value;

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();


            dataGridView1.ColumnCount = length;
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            
            if (length == 0)
                return;

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            dataGridView1.RowHeadersWidth = 100;

            for (int i = 0; i < length; ++i)
            {
                dataGridView1.Columns[i].Name = (i + 1).ToString();
                dataGridView1.Columns[i].Width = 45;
            }

            string[] nums1 = new string[length];

            Random rnd = new Random();
            int m = int.MaxValue;
            for (int i = 0; i < length; ++i)
            {
                int tmp = rnd.Next(-100, 100);
                if (tmp > 0 && tmp < m)
                    m = tmp;
                nums1[i] = tmp.ToString();
            }

            string[] nums2 = new string[length];
            for (int i = 0; i < length; ++i)
            {
                if (i < 10)
                    nums2[i] = (Int32.Parse(nums1[i]) + i + 1).ToString();
                else
                    nums2[i] = (Int32.Parse(nums1[i]) - i - 1).ToString();

                if (Int32.Parse(nums2[i]) == m)
                    nums2[i] = "0";

                if (k1.Value <= i + 1 && i + 1 <= k2.Value)
                    nums2[i] = (-1 * Int32.Parse(nums2[i])).ToString();
            }

            dataGridView1.Rows.Add(nums1);
            dataGridView1.Rows.Add(nums2);
            dataGridView1.Rows[0].HeaderCell.Value = "Source array";
            dataGridView1.Rows[1].HeaderCell.Value = "Result array";
        }

        private void k1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (k1.Value > numericUpDown1.Value)
                {
                    MessageBox.Show("k1 should be less than the length of the array");
                    throw new Exception("k1 should be less than the length of the array");
                }
                else if (k1.Value > k2.Value)
                {
                    MessageBox.Show("k1 should be less than k2");
                    throw new Exception("k1 should be less than k2");
                }
            }
            catch (Exception er)
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

        private void k2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (k2.Value + 1 > numericUpDown1.Value)
                {
                    MessageBox.Show("k2 should be less than the length of the array");
                    throw new Exception("k2 should be less than the length of the array");
                }
                else if (k1.Value + 1 > k2.Value)
                {
                    MessageBox.Show("k1 should be less than k2");
                    throw new Exception("k1 should be less than k2");
                }
            }
            catch (Exception er)
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

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            updateArray((int)numericUpDown1.Value);
        }

        void updateArray(int length)
        {
            if (k1.Value > k2.Value)
                k1.Value = k2.Value;
            if (k1.Value > numericUpDown1.Value)
                k1.Value = numericUpDown1.Value;
            if (k2.Value > numericUpDown1.Value)
                k2.Value = numericUpDown1.Value;

            if (dataGridView1.ColumnCount == 0)
            {
                newArray(length);
            }
            else if (length < dataGridView1.ColumnCount)
            {
                dataGridView1.ColumnCount = length;
            }
            else if (length > dataGridView1.ColumnCount)
            {
                int old_length = dataGridView1.ColumnCount;
                dataGridView1.ColumnCount = length;

                DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
                columnHeaderStyle.BackColor = Color.Beige;
                columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
                dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

                Random rnd = new Random();
                for (int i = old_length; i < length; ++i)
                {
                    dataGridView1.Columns[i].Name = (i + 1).ToString();
                    dataGridView1.Columns[i].Width = 45;

                    int temp = rnd.Next(-100, 100);
                    dataGridView1.Rows[0].Cells[i].Value = temp.ToString();

                    if (i < 10)
                        dataGridView1.Rows[1].Cells[i].Value = (temp + i + 1).ToString();
                    else
                        dataGridView1.Rows[1].Cells[i].Value = (temp - i - 1).ToString();
                }

                int m = int.MaxValue;
                for (int i = 0; i < length; ++i)
                {
                    if (m > Int32.Parse((string)dataGridView1.Rows[0].Cells[i].Value))
                        m = Int32.Parse((string)dataGridView1.Rows[0].Cells[i].Value);
                }

                for (int i = 0; i < length; ++i)
                {
                    if (Int32.Parse((string)dataGridView1.Rows[1].Cells[i].Value) == m)
                        dataGridView1.Rows[1].Cells[i].Value = "0";

                    if (k1.Value <= i + 1 && i + 1 <= k2.Value)
                        dataGridView1.Rows[1].Cells[i].Value = Int32.Parse((string)dataGridView1.Rows[1].Cells[i].Value) * -1;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                radioFreq.Checked = true;
                timer1.Interval = (int)numericUpDown2.Value * 1000;
                timer1.Tick += new EventHandler(timerArray);
                timer1.Start();
            }
            else
            {
                radioRandom.Checked = true;
                timer1.Tick -= new EventHandler(timerArray);
                timer1.Stop();
            }
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)numericUpDown2.Value * 1000;
        }
        void timerArray(object sender, EventArgs e)
        {
            newArray((int)numericUpDown1.Value);
        }

       
    }
}

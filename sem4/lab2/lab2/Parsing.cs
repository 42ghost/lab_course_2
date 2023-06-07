using System;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParseLib;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab2
{
    public partial class Parsing : Form
    {
        Form1 form1;
        public MatchCollection matches;
        public string[] signature;
        public Parsing(Form1 f)
        {
            InitializeComponent();
            form1 = f;
        }

        //open
        private void open_File(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = openFileDialog1.FileName;
            string filetext = System.IO.File.ReadAllText(filename);

            richTextBox1.Text = filetext;
        }

        // Search
        private void search_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "" || comboBox1.Text == "")
                return;

            if (!comboBox1.Items.Contains(comboBox1.Text))
                comboBox1.Items.Add(comboBox1.Text);

            signature = comboBox1.Text.Split(';');
            foreach (string sig in signature)
                MyParse.parsing(richTextBox1, textBox1, sig);
            //MyParse.parsing(richTextBox1, textBox1, "m\\w*i");
        }

        // HighLight
        private void highlight_Click(object sender, EventArgs e)
        {
            signature = comboBox1.Text.Split(';');
            if (richTextBox1.Text != "")
            {
                richTextBox1.SelectAll();
                richTextBox1.SelectionColor = Color.Black;

                string start = dateTimePicker1.Value.ToString().Split()[0];
                string stop = dateTimePicker2.Value.ToString().Split()[0];

                foreach (string sig in signature)
                {
                    HighlightText(richTextBox1, sig, start, stop);
                }
            }
        }
        private void parseDop_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                richTextBox1.SelectAll();
                richTextBox1.SelectionColor = Color.Black;

                MyParse.ParseDop(richTextBox1, "24.11.2022", "05.12.2022");
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            signature = comboBox1.Text.Split(';');

            foreach (string sig in signature)
            {
                MyParse.parsing(richTextBox1, textBox1, sig);
            }
        }

        public void HighlightText(RichTextBox rtb, string signature, string start, string stop, Color? highlight = null)
        {
            if (rtb == null || rtb.TextLength == 0)
                return;

            int index;
            int length = signature.Length;
            Color color = highlight ?? Color.Red;

            string date = "([0]?[0-9]|[12][0-9]|[3][01])[./-]([0]?[1-9]|[1][0-2])[./-]([0-9]{4}|[0-9]{2})";
            Regex regex = new Regex(@date);
            MatchCollection matches = regex.Matches(rtb.Text);

            //int shift = 0;
            //foreach (Match match in matches)
            //{
            //    if (MyParse.myCompare(start, match.Value) <= 0 && MyParse.myCompare(match.Value, stop) <= 0)
            //    {
            //        rtb.Text = rtb.Text.Substring(0, match.Index + match.Length + shift) + "\tmail@mail.ru\t" + rtb.Text.Substring(match.Index + match.Length + shift);
            //        shift += "\tmail@mail.ru\t".Length;
            //    }
            //}

            matches = regex.Matches(rtb.Text);
            for (int i = 0; i < matches.Count - 1; ++i)
            {
                if (MyParse.myCompare(start, matches[i].Value) <= 0 && MyParse.myCompare(matches[i].Value, stop) <= 0)
                {
                    int a = matches[i].Index;
                    int b = matches[i + 1].Index;
                    Regex rgx = new Regex(@signature, RegexOptions.IgnoreCase);
                    MatchCollection mtchs = rgx.Matches(rtb.Text.Substring(a, b - a));

                    for (int j = 0; j < mtchs.Count; ++j)
                    {
                        index = mtchs[j].Index + a;
                        if (index > 0)
                        {
                            rtb.SelectionStart = index;
                            rtb.SelectionLength = length;
                            rtb.SelectionColor = color;
                        }
                    }
                }
            }
        }
    }
}

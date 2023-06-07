using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ParseLib
{
    public class MyParse
    {
        public static void parsing(RichTextBox rtb, TextBox tb, string signature)
        {
            tb.Clear();

            Regex regex = new Regex(@signature, RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(rtb.Text);

            if (matches.Count > 0)
            {
                for (int i = 0; i < matches.Count; ++i)
                    tb.Text += matches[i].Index + "-ая позиция\t" + matches[i].Value + "\r\n";
            }
            else
            {
                tb.Text += "Совпадений не найдено";
            }
            return;
        }

        public static void ParseDop(RichTextBox rtb, string start, string stop, Color? highlight = null)
        {
            if (rtb == null || rtb.TextLength == 0)
                return;

            int index = 0;
            int length = 10;
            Color color = highlight ?? Color.Red;

            string date = "([0]?[0-9]|[12][0-9]|[3][01])[./-]([0]?[1-9]|[1][0-2])[./-]([0-9]{4}|[0-9]{2})";
            Regex regex = new Regex(@date);
            MatchCollection matches = regex.Matches(rtb.Text);

            int shift = 0;
            foreach (Match match in matches)
            {
                if (myCompare(start, match.Value) <= 0 && myCompare(match.Value, stop) <= 0)
                {
                    rtb.Text = rtb.Text.Substring(0, match.Index + match.Length + shift) + "\tERROR\t" + rtb.Text.Substring(match.Index + match.Length + shift);
                    shift += "\tERROR\t".Length;
                }
            }

            matches = regex.Matches(rtb.Text);
            foreach (Match match in matches)
            {
                if (myCompare(start, match.Value) <= 0 && myCompare(match.Value, stop) <= 0)
                {
                    index = match.Index;
                    rtb.SelectionStart = index;
                    rtb.SelectionLength = length + "\tERROR\t".Length;
                    rtb.SelectionColor = color;
                }
            }
        }


        public static int myCompare(string a, string b)
        {
            string[] tokens = a.Split('.');
            string[] tokens2 = b.Split('.');

            int year1 = int.Parse(tokens[2]);
            int year2 = int.Parse(tokens2[2]);

            if (year1 > year2)
                return 1;

            if (year1 < year2)
                return -1;

            int m1 = int.Parse(tokens[1]);
            int m2 = int.Parse(tokens2[1]);

            if (m1 > m2)
                return 1;

            if (m1 < m2)
                return -1;


            int d1 = int.Parse(tokens[0]);
            int d2 = int.Parse(tokens2[0]);

            if (d1 > d2)
                return 1;

            if (d1 < d2)
                return -1;

            return 0;
        }
    }
}

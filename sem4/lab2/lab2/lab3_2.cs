using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class lab3_2 : Form
    {
        Form1 form1;
        Pen myPen = new Pen(System.Drawing.Color.Black);
        Graphics g;

        public lab3_2(Form1 f)
        {
            InitializeComponent();

            form1 = f;
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            myPen.Color = Color.Black;
        }

        private void selectMethod(object sender, EventArgs e)
        {
            this.label7.Visible = false;
            this.label8.Visible = false;
            this.numericUpDown3.Visible = false;
            this.numericUpDown4.Visible = false;
            g = pictureBox1.CreateGraphics();
            pictureBox1.Refresh();
            
            try
            {
                int alpha = trackBar1.Value;
                int red = trackBar2.Value;
                int green = trackBar3.Value;
                int blue = trackBar4.Value;
                (int A, int R, int G, int B) color = (A: alpha, R: red, G: green, B: blue);
                if (radioButton1.Checked)
                {
                    drawPifagorTree(pictureBox1.Width / 2, pictureBox1.Height, Math.PI / 2, color, 120, (int)numericUpDown1.Value);
                }
                else if (radioButton2.Checked)
                {;
                    drawSierpinskyNapkin((int) (pictureBox1.Width / 2), (int) (pictureBox1.Height / 2), color, 150, (int)numericUpDown1.Value);
                }
                else if (radioButton3.Checked)
                {
                    this.label7.Visible = true;
                    this.label8.Visible = true;
                    this.numericUpDown3.Visible = true;
                    this.numericUpDown4.Visible = true;

                    int a = (int)numericUpDown3.Value;
                    int d = (int)numericUpDown4.Value;

                    drawAlg(a, d, color, (int)numericUpDown1.Value);
                }
            }
            catch
            {
                form1.errorStack.AppendText("Error");
            }
        }

        private async Task drawPifagorTree(double x0, double y0, double a, (int A, int R, int G, int B) color, int L, int N)
        {
            const double k = 0.66;
            double x1, y1;

            if (N > 0)
            {
                color.A -= 15;
                if (color.A < 0)
                    color.A = 0;
                color.R -= 5;
                if (color.R < 0)
                    color.R = 0;
                color.G += 10;
                if (color.G > 255)
                    color.G = 255;
                color.B -= 5;
                if (color.B < 0)
                    color.B = 0;

                Pen myPen_temp = new Pen(Color.FromArgb(color.A, color.R, color.G, color.B));
                myPen_temp.Width = (float) numericUpDown2.Value;
                
                x1 = x0 + L * Math.Cos(a);
                y1 = y0 - L * Math.Sin(a);
                g.DrawLine(myPen_temp, (float) x0, (float) y0, (float) x1, (float) y1);
                await drawPifagorTree(x1, y1, a + Math.PI / 3, color, (int)(L * k), N - 1);
                await drawPifagorTree(x1, y1, a + Math.PI / 7, color, (int)(L * k), N - 1);
                await drawPifagorTree(x1, y1, a - Math.PI / 7, color, (int)(L * k), N - 1);
                await drawPifagorTree(x1, y1, a - Math.PI / 3, color, (int)(L * k), N - 1);
                if (N == 1)
                {
                    SolidBrush brush = new SolidBrush(Color.MistyRose);
                    g.FillEllipse(brush, (float)x1, (float)y1, 3, 3);
                }
            }
        }

        private async Task drawSierpinskyNapkin(int x, int y, (int A, int R, int G, int B) color, int L, int N)
        {
            const double k = 0.5;

            if (N > 0)
            {
                color.A -= 10;
                if (color.A < 0)
                    color.A = 0;
                color.R += 20;
                if (color.R > 255)
                    color.R = 40;
                color.G += 15;
                if (color.G > 255)
                    color.G = 235;
                color.B -= 5;
                if (color.B < 0)
                    color.B = 0;

                Pen myPen_temp = new Pen(Color.FromArgb(color.A, color.R, color.G, color.B));
                myPen_temp.Width = (float)numericUpDown2.Value;

                Rectangle rect = new Rectangle(x - (int)(L / 2), y - (int)(L / 2), L, L);
                g.DrawRectangle(myPen_temp, rect);
                await drawSierpinskyNapkin(x - (int)(L / 2), y - (int)(L / 2), color, (int)(L * k), N - 1);
                await drawSierpinskyNapkin(x - (int)(L / 2), y + (int)(L / 2), color, (int)(L * k), N - 1);
                await drawSierpinskyNapkin(x + (int)(L / 2), y + (int)(L / 2), color, (int)(L * k), N - 1);
                await drawSierpinskyNapkin(x + (int)(L / 2), y - (int)(L / 2), color, (int)(L * k), N - 1);
            }
        }

        private int nArithm(int a, int d, int n)
        {
            if (n <= 1)
                return a;
            return nArithm(a, d, n-1) + d;
        }

        private async Task drawAlg(int a, int d, (int A, int R, int G, int B) color,  int N, int res=0)
        {
            SolidBrush brush = new SolidBrush(Color.FromArgb(color.A, color.R, color.G, color.B));

            if (N < 1)
                return;
            if (N == 1)
            {
                int x = 10 + 35 * (N - 1), y = 10;
                if (x > 200)
                {
                    x = 10 + x % 200;
                    y += 15;
                }
                g.DrawString(a.ToString(), new Font("Courier New", 10.0F), brush, new Point(x, y));
                x = 10; y += 30;
                g.DrawString("Result\t" + res.ToString(), new Font("Courier New", 15.0F), brush, new Point(x, y));
            }
            else
            {
                int an = nArithm(a, d, N);
                int x = 10 + 35 * (N - 1), y = 10;
                
                g.DrawString(an.ToString(), new Font("Courier New", 10.0F), brush, new Point(x, y));
                await drawAlg(a, d, color, N - 1, res + an);
            }
        }

        private void redraw(object sender, MouseEventArgs e)
        {
            selectMethod(sender, e);
        }
    }
}

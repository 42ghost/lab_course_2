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
    public partial class lab3_1 : Form
    {
        private Point movePt;
        private Point nullPt = new Point(int.MaxValue, 0);

        private SolidBrush brush = new SolidBrush(Color.White);
        private Pen pen = new Pen(Color.Black);
        private Point startPt;

        int A = 50;
        int F = 1;
        int nterms = 10;

        Form1 form1;
        public lab3_1(Form1 f)
        {
            InitializeComponent();
            form1 = f;
            openFileDialog1.InitialDirectory = saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = bmp;
            pictureBox1.Refresh();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            clearToolStripMenuItem_Click(sender, e);
            Text = "Редактор изображений";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string s = openFileDialog1.FileName;
                try
                {
                    Image im = new Bitmap(s);
                    Graphics g = Graphics.FromImage(im);
                    g.Dispose();
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                    }
                    pictureBox1.Image = im;
                    pictureBox1.Refresh();
                } catch {
                    MessageBox.Show("Файл " + s + "недопустимый формат", "Ошибка");
                    return;
                }
                Bitmap btm = new Bitmap(s);
                pictureBox1.Image = new Bitmap(btm, pictureBox1.Width, pictureBox1.Height);
                Text = "Редактор изображений " + s;
                saveFileDialog1.FileName = Path.ChangeExtension(s, "png");
                openFileDialog1.FileName = "";
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s0 = saveFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string s = saveFileDialog1.FileName;
                if (s.ToUpper() == s0.ToUpper())
                {
                    s0 = Path.GetDirectoryName(s0) + ".png";
                    pictureBox1.Image.Save(s0);
                    pictureBox1.Image.Dispose();

                    File.Delete(s);
                    File.Move(s0, s);
                    pictureBox1.Image = new Bitmap(s);
                }
                else
                    pictureBox1.Image.Save(s);
                Text = "Редактор излбражений" + s;
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics grf = Graphics.FromImage(bmp);
            grf.Clear(Color.White);
            pictureBox1.Image = bmp;
            pictureBox1.Refresh();
        }

        private void color_Click(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            colorDialog1.Color = lb.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                lb.BackColor = colorDialog1.Color;
            }
        }

        private void label2_BackColorChanged(object sender, EventArgs e)
        {
            pen.Color = label2.BackColor;
        }

        private void label3_BackColorChanged(object sender, EventArgs e)
        {
            brush.Color = label3.BackColor;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = (int)numericUpDown4.Value;
        }

        public void DrawFigure(Rectangle r, Graphics g)
        {
            g.FillRectangle(brush, r);
            g.DrawRectangle(pen, r);
        }

        private Rectangle PtToRect(Point p1, Point p2)
        {
            int x = Math.Min(p1.X, p2.X), y = Math.Min(p1.Y, p2.Y);
            int w = Math.Abs(p2.X - p1.X), h = Math.Abs(p2.Y - p1.Y);
            return new Rectangle(x, y, w, h);
        }
        private void ReversibleDraw()
        {
            Point p1 = pictureBox1.PointToScreen(startPt);
            Point p2 = pictureBox1.PointToScreen(movePt);

            if (radioButton2.Checked)
                ControlPaint.DrawReversibleLine(p1, p2, label2.BackColor);
            else if (radioButton3.Checked)
                ControlPaint.DrawReversibleFrame(PtToRect(p1, p2), label3.BackColor, FrameStyle.Thick);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            movePt = startPt = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (startPt == nullPt) return;
            if (e.Button == MouseButtons.Left)
            {
                if (radioButton1.Checked)
                {
                    Graphics g = Graphics.FromImage(pictureBox1.Image);
                    g.DrawLine(pen, startPt, e.Location);
                    g.Dispose();
                    startPt = e.Location;
                    pictureBox1.Invalidate();
                    pictureBox1.Update();
                }
                else if (radioButton2.Checked)
                {
                    ReversibleDraw();
                    movePt = e.Location;
                    ReversibleDraw();
                }
                else if (radioButton3.Checked)
                {
                    ReversibleDraw();
                    movePt = e.Location;
                    ReversibleDraw();
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (startPt == nullPt) return;
            if (e.Button == MouseButtons.Left)
            {
                ReversibleDraw();
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                if (radioButton2.Checked)
                {
                    g.DrawLine(pen, startPt, movePt);
                }
                else if (radioButton3.Checked)
                {
                    DrawFigure(PtToRect(startPt, movePt), g);
                    this.Invalidate();
                }
                g.Dispose();
                pictureBox1.Invalidate();
            }
        }

        private void Form5_Resize(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = (Bitmap)pictureBox1.Image.Clone();
                pictureBox1.Image = new Bitmap(bmp, pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Refresh();
            }
            catch (Exception er)
            {
                form1.errorStack.AppendText("Error\r\n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawFourier();
        }

        private void drawFourier()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            pictureBox1.Image = bmp;
            pictureBox1.Refresh();

            g.DrawLine(pen, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
            g.DrawLine(pen, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);
            pen.Width = (int)numericUpDown4.Value;

            int Interval = pictureBox1.Width;

            double yp = 0, yy1 = 0, yy2 = 0;
            int angle = 0;

            int xtemp = 0;
            int ytemp = pictureBox1.Height / 2;

            for (int i = 0; i < Interval; i++)
            {
                for (int j = 1; j < nterms; j++)
                {
                    double arg = 0;
                    if (radioButton4.Checked)
                    {
                        yy1 = A / ((2 * j) - 1);
                        arg = ((2 * j) - 1) * (int)F * 0.01397 * angle;
                    } else if (radioButton5.Checked)
                    {
                        yy1 = A / ((2 * j) + 1);
                        arg = ((2 * j) + 1) * (int)F * 0.01397 * angle;
                    } else if (radioButton6.Checked)
                    {
                        yy1 = A / j;
                        arg = j * (int)F * 0.01397 * angle;
                       
                    }

                    yy2 = Math.Sin(arg);
                    yp = yp + yy1 * yy2;
                }
                g.DrawLine(pen, xtemp, ytemp, i, pictureBox1.Height / 2 + (int)Math.Truncate(yp));
                xtemp = i;
                ytemp = pictureBox1.Height / 2 + (int)Math.Truncate(yp);

                yp = 0;
                angle = angle + 1;
            }
            g.Dispose();
            pictureBox1.Invalidate();
            pictureBox1.Update();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            nterms = (int)numericUpDown1.Value;
            drawFourier();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            A = (int)numericUpDown2.Value;
            drawFourier();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            F = (int)numericUpDown3.Value;
            drawFourier();
        }
    }
}

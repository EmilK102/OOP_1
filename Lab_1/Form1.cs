using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Bitmap bitmap;
        int r = 10;
        Brush brush;
        Pen pen;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            brush = Brushes.White;
            pen = new Pen(Color.Black);
            pen.Width = 2;
            graphics = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
            graphics.Clear(Color.White);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Visible = !numericUpDown1.Visible;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == progressBar1.Maximum)
                progressBar1.Value = progressBar1.Minimum;
            progressBar1.PerformStep();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = dateTimePicker1.Value.ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int size = (int)numericUpDown1.Value;
            Font font = new Font("Microsoft Sans Serif", size);
            label1.Font = font;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                BackColor = Color.Aqua;
            else
                BackColor = Color.White;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            progressBar1.Step = trackBar1.Value;
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            graphics.FillEllipse(brush, (e.X - r), (e.Y - r), 2 * r, 2 * r);
            graphics.DrawEllipse(pen, (e.X - r), (e.Y - r), 2 * r, 2 * r);
            pictureBox1.Image = bitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = bitmap;
            graphics.Clear(Color.White);
        }
    }
}

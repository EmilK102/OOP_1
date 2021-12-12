using System;
using System.Drawing;
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
            label1.Text = dateTimePicker1.Value.ToString();
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
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = !comboBox1.Visible;
            if (checkBox2.Checked)
                BackColor = Color.FromName(comboBox1.Text);
            else
                BackColor = Color.White;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BackColor = Color.FromName(comboBox1.Text);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (radioButton1.Checked)
                    listBox1.Items.Add(textBox1.Text);
                else
                {
                    if (listBox1.Items.Count > 0)
                        listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
                }
                textBox1.Text = "";
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Button button = new Button();
            button.BackColor = SystemColors.ActiveCaption;
            button.Location = new Point(e.X-button.Width/2, e.Y-button.Height/2);
            button.Click += new EventHandler(button2_Click);
            Controls.Add(button);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controls.Clear();
        }
    }
}

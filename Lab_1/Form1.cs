using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Bitmap bitmap;
        int r = 10; // радиус круга
        Brush brush;
        Pen pen;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000; //время интервала
            timer1.Enabled = true; 
            timer1.Tick += timer1_Tick; // запуск таймера
            label1.Text = dateTimePicker1.Value.ToString(); // добавляем данные из dateTimerPicker
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height); // размер холста
            brush = Brushes.White; //
            pen = new Pen(Color.Black); // черная обводка
            pen.Width = 2; // размер обводки
            graphics = Graphics.FromImage(bitmap); // обработка графики
            pictureBox1.Image = bitmap; // привязываем картинку
            graphics.Clear(Color.White); // очищаем picterBox
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Visible = !numericUpDown1.Visible; // меняем видимость numericUpDown
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = !comboBox1.Visible; //меняем видимость comboBox
            if (checkBox2.Checked)
                BackColor = Color.FromName(comboBox1.Text); //задаем цвет фона из comboBox
            else
                BackColor = SystemColors.Control; // оставляем обычный фон
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == progressBar1.Maximum) // проверяем заполненность progressBar
                progressBar1.Value = progressBar1.Minimum;
            progressBar1.PerformStep(); // новый шаг
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = dateTimePicker1.Value.ToString(); // добавляем данные из dateTimerPicker
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int size = (int)numericUpDown1.Value;
            Font font = new Font("Microsoft Sans Serif", size);
            label1.Font = font; // меняем  размер шрифта
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            progressBar1.Step = trackBar1.Value; // меняем величину шага
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            graphics.FillEllipse(brush, (e.X - r), (e.Y - r), 2 * r, 2 * r); //рисуем элипс
            graphics.DrawEllipse(pen, (e.X - r), (e.Y - r), 2 * r, 2 * r); //рисуем обводку
            pictureBox1.Image = bitmap; // обновляем холст
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = bitmap;
            graphics.Clear(Color.White); // очистка
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BackColor = Color.FromName(comboBox1.Text); // задаем цвет фона из comboBox
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) //если нажат Enter
            {
                if (radioButton1.Checked) // выбран первый radioButton
                    listBox1.Items.Add(textBox1.Text); // добавление 
                else
                {
                    if (listBox1.Items.Count > 0)
                        listBox1.Items.RemoveAt(listBox1.Items.Count - 1); //удаление
                }
                textBox1.Text = ""; //очистка поля ввода
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Button button = new Button(); // новая кнопка
            button.BackColor = SystemColors.ActiveCaption;
            button.Location = new Point(e.X-button.Width/2, e.Y-button.Height/2); // координаты
            button.Click += new EventHandler(button2_Click); // добавление события
            Controls.Add(button); // добавление кнопки в Form
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controls.Clear(); // удаление объектов из Form
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace issled_fyn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "{#}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
            double h = 0.01;
            int a = Convert.ToInt32(textBox1.Text);
            int b = Convert.ToInt32(textBox2.Text);
            double x = a, y;
            while (x <= b)
            {
                y = Math.Cos(x * (Math.Sin(x)));
                chart1.Series[0].Points.AddXY(x, y);
                x += h;
            }
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                button1.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                button1.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series[1].Points.Clear();
            double h = 0.01;
            int a = Convert.ToInt32(textBox1.Text);
            int b = Convert.ToInt32(textBox2.Text);
            double x = a + h, y;
            double y0, y1;
            int k = 0;
            while (x < (b - h))
            {
                y0 = Math.Cos((x - h) * (Math.Sin(x - h)));
                y = Math.Cos(x * (Math.Sin(x)));
                y1 = Math.Cos((x + h) * (Math.Sin(x + h)));
                if (y0 > y && y < y1)
                {
                    chart1.Series[1].Points.AddXY(x, y);
                    chart1.Series[1].Points[k].Label = $"{Math.Round(x, 2)}, {Math.Round(y, 2)}";
                    k += 1;
                }
                x += h;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chart1.Series[2].Points.Clear();
            double h = 0.01;
            int a = Convert.ToInt32(textBox1.Text);
            int b = Convert.ToInt32(textBox2.Text);
            double x = a + h, y;
            double y0, y1;
            int k = 0;
            while (x < (b - h))
            {
                y0 = Math.Cos((x - h) * (Math.Sin(x - h)));
                y = Math.Cos(x * (Math.Sin(x)));
                y1 = Math.Cos((x + h) * (Math.Sin(x + h)));
                if (y0 < y && y > y1)
                {
                    chart1.Series[2].Points.AddXY(x, y);
                    chart1.Series[2].Points[k].Label = $"{Math.Round(x, 2)}, {Math.Round(y, 2)}";
                    k += 1;
                }
                x += h;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chart1.Series[3].Points.Clear();
            double h = 0.01;
            int a = Convert.ToInt32(textBox1.Text);
            int b = Convert.ToInt32(textBox2.Text);
            double x = a, y;
            while (x <= b)
            {
                y = -(x * Math.Cos(x) + Math.Sin(x)) * Math.Sin(x * Math.Sin(x));
                chart1.Series[3].Points.AddXY(x, y);
                x += h;
            }
        }
    }
}

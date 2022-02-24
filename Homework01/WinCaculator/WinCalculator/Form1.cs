using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float x = Convert.ToSingle(textBox1.Text);
            float y = Convert.ToSingle(textBox2.Text);
            string a = comboBox1.Text;
            switch (a)
            {
                case "+":
                    textBox3.Text = (x + y).ToString();
                    break;
                case "-":
                    textBox3.Text = (x - y).ToString();
                    break;
                case "*":
                    textBox3.Text = (x * y).ToString();
                    break;
                case "/":
                    textBox3.Text = (x / y).ToString();
                    break;
            }
        }
    }
}

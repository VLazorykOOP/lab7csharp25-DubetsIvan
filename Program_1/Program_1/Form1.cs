using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_1
{
    public partial class Form1 : Form
    {
        private int i = 0;
        private Timer timer;
        private int numberBase = 10;

        public Form1()
        {
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 1000; 
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            i++;
            textBox1.Text = ConvertToBase(i, numberBase);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            numberBase = 10;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numberBase = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numberBase = 16;
        }
        private string ConvertToBase(int number, int baseValue)
        {
            return Convert.ToString(number, baseValue).ToUpper();
        }
    }
}

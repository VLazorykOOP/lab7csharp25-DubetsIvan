namespace Program_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out double sideLength) || sideLength <= 0)
            {
                MessageBox.Show("¬вед≥ть коректну довжину сторони (> 0)");
                return;
            }

            double radius = sideLength / (2 * Math.Sin(Math.PI / 5));

            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            Pen pen = new Pen(Color.DarkGreen, 2);

            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            Point[] points = new Point[5];

            for (int i = 0; i < 5; i++)
            {
                double angle = -Math.PI / 2 + i * 2 * Math.PI / 5;
                int x = centerX + (int)(radius * Math.Cos(angle));
                int y = centerY + (int)(radius * Math.Sin(angle));
                points[i] = new Point(x, y);
            }

            g.DrawPolygon(pen, points);

            pen.Dispose();
            g.Dispose();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox2.Text, out int sideA) || sideA <= 0)
            {
                MessageBox.Show("¬вед≥ть коректну сторону A (> 0)");
                return;
            }

            if (!int.TryParse(textBox3.Text, out int sideB) || sideB <= 0)
            {
                MessageBox.Show("¬вед≥ть коректну сторону B (> 0)");
                return;
            }

            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            Pen pen = new Pen(Color.Maroon, 2);

            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            int startX = centerX - sideA / 2;
            int startY = centerY - sideB / 2;

            g.DrawRectangle(pen, startX, startY, sideA, sideB);

            pen.Dispose();
            g.Dispose();
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox4.Text, out double a) || a <= 0 ||
                !double.TryParse(textBox5.Text, out double b) || b <= 0 ||
                !double.TryParse(textBox6.Text, out double c) || c <= 0)
            {
                MessageBox.Show("¬вед≥ть коректн≥ значенн€ стор≥н A, B, C (> 0)");
                return;
            }

            if (a + b <= c || a + c <= b || b + c <= a)
            {
                MessageBox.Show("“акий трикутник не ≥снуЇ (не виконуЇтьс€ нер≥вн≥сть трикутника)");
                return;
            }

            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            Pen pen = new Pen(Color.DarkRed, 2);

            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            PointF A = new PointF(centerX, centerY);

            PointF B = new PointF(centerX + (float)a, centerY);

            double cosGamma = (b * b + a * a - c * c) / (2 * a * b);
            double angle = Math.Acos(cosGamma); 

            float cx = centerX + (float)(b * Math.Cos(angle));
            float cy = centerY - (float)(b * Math.Sin(angle));
            PointF C = new PointF(cx, cy);

            g.DrawPolygon(pen, new PointF[] { A, B, C });

            pen.Dispose();
            g.Dispose();
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox7.Text, out double d1) || d1 <= 0)
            {
                MessageBox.Show("¬вед≥ть коректну першу д≥агональ (> 0)");
                return;
            }

            if (!double.TryParse(textBox8.Text, out double d2) || d2 <= 0)
            {
                MessageBox.Show("¬вед≥ть коректну другу д≥агональ (> 0)");
                return;
            }

            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            Pen pen = new Pen(Color.Indigo, 2);

            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            Point[] points = new Point[4];

            points[0] = new Point(centerX, centerY - (int)(d1 / 2)); 
            points[1] = new Point(centerX + (int)(d2 / 2), centerY); 
            points[2] = new Point(centerX, centerY + (int)(d1 / 2)); 
            points[3] = new Point(centerX - (int)(d2 / 2), centerY); 

            g.DrawPolygon(pen, points);

            pen.Dispose();
            g.Dispose();
        }


        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

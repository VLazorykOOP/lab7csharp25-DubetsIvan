using System;
using System.Drawing;
using System.Windows.Forms;

namespace Program_2
{
    public partial class Form1 : Form
    {
        // Змінна тепер nullable
        private Bitmap? originalImage;

        public Form1()
        {
            InitializeComponent();
        }

        // Відкриття зображення
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Зображення (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                originalImage = new Bitmap(openDialog.FileName);  // Завантажуємо зображення
                pictureBox1.Image = originalImage;  // Відображаємо в PictureBox
            }
        }

        // Перетворення зображення в відтінки сірого
        private void button2_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;  // Перевірка на null

            Bitmap grayImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color pixel = originalImage.GetPixel(x, y);  // Отримуємо піксель
                    int gray = (int)(0.3 * pixel.R + 0.59 * pixel.G + 0.11 * pixel.B);  // Обчислюємо сірий колір
                    grayImage.SetPixel(x, y, Color.FromArgb(gray, gray, gray));  // Задаємо піксель сірого кольору
                }
            }

            pictureBox1.Image = grayImage;  // Відображаємо перетворене зображення
            originalImage = grayImage;  // Оновлюємо оригінальне зображення
        }

        // Збереження зображення
        private void button3_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;  // Перевірка на null

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PNG зображення|*.png";  // Формат збереження

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                originalImage.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);  // Зберігаємо зображення
            }
        }

        // Обробник для кліку по PictureBox (якщо потрібно)
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Тут нічого не потрібно, якщо тільки не хочете додати якусь додаткову логіку
        }
    }
}
